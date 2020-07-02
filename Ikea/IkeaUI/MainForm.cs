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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IkeaUI
{
    public partial class MainForm : Form
    {
        private string RecipeMaterialName;
        private ReadDrawingsProcedure ReadDrawings;

        Material Plank;
        DrawingSide DrawingSide;
        Hole Hole;

        HDevProc Procedures;
        PersistentVariables PersistentVariables;

        public Producer ProducerCam1LsTopL;
        public Consumer ConsumerCam1LsTopL;

        public Producer ProducerCam2LsTopR;
        public Consumer ConsumerCam2LsTopR;

        private bool KeyboardIsShowed = false;

        private DeviceManager Adam1;
        private DeviceManager Adam2;


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
            timer_AdamCoilsRead.Enabled = true;
            timer_AdamCoilsRead.Start();

            Adam1 = new DeviceManager(" ");
            Adam2 = new DeviceManager(" ");
            CameraDefaultSettings.SetCameraDefaultSettingsFromFile(GlobalVariables.SetCamParameteresPFSFilePath);
            ReadAllRecipes();

            Loging.MakeLog(DateTime.Now, "System Start", "|OK|");

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

        private void tabControl_MainCameras_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;

                var text = tabControl_MainCameras.TabPages[e.Index].Text;
                var x = e.Bounds.Left + 70;
                var y = e.Bounds.Top + 13;
                g.FillRectangle(Brushes.Silver, new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height + 2));
                g.DrawString(text, tabControl_MainCameras.Font, Brushes.Black, x, y);

                if (tabControl_MainCameras.TabPages[e.Index] == tabControl_MainCameras.SelectedTab)
                {
                    g.FillRectangle(Brushes.LightSteelBlue, e.Bounds);
                    g.DrawString(text, tabControl_MainCameras.Font, Brushes.Black, x, y);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }
        }

        private void Cunsumer_TileImages(object sender, TileImageReadyEventArgs e)
        {
            switch (e.CamName)
            {
                case "Cam1LsTopL":
                    HObject firstImage = e.TileImageCam1;
                    Hwindow_LeftSide.HalconWindow.DispObj(firstImage);
                    Hwindow_LeftSide.HalconWindow.SetPart(0, 0, -1, -1);

                    break;

                case "Cam2LsTopR":
                    HObject secondImage = e.TileImageCam2;
                    Hwindow_RightSide.HalconWindow.DispObj(secondImage);
                    Hwindow_RightSide.HalconWindow.SetPart(0, 0, -1, -1);
                    break;

                case "Cam3LsBottomL":
                    break;

                case "Cam4LsBottomR":
                    break;

                case "Cam5LsLeft":
                    break;

                case "Cam6LsRight":
                    break;

                case "Cam7ArFrontL":
                    break;

                case "Cam8ArFrontR":
                    break;

                case "Cam9ArRearL":
                    break;

                case "Cam10ArRearR":
                    break;

                case "Cam11ArTopL":
                    break;

                case "Cam12ArTopR":
                    break;

                case "Cam13ArBottomL":
                    break;

                case "Cam14ArBottomR":
                    break;
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
                if (ProducerCam1LsTopL != null)
                {
                    ProducerCam1LsTopL.AbortThread();
                    ProducerCam2LsTopR.AbortThread();
                }

                Application.Exit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{ 0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
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
                Console.WriteLine("{ 0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
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
            var pingTargetHosts = GlobalVariables.CameraAdresses;
            var pingTasks = pingTargetHosts.Select(host => new Ping().SendPingAsync(host, 3000)).ToList();
            var pingResults = await Task.WhenAll(pingTasks);

            for (int i = 0; i < pingResults.Length; i++)
            {
                if (pingResults[i].Status == IPStatus.Success)
                {
                    PictureBox pictureBox = (PictureBox)groupBox_DiagnosticsCamInfo.Controls[i];
                    UpdateUI.UpdatePictureBox(pictureBox, true);
                }
                else
                {
                    PictureBox pictureBox = (PictureBox)groupBox_DiagnosticsCamInfo.Controls[i];
                    UpdateUI.UpdatePictureBox(pictureBox, false);
                }
            }
            timer_CameraPing.Start();
        }

        private void button_DiagnosticsOutput_Click(object sender, EventArgs e)
        {
            bool resultStatus = false;
            bool coilStatus = false;

            try
            {
                Button btn = (Button)sender;
                List<bool> coilStatusesAdam1 = Adam1.ReadAdamCoils(15);
                List<bool> coilStatusesAdam2 = Adam2.ReadAdamCoils(16);
                if (coilStatusesAdam1 != null && coilStatusesAdam2 != null)
                {
                    switch (btn.Name.ToString())
                    {
                        case "button_DiagnosticsOutput1Adam8":
                            coilStatus = !coilStatusesAdam1[7];
                            Adam1.WriteAdamCoils(8 + 17, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput1Adam9":
                            coilStatus = !coilStatusesAdam1[8];
                            Adam1.WriteAdamCoils(9 + 17, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput1Adam10":
                            coilStatus = !coilStatusesAdam1[10];
                            Adam1.WriteAdamCoils(10 + 17, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput1Adam11":
                            coilStatus = !coilStatusesAdam1[11];
                            Adam1.WriteAdamCoils(11 + 17, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput1Adam12":
                            coilStatus = !coilStatusesAdam1[12];
                            Adam1.WriteAdamCoils(12 + 17, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput1Adam13":
                            coilStatus = !coilStatusesAdam1[13];
                            Adam1.WriteAdamCoils(13 + 17, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput1Adam14":
                            coilStatus = !coilStatusesAdam1[14];
                            Adam1.WriteAdamCoils(14 + 17, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput2Adam0":
                            coilStatus = !coilStatusesAdam2[0];
                            Adam2.WriteAdamCoils(0 + 17, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput2Adam1":
                            coilStatus = !coilStatusesAdam2[1];
                            Adam2.WriteAdamCoils(1 + 17, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput2Adam2":
                            coilStatus = !coilStatusesAdam2[2];
                            Adam2.WriteAdamCoils(2 + 17, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput2Adam3":
                            coilStatus = !coilStatusesAdam2[3];
                            Adam2.WriteAdamCoils(3 + 17, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput2Adam4":
                            coilStatus = !coilStatusesAdam2[4];
                            Adam2.WriteAdamCoils(4 + 17, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput2Adam5":
                            coilStatus = !coilStatusesAdam2[5];
                            Adam2.WriteAdamCoils(5 + 17, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput2Adam6":
                            coilStatus = !coilStatusesAdam2[6];
                            Adam2.WriteAdamCoils(6 + 17, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput2Adam7":
                            coilStatus = !coilStatusesAdam2[7];
                            Adam2.WriteAdamCoils(7 + 17, coilStatus, out resultStatus);
                            break;
                        case "button_DiagnosticsOutput2Adam8":
                            coilStatus = !coilStatusesAdam2[8];
                            Adam2.WriteAdamCoils(8 + 17, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput2Adam9":
                            coilStatus = !coilStatusesAdam2[9];
                            Adam2.WriteAdamCoils(9 + 17, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput2Adam10":
                            coilStatus = !coilStatusesAdam2[10];
                            Adam2.WriteAdamCoils(10 + 17, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput2Adam11":
                            coilStatus = !coilStatusesAdam2[11];
                            Adam2.WriteAdamCoils(11 + 17, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput2Adam12":
                            coilStatus = !coilStatusesAdam2[12];
                            Adam2.WriteAdamCoils(12 + 17, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput2Adam13":
                            coilStatus = !coilStatusesAdam1[13];
                            Adam2.WriteAdamCoils(13 + 17, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput2Adam14":
                            coilStatus = !coilStatusesAdam2[14];
                            Adam2.WriteAdamCoils(14 + 17, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput2Adam15":
                            coilStatus = !coilStatusesAdam2[15];
                            Adam2.WriteAdamCoils(15 + 17, coilStatus, out resultStatus);
                            break;
                    }
                }

                if (resultStatus == true)
                {
                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"{btn.Name} set to {coilStatus}", "|OK|");
                }
                else
                {
                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"{btn.Name} set to {coilStatus}", "|Failed|");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }
        }

        private void listBox_MainRecipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Hwindow_Diagnostika.HalconWindow.ClearWindow();
                RecipeMaterialName = listBox_MainRecipe.SelectedItem.ToString();
                ReadDrawings = new ReadDrawingsProcedure();
                ReadDrawings.Function_ReadDrawing(
                        RecipeMaterialName,
                        out HObject RegionRight,
                        out HObject RegionFront,
                        out HObject RegionBottom,
                        out HObject RegionBack,
                        out HObject RegionTop,
                        out HObject RegionLeft,
                        out HObject CirclesInRegionRight,
                        out HObject CirclesInRegionFront,
                        out HObject CirclesInRegionBottom,
                        out HObject CirclesInRegionBack,
                        out HObject CirclesInRegionTop,
                        out HObject CirclesInRegionLeft,
                        out HObject ContourOnlyFromCircles,
                        out HTuple Recipe_LengthOfBoardMm,
                        out HTuple Recipe_WitdhOfBoardMm,
                        out HTuple Recipe_ThickessOfBoardMm,
                        out HTuple h_mix_arrException);
                if (h_mix_arrException.Length <= 0)
                {
                    Hwindow_Diagnostika.HalconWindow.SetDraw("margin");
                    Hwindow_Diagnostika.HalconWindow.SetLineWidth(1);
                    Hwindow_Diagnostika.HalconWindow.SetColor("white");
                    Hwindow_Diagnostika.HalconWindow.DispObj(RegionRight);
                    Hwindow_Diagnostika.HalconWindow.DispObj(RegionFront);
                    Hwindow_Diagnostika.HalconWindow.DispObj(RegionBottom);
                    Hwindow_Diagnostika.HalconWindow.DispObj(RegionBack);
                    Hwindow_Diagnostika.HalconWindow.DispObj(RegionTop);
                    Hwindow_Diagnostika.HalconWindow.DispObj(RegionLeft);
                    Hwindow_Diagnostika.HalconWindow.SetColor("green");
                    Hwindow_Diagnostika.HalconWindow.DispObj(CirclesInRegionRight);
                    Hwindow_Diagnostika.HalconWindow.DispObj(CirclesInRegionFront);
                    Hwindow_Diagnostika.HalconWindow.DispObj(CirclesInRegionBottom);
                    Hwindow_Diagnostika.HalconWindow.DispObj(CirclesInRegionBack);
                    Hwindow_Diagnostika.HalconWindow.DispObj(CirclesInRegionTop);
                    Hwindow_Diagnostika.HalconWindow.DispObj(CirclesInRegionLeft);
                    Hwindow_Diagnostika.HalconWindow.DispObj(ContourOnlyFromCircles);
                Hwindow_Diagnostika.HalconWindow.SetPart(0,0,-1,-1);
                Loging.MakeLog(DateTime.Now, "Vybrany novy recept", "|OK|");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }

        }

        private void button_MainStart_Click(object sender, EventArgs e)
        {

            try
            {
                ConsumerCam1LsTopL = new Consumer("Cam1LsTopL", 100);
                ConsumerCam1LsTopL.TileImageReady += Cunsumer_TileImages;
                ConsumerCam1LsTopL.Start();

                ProducerCam1LsTopL = new Producer("Cam1LsTopL", PersistentVariables, ConsumerCam1LsTopL);
                ProducerCam1LsTopL.Start();

                ConsumerCam2LsTopR = new Consumer("Cam2LsTopR", 100);
                ConsumerCam2LsTopR.TileImageReady += Cunsumer_TileImages;
                ConsumerCam2LsTopR.Start();

                ProducerCam2LsTopR = new Producer("Cam2LsTopR", PersistentVariables, ConsumerCam2LsTopR);
                ProducerCam2LsTopR.Start();


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

            string expTime = splittedtex[indexSelected * 2];
            string gain = text.Split(',')[indexSelected * 2 + 1];

            string changedExpTime = expTime.Split(':')[1];
            string changedGain = gain.Split(':')[1];

            UpdateUI.UpdateTextBoxText(textBox_DiagnosticsExposureTime, changedExpTime);
            UpdateUI.UpdateTextBoxText(textBox_DiagnosticsGain, changedGain);
        }

        private async void button_MainStop_Click(object sender, EventArgs e)
        {
            Parallel.Invoke(() =>
            {
                ConsumerCam1LsTopL.TileImageReady -= Cunsumer_TileImages;
                ConsumerCam2LsTopR.TileImageReady -= Cunsumer_TileImages;
                ProducerCam1LsTopL.AbortThread();
                ProducerCam2LsTopR.AbortThread();

                ConsumerCam1LsTopL.AbortThread();
                ConsumerCam2LsTopR.AbortThread();
            });
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
                    MessageBox.Show("Heslo bolo zmenene", "Message");
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

        private void pictureBox_FooterKeyBoard_Click(object sender, EventArgs e)
        {
            try
            {
                ShowKeyBoard();
            }

            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }
        }

        private void ShowKeyBoard()
        {
            Process[] keyboard = new Process[1];
            keyboard = Process.GetProcessesByName("osk");

            if (KeyboardIsShowed == true && keyboard.Length >= 1)
            {
                keyboard[0].Kill();
                KeyboardIsShowed = false;
            }
            else
            {
                Process.Start("osk.exe");
                KeyboardIsShowed = true;
            }
        }

        private void timer_AdamCoilsRead_Tick(object sender, EventArgs e)
        {
            try
            {
                List<bool> coilsStatusAdam1 = Adam1.ReadAdamCoils(15);
                List<bool> coilsStatusAdam2 = Adam2.ReadAdamCoils(16);

                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsInput1Adam0, coilsStatusAdam1[0]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsInput1Adam1, coilsStatusAdam1[1]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsInput1Adam2, coilsStatusAdam1[2]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsInput1Adam3, coilsStatusAdam1[3]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsInput1Adam4, coilsStatusAdam1[4]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsInput1Adam5, coilsStatusAdam1[5]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsInput1Adam6, coilsStatusAdam1[6]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsInput1Adam7, coilsStatusAdam1[7]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput1Adam8, coilsStatusAdam1[8]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput1Adam9, coilsStatusAdam1[9]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput1Adam10, coilsStatusAdam1[10]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput1Adam11, coilsStatusAdam1[11]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput1Adam12, coilsStatusAdam1[12]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput1Adam13, coilsStatusAdam1[13]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput1Adam14, coilsStatusAdam1[14]);

                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput2Adam0, coilsStatusAdam2[0]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput2Adam1, coilsStatusAdam2[1]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput2Adam2, coilsStatusAdam2[2]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput2Adam3, coilsStatusAdam2[3]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput2Adam4, coilsStatusAdam2[4]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput2Adam5, coilsStatusAdam2[5]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput2Adam6, coilsStatusAdam2[6]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput2Adam7, coilsStatusAdam2[7]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput2Adam8, coilsStatusAdam2[8]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput2Adam9, coilsStatusAdam2[9]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput2Adam10, coilsStatusAdam2[10]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput2Adam11, coilsStatusAdam2[11]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput2Adam12, coilsStatusAdam2[12]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput2Adam13, coilsStatusAdam2[13]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput2Adam14, coilsStatusAdam2[14]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput2Adam15, coilsStatusAdam2[15]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }
        }

        private void button_MainSaveImg_Click(object sender, EventArgs e)
        {
            HObject image = new HObject();
            HOperatorSet.GenEmptyObj(out image);
            string timeStamp = DateTime.Now.ToString("MM_dd_yyyy HH_mm_ss");
            if(listBox_MainRecipe.SelectedItem == null || listBox_MainRecipe.SelectedItem.ToString() == "")
            {
                return;
            }

            try
            {
                if (checkBox_SaveOnlyOneSide.CheckState == CheckState.Checked)
                {
                    switch (tabControl_MainCameras.SelectedTab.Name)
                    {
                        case "tabPage_LeftSide":
                            HOperatorSet.DumpWindowImage(out image, Hwindow_LeftSide.HalconWindow);
                            HOperatorSet.WriteImage(image, "tiff", 0, $"{GlobalVariables.SavedImagesFromProgramPath}\\LeftSide\\{timeStamp}__LeftSideImage_{listBox_MainRecipe.SelectedItem}"); 
                            break;
                        case "tabPage_RightSide":
                            HOperatorSet.DumpWindowImage(out image, Hwindow_RightSide.HalconWindow);
                            HOperatorSet.WriteImage(image, "tiff", 0, $"{GlobalVariables.SavedImagesFromProgramPath}\\RightSide\\{timeStamp}__RightSideImage_{listBox_MainRecipe.SelectedItem}");
                            break;
                        case "tabPage_FrontSide":
                            HOperatorSet.DumpWindowImage(out image, Hwindow_FrontSide.HalconWindow);
                            HOperatorSet.WriteImage(image, "tiff", 0, $"{GlobalVariables.SavedImagesFromProgramPath}\\FrontSide\\{timeStamp}__FrontSideImage_{listBox_MainRecipe.SelectedItem}");
                            break;
                        case "tabPage_BackSide":
                            HOperatorSet.DumpWindowImage(out image, Hwindow_BackSide.HalconWindow);
                            HOperatorSet.WriteImage(image, "tiff", 0, $"{GlobalVariables.SavedImagesFromProgramPath}\\BackSide\\{timeStamp}__BackSideImage_{listBox_MainRecipe.SelectedItem}");
                            break;
                        case "tabPage_UpperSide":
                            HOperatorSet.DumpWindowImage(out image, Hwindow_UpperSide.HalconWindow);
                            HOperatorSet.WriteImage(image, "tiff", 0, $"{GlobalVariables.SavedImagesFromProgramPath}\\UpperSide\\{timeStamp}__UpperSideImage_{listBox_MainRecipe.SelectedItem}");
                            break;
                        case "tabPage_LowerSide":
                            HOperatorSet.DumpWindowImage(out image, Hwindow_LowerSide.HalconWindow);
                            HOperatorSet.WriteImage(image, "tiff", 0, $"{GlobalVariables.SavedImagesFromProgramPath}\\LowerSide\\{timeStamp}__LowerSideImage_{listBox_MainRecipe.SelectedItem}");
                            break;
                    }
                }

                else
                {
                    HOperatorSet.DumpWindowImage(out image, Hwindow_LeftSide.HalconWindow);
                    HOperatorSet.WriteImage(image, "tiff", 0, $"{GlobalVariables.SavedImagesFromProgramPath}\\LeftSide\\{timeStamp}__LeftSideImage_{listBox_MainRecipe.SelectedItem}");
                    HOperatorSet.DumpWindowImage(out image, Hwindow_RightSide.HalconWindow);
                    HOperatorSet.WriteImage(image, "tiff", 0, $"{GlobalVariables.SavedImagesFromProgramPath}\\RightSide\\{timeStamp}__RightSideImage_{listBox_MainRecipe.SelectedItem}");
                    HOperatorSet.DumpWindowImage(out image, Hwindow_FrontSide.HalconWindow);
                    HOperatorSet.WriteImage(image, "tiff", 0, $"{GlobalVariables.SavedImagesFromProgramPath}\\FrontSide\\{timeStamp}__FrontSideImage_{listBox_MainRecipe.SelectedItem}");
                    HOperatorSet.DumpWindowImage(out image, Hwindow_BackSide.HalconWindow);
                    HOperatorSet.WriteImage(image, "tiff", 0, $"{GlobalVariables.SavedImagesFromProgramPath}\\BackSide\\{timeStamp}__BackSideImage_{listBox_MainRecipe.SelectedItem}");
                    HOperatorSet.DumpWindowImage(out image, Hwindow_UpperSide.HalconWindow);
                    HOperatorSet.WriteImage(image, "tiff", 0, $"{GlobalVariables.SavedImagesFromProgramPath}\\UpperSide\\{timeStamp}__UpperSideImage_{listBox_MainRecipe.SelectedItem}");
                    HOperatorSet.DumpWindowImage(out image, Hwindow_LowerSide.HalconWindow);
                    HOperatorSet.WriteImage(image, "tiff", 0, $"{GlobalVariables.SavedImagesFromProgramPath}\\LowerSide\\{timeStamp}__LowerSideImage_{listBox_MainRecipe.SelectedItem}");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }
        }
        private void ReadAllRecipes()
        {
            List<string> allRecipes = Directory.GetFiles(GlobalVariables.DrawingsPath).ToList();
            foreach(string line in allRecipes)
            {
                listBox_MainRecipe.Items.Add(line.Split('\\')[4]);
            }

        }
        private void ReadAllRecipes(string text)
        {
            List<string> allRecipes = Directory.EnumerateFiles(GlobalVariables.DrawingsPath, "*.*", SearchOption.AllDirectories).Where(s => s.Contains(text)).ToList();
            foreach (string line in allRecipes)
            {
                listBox_MainRecipe.Items.Add(line.Split('\\')[4]);
            }
        }

        private void textBox_MainSearchRecipe_TextChanged(object sender, EventArgs e)
        {
            listBox_MainRecipe.Items.Clear();
            ReadAllRecipes(textBox_MainSearchRecipe.Text);
        }
    }
}
