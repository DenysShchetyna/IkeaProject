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
        private MainProgramProcedures MainProcedures;
        private DrawingVariables DrawingVariables;
        private RecipeVariables RecipeVariables;


        Material Plank;
        DrawingSide DrawingSide;
        Hole Hole;

        HDevProc Procedures;
        PersistentVariables PersistentVariables;

        public ProducerDouble ProducerCam1LsTopLCam2LsTopR;
        public ConsumerDouble ConsumerCam1LsTopLCam2LsTopR;

        public ProducerDouble ProducerCam3LsBottomLCam4LsBottomR;
        public ConsumerDouble ConsumerCam3LsBottomLCam4LsBottomR;


        public Producer ProducerCam5LsLeft;
        public Consumer ConsumerCam5LsLeft;
        public Producer ProducerCam6LsRight;
        public Consumer ConsumerCam6LsRight;

        public ProducerDouble ProducerCam5LsLeftCam6LsRight;
        public ConsumerDouble ConsumerCam5LsLeftCam6LsRight;



        public ProducerDouble ProducerCam7ArFrontLCam8ArFrontR;
        public ConsumerDouble ConsumerCam7ArFrontLCam8ArFrontR;


        public ProducerDouble ProducerCam9ArBackLCam10ArBackR;
        public ConsumerDouble ConsumerCam9ArBackLCam10ArBackR;


        public ProducerDouble ProducerCam11ArTopLCam12ArTopR;
        public ConsumerDouble ConsumerCam11ArTopLCam12ArTopR;


        public ProducerDouble ProducerCam13ArBottomLCam14ArBottomR;
        public ConsumerDouble ConsumerCam13ArBottomLCam14ArBottomR;


        private bool KeyboardIsShowed = false;

        private DeviceManager Adam1;
        private DeviceManager Adam2;


        public int ImgNum = 0;

        List<string> ListOfImagesPaths = new List<string>()
        {
                @"C:\Trifid\A0670\SW\C#\IKEA\Data/DGG_435_BR.bmp",
                @"C:\Trifid\A0670\SW\C#\IKEA\Data/DGG_441_JS_DB.bmp",
                @"C:\Trifid\A0670\SW\C#\IKEA\Data/DGG_506_BR.bmp",
                @"C:\Trifid\A0670\SW\C#\IKEA\Data/DGG07440.bmp",
                @"C:\Trifid\A0670\SW\C#\IKEA\Data/FBA_025_obycajny_papier.bmp",
                @"C:\Trifid\A0670\SW\C#\IKEA\Data/DGG_400.bmp",
                @"C:\Trifid\A0670\SW\C#\IKEA\Data/DGL_016_biely.bmp",
                @"C:\Trifid\A0670\SW\C#\IKEA\Data/DGN_706_obycajny.jpg",
                @"C:\Trifid\A0670\SW\C#\IKEA\Data/DGL_130_obycajny.bmp"
        };

        private bool IsAdministratorLoggedIn = false;
        private string CurrentAdministrator = "";

        public MainForm()
        {
            InitializeComponent();

            // Procedures = new HDevProc(GlobalVariables.HalconEvaluationPath); //testova

            MainProcedures = new MainProgramProcedures();

            SqliteDataAccess.IsAvailable();

            
            timer_Clock.Enabled = true;
            timer_Clock.Start();
            //timer_DiscsCheck.Enabled = true;
            //timer_DiscsCheck.Start();
            //timer_CameraPing.Enabled = true;
            //timer_CameraPing.Start();
            //timer_AdamCoilsRead.Enabled = true;
            //timer_AdamCoilsRead.Start();
            //Adam1 = new DeviceManager("192.168.200.21");// 6250 7in 8 out
            //Adam2 = new DeviceManager("192.168.200.22");// 6256 16 outs

            LoadAllRecipes();

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

            switch (e.CamNames)
            {
                case "Cam1LsTopL_Cam2LsTopR":
                    HObject tile1_2 = e.TileImageCam1_2;
                    Hwindow_RightSide.HalconWindow.DispObj(tile1_2);
                    Hwindow_RightSide.HalconWindow.SetPart(0, 0, -1, -1);
                    break;


                case "Cam3LsBottomL_Cam4LsBottomR":
                    HObject tile3_4 = e.TileImageCam3_4;
                    Hwindow_RightSide.HalconWindow.DispObj(tile3_4);
                    Hwindow_RightSide.HalconWindow.SetPart(0, 0, -1, -1);
                    break;


                case "Cam5LsLeft":
                    HObject tile5 = e.TileImageCam5;
                    Hwindow_RightSide.HalconWindow.DispObj(tile5);
                    Hwindow_RightSide.HalconWindow.SetPart(0, 0, -1, -1);

                    break;

                case "Cam6LsRight":
                    HObject tile6 = e.TileImageCam6;
                    Hwindow_RightSide.HalconWindow.DispObj(tile6);
                    Hwindow_RightSide.HalconWindow.SetPart(0, 0, -1, -1);
                    break;

                case "Cam7ArFrontL_Cam8ArFrontR":
                    HObject tile7_8 = e.TileImageCam7_8;
                    Hwindow_RightSide.HalconWindow.DispObj(tile7_8);
                    Hwindow_RightSide.HalconWindow.SetPart(0, 0, -1, -1);

                    break;

                case "Cam9ArBackL_Cam10ArBackR":
                    HObject tile9_10 = e.TileImageCam9_10;
                    Hwindow_RightSide.HalconWindow.DispObj(tile9_10);
                    Hwindow_RightSide.HalconWindow.SetPart(0, 0, -1, -1);
                    break;

                case "Cam11ArTopL_Cam12ArTopR":
                    HObject tile11_12 = e.TileImageCam11_12;
                    Hwindow_RightSide.HalconWindow.DispObj(tile11_12);
                    Hwindow_RightSide.HalconWindow.SetPart(0, 0, -1, -1);

                    break;

                case "Cam13ArBottomL_Cam14ArBottomR":
                    HObject tile13_14 = e.TileImageCam13_14;
                    Hwindow_RightSide.HalconWindow.DispObj(tile13_14);
                    Hwindow_RightSide.HalconWindow.SetPart(0, 0, -1, -1);
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
            //string availableSpaceDiscC = DiscManagement.CheckDiscs(GlobalVariables.DiscManagementGigabytes, GlobalVariables.ImagesDiscC).ToString();
            //UpdateUI.UpdateLabelText(label_AvailableSpaceC, availableSpaceDiscC + " GB");
        }

        private void timer_Simulation_Tick(object sender, EventArgs e)
        {

        }

        private void button_ExitApp_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProducerCam1LsTopLCam2LsTopR != null)
                {
                    ProducerCam1LsTopLCam2LsTopR.AbortThread();
                }
                if (ProducerCam7ArFrontLCam8ArFrontR != null)
                {
                    ProducerCam7ArFrontLCam8ArFrontR.AbortThread();
                }
                Application.Exit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{ 0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }
        }


        private async void timer_CameraPing_Tick(object sender, EventArgs e)
        {
            try
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
            catch(Exception ex)
            {
                Console.WriteLine("{ 0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");

            }

        }

        private void button_DiagnosticsOutput_Click(object sender, EventArgs e)
        {
            bool resultStatus = false;
            bool coilStatus = false;

            try
            {
                Button btn = (Button)sender;
                List<bool> coilStatusesAdam1 = Adam1.ReadAdamCoils(23);// 7int 8 outs
                List<bool> coilStatusesAdam2 = Adam2.ReadAdamCoils(16); //16 outs

                if (coilStatusesAdam1 != null && coilStatusesAdam2 != null)
                {
                    switch (btn.Name.ToString())
                    {
                        case "button_DiagnosticsOutput1Adam8":
                            coilStatus = !coilStatusesAdam1[16];
                            Adam1.WriteAdamCoils(17, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput1Adam9":
                            coilStatus = !coilStatusesAdam1[17];
                            Adam1.WriteAdamCoils(18, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput1Adam10":
                            coilStatus = !coilStatusesAdam1[18];
                            Adam1.WriteAdamCoils(19, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput1Adam11":
                            coilStatus = !coilStatusesAdam1[19];
                            Adam1.WriteAdamCoils(20, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput1Adam12":
                            coilStatus = !coilStatusesAdam1[20];
                            Adam1.WriteAdamCoils(21, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput1Adam13":
                            coilStatus = !coilStatusesAdam1[21];
                            Adam1.WriteAdamCoils(22, coilStatus, out resultStatus);
                            break;

                        case "button_DiagnosticsOutput1Adam14":
                            coilStatus = !coilStatusesAdam1[22];
                            Adam1.WriteAdamCoils(23, coilStatus, out resultStatus);
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
                string recipeDrawingName = listBox_MainRecipe.SelectedItem.ToString();
                string recipeName = recipeDrawingName.Replace(".DXF", ".txt");

                ReadDrawing(recipeDrawingName);
                ReadRecipe(recipeDrawingName);

                CameraDefaultSettings.SetCameraDefaultSettingsFromFile(GlobalVariables.SetCamParameteresPFSFilePathProcedure, DrawingVariables.IntSurfaceTypeFromDrawing);


                Loging.MakeLog(DateTime.Now, $"Vybrany novy recept {recipeName}", "|OK|");
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"New recipe {recipeName} is selected", "|OK|");
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                Loging.MakeLog(DateTime.Now, ex.Message, "|Error|");
            }
        }

        private void ReadRecipe(string recipeName)
        {
            try
            {
                RecipeVariables = MainProcedures.Function_RecipeReader(
                   recipeName,
                   out HTuple h_realTolerancePositionPlusMinusMm,
                   out HTuple h_realToleranceDiameterPlusMinusMm,
                   out HTuple h_intMaxAllowedNumberErrorsPosition,
                   out HTuple h_intMaxAllowedNumberErrorsDiameter,
                   out HTuple Exception);

                if (RecipeVariables != null)
                {
                    textBox_MainToleranceDiameter.Text = RecipeVariables.RecipeToleranceDiameter;
                    textBox_MainTolerancePosition.Text = RecipeVariables.RecipeTolerancePosition;
                    textBox_MainMaxPosErrors.Text = RecipeVariables.RecipeMaxPositionError;
                    textBox_MainMaxDiameterErrors.Text = RecipeVariables.RecipeMaxDiameterError;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }

        }
        private void ReadDrawing(string recipeDrawingName)
        {
            try
            {
                Hwindow_Diagnostika.HalconWindow.ClearWindow();
                RecipeMaterialName = listBox_MainRecipe.SelectedItem.ToString();

                DrawingVariables = MainProcedures.Function_ReadDrawing(
                        recipeDrawingName,
                        0,
                        out HObject h_reg_arrRoiMmTopPartSmallHolesForLsCameras,
                        out HObject h_reg_arrRoiMmTopPartLargeHolesForArCameras,
                        out HObject h_reg_arrRoiMmBottomPartSmallHolesForLsCameras,
                        out HObject h_reg_arrRoiMmBottomPartLargeHolesForArCameras,
                        out HObject h_reg_arrRoiMmLeftPartHolesForLsCameras,
                        out HObject h_reg_arrRoiMmRightPartHolesForLsCameras,
                        out HObject h_reg_arrRoiMmFrontPartHolesForArCameras,
                        out HObject h_reg_arrRoiMmBackPartHolesForArCameras,
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
                        out HTuple h_intSurfaceTypeFromDrawing,
                        out HTuple h_realRecipeLengthOfBoardMm,
                        out HTuple h_realRecipeWitdhOfBoardMm,
                        out HTuple h_realRecipeThickessOfBoardMm,
                        out HTuple h_real_arrXPositionMmRightFromDrawing,
                        out HTuple h_real_arrYPositionMmRightFromDrawing,
                        out HTuple h_real_arrDiameterMmRightFromDrawing,
                        out HTuple h_real_arrXPositionMmFrontFromDrawing,
                        out HTuple h_real_arrYPositionMmFrontFromDrawing,
                        out HTuple h_real_arrDiameterMmFrontFromDrawing,
                        out HTuple h_real_arrXPositionMmBottomFromDrawing,
                        out HTuple h_real_arrYPositionMmBottomFromDrawing,
                        out HTuple h_real_arrDiameterMmBottomFromDrawing,
                        out HTuple h_real_arrXPositionMmBackFromDrawing,
                        out HTuple h_real_arrYPositionMmBackFromDrawing,
                        out HTuple h_real_arrDiameterMmBackFromDrawing,
                        out HTuple h_real_arrXPositionMmTopFromDrawing,
                        out HTuple h_real_arrYPositionMmTopFromDrawing,
                        out HTuple h_real_arrDiameterMmTopFromDrawing,
                        out HTuple h_real_arrXPositionMmLeftFromDrawing,
                        out HTuple h_real_arrYPositionMmLeftFromDrawing,
                        out HTuple h_real_arrDiameterMmLeftFromDrawing,
                        out HTuple h_mix_arrException);


                Hwindow_Diagnostika.HalconWindow.SetDraw("margin");
                Hwindow_Diagnostika.HalconWindow.SetLineWidth(2);
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
                Hwindow_Diagnostika.HalconWindow.SetPart(0, 0, -1, -1);
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

                if (DrawingVariables != null)
                {

                    ConsumerCam1LsTopLCam2LsTopR = new ConsumerDouble("Cam1LsTopL", "Cam2LsTopR", 10);
                    ConsumerCam1LsTopLCam2LsTopR.TileImageReady += Cunsumer_TileImages;
                    ConsumerCam1LsTopLCam2LsTopR.Start();

                    ProducerCam1LsTopLCam2LsTopR = new ProducerDouble("Cam1LsTopL", "Cam2LsTopR", ConsumerCam1LsTopLCam2LsTopR, DrawingVariables.IntSurfaceTypeFromDrawing);
                    ProducerCam1LsTopLCam2LsTopR.Start();


                    //ConsumerCam3LsBottomLCam4LsBottomR = new ConsumerDouble("Cam3LsBottomL", "Cam4LsBottomR", 10);
                    //ConsumerCam3LsBottomLCam4LsBottomR.TileImageReady += Cunsumer_TileImages;
                    //ConsumerCam3LsBottomLCam4LsBottomR.Start();

                    //ProducerCam3LsBottomLCam4LsBottomR = new ProducerDouble("Cam3LsBottomL", "Cam4LsBottomR", ConsumerCam3LsBottomLCam4LsBottomR, DrawingVariables.IntSurfaceTypeFromDrawing);
                    //ProducerCam3LsBottomLCam4LsBottomR.Start();

                    //ConsumerCam5LsLeftCam6LsRight = new ConsumerDouble("Cam5LsLeft", "Cam6LsRight", 10);
                    //ConsumerCam5LsLeftCam6LsRight.Start();

                    //ProducerCam5LsLeftCam6LsRight = new ProducerDouble("Cam5LsLeft", "Cam6LsRight", ConsumerCam5LsLeftCam6LsRight, DrawingVariables.IntSurfaceTypeFromDrawing);
                    //ProducerCam5LsLeftCam6LsRight.Start();


                    ConsumerCam11ArTopLCam12ArTopR = new ConsumerDouble("Cam11ArTopL", "Cam12ArTopR", 10);
                    ConsumerCam11ArTopLCam12ArTopR.TileImageReady += Cunsumer_TileImages;
                    ConsumerCam11ArTopLCam12ArTopR.Start();

                    ProducerCam11ArTopLCam12ArTopR = new ProducerDouble("Cam11ArTopL", "Cam12ArTopR", ConsumerCam11ArTopLCam12ArTopR, DrawingVariables.IntSurfaceTypeFromDrawing);
                    ProducerCam11ArTopLCam12ArTopR.Start();


                    //ConsumerCam13ArBottomLCam14ArBottomR = new ConsumerDouble("Cam13ArBottomL", "Cam14ArBottomR", 10);
                    //ConsumerCam13ArBottomLCam14ArBottomR.TileImageReady += Cunsumer_TileImages;
                    //ConsumerCam13ArBottomLCam14ArBottomR.Start();

                    //ProducerCam13ArBottomLCam14ArBottomR = new ProducerDouble("Cam13ArBottomL", "Cam14ArBottomR", ConsumerCam13ArBottomLCam14ArBottomR, DrawingVariables.IntSurfaceTypeFromDrawing);
                    //ProducerCam13ArBottomLCam14ArBottomR.Start();


                    //ConsumerCam2LsTopR = new Consumer("Cam2LsTopR", 100);
                    //ConsumerCam2LsTopR.TileImageReady += Cunsumer_TileImages;
                    //ConsumerCam2LsTopR.Start();

                    //ProducerCam2LsTopR = new Producer("Cam2LsTopR", PersistentVariables, ConsumerCam2LsTopR);
                    //ProducerCam2LsTopR.Start();


                    //ConsumerCam1Cam2 = new Consumer("Cam1Cam2", 100);
                    //ConsumerCam1Cam2.TileImageReady += Cunsumer_TileImages;
                    //ConsumerCam1Cam2.Start();

                    //ProducerrCam1Cam2 = new Producer("Cam1Cam2", PersistentVariables, ConsumerCam1Cam2);
                    //ProducerrCam1Cam2.Start();

                    //ConsumerCam5LsLeft = new Consumer("Cam5LsLeft", 100);
                    //ConsumerCam5LsLeft.TileImageReady += Cunsumer_TileImages;
                    //ConsumerCam5LsLeft.Start();

                    //ProducerrCam5LsLeft = new Producer("Cam5LsLeft", PersistentVariables, ConsumerCam5LsLeft, DrawingVariables.IntSurfaceTypeFromDrawing);
                    //ProducerrCam5LsLeft.Start();

                }



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
            try
            {
                string gainRaw;
                string exposureTime;
                if (DrawingVariables != null && DrawingVariables.IntSurfaceTypeFromDrawing != null)
                {
                    string cameraPfsFileName = listBox_DiagnosticsCamerasSettings.SelectedItem.ToString() + DrawingVariables.IntSurfaceTypeFromDrawing + ".pfs";
                    var text = File.ReadAllLines(GlobalVariables.CamPfsFilesPath + cameraPfsFileName);

                    if (cameraPfsFileName.Contains("Ls") == true)
                    {
                        gainRaw = text[9].Split('\t')[1];
                        exposureTime = text[64].Split('\t')[1];
                    }
                    else
                    {
                        gainRaw = text[9].Split('\t')[1];
                        exposureTime = text[54].Split('\t')[1];
                    }

                    UpdateUI.UpdateTextBoxText(textBox_DiagnosticsExposureTime, exposureTime);
                    UpdateUI.UpdateTextBoxText(textBox_DiagnosticsGain, gainRaw);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                Loging.MakeLog(DateTime.Now, "Vision Process Start", " |Error| ");
            }
        }

        private void button_MainStop_Click(object sender, EventArgs e)
        {
            try
            {
                Parallel.Invoke(() =>
                {
                    try
                    {
                        if (ConsumerCam1LsTopLCam2LsTopR != null)
                        {
                            ConsumerCam1LsTopLCam2LsTopR.TileImageReady -= Cunsumer_TileImages;
                        }

                        if (ProducerCam1LsTopLCam2LsTopR != null)
                        {
                            ProducerCam1LsTopLCam2LsTopR.AbortThread();
                            ConsumerCam1LsTopLCam2LsTopR.AbortThread();

                        }

                        if (ConsumerCam7ArFrontLCam8ArFrontR != null)
                        {
                            ConsumerCam7ArFrontLCam8ArFrontR.TileImageReady -= Cunsumer_TileImages;
                        }
                        if (ProducerCam7ArFrontLCam8ArFrontR != null)
                        {
                            ProducerCam7ArFrontLCam8ArFrontR.AbortThread();
                            ConsumerCam7ArFrontLCam8ArFrontR.AbortThread();

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                        Loging.MakeLog(DateTime.Now, "Main Stop", "|Error|");
                    }

                });
                Loging.MakeLog(DateTime.Now, "All thread aborted", "|OK|");

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                Loging.MakeLog(DateTime.Now, "Main Stop", "|Error|");

            }

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
            tabControl_MainControl.SelectedTab = tabControl_MainControl.TabPages[2];
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
            try
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
            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");

            }
        }

        private void timer_AdamCoilsRead_Tick(object sender, EventArgs e)
        {
            if (label_AccessLevel.Text != "Administrator")
            {
                foreach (Control c in groupBox_DiagnosticsOutputs.Controls)
                {
                    if (c.Name.Contains("button"))
                    {
                        Button btn = (Button)c;
                        btn.Enabled = false;
                    }
                }
                foreach (Control c in groupBox_DiagnosticsVstupy.Controls)
                {
                    if (c.Name.Contains("button"))
                    {
                        Button btn = (Button)c;
                        btn.Enabled = false;
                    }
                }
            }
            else
            {
                foreach (Control c in groupBox_DiagnosticsOutputs.Controls)
                {
                    if (c.Name.Contains("button"))
                    {
                        Button btn = (Button)c;
                        btn.Enabled = true;
                    }
                }
                foreach (Control c in groupBox_DiagnosticsVstupy.Controls)
                {
                    if (c.Name.Contains("button"))
                    {
                        Button btn = (Button)c;
                        btn.Enabled = true;
                    }
                }
            }

            try
            {
                List<bool> coilsStatusAdam1 = Adam1.ReadAdamCoils(25);
                List<bool> coilsStatusAdam2 = Adam2.ReadAdamCoils(16);

                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsInput1Adam0, coilsStatusAdam1[0]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsInput1Adam1, coilsStatusAdam1[1]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsInput1Adam2, coilsStatusAdam1[2]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsInput1Adam3, coilsStatusAdam1[3]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsInput1Adam4, coilsStatusAdam1[4]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsInput1Adam5, coilsStatusAdam1[5]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsInput1Adam6, coilsStatusAdam1[6]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsInput1Adam7, coilsStatusAdam1[7]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput1Adam8, coilsStatusAdam1[16]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput1Adam9, coilsStatusAdam1[17]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput1Adam10, coilsStatusAdam1[18]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput1Adam11, coilsStatusAdam1[19]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput1Adam12, coilsStatusAdam1[20]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput1Adam13, coilsStatusAdam1[21]);
                UpdateUI.UpdatePictureBox(pictureBox_DiagnosticsOutput1Adam14, coilsStatusAdam1[22]);

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
            if (listBox_MainRecipe.SelectedItem == null || listBox_MainRecipe.SelectedItem.ToString() == "")
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
        private void LoadAllRecipes()
        {
            List<string> allRecipes = Directory.GetFiles(GlobalVariables.DrawingsPath).ToList();
            foreach (string line in allRecipes)
            {
                listBox_MainRecipe.Items.Add(line.Split('\\')[6]);
            }

        }
        private void SearchFromRecipes(string text)
        {
            List<string> allRecipes = Directory.EnumerateFiles(GlobalVariables.DrawingsPath, "*.DXF", SearchOption.AllDirectories).Where(s => s.Contains(text)).ToList();
            foreach (string line in allRecipes)
            {
                listBox_MainRecipe.Items.Add(line.Split('\\')[6]);
            }
        }

        private void textBox_MainSearchRecipe_TextChanged(object sender, EventArgs e)
        {
            listBox_MainRecipe.Items.Clear();
            SearchFromRecipes(textBox_MainSearchRecipe.Text);
        }

        private void button_Trigger_click(object sender, EventArgs e)
        {
        }

        private void button_MainChangeRecipeValues_Click(object sender, EventArgs e)
        {
            try
            {
                string recipeName = listBox_MainRecipe.SelectedItem.ToString().Replace(".DXF", ".txt");
                string tolerPos = textBox_MainTolerancePosition.Text;
                string tolerDiameter = textBox_MainToleranceDiameter.Text;
                string maxPosErrors = textBox_MainMaxPosErrors.Text;
                string maxDiameterErrors = textBox_MainMaxDiameterErrors.Text;

                tolerPos = tolerPos.Contains(',') ? tolerPos.Replace(',', '.') : tolerPos;
                tolerDiameter = tolerDiameter.Contains(',') ? tolerDiameter.Replace(',', '.') : tolerDiameter;
                maxPosErrors = maxPosErrors.Contains(',') ? maxPosErrors.Replace(',', '.') : maxPosErrors;
                maxDiameterErrors = maxDiameterErrors.Contains(',') ? maxDiameterErrors.Replace(',', '.') : maxDiameterErrors;

                if ((double.TryParse(tolerPos, out double res1) == true || string.IsNullOrEmpty(tolerPos) == true)
                    && (double.TryParse(tolerDiameter, out double res2) == true || string.IsNullOrEmpty(tolerDiameter) == true)
                    && (double.TryParse(maxPosErrors, out double res3) == true || string.IsNullOrEmpty(maxPosErrors) == true)
                    && (double.TryParse(maxDiameterErrors, out double res4) == true || string.IsNullOrEmpty(maxDiameterErrors) == true))
                {
                    MainProcedures.Function_RecipeWriter(recipeName, res1, res2, res3, res4, out HTuple h_mix_arrException);
                    if (h_mix_arrException.Length < 1)
                    {
                        textBox_MainSystemMessage.Text = $"{DateTime.Now} Receptove hodnoty pre {recipeName.Replace(".txt", "")} boli zmenene";
                    }
                }
                else
                {
                    textBox_MainSystemMessage.Text = $"{DateTime.Now} Nespravne zadane parametre pre {recipeName.Replace(".txt", "")}";
                    textBox_MainToleranceDiameter.Text = RecipeVariables.RecipeToleranceDiameter;
                    textBox_MainTolerancePosition.Text = RecipeVariables.RecipeTolerancePosition;
                    textBox_MainMaxPosErrors.Text = RecipeVariables.RecipeMaxPositionError;
                    textBox_MainMaxDiameterErrors.Text = RecipeVariables.RecipeMaxDiameterError;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{ 0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }
        }

        private void button_DiagnosticSetExpTimeAndGain(object sender, EventArgs e)
        {
            try
            {
                string camName = listBox_DiagnosticsCamerasSettings.SelectedItem.ToString();
                int exposureTimeValue = Convert.ToInt32(textBox_DiagnosticsExposureTime.Text);
                int gainValue = Convert.ToInt32(textBox_DiagnosticsGain.Text);

                if (camName.Contains("Ls"))
                {
                    if (gainValue < 256 || gainValue > 2047)
                    {
                        gainValue = 1024;

                    }
                    if (exposureTimeValue < 20 || exposureTimeValue > 100000)
                    {
                        exposureTimeValue = 1000;
                    }
                }
                else if (camName.Contains("Ar"))
                {
                    if (gainValue < 36 || gainValue > 512)
                    {
                        gainValue = 256;

                    }
                    if (exposureTimeValue < 20 || exposureTimeValue > 100000)
                    {
                        exposureTimeValue = 1000;
                    }
                }

                MainProcedures.Function_PfsParametersModify(DrawingVariables.IntSurfaceTypeFromDrawing, camName, exposureTimeValue/10, gainValue, out HTuple h_mix_arrException);
                if (h_mix_arrException.Length < 1)
                {
                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"Changed Exposure time and gain for {camName} to {exposureTimeValue} and {gainValue} ", "|OK|");
                    Loging.MakeLog(DateTime.Now, $"Changed Exposure time and gain for {camName} to {exposureTimeValue} and {gainValue} ", "|OK|");
                }

                switch (camName)
                {

                    case "Cam3LsBottomL":
                        ProducerCam3LsBottomLCam4LsBottomR.ChangeParametersCam1(exposureTimeValue/10, gainValue);
                        break;
                    case "Cam4LsBottomR":
                        ProducerCam3LsBottomLCam4LsBottomR.ChangeParametersCam2(exposureTimeValue/10, gainValue);
                        break;

                    case "Cam5LsLeft":
                        ProducerCam5LsLeftCam6LsRight.ChangeParametersCam1(exposureTimeValue, gainValue);
                        break;

                    case "Cam6LsRight":
                        ProducerCam5LsLeftCam6LsRight.ChangeParametersCam2(exposureTimeValue, gainValue);
                        break;

                    case "Cam7ArFrontL":

                        ProducerCam7ArFrontLCam8ArFrontR.ChangeParametersCam1(exposureTimeValue, gainValue);

                        break;

                    case "Cam8ArFrontR":
                        ProducerCam7ArFrontLCam8ArFrontR.ChangeParametersCam2(exposureTimeValue, gainValue);

                        break;

                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("{ 0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                Loging.MakeLog(DateTime.Now, ex.Message, "|Error|");
            }
        }

        private void ReadCoilsLoop()
        {
            Thread loop = new Thread(() =>
            {
                List<bool> coilsStatusAdam1 = new List<bool>();
                List<bool> coilsStatusAdam2 = new List<bool>();
                List<bool> coilsStatusAdam1Previous = new List<bool>();
                List<bool> coilsStatusAdam2Previous = new List<bool>();

                while (true)
                {
                    coilsStatusAdam1 = Adam1.ReadAdamCoils(25);
                    coilsStatusAdam2 = Adam2.ReadAdamCoils(16);
                    Thread.Sleep(10);

                    if (coilsStatusAdam1[0] == true && coilsStatusAdam1Previous[0] == false)
                    {

                        GlobalVariables.SaveImageCam7ArFrontL = true;
                    }

                    switch (coilsStatusAdam1)
                    {
                        //case:
                        //    //if ()
                        //    //{
                        //    //    ProducerCam7ArFrontLCam8ArFrontR.GrabImageStartSignal();
                        //    //}
                        //    break;
                    }
                    switch (coilsStatusAdam2)
                    {
                        //case:
                        //    //if ()
                        //    //{
                        //    //    ProducerCam7ArFrontLCam8ArFrontR.GrabImageStartSignal();
                        //    //}
                        //    break;
                    }


                    coilsStatusAdam1Previous = coilsStatusAdam1;
                    coilsStatusAdam2Previous = coilsStatusAdam2;
                }

            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
