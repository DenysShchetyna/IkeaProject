using Advantech.Adam;
using HalconDotNet;
using Ikea_Library;
using Ikea_Library.DataGridTables;
using Ikea_Library.DBAccess;
using Ikea_Library.HDevProcedures;
using Ikea_Library.Helpers;
using Ikea_Library.ProduceConsumer;
using Ikea_Library.Utilities;
using IkeaProject;
using IkeaUI.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IkeaUI
{
    public partial class MainForm : Form
    {
        private string RecipeMaterialName;

        Material Plank;
        DrawingSide DrawingSide;
        Hole Hole;

        HDevProc Procedures;
        AdamSocket AdamSocket;
        PersistentVariables PersistentVariables;


        public Producer ProducerCam1;
        public Consumer ConsumerCam1;

        public int ImgNum = 0;

        List<string> ListOfImagesPaths = new List<string>()
        {
                @"C:/Trifid/IKEA/Data/DGG_435_BR.bmp",
                @"C:/Trifid/IKEA/Data/DGG_441_JS_DB.bmp",
                @"C:/Trifid/IKEA/Data/DGG_506_BR.bmp",
                @"C:/Trifid/IKEA/Data/DGG07440.bmp",
                @"C:/Trifid/IKEA/Data/FBA_025_obycajny_papier.bmp",
                @"C:/Trifid/IKEA/Data/DGG_400.bmp",
                @"C:/Trifid/IKEA/Data/DGL_016_biely.bmp",
                @"C:/Trifid/IKEA/Data/DGN_706_obycajny.jpg",
                @"C:/Trifid/IKEA/Data/DGL_130_obycajny.bmp"
        };

        public MainForm()
        {
            InitializeComponent();

            Procedures = new HDevProc(GlobalVariables.HalconEvaluationPath);

            PersistentVariables = JsonFunctions.ReadJsonFunc(GlobalVariables.JsonPersistenCamSettingsPath);

            timer_Simulation.Enabled = true;
            timer_Simulation.Start();
            timer_Clock.Enabled = true;
            timer_Clock.Start();
            timer_DiscsCheck.Enabled = true;
            timer_DiscsCheck.Start();
            timer_CameraPing.Enabled = true;
            timer_CameraPing.Start();
        }

        private void tabControl_MainControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            var text = tabControl_MainControl.TabPages[e.Index].Text;
            var x = e.Bounds.Left + 20;
            var y = e.Bounds.Top + 25;
            g.FillRectangle(Brushes.Silver, e.Bounds);
            g.DrawString(text, tabControl_MainControl.Font, Brushes.Black, x, y);
        }

        private void button_TakeInfoFromDB_Click(object sender, EventArgs e)
        {
            string materialname = RecipeMaterialName;
            string drawingSide = "Front Side"; //take value regarding to camera position
            Plank = new Material(materialname);
            DrawingSide = new DrawingSide(drawingSide);
            DrawingSide.Holes = new List<Hole>();
            Plank.DrawingSides = new List<DrawingSide>();

            Random rnd = new Random();
            int goodHoles = 0;
            int badHoles = 0;

            //For Simulation of reading photos
            if (ImgNum == ListOfImagesPaths.Count)
            {
                ImgNum = 0;
            }

            HOperatorSet.ReadImage(out HObject Image, ListOfImagesPaths[ImgNum]);
            Procedures.FindHoleFunc(Image, out HTuple rows, out HTuple columns, out HTuple radius);

            //Simulation BAD HOLES
            int randomNum = rnd.Next(0, 8);
            string timestamp = DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");

            //DEVIDE GOOD HOLES AND BAD HOLES by RANDOM NUMBER
            for (int i = 0; i < rows.Length - randomNum; i++)
            {
                Hole = new Hole();
                Hole.TimeStamp = timestamp;
                Hole.X = Math.Round(rows[i].D, 1);
                Hole.Y = Math.Round(columns[i].D, 1);
                Hole.Radius = Math.Round(radius[i].D, 1);
                Hole.Status = true;
                goodHoles++;
                DrawingSide.Holes.Add(Hole);
            }

            for (int i = rows.Length - randomNum; i < rows.Length; i++)
            {
                Hole = new Hole();
                Hole.TimeStamp = timestamp;
                Hole.X = Math.Round(rows[i].D, 1);
                Hole.Y = Math.Round(columns[i].D, 1);
                Hole.Radius = Math.Round(radius[i].D, 1);
                Hole.Status = false;
                badHoles++;
                DrawingSide.Holes.Add(Hole);
            }

            DrawingSide.HolesCount = DrawingSide.Holes.Count();
            DrawingSide.TimeStamp = timestamp;
            DrawingSide.ImagePath = GlobalVariables.SaveImagesPath + (DrawingSide.TimeStamp +"\\" + DrawingSide.TimeStamp).Replace('-', '_').Replace(" ", "__").Replace(':', '_')+DrawingSide.Name+".tiff";

            Plank.TimeStamp = timestamp;
            Plank.DrawingSides.Add(DrawingSide);
            Plank.DrawingsCount = Plank.DrawingSides.Count;

            if (goodHoles > badHoles)
            {
                DrawingSide.Status = true;
                Plank.Status = true;
            }
            else
            {
                DrawingSide.Status = false;
                Plank.Status = false;
            }

            try
            {
                //ADDING TO DB
                bool insertingToDatabaseStatus = DBFunctions.InsterMeasurement(Plank);

                //SAVING IMAGES
                if (insertingToDatabaseStatus == true)
                {
                    string fileName = timestamp.Replace('-', '_').Replace(" ", "__").Replace(':', '_')+ DrawingSide.Name + ".tiff";
                    string dirPath = GlobalVariables.SaveImagesPath + timestamp.Replace('-', '_').Replace(" ", "__").Replace(':', '_');
                    string filePath = dirPath +"\\" + fileName;

                    Directory.CreateDirectory(dirPath);
                    HOperatorSet.WriteImage(Image, "tiff", 0, filePath);
                    ImgNum++;
                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"Saved image to {filePath}", "|OK|");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }
        }


        private void button_RefreshTable_Click(object sender, EventArgs e)
        {
            DataGridFunctions.UpdateTable(dataGridView_Data);
            dataGridView_ArchiveDrawingSides.Rows.Clear();
            dataGridView_HolesData.Rows.Clear();
            dataGridView_Data.ClearSelection();
            Hwindow_ArchiveImage.HalconWindow.ClearWindow();
        }
        

        private void dataGridView_Data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            dataGridView_Data.Columns[0].Selected = false;
            dataGridView_HolesData.Rows.Clear();
            dataGridView_ArchiveDrawingSides.Rows.Clear();
            string timeStamp = dataGridView_Data.Rows[e.RowIndex].Cells[1].Value.ToString();
            List<DrawingSide> drawingSides = DBFunctions.TakeDrawingSides(timeStamp);
            DataGridFunctions.ShowResultsDrawingSides(dataGridView_ArchiveDrawingSides, drawingSides);
        }

        private void dataGridView_ArchiveDrawingSides_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DrawingSide drawingSide = new DrawingSide();
            if (e.RowIndex < 0)
            {
                return;
            }

            dataGridView_ArchiveDrawingSides.Columns[0].Selected = false;
            dataGridView_HolesData.Rows.Clear();
            string timeStamp = dataGridView_ArchiveDrawingSides.Rows[e.RowIndex].Cells[1].Value.ToString();
            List<Hole> holes = DBFunctions.TakeHoles(timeStamp);
            DataGridFunctions.ShowResultsHoles(dataGridView_HolesData, holes);

            drawingSide = DBFunctions.TakeImage(timeStamp);
            string readPath = drawingSide.ImagePath;
            HOperatorSet.ReadImage(out HObject Image, readPath);

            //SHOW IMAGE
            Hwindow_ArchiveImage.HalconWindow.DispObj(Image);
            Hwindow_ArchiveImage.HalconWindow.SetPart(0, 0, -2, -2);
            Hwindow_ArchiveImage.HalconWindow.SetDraw("margin");
            Hwindow_ArchiveImage.HalconWindow.SetLineWidth(3);

            for (int i = 0; i < holes.Count; i++)
            {
                HOperatorSet.GenCircleContourXld(out HObject circle, holes[i].X, holes[i].Y, holes[i].Radius + 5, 0, Math.PI * 2, "positive", 1);

                if (holes[i].Status == true)
                {
                    Hwindow_ArchiveImage.HalconWindow.SetColor("green");
                }
                else
                {
                    Hwindow_ArchiveImage.HalconWindow.SetColor("red");
                }

                Hwindow_ArchiveImage.HalconWindow.DispObj(circle);
            }
        }


        private void timer_Clock_Tick(object sender, EventArgs e)
        {
            label_Clock.Text = DateTime.Now.ToString();

        }

        private void timer_DiscsCheck_Tick(object sender, EventArgs e)
        {
            string availableSpaceDiscC = DiscManagement.CheckDiscs(GlobalVariables.DiscManagementGigabytes, GlobalVariables.ImagesDiscC).ToString();
            UpdateUI.UpdateLabelText(label_AvailableSpaceC, availableSpaceDiscC + " GB");
        }

        private void timer_Simulation_Tick(object sender, EventArgs e)
        {

        }

        private void button_ExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        

        private void button_DiagnosticsExposureSet_Click(object sender, EventArgs e)
        {
            try
            {
                string camName = listBox_DiagnosticsCamerasSettings.SelectedItem.ToString();
                int value = Convert.ToInt32(textBox_DiagnosticsExposureTime.Text);
                JsonFunctions.CamExposureTimeSet(PersistentVariables, camName, value);
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"Changed Exposure time for {camName} to {value} ", "|OK|");
            }
            catch (Exception ex)
            {
                Console.WriteLine("{ 0,-30}|{1,-70}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }
        }

        private void button_DiagnosticsGainSet_Click(object sender, EventArgs e)
        {
            try
            {
                string camName = listBox_DiagnosticsCamerasSettings.SelectedItem.ToString();
                int value = Convert.ToInt32(textBox_DiagnosticsGain.Text);
                JsonFunctions.CamGainSet(PersistentVariables, camName, value);
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"Changed Gain for {camName} to {value} ", "|OK|");
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }
        }

        private void timer_CameraPing_Tick(object sender, EventArgs e)
        {
            // cameraStatus = DeviceManager.PingCamera(GlobalVariables.CameraNames);
            List<bool> cameraStatus = new List<bool>() { true, true, true, true, true, true, true, true, true, true, true, true, true, true };
            
            for (int i = 0; i < cameraStatus.Count; i++)
            {
                PictureBox pictureBox = (PictureBox)groupBox_DiagnosticsCamInfo.Controls[i];
                UpdateUI.UpdatePictureBox(pictureBox, cameraStatus[i]);
            }
        }

        private void button_DiagnosticsInput_Click(object sender, EventArgs e)
        {
        }

        private void listBox_MainRecipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecipeMaterialName = listBox_MainRecipe.SelectedItem.ToString();

        }

        private void button_MainStart_Click(object sender, EventArgs e)
        {

        }

        private void listBox_DiagnosticsCamerasSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexSelected = listBox_DiagnosticsCamerasSettings.SelectedIndex;

            string text = File.ReadAllText(GlobalVariables.JsonPersistenCamSettingsPath);
            string[] splittedtex = text.Split(',');

            string unformatedExpTime = splittedtex[indexSelected*2];
            string unformatedGain = text.Split(',')[indexSelected*2 +1];

            string formatedExpTime = unformatedExpTime.Split(':')[1];
            string formatedGain = unformatedGain.Split(':')[1];

            UpdateUI.UpdateTextBoxText(textBox_DiagnosticsExposureTime, formatedExpTime);
            UpdateUI.UpdateTextBoxText(textBox_DiagnosticsGain, formatedGain);
        }
        //hello
    }
}
