using Advantech.Adam;
using HalconDotNet;
using Ikea_Library;
using Ikea_Library.DataGridTables;
using Ikea_Library.DBAccess;
using Ikea_Library.Events;
using Ikea_Library.HdevProcedures;
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
using System.Windows;
using System.Windows.Forms;

namespace IkeaUI
{
    public partial class MainForm : Form
    {
        private MainProgramProcedures MainProcedures;
        private DrawingVariables DrawingVariables;
        private RecipeVariables RecipeVariables;

        ResultsForWriting Results = new ResultsForWriting();
        List<List<HTuple>> ResultToWrite = new List<List<HTuple>>();
        private int TotalCamPairsRunning = 0;

        Material Plank;

        public ProducerDouble ProducerCam1LsTopLCam2LsTopR;
        public ConsumerDouble ConsumerCam1LsTopLCam2LsTopR;

        public ProducerDouble ProducerCam3LsBottomLCam4LsBottomR;
        public ConsumerDouble ConsumerCam3LsBottomLCam4LsBottomR;

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

        private bool IsAdministratorLoggedIn = false;
        private string CurrentAdministrator = "";

        public MainForm()
        {
            InitializeComponent();

            MainProcedures = new MainProgramProcedures();

            SqliteDataAccess.IsAvailable();

            timer_Clock.Enabled = true;
            timer_Clock.Start();
            timer_DiscsCheck.Enabled = true;
            timer_DiscsCheck.Start();
            timer_CameraPing.Enabled = true;
            timer_CameraPing.Start();
            timer_AdamCoilsRead.Enabled = true;
            timer_AdamCoilsRead.Start();
            Adam1 = new DeviceManager("192.168.200.21");// 6250 7in 8 out
            Adam2 = new DeviceManager("192.168.200.22");// 6256 16 outs
            timer_checkDrawings.Enabled = true;
            timer_checkDrawings.Start();

            progressBar_MainPodozrive.Maximum = 5;
            progressBar_MainPodozrive.Minimum = 0;
            progressBar_MainPodozrive.Visible = true;
            progressBar_MainPodozrive.Step = 1;
            progressBar_MainPodozrive.Style = ProgressBarStyle.Blocks;

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
                var x = e.Bounds.Left + 50;
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
                Console.WriteLine("{ 0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                Loging.MakeLog(DateTime.Now, ex.Message, "|Error|");
            }
        }

        public void DisplayingHolesOnImage(HSmartWindowControl hWindow, HTuple measurementResults, HObject drawingSideCircles, HTuple xValues, HTuple yValues, HTuple diameterValues)
        {
            for (int i = 0; i < drawingSideCircles.CountObj(); i++)
            {
                HOperatorSet.GenCircle(out HObject circle, yValues[i] * 10, xValues[i] * 10, (diameterValues[i] * 30));
                hWindow.HalconWindow.SetDraw("margin");
                hWindow.HalconWindow.SetLineWidth(2);

                if (measurementResults[i] == 0)
                {
                    hWindow.HalconWindow.SetColor("red");
                    hWindow.HalconWindow.DispObj(circle);
                }

                else
                {
                    hWindow.HalconWindow.SetColor("green");
                    hWindow.HalconWindow.DispObj(circle);
                }
            }


        }


