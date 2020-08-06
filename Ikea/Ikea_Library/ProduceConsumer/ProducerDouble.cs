using HalconDotNet;
using Ikea_Library.Events;
using Ikea_Library.HdevProcedures;
using Ikea_Library.Helpers;
using Ikea_Library.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advantech.Adam;
using System.Net.Sockets;

namespace Ikea_Library.ProduceConsumer
{
    public class ProducerDouble
    {
        public event EventHandler<bool> TileImageLineScan;

        private string CamName1 { get; set; }
        private string CamName2 { get; set; }
        private string CamNames { get; set; }

        private AdamSocket Adam1;

        private HTuple AcqHandleCam1;
        private HTuple AcqHandleCam2;
        private bool Run;
        private Thread ProducerThread;
        public CamProcedures CamProcedures;
        private CameraState CameraState;
        private ConsumerDouble Consumer;

        private Message MessageCam1;
        private Message MessageCam2;

        HTuple IntSurfaceTypeFromDrawing;

        int Gain1 = 0;
        int ExposureTime1 = 0;

        int Gain2 = 0;
        int ExposureTime2 = 0;




        public ProducerDouble(string camName1, string camName2, ConsumerDouble consumer, HTuple intSurface)
        {
            CamName1 = camName1;
            CamName2 = camName2;
            CamNames = CamName1 + "_" + CamName2;
            Consumer = consumer;
            IntSurfaceTypeFromDrawing = intSurface;
        }

        private bool Initialize()
        {
            try
            {
                CamProcedures = new CamProcedures(GlobalVariables.CameraProcedures);
                return true;
            }
            catch (Exception ex)
            {
                Run = false;
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");

                return false;
            }
        }

        private void MainFunction()
        {

            bool grabingDone = false;

            while (Run == true)
            {
                switch (CameraState)
                {
                    case CameraState.Initialization:

                        try
                        {
                            if (Initialize() == true)
                            {
                                AcqHandleCam1 = new HTuple(-1);
                                AcqHandleCam2 = new HTuple(-1);

                                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"Initialization {CamName1} {CamName2}", "|OK|");
                                CameraState = CameraState.ConnectCamera;
                            }
                            else
                            {

                            }
                        }

                        catch (Exception ex)
                        {
                            CameraState = CameraState.Exception;
                            Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                        }

                        break;

                    case CameraState.ConnectCamera:

                        try
                        {

                            switch (CamNames)
                            {
                                case "Cam1LsTopL_Cam2LsTopR":
                                    CamProcedures.OpenFramegrabber(CamName1, out AcqHandleCam1);
                                    CamProcedures.OpenFramegrabber(CamName2, out AcqHandleCam2);

                                    HOperatorSet.GrabImageStart(AcqHandleCam1, (-1));
                                    HOperatorSet.GrabImageStart(AcqHandleCam2, (-1));

                                    MessageCam1 = new Message();
                                    MessageCam2 = new Message();
                                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"{CamName1} Camera is connected", "|OK|");
                                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"{CamName2} Camera is connected", "|OK|");

                                    break;

                                //Cam3LsBottomL
                                case "Cam3LsBottomL_Cam4LsBottomR":
                                    CamProcedures.OpenFramegrabber(CamName1, out AcqHandleCam1);
                                    CamProcedures.OpenFramegrabber(CamName2, out AcqHandleCam2);

                                    HOperatorSet.GrabImageStart(AcqHandleCam1, (-1));
                                    HOperatorSet.GrabImageStart(AcqHandleCam2, (-1));

                                    MessageCam1 = new Message();
                                    MessageCam2 = new Message();

                                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"{CamName1} Camera is connected", "|OK|");
                                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"{CamName2} Camera is connected", "|OK|");
                                    break;

                                case "Cam5LsLeft_Cam6LsRight":

                                    CamProcedures.OpenFramegrabber(CamName1, out AcqHandleCam1);
                                    CamProcedures.OpenFramegrabber(CamName2, out AcqHandleCam2);

                                    HOperatorSet.GrabImageStart(AcqHandleCam1, (-1));
                                    HOperatorSet.GrabImageStart(AcqHandleCam2, (-1));

