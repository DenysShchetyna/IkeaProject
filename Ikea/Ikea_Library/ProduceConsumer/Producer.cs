using HalconDotNet;
using Ikea_Library.Events;
using Ikea_Library.HdevProcedures;
using Ikea_Library.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ikea_Library.ProduceConsumer
{
    public class Producer
    {
        private string CamName { get; set; }

        public HTuple AcqHandleCam;

        private bool Run;
        private Thread ProducerThread;
        public CamProcedures CamProcedures;
        private CameraState CameraState;
        private Consumer Consumer;
        private Message Message;

        HTuple IntSurfaceTypeFromDrawing;

        int Gain = 0;
        int ExposureTime = 0;

        public event EventHandler<ReadAdamCoilsEventArgs> ReadAdamCoil;


        public Producer(string camName, Consumer consumer, HTuple intSurface)
        {
            CamName = camName;
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
                                AcqHandleCam = new HTuple(-1);

                                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"Initialization {CamName}", "|OK|");
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

                            switch (CamName)
                            {
                                case "Cam5LsLeft":

                                    CamProcedures.OpenFramegrabber("Cam5LsLeft", out AcqHandleCam);
                                    Message = new Message();
                                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"Cam5LsLeft Camera is connected", "|OK|");
                                    break;

                                case "Cam6LsRight":
                                    CamProcedures.OpenFramegrabber(CamName, out AcqHandleCam);
                                    Message = new Message();
                                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"Cam6LsRight Camera is connected", "|OK|");
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

                        HTuple imageAvailable = new HTuple(false);
                        HOperatorSet.GenEmptyObj(out HObject image);
                        HTuple value = new HTuple(0);

                        if (Run == true)
                        {
                            try
                            {
                                switch (CamName)
                                {
                                    case "Cam5LsLeft":

                                        HOperatorSet.SetFramegrabberParam(AcqHandleCam, "LineSelector", "Line3");
                                        HOperatorSet.GetFramegrabberParam(AcqHandleCam, "LineStatus", out value);
                                        GlobalVariables.CurentValueCam1 = value.I;

                                        if (ExposureTime != 0 && Gain != 0)
                                        {
                                            CamProcedures.SetFramegrabberParameter(AcqHandleCam, "ExposureTimeAbs", new HTuple(ExposureTime));
                                            CamProcedures.SetFramegrabberParameter(AcqHandleCam, "GainRaw", new HTuple(Gain));
                                        }

                                        if (GlobalVariables.CurentValueCam1 == 1 && GlobalVariables.PreviousValueCam1 == 0)
                                        {
                                            grabingDone = false;

                                        }

                                        else if (GlobalVariables.CurentValueCam1 == 0 && GlobalVariables.PreviousValueCam1 == 1)
                                        {
                                            do
                                            {

                                                HOperatorSet.GrabImageAsync(out image, AcqHandleCam, new HTuple(-1));

                                                Message.Image = image;
                                                Message.LastImage = false;

                                                Consumer.Enqueue(Message);
                                                Console.WriteLine("send1");

                                            } while (imageAvailable == true);

                                            grabingDone = true;
                                            Message = new Message();
                                            Message.LastImage = true;
                                            Consumer.Enqueue(Message);
                                        }

                                        HOperatorSet.SetFramegrabberParam(AcqHandleCam, new HTuple("grab_timeout"), 100);
                                        HOperatorSet.GrabImageAsync(out image, AcqHandleCam, new HTuple(-1));

                                        Message.Image = image;
                                        Message.LastImage = false;

                                        Consumer.Enqueue(Message);
                                        Console.WriteLine("send2");


                                        break;

                                    case "Cam6LsRight":

                                        HOperatorSet.SetFramegrabberParam(AcqHandleCam, "LineSelector", "Line3");
                                        HOperatorSet.GetFramegrabberParam(AcqHandleCam, "LineStatus", out value);
                                        GlobalVariables.CurentValueCam1 = value.I;

                                        if (ExposureTime != 0 && Gain != 0)
                                        {
                                            CamProcedures.SetFramegrabberParameter(AcqHandleCam, "ExposureTimeAbs", new HTuple(ExposureTime));
                                            CamProcedures.SetFramegrabberParameter(AcqHandleCam, "GainRaw", new HTuple(Gain));
                                        }

                                        if (GlobalVariables.CurentValueCam1 == 1 && GlobalVariables.PreviousValueCam1 == 0)
                                        {
                                            grabingDone = false;

                                        }

                                        else if (GlobalVariables.CurentValueCam1 == 0 && GlobalVariables.PreviousValueCam1 == 1)
                                        {
                                            do
                                            {
                                                HOperatorSet.GetFramegrabberParam(AcqHandleCam, new HTuple("image_available"), out imageAvailable);

                                                HOperatorSet.GrabImageAsync(out image, AcqHandleCam, new HTuple(-1));

                                                Message.Image = image;
                                                Message.LastImage = false;

                                                Consumer.Enqueue(Message);
                                                Console.WriteLine("send1");

                                            } while (imageAvailable == true);

                                            grabingDone = true;
                                            Message = new Message();
                                            Message.LastImage = true;
                                            Consumer.Enqueue(Message);
                                        }
                                        HOperatorSet.GetFramegrabberParam(AcqHandleCam, new HTuple("image_available"), out imageAvailable);

                                        if (imageAvailable == true)
                                        {
                                            HOperatorSet.GrabImageAsync(out image, AcqHandleCam, new HTuple(-1));

                                            Message.Image = image;
                                            Message.LastImage = false;

                                            Consumer.Enqueue(Message);
                                            Console.WriteLine("send2");

                                        }

                                        break;
                                }

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
                            //if (AcqHandleCam != -1)
                            //{
                            CamProcedures.CloseFramegrabber(AcqHandleCam);
                            // }
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
                if (AcqHandleCam != null)
                {
                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"Disconnecting Camera {CamName}", "|OK|");
                    CamProcedures.CloseFramegrabber(AcqHandleCam);
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
                Name = $"ProducerThread {CamName}",
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

        public void ChangeParameters(int exposureTime, int gain)
        {
            ExposureTime = exposureTime;
            Gain = gain;
        }


    }
}
