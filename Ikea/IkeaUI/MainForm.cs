using HalconDotNet;
using Ikea_Library;
using Ikea_Library.DataGridTables;
using Ikea_Library.DBAccess;
using Ikea_Library.HDevProcedures;
using Ikea_Library.Helpers;
using Ikea_Library.Utilities;
using IkeaProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IkeaUI
{
    public partial class MainForm : Form
    {
        Material Plank;
        Hole Hole;
        HDevProc Procedures;

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

        public int ImgNum = 0;
        string ImagesPath = @"C:\Trifid\IKEA\SavedImages";

        public MainForm()
        {
            InitializeComponent();

            Procedures = new HDevProc(GlobalVariables.HalconEvaluationPath);
            timer_Simulation.Enabled = true;
            timer_Simulation.Start();
            timer_Clock.Enabled = true;
            timer_Clock.Start();
            timer_DiscsCheck.Enabled = true;
            timer_DiscsCheck.Start();
        }

        private void tabControl_MainControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            var text = tabControl_MainControl.TabPages[e.Index].Text;
            var x = e.Bounds.Left + 20;
            var y = e.Bounds.Top + 25;
            g.FillRectangle(Brushes.Silver, e.Bounds);
            g.DrawString(text, tabControl_MainControl.Font,Brushes.Black, x, y);
        }

        private void button_TakeInfoFromDB_Click(object sender, EventArgs e)
        {
            Plank = new Material();
            Random rnd = new Random();
            int goodHoles = 0;
            int badHoles = 0;
            List<Hole> Holes = new List<Hole>();

            //For Simulation of reading photos
            if (ImgNum == ListOfImagesPaths.Count)
            {
                ImgNum = 0;
            }

            HOperatorSet.ReadImage(out HObject Image, ListOfImagesPaths[ImgNum]);

            Procedures.FindHoleFunc(Image, out HTuple rows, out HTuple columns, out HTuple radius);

            //Simulation BAD HOLES
            int randomNum = rnd.Next(0, 8);
            string Timestamp = DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");

            //DEVIDE GOOD HOLES AND BAD HOLES by RANDOM NUMBER
            for (int i = 0; i < rows.Length - randomNum; i++)
            {
                Hole = new Hole();
                Hole.IDMeasurement = Timestamp;
                Hole.X = Math.Round(rows[i].D, 1);
                Hole.Y = Math.Round(columns[i].D, 1);
                Hole.Radius = Math.Round(radius[i].D, 1);
                Hole.Status = true;
                goodHoles++;
                Holes.Add(Hole);
            }

            for (int i = rows.Length - randomNum; i < rows.Length; i++)
            {
                Hole = new Hole();
                Hole.IDMeasurement = Timestamp;
                Hole.X = Math.Round(rows[i].D, 1);
                Hole.Y = Math.Round(columns[i].D, 1);
                Hole.Radius = Math.Round(radius[i].D, 1);
                Hole.Status = false;
                badHoles++;
                Holes.Add(Hole);
            }

            Plank.IDMeasurement = Timestamp;
            Plank.TimeStamp = Timestamp;
            Plank.Barcode = Timestamp;
            Plank.Holes = Holes;
            Plank.HolesCount = Holes.Count;
            Plank.ImagePath = ImagesPath + Plank.TimeStamp.Replace('-', '_').Replace(" ", "__").Replace(':', '_');

            if (goodHoles > badHoles)
            {
                Plank.Status = true;
            }
            else
            {
                Plank.Status = false;
            }

            try
            {
                //ADDING TO DB
                bool insertingToDatabaseStatus = DBFunctions.InsterMeasurement(Plank);
                Console.WriteLine(DateTime.Now + $" Saved image to Database");

                //SAVING IMAGES
                if (insertingToDatabaseStatus == true)
                {
                    string filePath = ImagesPath + Timestamp.Replace('-', '_').Replace(" ", "__").Replace(':', '_');
                    HOperatorSet.WriteImage(Image, "tiff", 0, filePath);
                    ImgNum++;
                    Console.WriteLine(DateTime.Now + $" Saved image to {filePath}");
                }
                else
                {
                    Console.WriteLine(DateTime.Now + " Error inserting");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + ex.Message);
            }

        }


        private void button_RefreshTable_Click(object sender, EventArgs e)
        {
            DataGridFunctions.UpdateTable(datagridTable_Data);
            datagridTable_Data.ClearSelection();
        }

        private void datagridTable_Data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            datagridTable_Data.Columns[0].Selected = false;
            datagridTable_HolesData.Rows.Clear();
            string idMeasurement = datagridTable_Data.Rows[e.RowIndex].Cells[0].Value.ToString();
            List<Hole> holes = DBFunctions.TakeMeasurement(idMeasurement);
            DataGridFunctions.ShowResults(datagridTable_HolesData, holes);

            Plank = DBFunctions.TakeImage(idMeasurement);
            string readPath = ImagesPath + Plank.TimeStamp.Replace('-', '_').Replace(" ", "__").Replace(':', '_');
            HOperatorSet.ReadImage(out HObject Image, readPath);

            //SHOW IMAGE
            hWindow_Image.HalconWindow.DispObj(Image);
            hWindow_Image.HalconWindow.SetPart(0, 0, -2, -2);
            hWindow_Image.HalconWindow.SetDraw("margin");
            hWindow_Image.HalconWindow.SetLineWidth(3);

            for (int i = 0; i < holes.Count; i++)
            {
                HOperatorSet.GenCircleContourXld(out HObject circle, holes[i].X, holes[i].Y, holes[i].Radius + 5, 0, Math.PI * 2, "positive", 1);

                if (holes[i].Status == true)
                {
                    hWindow_Image.HalconWindow.SetColor("green");
                }
                else
                {
                    hWindow_Image.HalconWindow.SetColor("red");
                }

                hWindow_Image.HalconWindow.DispObj(circle);
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
    }
}