                                    MessageCam1 = new Message();
                                    MessageCam2 = new Message();

                                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"{CamName1} Camera is connected", "|OK|");
                                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"{CamName2} Camera is connected", "|OK|");
                                    break;

                                case "Cam7ArFrontL_Cam8ArFrontR":

                                    CamProcedures.OpenFramegrabber(CamName1, out AcqHandleCam1);
                                    CamProcedures.OpenFramegrabber(CamName2, out AcqHandleCam2);
                                    HOperatorSet.GrabImageStart(AcqHandleCam1, (-1));
                                    HOperatorSet.GrabImageStart(AcqHandleCam2, (-1));
                                    MessageCam1 = new Message();
                                    MessageCam2 = new Message();
                                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"{CamName1} Camera is connected", "|OK|");
                                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"{CamName2} Camera is connected", "|OK|");
                                    break;

                                case "Cam9ArBackL_Cam10ArBackR":
                                    CamProcedures.OpenFramegrabber(CamName1, out AcqHandleCam1);
                                    CamProcedures.OpenFramegrabber(CamName2, out AcqHandleCam2);
                                    HOperatorSet.GrabImageStart(AcqHandleCam1, (-1));
                                    HOperatorSet.GrabImageStart(AcqHandleCam2, (-1));
                                    MessageCam1 = new Message();
                                    MessageCam2 = new Message();
                                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"{CamName1} Camera is connected", "|OK|");
                                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"{CamName2} Camera is connected", "|OK|");
                                    break;

                                case "Cam11ArTopL_Cam12ArTopR":
                                    Adam1 = new AdamSocket();
                                    Adam1.Connect("192.168.200.21", ProtocolType.Tcp, 502);

                                    CamProcedures.OpenFramegrabber(CamName1, out AcqHandleCam1);
                                    CamProcedures.OpenFramegrabber(CamName2, out AcqHandleCam2);
                                    HOperatorSet.GrabImageStart(AcqHandleCam1, (-1));
                                    HOperatorSet.GrabImageStart(AcqHandleCam2, (-1));
                                    MessageCam1 = new Message();
                                    MessageCam2 = new Message();
                                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"{CamName1} Camera is connected", "|OK|");
                                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"{CamName2} Camera is connected", "|OK|");
                                    break;

                                case "Cam13ArBottomL_Cam14ArBottomR":

                                    Adam1 = new AdamSocket();
                                    Adam1.Connect("192.168.200.21", ProtocolType.Tcp, 502);

                                    CamProcedures.OpenFramegrabber(CamName1, out AcqHandleCam1);
                                    CamProcedures.OpenFramegrabber(CamName2, out AcqHandleCam2);
                                    HOperatorSet.GrabImageStart(AcqHandleCam1, (-1));
                                    HOperatorSet.GrabImageStart(AcqHandleCam2, (-1));
                                    MessageCam1 = new Message();
                                    MessageCam2 = new Message();
                                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"{CamName1} Camera is connected", "|OK|");
                                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"{CamName2} Camera is connected", "|OK|");
                                    break;

                            }
                            CameraState = CameraState.GrabImage;
                        }

                        catch (Exception ex)
                        {
                            CameraState = CameraState.Exception;
                            Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                        }


                        break;

                    case CameraState.GrabImage:
                        HTuple imageAvailable1 = new HTuple(false);
                        HTuple imageAvailable2 = new HTuple(false);
                        HOperatorSet.GenEmptyObj(out HObject image1);
                        HOperatorSet.GenEmptyObj(out HObject image2);
                        HTuple value = new HTuple(0);


                        if (Run == true)
                        {
                            try
                            {
                                switch (CamNames)
                                {
                                    case "Cam1LsTopL_Cam2LsTopR":

                                        HOperatorSet.SetFramegrabberParam(AcqHandleCam1, "LineSelector", "Line3");
                                        HOperatorSet.GetFramegrabberParam(AcqHandleCam1, "LineStatus", out value);
                                        GlobalVariables.CurentValueCam1 = value.I;

                                        if (ExposureTime1 != 0 && Gain1 != 0)
                                        {
                                            CamProcedures.SetFramegrabberParameter(AcqHandleCam1, "ExposureTimeAbs", new HTuple(ExposureTime1));
                                            CamProcedures.SetFramegrabberParameter(AcqHandleCam1, "GainRaw", new HTuple(Gain1));
                                        }
                                        if (ExposureTime2 != 0 && Gain2 != 0)
                                        {
                                            CamProcedures.SetFramegrabberParameter(AcqHandleCam2, "ExposureTimeAbs", new HTuple(ExposureTime2));
                                            CamProcedures.SetFramegrabberParameter(AcqHandleCam2, "GainRaw", new HTuple(Gain2));
                                        }

                                        if (GlobalVariables.CurentValueCam1 == 1 && GlobalVariables.PreviousValueCam1 == 0)
                                        {
                                            grabingDone = false;

                                        }

                                        else if (GlobalVariables.CurentValueCam1 == 0 && GlobalVariables.PreviousValueCam1 == 1)
                                        {
                                            do
                                            {


                                                HOperatorSet.GrabImageAsync(out image1, AcqHandleCam1, new HTuple(100));
                                                HOperatorSet.GrabImageAsync(out image2, AcqHandleCam2, new HTuple(100));
                                                HOperatorSet.GetFramegrabberParam(AcqHandleCam1, new HTuple("image_available"), out imageAvailable1);
                                                HOperatorSet.GetFramegrabberParam(AcqHandleCam2, new HTuple("image_available"), out imageAvailable2);

                                                MessageCam1.Image = image1;
                                                MessageCam2.Image = image2;
                                                MessageCam1.LastImage = false;
                                                MessageCam2.LastImage = false;

                                                Consumer.Enqueue1(MessageCam1);
                                                Consumer.Enqueue2(MessageCam2);

                                            } while (imageAvailable1 == true);

                                            grabingDone = true;
                                            MessageCam1 = new Message();
                                            MessageCam2 = new Message();
                                            MessageCam1.LastImage = true;
                                            MessageCam2.LastImage = true;
                                            Consumer.Enqueue1(MessageCam1);
                                            Consumer.Enqueue2(MessageCam2);
                                        }
                                        HOperatorSet.GetFramegrabberParam(AcqHandleCam1, new HTuple("image_available"), out imageAvailable1);
                                        HOperatorSet.GetFramegrabberParam(AcqHandleCam2, new HTuple("image_available"), out imageAvailable2);

                                        if (imageAvailable1 == true && grabingDone == false)
                                        {
                                            HOperatorSet.GrabImageAsync(out image1, AcqHandleCam1, new HTuple(100));
                                            HOperatorSet.GrabImageAsync(out image2, AcqHandleCam2, new HTuple(100));

                                            MessageCam1.Image = image1;
                                            MessageCam2.Image = image2;
                                            MessageCam1.LastImage = false;
                                            MessageCam2.LastImage = false;

                                            Consumer.Enqueue1(MessageCam1);
                                            Consumer.Enqueue2(MessageCam2);
                                        }

                                        break;

                                    case "Cam3LsBottomL_Cam4LsBottomR":

                                        HOperatorSet.SetFramegrabberParam(AcqHandleCam1, "LineSelector", "Line3");
                                        HOperatorSet.GetFramegrabberParam(AcqHandleCam1, "LineStatus", out value);
                                        GlobalVariables.CurentValueCam1 = value.I;

                                        if (ExposureTime1 != 0 && Gain1 != 0)
                                        {
                                            CamProcedures.SetFramegrabberParameter(AcqHandleCam1, "ExposureTimeAbs", new HTuple(ExposureTime1));
                                            CamProcedures.SetFramegrabberParameter(AcqHandleCam1, "GainRaw", new HTuple(Gain1));
                                        }
                                        if (ExposureTime2 != 0 && Gain2 != 0)
                                        {
                                            CamProcedures.SetFramegrabberParameter(AcqHandleCam2, "ExposureTimeAbs", new HTuple(ExposureTime2));
                                            CamProcedures.SetFramegrabberParameter(AcqHandleCam2, "GainRaw", new HTuple(Gain2));
                                        }

                                        if (GlobalVariables.CurentValueCam1 == 1 && GlobalVariables.PreviousValueCam1 == 0)
                                        {
                                            grabingDone = false;

                                        }

                                        else if (GlobalVariables.CurentValueCam1 == 0 && GlobalVariables.PreviousValueCam1 == 1)
                                        {
                                            try
                                            {
                                                do
                                                {
                                                    HOperatorSet.GrabImageAsync(out image1, AcqHandleCam1, new HTuple(100));
                                                    HOperatorSet.GrabImageAsync(out image2, AcqHandleCam2, new HTuple(100));

                                                    HOperatorSet.GetFramegrabberParam(AcqHandleCam1, new HTuple("image_available"), out imageAvailable1);
                                                    HOperatorSet.GetFramegrabberParam(AcqHandleCam2, new HTuple("image_available"), out imageAvailable2);

                                                    MessageCam1.Image = image1;
                                                    MessageCam2.Image = image2;
                                                    MessageCam1.LastImage = false;
                                                    MessageCam2.LastImage = false;

                                                    Consumer.Enqueue1(MessageCam1);
                                                    Consumer.Enqueue2(MessageCam2);

                                                } while (imageAvailable1 == true);

                                                grabingDone = true;
                                                MessageCam1 = new Message();
                                                MessageCam2 = new Message();
                                                MessageCam1.LastImage = true;
                                                MessageCam2.LastImage = true;
                                                Consumer.Enqueue1(MessageCam1);
                                                Consumer.Enqueue2(MessageCam2);
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("Error is here1");

                                            }

                                        }
                                        HOperatorSet.GetFramegrabberParam(AcqHandleCam1, new HTuple("image_available"), out imageAvailable1);
                                        HOperatorSet.GetFramegrabberParam(AcqHandleCam2, new HTuple("image_available"), out imageAvailable2);

                                        try
                                        {
                                            if (imageAvailable1 == true && grabingDone == false)
                                            {
                                                HOperatorSet.GrabImageAsync(out image1, AcqHandleCam1, new HTuple(100));
                                                HOperatorSet.GrabImageAsync(out image2, AcqHandleCam2, new HTuple(100));

                                                MessageCam1.Image = image1;
                                                MessageCam2.Image = image2;
                                                MessageCam1.LastImage = false;
                                                MessageCam2.LastImage = false;

                                                Consumer.Enqueue1(MessageCam1);
                                                Consumer.Enqueue2(MessageCam2);
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Error is here2");
                                        }

                                        break;

                                    case "Cam5LsLeft_Cam6LsRight":

                                        HOperatorSet.SetFramegrabberParam(AcqHandleCam1, "LineSelector", "Line3");
                                        HOperatorSet.GetFramegrabberParam(AcqHandleCam1, "LineStatus", out value);
                                        GlobalVariables.CurentValueCam1 = value.I;

                                        if (ExposureTime1 != 0 && Gain1 != 0)
                                        {
                                            CamProcedures.SetFramegrabberParameter(AcqHandleCam1, "ExposureTimeAbs", new HTuple(ExposureTime1));
                                            CamProcedures.SetFramegrabberParameter(AcqHandleCam1, "GainRaw", new HTuple(Gain1));
                                        }
                                        if (ExposureTime2 != 0 && Gain2 != 0)
                                        {
                                            CamProcedures.SetFramegrabberParameter(AcqHandleCam2, "ExposureTimeAbs", new HTuple(ExposureTime2));
                                            CamProcedures.SetFramegrabberParameter(AcqHandleCam2, "GainRaw", new HTuple(Gain2));
                                        }

                                        if (GlobalVariables.CurentValueCam1 == 1 && GlobalVariables.PreviousValueCam1 == 0)
                                        {
                                            grabingDone = false;

                                        }

                                        else if (GlobalVariables.CurentValueCam1 == 0 && GlobalVariables.PreviousValueCam1 == 1)
                                        {
                                            do
                                            {
                                               
                                                HOperatorSet.GrabImageAsync(out image1, AcqHandleCam1, new HTuple(100));
                                                HOperatorSet.GrabImageAsync(out image2, AcqHandleCam2, new HTuple(100));

                                                HOperatorSet.GetFramegrabberParam(AcqHandleCam1, new HTuple("image_available"), out imageAvailable1);
                                                HOperatorSet.GetFramegrabberParam(AcqHandleCam2, new HTuple("image_available"), out imageAvailable2);

                                                MessageCam1.Image = image1;
                                                MessageCam2.Image = image2;
                                                MessageCam1.LastImage = false;
                                                MessageCam2.LastImage = false;

                                                Consumer.Enqueue1(MessageCam1);
                                                Consumer.Enqueue2(MessageCam2);

                                            } while (imageAvailable1 == true);

                                            grabingDone = true;
                                            MessageCam1 = new Message();
                                            MessageCam2 = new Message();
                                            MessageCam1.LastImage = true;
                                            MessageCam2.LastImage = true;
                                            Consumer.Enqueue1(MessageCam1);
                                            Consumer.Enqueue2(MessageCam2);
                                        }
                                        HOperatorSet.GetFramegrabberParam(AcqHandleCam1, new HTuple("image_available"), out imageAvailable1);
                                        HOperatorSet.GetFramegrabberParam(AcqHandleCam2, new HTuple("image_available"), out imageAvailable2);

                                        if (imageAvailable1 == true && grabingDone == false)
                                        {
                                            HOperatorSet.GrabImageAsync(out image1, AcqHandleCam1, new HTuple(100));
                                            HOperatorSet.GrabImageAsync(out image2, AcqHandleCam2, new HTuple(100));

                                            MessageCam1.Image = image1;
                                            MessageCam2.Image = image2;
                                            MessageCam1.LastImage = false;
                                            MessageCam2.LastImage = false;

                                            Consumer.Enqueue1(MessageCam1);
                                            Consumer.Enqueue2(MessageCam2);
                                        }


                                        break;
                                    case "Cam7ArFrontL_Cam8ArFrontR":


                                        HOperatorSet.GetFramegrabberParam(AcqHandleCam1, new HTuple("image_available"), out imageAvailable1);
                                        HOperatorSet.GetFramegrabberParam(AcqHandleCam2, new HTuple("image_available"), out imageAvailable2);

                                        if (imageAvailable1 == true)
                                        {
                                            HOperatorSet.GrabImageAsync(out image1, AcqHandleCam1, new HTuple(100));
                                            HOperatorSet.GrabImageAsync(out image2, AcqHandleCam2, new HTuple(100));

                                            MessageCam1.Image = image1;
                                            MessageCam2.Image = image2;

                                            Consumer.Enqueue1(MessageCam1);
                                            Consumer.Enqueue2(MessageCam2);
                                        }
                                        break;

                                    case "Cam9ArBackL_Cam10ArBackR":


                                        HOperatorSet.GetFramegrabberParam(AcqHandleCam1, new HTuple("image_available"), out imageAvailable1);
                                        HOperatorSet.GetFramegrabberParam(AcqHandleCam2, new HTuple("image_available"), out imageAvailable2);

                                        if (imageAvailable1 == true)
                                        {
                                            HOperatorSet.GrabImageAsync(out image1, AcqHandleCam1, new HTuple(100));
                                            HOperatorSet.GrabImageAsync(out image2, AcqHandleCam2, new HTuple(100));

                                            MessageCam1.Image = image1;
                                            MessageCam2.Image = image2;

                                            Consumer.Enqueue1(MessageCam1);
                                            Consumer.Enqueue2(MessageCam2);
                                        }
                                        break;


                                    case "Cam11ArTopL_Cam12ArTopR":

                                        Adam1.Modbus().ReadCoilStatus(5, 5, out bool[] status);


                                        GlobalVariables.CurentValueCam11_12 = status[0];
                                        Console.WriteLine(status[0]);

                                        if (ExposureTime1 != 0 && Gain1 != 0)
                                        {
                                            CamProcedures.SetFramegrabberParameter(AcqHandleCam1, "ExposureTimeAbs", new HTuple(ExposureTime1));
                                            CamProcedures.SetFramegrabberParameter(AcqHandleCam1, "GainRaw", new HTuple(Gain1));
                                        }
                                        if (ExposureTime2 != 0 && Gain2 != 0)
                                        {
                                            CamProcedures.SetFramegrabberParameter(AcqHandleCam2, "ExposureTimeAbs", new HTuple(ExposureTime2));
                                            CamProcedures.SetFramegrabberParameter(AcqHandleCam2, "GainRaw", new HTuple(Gain2));
                                        }

                                        if (GlobalVariables.CurentValueCam11_12 == true && GlobalVariables.PreviousValueCam11_12 == false)
                                        {
                                            grabingDone = false;

                                        }

                                        else if (GlobalVariables.CurentValueCam11_12 == false && GlobalVariables.PreviousValueCam11_12 == true)
                                        {
                                            do
                                            {
                                                HOperatorSet.GetFramegrabberParam(AcqHandleCam1, new HTuple("image_available"), out imageAvailable1);
                                                HOperatorSet.GetFramegrabberParam(AcqHandleCam2, new HTuple("image_available"), out imageAvailable2);

                                                if (imageAvailable1 == true)
                                                {
                                                    HOperatorSet.GrabImageAsync(out image1, AcqHandleCam1, new HTuple(100));
                                                    HOperatorSet.GrabImageAsync(out image2, AcqHandleCam2, new HTuple(100));

                                                    MessageCam1.Image = image1;
                                                    MessageCam2.Image = image2;

                                                    Consumer.Enqueue1(MessageCam1);
                                                    Consumer.Enqueue2(MessageCam2);
                                                }

                                            } while (imageAvailable1 == true);

                                            grabingDone = true;
                                            MessageCam1 = new Message();
                                            MessageCam2 = new Message();
                                            MessageCam1.LastImage = true;
                                            MessageCam2.LastImage = true;
                                            Consumer.Enqueue1(MessageCam1);
                                            Consumer.Enqueue2(MessageCam2);
                                        }
                                        HOperatorSet.GetFramegrabberParam(AcqHandleCam1, new HTuple("image_available"), out imageAvailable1);
                                        HOperatorSet.GetFramegrabberParam(AcqHandleCam2, new HTuple("image_available"), out imageAvailable2);

                                        if (imageAvailable1 == true && grabingDone == false)
                                        {
                                            HOperatorSet.GrabImageAsync(out image1, AcqHandleCam1, new HTuple(100));
                                            HOperatorSet.GrabImageAsync(out image2, AcqHandleCam2, new HTuple(100));

                                            MessageCam1.Image = image1;
                                            MessageCam2.Image = image2;
                                            MessageCam1.LastImage = false;
                                            MessageCam2.LastImage = false;

                                            Consumer.Enqueue1(MessageCam1);
                                            Consumer.Enqueue2(MessageCam2);
                                        }

                                        GlobalVariables.PreviousValueCam11_12 = GlobalVariables.CurentValueCam11_12;
                                        break;


                                    case "Cam13ArBottomL_Cam14ArBottomR":


                                        Adam1.Modbus().ReadCoilStatus(5, 5, out bool[] status2);

                                        GlobalVariables.CurentValueCam13_14 = status2[0];
                                        Console.WriteLine(status2[0]);

                                        if (ExposureTime1 != 0 && Gain1 != 0)
                                        {
                                            CamProcedures.SetFramegrabberParameter(AcqHandleCam1, "ExposureTimeAbs", new HTuple(ExposureTime1));
                                            CamProcedures.SetFramegrabberParameter(AcqHandleCam1, "GainRaw", new HTuple(Gain1));
                                        }
                                        if (ExposureTime2 != 0 && Gain2 != 0)
                                        {
                                            CamProcedures.SetFramegrabberParameter(AcqHandleCam2, "ExposureTimeAbs", new HTuple(ExposureTime2));
                                            CamProcedures.SetFramegrabberParameter(AcqHandleCam2, "GainRaw", new HTuple(Gain2));
                                        }

                                        if (GlobalVariables.CurentValueCam13_14 == true && GlobalVariables.PreviousValueCam13_14 == false)
                                        {
                                            grabingDone = false;

                                        }

                                        else if (GlobalVariables.CurentValueCam13_14 == false && GlobalVariables.PreviousValueCam13_14 == true)
                                        {
                                            do
                                            {
                                                HOperatorSet.GetFramegrabberParam(AcqHandleCam1, new HTuple("image_available"), out imageAvailable1);
                                                HOperatorSet.GetFramegrabberParam(AcqHandleCam2, new HTuple("image_available"), out imageAvailable2);

                                                if (imageAvailable1 == true)
                                                {
                                                    HOperatorSet.GrabImageAsync(out image1, AcqHandleCam1, new HTuple(100));
                                                    HOperatorSet.GrabImageAsync(out image2, AcqHandleCam2, new HTuple(100));

                                                    MessageCam1.Image = image1;
                                                    MessageCam2.Image = image2;

                                                    Consumer.Enqueue1(MessageCam1);
                                                    Consumer.Enqueue2(MessageCam2);
                                                }

                                            } while (imageAvailable1 == true);

                                            grabingDone = true;
                                            MessageCam1 = new Message();
                                            MessageCam2 = new Message();
                                            MessageCam1.LastImage = true;
                                            MessageCam2.LastImage = true;
                                            Consumer.Enqueue1(MessageCam1);
                                            Consumer.Enqueue2(MessageCam2);
                                        }
                                        HOperatorSet.GetFramegrabberParam(AcqHandleCam1, new HTuple("image_available"), out imageAvailable1);
                                        HOperatorSet.GetFramegrabberParam(AcqHandleCam2, new HTuple("image_available"), out imageAvailable2);

                                        if (imageAvailable1 == true && grabingDone == false)
                                        {
                                            HOperatorSet.GrabImageAsync(out image1, AcqHandleCam1, new HTuple(100));
                                            HOperatorSet.GrabImageAsync(out image2, AcqHandleCam2, new HTuple(100));

                                            MessageCam1.Image = image1;
                                            MessageCam2.Image = image2;
                                            MessageCam1.LastImage = false;
                                            MessageCam2.LastImage = false;

                                            Consumer.Enqueue1(MessageCam1);
                                            Consumer.Enqueue2(MessageCam2);
                                        }

                                        GlobalVariables.PreviousValueCam13_14 = GlobalVariables.CurentValueCam13_14;

                                        break;

                                }

                                GlobalVariables.PreviousValueCam1 = GlobalVariables.CurentValueCam1;

                            }
                            catch (Exception ex)
                            {
                                CameraState = CameraState.Exception;
                                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                            }
                        }

                        break;

                    case CameraState.Exception:
                        try
                        {
                            CameraState = CameraState.Initialization;
                            if (AcqHandleCam1 != -1)
                            {
                                CamProcedures.CloseFramegrabber(AcqHandleCam1);
                            }
                            if (AcqHandleCam2 != -1)
                            {
                                CamProcedures.CloseFramegrabber(AcqHandleCam2);
                            }
                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                        }
                        break;
                }

            }
            try
            {
                if (AcqHandleCam1 != null)
                {
                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"Disconnecting Camera {CamName1} ", "|OK|");
                    CamProcedures.CloseFramegrabber(AcqHandleCam1);
                }
                if (AcqHandleCam2 != null)
                {
                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"Disconnecting Camera {CamName2}", "|OK|");
                    CamProcedures.CloseFramegrabber(AcqHandleCam2);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }

            CameraState = CameraState.Initialization;
        }

        public void Start()
        {
            Run = true;
            CameraState = CameraState.Initialization;

            ProducerThread = new Thread(MainFunction)
            {
                Name = $"ProducerThread {CamName1} {CamName2}",
                IsBackground = true,
                Priority = ThreadPriority.Normal
            };

            ProducerThread.Start();
        }

        public void AbortThread()
        {
            Run = false;
            ProducerThread.Join(5000);
            ProducerThread.Abort();
            Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"Aborted Thread {ProducerThread.Name}", "|OK|");
        }

        public void ChangeParametersCam1(int exposureTime, int gain)
        {
            ExposureTime1 = exposureTime;
            Gain1 = gain;
        }

        public void ChangeParametersCam2(int exposureTime, int gain)
        {
            ExposureTime2 = exposureTime;
            Gain2 = gain;
        }

        public void GrabImageStartSignal()
        {
            HOperatorSet.GrabImageStart(AcqHandleCam1, -1);
            HOperatorSet.GrabImageStart(AcqHandleCam2, -1);
        }
    }
}
