using Advantech.Adam;
using HalconDotNet;
using Ikea_Library;
using Ikea_Library.DataGridTables;
using Ikea_Library.DBAccess;
using Ikea_Library.Events;
using Ikea_Library.HdevProcedures;
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
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IkeaUI
{
    public partial class MainForm : Form
    {
        private string RecipeMaterialName;
        private ReadDrawings ReadDrawings;

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

        private bool IsAdministratorLoggedIn = false;
        private string CurrentAdministrator = "";

        public MainForm()
        {
            InitializeComponent();

            Procedures = new HDevProc(GlobalVariables.HalconEvaluationPath);

            PersistentVariables = JsonFunctions.ReadJsonFunc(GlobalVariables.JsonPersistentCamSettingsPath);
            SqliteDataAccess.IsAvailable();

            timer_Simulation.Enabled = true;
            timer_Simulation.Start();
            timer_Clock.Enabled = true;
            timer_Clock.Start();
            timer_DiscsCheck.Enabled = true;
            timer_DiscsCheck.Start();
            timer_CameraPing.Enabled = true;
            timer_CameraPing.Start();

            Loging.MakeLog(DateTime.Now, "System Start", "|OK|");

        }

        private void Cunsumer_TileImages(object sender, TileImageReadyEventArgs e)
        {
            switch (e.CamName)
            {
                case "CAM1":
                    break;

                case "CAM2":
                    break;

                case "CAM3":
                    break;

                case "CAM4":
                    break;

                case "CAM5":
                    break;

                case "CAM6":
                    break;

                case "CAM7":
                    break;

                case "CAM8":
                    break;

                case "CAM9":
                    break;

                case "CAM10":
                    break;

                case "CAM11":
                    break;

                case "CAM12":
                    break;

                case "CAM13":
                    break;

                case "CAM14":
                    break;
            }

            HObject firstImage = e.TileImageCam1;
            HObject secondImage = e.TileImageCam2;

            Hwindow_LeftSide.HalconWindow.DispObj(firstImage);
            Hwindow_RightSide.HalconWindow.DispObj(firstImage);

            Hwindow_RightSide.HalconWindow.SetPart(0, 0, -2, -2);
            Hwindow_LeftSide.HalconWindow.SetPart(0, 0, -2, -2);
        }

        private void tabControl_MainControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;

            var text = tabControl_MainControl.TabPages[e.Index].Text;
            var x = e.Bounds.Left + 25;
            var y = e.Bounds.Top + 25;
            g.FillRectangle(Brushes.Silver, e.Bounds);
            g.DrawString(text, tabControl_MainControl.Font, Brushes.Black, x, y);

            if (tabControl_MainControl.TabPages[e.Index] == tabControl_MainControl.SelectedTab)
            {
                g.FillRectangle(Brushes.LightSteelBlue, e.Bounds);
                g.DrawString(text, tabControl_MainControl.Font, Brushes.Black, x, y);
            }

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
            DrawingSide.ImagePath = GlobalVariables.SaveImagesPath + (DrawingSide.TimeStamp + "\\" + DrawingSide.TimeStamp).Replace('-', '_').Replace(" ", "__").Replace(':', '_') + DrawingSide.Name + ".tiff";

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
                    string fileName = timestamp.Replace('-', '_').Replace(" ", "__").Replace(':', '_') + DrawingSide.Name + ".tiff";
                    string dirPath = GlobalVariables.SaveImagesPath + timestamp.Replace('-', '_').Replace(" ", "__").Replace(':', '_');
                    string filePath = dirPath + "\\" + fileName;

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

            if (e.RowIndex < 0)
            {
                return;
            }

            dataGridView_ArchiveDrawingSides.Columns[0].Selected = false;
            dataGridView_HolesData.Rows.Clear();
            string timeStamp = dataGridView_ArchiveDrawingSides.Rows[e.RowIndex].Cells[1].Value.ToString();
            List<Hole> holes = DBFunctions.TakeHoles(timeStamp);
            DataGridFunctions.ShowResultsHoles(dataGridView_HolesData, holes);

            DrawingSide drawingSide = DBFunctions.TakeImage(timeStamp);
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
            try
            {
                if (ProducerCam1 != null)
                {
                    ProducerCam1.AbortThread();
                }

                Application.Exit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{ 0,-30}|{1,-70}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }
        }

        private void button_DiagnosticsExposureSet_Click(object sender, EventArgs e)
        {
            try
            {
                string camName = listBox_DiagnosticsCamerasSettings.SelectedItem.ToString();
                int value = Convert.ToInt32(textBox_DiagnosticsExposureTime.Text);
                JsonFunctions.CamExposureTimeSet(PersistentVariables, camName, value);
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"Changed Exposure time for {camName} to {value} ", "|OK|");
                Loging.MakeLog(DateTime.Now, $"Changed Exposure time for {camName} to {value} ", "|OK|");

            }

            catch (Exception ex)
            {
                Console.WriteLine("{ 0,-30}|{1,-70}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                Loging.MakeLog(DateTime.Now, ex.Message, "|Error|");

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
                Loging.MakeLog(DateTime.Now, $"Changed Gain for {camName} to {value} ", "|OK|");
            }

            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                Loging.MakeLog(DateTime.Now, ex.Message, "|Error|");
            }
        }

        private async void timer_CameraPing_Tick(object sender, EventArgs e)
        {
            timer_CameraPing.Stop();
            bool cam1 = await Task.Run(()=>DeviceManager.PingCamera(GlobalVariables.CameraAdresses[0]));
            Console.WriteLine(cam1);

            //for (int i = 0; i < statuses.Count; i++)
            //{
            //    PictureBox pictureBox = (PictureBox)groupBox_DiagnosticsCamInfo.Controls[i];
            //    UpdateUI.UpdatePictureBox(pictureBox, statuses[i]);
            //}

            timer_CameraPing.Start();
        }

        private void button_DiagnosticsInput_Click(object sender, EventArgs e)
        {
        }

        private void listBox_MainRecipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecipeMaterialName = listBox_MainRecipe.SelectedItem.ToString();
            ReadDrawings = new ReadDrawings();
            ReadDrawings.Function_ReadDrawing(RecipeMaterialName, out HXLD CountersRead, out HXLD Cross);

            if (CountersRead != null && Cross != null)
            {
                Hwindow_Diagnostika.HalconWindow.DispXld(CountersRead);
                Hwindow_Diagnostika.HalconWindow.DispXld(Cross);
                Hwindow_Diagnostika.HalconWindow.SetPart(-300, -150, 600, 1000);
                Loging.MakeLog(DateTime.Now, "Vybrany novy recept", "|OK|");
            }
        }

        private void button_MainStart_Click(object sender, EventArgs e)
        {

            try
            {
                ConsumerCam1 = new Consumer("CAM1", 100);
                ConsumerCam1.Start();
                ConsumerCam1.TileImageReady += Cunsumer_TileImages;

                ProducerCam1 = new Producer("CAM1", PersistentVariables, ConsumerCam1);
                ProducerCam1.Start();

                Loging.MakeLog(DateTime.Now, "Vision Process Start", "|OK|");
            }

            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                Loging.MakeLog(DateTime.Now, "Vision Process Start", " |Error| ");
            }
        }

        private void listBox_DiagnosticsCamerasSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexSelected = listBox_DiagnosticsCamerasSettings.SelectedIndex;

            string text = File.ReadAllText(GlobalVariables.JsonPersistentCamSettingsPath);
            string[] splittedtex = text.Split(',');

            string unformatedExpTime = splittedtex[indexSelected * 2];
            string unformatedGain = text.Split(',')[indexSelected * 2 + 1];

            string formatedExpTime = unformatedExpTime.Split(':')[1];
            string formatedGain = unformatedGain.Split(':')[1];

            UpdateUI.UpdateTextBoxText(textBox_DiagnosticsExposureTime, formatedExpTime);
            UpdateUI.UpdateTextBoxText(textBox_DiagnosticsGain, formatedGain);
        }

        private void button_MainStop_Click(object sender, EventArgs e)
        {
            ConsumerCam1.TileImageReady -= Cunsumer_TileImages;
            ProducerCam1.AbortThread();
            ConsumerCam1.AbortThread();
        }

        //autorization functions start
        private void button_DiagnosticsLogOff_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsAdministratorLoggedIn == true)
                {
                    IsAdministratorLoggedIn = false;
                    CurrentAdministrator = "";
                    label_AccessLevel.Text = "Operátor";
                    button_DiagnosticsChangePassword.Enabled = false;
                    panel_DiagnosticsAutorization.Visible = false;
                    textBox_UserPassword.Text = "";
                    Loging.MakeLog(DateTime.Now, "Odhlasenie Administratora", "|OK|");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                Loging.MakeLog(DateTime.Now, "Odhlasenie Administratora", "|Error|");
            }
        }

        private void button_DiagnosticsChangePassword_Click(object sender, EventArgs e)
        {
            if (IsAdministratorLoggedIn == true && string.IsNullOrEmpty(textBox_UserPassword.Text) == false)
            {
                try
                {
                    SqliteDataAccess.ChangePassword(CurrentAdministrator, textBox_UserPassword.Text);
                    MessageBox.Show("Heslo bolo zmenene", "Info");
                    textBox_UserPassword.Clear();

                    Loging.MakeLog(DateTime.Now, "Zmena hesla", "|OK|");
                }

                catch (Exception ex)
                {
                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                    Loging.MakeLog(DateTime.Now, "Zmena hesla", "|Error|");

                }
            }
            panel_DiagnosticsAutorization.Visible = false;
        }

        private void button_DiagnosticsLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                string password = textBox_UserPassword.Text;
                textBox_UserPassword.Clear();

                if (string.IsNullOrEmpty(password) == false)
                {
                    PersonModel personModel = SqliteDataAccess.ChceckUserPassword(password);

                    if (personModel != null)
                    {
                        if (personModel.Name == "Admin")
                        {
                            IsAdministratorLoggedIn = true;
                            CurrentAdministrator = personModel.Name;
                            label_AccessLevel.Text = "Administrator";
                            button_DiagnosticsChangePassword.Enabled = true;
                            panel_DiagnosticsAutorization.Visible = false;
                            Loging.MakeLog(DateTime.Now, "Administrator prihlaseny", "|OK|");
                        }

                        else
                        {
                            IsAdministratorLoggedIn = false;
                            button_DiagnosticsChangePassword.Enabled = false;
                            label_AccessLevel.Text = "Operator";
                            CurrentAdministrator = "";
                        }
                    }

                    else
                    {
                        MessageBox.Show("Nespravne heslo", "Info");
                        panel_DiagnosticsAutorization.Visible = true;
                    }

                }

                else
                {
                    MessageBox.Show("Please insert valid password", "Info");
                    panel_DiagnosticsAutorization.Visible = true;

                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }
        }

        private void button_Autorization_Click(object sender, EventArgs e)
        {
            panel_DiagnosticsAutorization.Visible = !panel_DiagnosticsAutorization.Visible;
        }

    }
}