        private void Consumer_ResultsReady(object sender, ResultsForWritingReadyEventArgs e)
        {
            try
            {
                string timeStamp = DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");

                Plank = new Material(timeStamp, DrawingVariables.H_strDxfName.S.Replace(".DXF", ""));//remove to newPlank event;
                Plank.DrawingSides = new List<DrawingSide>();

                switch (e.CamNames.S)
                {
                    case "Cam1LsTopL_Cam2LsTopR":
                        break;

                    case "Cam3LsBottomL_Cam4LsBottomR":
                        DrawingSide drawingSide = new DrawingSide("Bottom", timeStamp);
                        drawingSide.ImagePath = e.ImgSavePath;

                        for (int i = 0; i < e.DiameterValues.Length; i++)
                        {
                            Hole hole = new Hole(timeStamp, e.XValues[i], e.YValues[i], e.DiameterValues[i], e.MeasurementResult[i]);
                            drawingSide.HolesList.Add(hole);
                        }

                        Plank.DrawingSides.Add(drawingSide);
                        Results.ResultsBottom = new List<HTuple> { e.XValues, e.YValues, e.DiameterValues };

                        ResultToWrite.Add(Results.ResultsBottom);
                        //DisplayingHolesOnImage(Hwindow_LowerSide, e.MeasurementResult, DrawingVariables.CirclesInRegionBottom, e.XValues, e.YValues, e.DiameterValues);

                        break;

                    case "Cam5LsLeft":

                        break;

                    case "Cam6LsRight":
                        break;

                    case "Cam7ArFrontL_Cam8ArFrontR":

                        break;

                    case "Cam9ArBackL_Cam10ArBackR":
                        break;
                }

                if (ResultToWrite.Count() == TotalCamPairsRunning)
                {
                    MainProcedures.WriteResultsFunc(DrawingVariables.H_strDxfName, DrawingVariables.RealRecipeThickessOfBoardMm, DrawingVariables.RealRecipeLengthOfBoardMm, DrawingVariables.RealRecipeWitdhOfBoardMm,
                        DrawingVariables.Real_arrXPositionMmRightFromDrawing, DrawingVariables.Real_arrYPositionMmRightFromDrawing, DrawingVariables.Real_arrDiameterMmRightFromDrawing, DrawingVariables.Real_arrXPositionMmFrontFromDrawing,
                        DrawingVariables.Real_arrYPositionMmFrontFromDrawing, DrawingVariables.Real_arrDiameterMmFrontFromDrawing, DrawingVariables.Real_arrXPositionMmBottomFromDrawing,
                        DrawingVariables.Real_arrYPositionMmBottomFromDrawing, DrawingVariables.Real_arrDiameterMmBottomFromDrawing, DrawingVariables.Real_arrXPositionMmBackFromDrawing,
                        DrawingVariables.Real_arrYPositionMmBackFromDrawing, DrawingVariables.Real_arrDiameterMmBackFromDrawing, DrawingVariables.Real_arrXPositionMmTopFromDrawing,
                        DrawingVariables.Real_arrYPositionMmTopFromDrawing, DrawingVariables.Real_arrDiameterMmTopFromDrawing, DrawingVariables.Real_arrXPositionMmLeftFromDrawing,
                        DrawingVariables.Real_arrYPositionMmLeftFromDrawing, DrawingVariables.Real_arrDiameterMmLeftFromDrawing, Results.ResultsRight[0], Results.ResultsRight[1],
                        Results.ResultsRight[2], Results.ResultsFront[0], Results.ResultsFront[1], Results.ResultsFront[2], Results.ResultsBottom[0], Results.ResultsBottom[1],
                        Results.ResultsBottom[2], Results.ResultsBack[0], Results.ResultsBack[1], Results.ResultsBack[2], Results.ResultsTop[0], Results.ResultsTop[1],
                        Results.ResultsTop[2], Results.ResultsLeft[0], Results.ResultsLeft[1], Results.ResultsLeft[2], RecipeVariables.RecipeTolerancePosition, RecipeVariables.RecipeToleranceDiameter,
                        out HTuple exception);

                    ResultEvaluation resultEvaluation = new ResultEvaluation();

                    Plank.Status = resultEvaluation.ResultEvaluationFunc(Plank, RecipeVariables, DrawingVariables);
                    bool insertingToDatabaseStatus = DBFunctions.InsterMeasurement(Plank);

                    if (Plank.Status == false)
                    {

                        UpdateUI.UpdateProgressiveBar(progressBar_MainPodozrive, "step");
                        if (progressBar_MainPodozrive.Value == 5)
                        {
                            UpdateUI.UpdateProgressiveBar(progressBar_MainPodozrive, "reset");
                            Console.WriteLine("STOP LINKA");
                        }
                    }
                    else if (Plank.Status == true)
                    {
                        UpdateUI.UpdateProgressiveBar(progressBar_MainPodozrive, "reset");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void Producer_NewPlankSignalFunc(object sender, NewPlankEventArgs e)
        {
            ResultToWrite = new List<List<HTuple>>();
            Plank = new Material(DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss"), e.Name);
            Plank.DrawingSides = new List<DrawingSide>();

        }

        private void Cunsumer_TileImages(object sender, TileImageReadyEventArgs e)
        {

            switch (e.CamNames)
            {
                case "Cam1LsTopL_Cam2LsTopR":
                    HObject tile1_2 = e.TileImageCam1_2;
                    Hwindow_UpperSide.HalconWindow.DispObj(tile1_2);
                    Hwindow_UpperSide.HalconWindow.SetPart(0, 0, -1, -1);
                    break;


                case "Cam3LsBottomL_Cam4LsBottomR":
                    HObject tile3_4 = e.TileImageCam3_4;
                    Hwindow_LowerSide.HalconWindow.DispObj(tile3_4);
                    Hwindow_LowerSide.HalconWindow.SetPart(0, 0, -1, -1);
                    break;


                case "Cam5LsLeft":
                    HObject tile5 = e.TileImageCam5;
                    Hwindow_LeftSide.HalconWindow.DispObj(tile5);
                    Hwindow_LeftSide.HalconWindow.SetPart(0, 0, -1, -1);

                    break;

                case "Cam6LsRight":
                    HObject tile6 = e.TileImageCam6;
                    Hwindow_RightSide.HalconWindow.DispObj(tile6);
                    Hwindow_RightSide.HalconWindow.SetPart(0, 0, -1, -1);
                    break;

                case "Cam7ArFrontL_Cam8ArFrontR":
                    HObject tile7_8 = e.TileImageCam7_8;
                    Hwindow_FrontSide.HalconWindow.DispObj(tile7_8);
                    Hwindow_FrontSide.HalconWindow.SetPart(0, 0, -1, -1);

                    break;

                case "Cam9ArBackL_Cam10ArBackR":
                    HObject tile9_10 = e.TileImageCam9_10;
                    Hwindow_BackSide.HalconWindow.DispObj(tile9_10);
                    Hwindow_BackSide.HalconWindow.SetPart(0, 0, -1, -1);
                    break;
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
            Hwindow_ArchiveImage.HalconWindow.SetPart(0, 0, -1, -1);
            Hwindow_ArchiveImage.HalconWindow.SetDraw("margin");
            Hwindow_ArchiveImage.HalconWindow.SetLineWidth(2);
            try
            {
                for (int i = 0; i < holes.Count; i++)
                {
                    HOperatorSet.GenCircleContourXld(out HObject circle, holes[i].X * 10, holes[i].Y * 10, holes[i].Diameter * 2 * 25, 0, Math.PI * 2, "positive", 1);

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
            catch
            {

            }
        }



        private void timer_Clock_Tick(object sender, EventArgs e)
        {
            label_Clock.Text = DateTime.Now.ToString();

        }

        private void timer_DiscsCheck_Tick(object sender, EventArgs e)
        {
            string availableSpaceDiscD = DiscManagement.CheckDiscs(GlobalVariables.DiscManagementGigabytes, GlobalVariables.ImagesDiscD).ToString();
            UpdateUI.UpdateLabelText(label_AvailableSpaceC, availableSpaceDiscD + " GB");
        }

        private void button_ExitApp_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProducerCam1LsTopLCam2LsTopR != null)
                {
                    ProducerCam1LsTopLCam2LsTopR.AbortThread();
                }

                if (ProducerCam3LsBottomLCam4LsBottomR != null)
                {
                    ProducerCam3LsBottomLCam4LsBottomR.AbortThread();
                }

                if (ProducerCam5LsLeftCam6LsRight != null)
                {
                    ProducerCam5LsLeftCam6LsRight.AbortThread();
                }

                if (ProducerCam7ArFrontLCam8ArFrontR != null)
                {
                    ProducerCam7ArFrontLCam8ArFrontR.AbortThread();
                }

                if (ProducerCam9ArBackLCam10ArBackR != null)
                {
                    ProducerCam9ArBackLCam10ArBackR.AbortThread();
                }

                if (ProducerCam11ArTopLCam12ArTopR != null)
                {
                    ProducerCam11ArTopLCam12ArTopR.AbortThread();
                }

                if (ProducerCam13ArBottomLCam14ArBottomR != null)
                {
                    ProducerCam13ArBottomLCam14ArBottomR.AbortThread();
                }

                Application.Exit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{ 0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                Loging.MakeLog(DateTime.Now, ex.Message, "|Error|");
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
            catch (Exception ex)
            {
                Console.WriteLine("{ 0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                Loging.MakeLog(DateTime.Now, ex.Message, "|Error|");
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
                Console.WriteLine("{ 0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                Loging.MakeLog(DateTime.Now, ex.Message, "|Error|");
            }
        }

        private void listBox_MainRecipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedItem;
                if (listBox_MainRecipe.SelectedItem == null)
                {
                    return;
                }
                else
                {
                    selectedItem = listBox_MainRecipe.SelectedItem.ToString();
                    string recipeName = selectedItem.Replace(".DXF", ".txt");

                    ReadDrawing(selectedItem);
                    ReadRecipe(selectedItem);

                    CameraDefaultSettings.SetAllCamerasDefaultSettingsFromFile(GlobalVariables.SetCamParameteresPFSFilePathProcedure, DrawingVariables);

                    Loging.MakeLog(DateTime.Now, $"Vybrany novy recept {recipeName}", "|OK|");
                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"New recipe {recipeName} is selected", "|OK|");
                }


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
                   out HTuple h_realToleranceThicknessPlusMinusMm,
                   out HTuple h_realToleranceLengthPlusMinusMm,
                   out HTuple h_realToleranceWidthPlusMinusMm,
                   out HTuple Exception);

                if (RecipeVariables != null)
                {
                    textBox_MainToleranceDiameter.Text = RecipeVariables.RecipeToleranceDiameter;
                    textBox_MainTolerancePosition.Text = RecipeVariables.RecipeTolerancePosition;
                    textBox_MainMaxPosErrors.Text = RecipeVariables.RecipeMaxPositionError;
                    textBox_MainMaxDiameterErrors.Text = RecipeVariables.RecipeMaxDiameterError;
                    textBox_ToleranceThickness.Text = RecipeVariables.ToleranceThickness;
                    textBox_ToleranceLength.Text = RecipeVariables.ToleranceLength;
                    textBox_ToleranceWidth.Text = RecipeVariables.ToleranceWidth;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("{ 0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                Loging.MakeLog(DateTime.Now, ex.Message, "|Error|");
            }

        }
        private void ReadDrawing(string recipeDrawingName)
        {
            try
            {
                Hwindow_Diagnostika.HalconWindow.ClearWindow();

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
                        out HTuple h_strDxfName,
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
                Console.WriteLine("{ 0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message.ToString(), "|Error|");
                Loging.MakeLog(DateTime.Now, ex.Message, "|Error|");
            }
        }

        private void button_MainStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (DrawingVariables != null)
                {
                    button_MainStart.Enabled = false;
                    button_DiagnosticsExposureTimeAndGainSet.Enabled = false;

                    //ConsumerCam1LsTopLCam2LsTopR = new ConsumerDouble("Cam1LsTopL", "Cam2LsTopR", DrawingVariables, RecipeVariables);
                    //ConsumerCam1LsTopLCam2LsTopR.TileImageReady += Cunsumer_TileImages;
                    //ConsumerCam1LsTopLCam2LsTopR.ResultsForWritingReady += Consumer_ResultsReady;
                    //ConsumerCam1LsTopLCam2LsTopR.Start();
                    //TotalCamPairsRunning++;

                    //ProducerCam1LsTopLCam2LsTopR = new ProducerDouble("Cam1LsTopL", "Cam2LsTopR", ConsumerCam1LsTopLCam2LsTopR, DrawingVariables);
                    //ProducerCam1LsTopLCam2LsTopR.Start();

                    ////if (DrawingVariables.Real_arrXPositionMmTopFromDrawing.Length > 0)
                    ////{
                    //TotalCamsRunning++;
                    ///
                    //ConsumerCam11ArTopLCam12ArTopR = new ConsumerDouble("Cam11ArTopL", "Cam12ArTopR", DrawingVariables, RecipeVariables);
                    //ConsumerCam11ArTopLCam12ArTopR.TileImageReady += Cunsumer_TileImages;
                    //ConsumerCam11ArTopLCam12ArTopR.ResultsForWritingReady += Consumer_ResultsReady;
                    //ConsumerCam11ArTopLCam12ArTopR.Start();

                    //ProducerCam11ArTopLCam12ArTopR = new ProducerDouble("Cam11ArTopL", "Cam12ArTopR", ConsumerCam11ArTopLCam12ArTopR, DrawingVariables.IntSurfaceTypeFromDrawing);
                    //ProducerCam11ArTopLCam12ArTopR.Start();
                    //}

                    //if (DrawingVariables.Real_arrXPositionMmBottomFromDrawing.Length > 0)
                    //{

                    TotalCamPairsRunning++;
                    ConsumerCam3LsBottomLCam4LsBottomR = new ConsumerDouble("Cam3LsBottomL", "Cam4LsBottomR", DrawingVariables, RecipeVariables);
                    ConsumerCam3LsBottomLCam4LsBottomR.TileImageReady += Cunsumer_TileImages;
                    ConsumerCam3LsBottomLCam4LsBottomR.ResultsForWritingReady += Consumer_ResultsReady;
                    ConsumerCam3LsBottomLCam4LsBottomR.Start();

                    ProducerCam3LsBottomLCam4LsBottomR = new ProducerDouble("Cam3LsBottomL", "Cam4LsBottomR", ConsumerCam3LsBottomLCam4LsBottomR, DrawingVariables);
                    ProducerCam3LsBottomLCam4LsBottomR.NewPlankEvent += Producer_NewPlankSignalFunc;
                    ProducerCam3LsBottomLCam4LsBottomR.Start();

                    //TotalCamsRunning++;

                    //ConsumerCam13ArBottomLCam14ArBottomR = new ConsumerDouble("Cam13ArBottomL", "Cam14ArBottomR", DrawingVariables, RecipeVariables);
                    //ConsumerCam13ArBottomLCam14ArBottomR.TileImageReady += Cunsumer_TileImages;
                    //ConsumerCam13ArBottomLCam14ArBottomR.ResultsForWritingReady += Consumer_ResultsReady;

                    //ConsumerCam13ArBottomLCam14ArBottomR.Start();

                    //ProducerCam13ArBottomLCam14ArBottomR = new ProducerDouble("Cam13ArBottomL", "Cam14ArBottomR", ConsumerCam13ArBottomLCam14ArBottomR, DrawingVariables.IntSurfaceTypeFromDrawing);
                    //ProducerCam13ArBottomLCam14ArBottomR.Start();
                    //////}


                    //////if (DrawingVariables.Real_arrXPositionMmLeftFromDrawing.Length > 0 || DrawingVariables.Real_arrXPositionMmRightFromDrawing.Length > 0)
                    //////{
                    //TotalCamPairsRunning++;
                    //ConsumerCam5LsLeftCam6LsRight = new ConsumerDouble("Cam5LsLeft", "Cam6LsRight", DrawingVariables, RecipeVariables);
                    //ConsumerCam5LsLeftCam6LsRight.TileImageReady += Cunsumer_TileImages;
                    //ConsumerCam5LsLeftCam6LsRight.ResultsForWritingReady += Consumer_ResultsReady;

                    //ConsumerCam5LsLeftCam6LsRight.Start();

                    //ProducerCam5LsLeftCam6LsRight = new ProducerDouble("Cam5LsLeft", "Cam6LsRight", ConsumerCam5LsLeftCam6LsRight, DrawingVariables);
                    //ProducerCam5LsLeftCam6LsRight.Start();
                    //////}


                    //////if (DrawingVariables.Real_arrXPositionMmFrontFromDrawing.Length > 0)
                    ////////{
                    //TotalCamPairsRunning++;
                    //ConsumerCam7ArFrontLCam8ArFrontR = new ConsumerDouble("Cam7ArFrontL", "Cam8ArFrontR", DrawingVariables, RecipeVariables);
                    //ConsumerCam7ArFrontLCam8ArFrontR.TileImageReady += Cunsumer_TileImages;
                    //ConsumerCam7ArFrontLCam8ArFrontR.ResultsForWritingReady += Consumer_ResultsReady;
                    //ConsumerCam7ArFrontLCam8ArFrontR.Start();

                    //ProducerCam7ArFrontLCam8ArFrontR = new ProducerDouble("Cam7ArFrontL", "Cam8ArFrontR", ConsumerCam7ArFrontLCam8ArFrontR, DrawingVariables);
                    //ProducerCam7ArFrontLCam8ArFrontR.Start();
                    ////////}

                    ////////if (DrawingVariables.Real_arrXPositionMmBackFromDrawing.Length > 0)
                    ////////{
                    //TotalCamPairsRunning++;

                    //ConsumerCam9ArBackLCam10ArBackR = new ConsumerDouble("Cam9ArBackL", "Cam10ArBackR", DrawingVariables, RecipeVariables);
                    //ConsumerCam9ArBackLCam10ArBackR.TileImageReady += Cunsumer_TileImages;
                    //ConsumerCam9ArBackLCam10ArBackR.ResultsForWritingReady += Consumer_ResultsReady;

                    //ConsumerCam9ArBackLCam10ArBackR.Start();

                    //ProducerCam9ArBackLCam10ArBackR = new ProducerDouble("Cam9ArBackL", "Cam10ArBackR", ConsumerCam9ArBackLCam10ArBackR, DrawingVariables);
                    //ProducerCam9ArBackLCam10ArBackR.Start();
                    ////}

                    Loging.MakeLog(DateTime.Now, "Vision Process Start", "|OK|");
                }
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
                    string cameraPfsFileName = listBox_DiagnosticsCamerasSettings.SelectedItem.ToString() + "_" + DrawingVariables.IntSurfaceTypeFromDrawing + ".pfs";
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
                button_DiagnosticsExposureTimeAndGainSet.Enabled = true;

                try
                {
                    if (ConsumerCam1LsTopLCam2LsTopR != null)
                    {
                        ConsumerCam1LsTopLCam2LsTopR.TileImageReady -= Cunsumer_TileImages;
                        ConsumerCam1LsTopLCam2LsTopR.ResultsForWritingReady -= Consumer_ResultsReady;
                        ProducerCam1LsTopLCam2LsTopR.AbortThread();
                        ConsumerCam1LsTopLCam2LsTopR.AbortThread();
                        TotalCamPairsRunning--;
                    }
                    if (ConsumerCam3LsBottomLCam4LsBottomR != null)
                    {
                        ConsumerCam3LsBottomLCam4LsBottomR.TileImageReady -= Cunsumer_TileImages;
                        ConsumerCam3LsBottomLCam4LsBottomR.ResultsForWritingReady -= Consumer_ResultsReady;
                        ProducerCam3LsBottomLCam4LsBottomR.AbortThread();
                        ConsumerCam3LsBottomLCam4LsBottomR.AbortThread();
                        TotalCamPairsRunning--;

                    }
                    if (ConsumerCam5LsLeftCam6LsRight != null)
                    {
                        ConsumerCam5LsLeftCam6LsRight.TileImageReady -= Cunsumer_TileImages;
                        ConsumerCam5LsLeftCam6LsRight.ResultsForWritingReady -= Consumer_ResultsReady;
                        ProducerCam5LsLeftCam6LsRight.AbortThread();
                        ConsumerCam5LsLeftCam6LsRight.AbortThread();
                        TotalCamPairsRunning--;

                    }

                    if (ConsumerCam7ArFrontLCam8ArFrontR != null)
                    {
                        ConsumerCam7ArFrontLCam8ArFrontR.TileImageReady -= Cunsumer_TileImages;
                        ConsumerCam7ArFrontLCam8ArFrontR.ResultsForWritingReady -= Consumer_ResultsReady;
                        ProducerCam7ArFrontLCam8ArFrontR.AbortThread();
                        ConsumerCam7ArFrontLCam8ArFrontR.AbortThread();
                        TotalCamPairsRunning--;

                    }
                    if (ConsumerCam9ArBackLCam10ArBackR != null)
                    {
                        ConsumerCam9ArBackLCam10ArBackR.TileImageReady -= Cunsumer_TileImages;
                        ConsumerCam9ArBackLCam10ArBackR.ResultsForWritingReady -= Consumer_ResultsReady;
                        ProducerCam9ArBackLCam10ArBackR.AbortThread();
                        ConsumerCam9ArBackLCam10ArBackR.AbortThread();
                        TotalCamPairsRunning--;

                    }
                    if (ConsumerCam11ArTopLCam12ArTopR != null)
                    {
                        ConsumerCam11ArTopLCam12ArTopR.TileImageReady -= Cunsumer_TileImages;
                        ConsumerCam11ArTopLCam12ArTopR.ResultsForWritingReady -= Consumer_ResultsReady;
                        ProducerCam11ArTopLCam12ArTopR.AbortThread();
                        ConsumerCam11ArTopLCam12ArTopR.AbortThread();
                        TotalCamPairsRunning--;

                    }
                    if (ConsumerCam13ArBottomLCam14ArBottomR != null)
                    {
                        ConsumerCam13ArBottomLCam14ArBottomR.TileImageReady -= Cunsumer_TileImages;
                        ConsumerCam13ArBottomLCam14ArBottomR.ResultsForWritingReady -= Consumer_ResultsReady;
                        ProducerCam13ArBottomLCam14ArBottomR.AbortThread();
                        ConsumerCam13ArBottomLCam14ArBottomR.AbortThread();
                        TotalCamPairsRunning--;

                    }
                    button_MainStart.Enabled = true;
                    Console.WriteLine("Total Cams running = " + TotalCamPairsRunning);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                    Loging.MakeLog(DateTime.Now, "Main Stop", "|Error|");
                }

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
                Console.WriteLine("{ 0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                Loging.MakeLog(DateTime.Now, ex.Message, "|Error|");
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
                Console.WriteLine("{ 0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                Loging.MakeLog(DateTime.Now, ex.Message, "|Error|");
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
                Console.WriteLine("{ 0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                Loging.MakeLog(DateTime.Now, ex.Message, "|Error|");
            }
        }

        private void timer_AdamCoilsRead_Tick(object sender, EventArgs e)
        {
            if (label_AccessLevel.Text == "Administrator")
            {
                AdamButtonsAccess(true);
            }
            else
            {
                AdamButtonsAccess(false);
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
                Console.WriteLine("{ 0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                Loging.MakeLog(DateTime.Now, ex.Message, "|Error|");
            }
        }

        private void AdamButtonsAccess(bool status)
        {

            foreach (Control c in groupBox_DiagnosticsOutputs.Controls)
            {
                if (c.Name.Contains("button"))
                {
                    Button btn = (Button)c;
                    btn.Enabled = status;
                }
            }
            foreach (Control c in groupBox_DiagnosticsVstupy.Controls)
            {
                if (c.Name.Contains("button"))
                {
                    Button btn = (Button)c;
                    btn.Enabled = status;
                }
            }
        }


        private void button_MainSaveImg_Click(object sender, EventArgs e)
        {
            HOperatorSet.GenEmptyObj(out HObject image);
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
                Console.WriteLine("{ 0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                Loging.MakeLog(DateTime.Now, ex.Message, "|Error|");
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
            List<string> allRecipes = Directory.EnumerateFiles(GlobalVariables.DrawingsPath, "*.DXF", SearchOption.TopDirectoryOnly).Where(s => s.Contains(text)).ToList();
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


        private void button_MainChangeRecipeValues_Click(object sender, EventArgs e)
        {
            try
            {
                string recipeName = listBox_MainRecipe.SelectedItem.ToString().Replace(".DXF", ".txt");
                string tolerPos = textBox_MainTolerancePosition.Text;
                string tolerDiameter = textBox_MainToleranceDiameter.Text;
                string maxPosErrors = textBox_MainMaxPosErrors.Text;
                string maxDiameterErrors = textBox_MainMaxDiameterErrors.Text;
                string tolerThickness = textBox_ToleranceThickness.Text;
                string tolerWidth = textBox_ToleranceWidth.Text;
                string tolerLength = textBox_ToleranceLength.Text;

                tolerPos = tolerPos.Contains(',') ? tolerPos.Replace(',', '.') : tolerPos;
                tolerDiameter = tolerDiameter.Contains(',') ? tolerDiameter.Replace(',', '.') : tolerDiameter;
                maxPosErrors = maxPosErrors.Contains(',') ? maxPosErrors.Replace(',', '.') : maxPosErrors;
                maxDiameterErrors = maxDiameterErrors.Contains(',') ? maxDiameterErrors.Replace(',', '.') : maxDiameterErrors;
                tolerThickness = tolerThickness.Contains(',') ? tolerThickness.Replace(',', '.') : tolerThickness;
                tolerWidth = tolerWidth.Contains(',') ? tolerWidth.Replace(',', '.') : tolerWidth;
                tolerLength = tolerLength.Contains(',') ? tolerLength.Replace(',', '.') : tolerLength;


                if ((double.TryParse(tolerPos, out double res1) == true || string.IsNullOrEmpty(tolerPos) == true)
                    && (double.TryParse(tolerDiameter, out double res2) == true || string.IsNullOrEmpty(tolerDiameter) == true)
                    && (double.TryParse(maxPosErrors, out double res3) == true || string.IsNullOrEmpty(maxPosErrors) == true)
                    && (double.TryParse(maxDiameterErrors, out double res4) == true || string.IsNullOrEmpty(maxDiameterErrors) == true)
                    && (double.TryParse(tolerThickness, out double res5) == true || string.IsNullOrEmpty(tolerThickness) == true)
                    && (double.TryParse(tolerWidth, out double res6) == true || string.IsNullOrEmpty(tolerWidth) == true)
                    && (double.TryParse(tolerLength, out double res7) == true || string.IsNullOrEmpty(tolerLength) == true))

                {
                    MainProcedures.Function_RecipeWriter(recipeName, res1, res2, res3, res4, res5, res6, res7, out HTuple h_mix_arrException);
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
                    textBox_ToleranceThickness.Text = RecipeVariables.ToleranceThickness;
                    textBox_ToleranceWidth.Text = RecipeVariables.ToleranceWidth;
                    textBox_ToleranceLength.Text = RecipeVariables.ToleranceLength;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{ 0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                Loging.MakeLog(DateTime.Now, ex.Message, "|Error|");
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

                MainProcedures.Function_PfsParametersModify(DrawingVariables.IntSurfaceTypeFromDrawing, camName, exposureTimeValue, gainValue, out HTuple h_mix_arrException);

                if (h_mix_arrException.Length < 1)
                {
                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"Changed Exposure time and gain for {camName} to {exposureTimeValue} and {gainValue} ", "|OK|");
                    Loging.MakeLog(DateTime.Now, $"Changed Exposure time and gain for {camName} to {exposureTimeValue} and {gainValue} ", "|OK|");
                }
                CameraDefaultSettings.SetoneCameraDefaultSettingsFromFile(GlobalVariables.SetCamParameteresPFSFilePathProcedure, camName, DrawingVariables);
            }

            catch (Exception ex)
            {
                Console.WriteLine("{ 0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                Loging.MakeLog(DateTime.Now, ex.Message, "|Error|");
            }
        }

        private void timer_checkDrawings_Tick(object sender, EventArgs e)
        {
            DirectoryInfo dirWithDrawings = new DirectoryInfo(GlobalVariables.DrawingsPath);
            FileInfo[] files = dirWithDrawings.GetFiles("*");
            DirectoryInfo dirWithCamParams = new DirectoryInfo(GlobalVariables.CamPfsFilesPath);
            FileInfo[] allPFS = dirWithCamParams.GetFiles("*");
            FileInfo[] defaultPFS = dirWithCamParams.GetFiles("*default*");
            DirectoryInfo dirWithRecipes = new DirectoryInfo(GlobalVariables.RecipesPath);
            FileInfo[] recipes = dirWithRecipes.GetFiles("*");

            foreach (FileInfo file in files)
            {
                string filename = file.Name;

                if (filename.Length >= 12)
                {
                    if (filename.Contains(" ") == true)
                    {
                        filename = filename.Replace(" ", "_");
                        if (File.Exists(GlobalVariables.DrawingsPath + "\\" + filename) == false)
                        {
                            File.Copy(file.FullName, GlobalVariables.DrawingsPath + "\\" + filename);
                            File.Delete(file.FullName);
                        }

                    }

                    for (int i = 0; i < defaultPFS.Length; i++)
                    {
                        string pfsFileName = defaultPFS[i].Name.Replace("default", $"_{filename.Substring(5, 3)}");

                        if (File.Exists(GlobalVariables.CamPfsFilesPath + "\\" + pfsFileName) == false)
                        {
                            File.Copy(GlobalVariables.CamPfsFilesPath + "\\" + $"{defaultPFS[i]}", GlobalVariables.CamPfsFilesPath + "\\" + pfsFileName);
                        }

                    }

                    if (filename != null)
                    {
                        for (int i = 0; i < recipes.Length; i++)
                        {
                            string newRecipeName = filename.Replace(".DXF", ".txt");

                            if (File.Exists(GlobalVariables.RecipesPath + "\\" + newRecipeName) == false)
                            {
                                File.Copy(GlobalVariables.RecipesPath + "\\" + "Default.txt", GlobalVariables.RecipesPath + "\\" + newRecipeName);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine(filename.Length);
                }
            }

        }
    }
}

