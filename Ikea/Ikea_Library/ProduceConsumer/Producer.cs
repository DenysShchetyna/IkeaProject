using HalconDotNet;
using Ikea_Library.HdevProcedures;
using Ikea_Library.Helpers;
using System;
using System.Collections.Generic;
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

        private HTuple AcqHandleCam;
        private bool Run;
        private Thread ProducerThread;
        public CamProcedures CamProcedures;
        private CameraState CameraState;
        private PersistentVariables PersistentVariables;
        private Consumer Consumer;
        private Message Message;

        public Producer(string camName, PersistentVariables persistentVariables, Consumer consumer)
        {
            CamName = camName;
            PersistentVariables = persistentVariables;
            Consumer = consumer;
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
                            Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"Connecting Camera {CamName} with exp:{PersistentVariables.ExposureTimeCam1}, gain:{ PersistentVariables.GainCam1}", "|OK|");
                            CamProcedures.OpenFramegrabber(CamName, 2048, 50, PersistentVariables.ExposureTimeCam1, PersistentVariables.GainCam1, out AcqHandleCam);
                            Message = new Message();
                            Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"{CamName} Camera is connected", "|OK|");

                            CameraState = CameraState.GrabImage;
                        }

                        catch (Exception ex)
                        {
                            CameraState = CameraState.Exception;
                            Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                        }

                        break;

                    case CameraState.GrabImage:

                        try
                        {
                            switch (CamName)
                            {
                                case "CAM1":

                                    CamProcedures.SetFramegrabberParameter(AcqHandleCam, "ExposureTimeAbs", PersistentVariables.ExposureTimeCam1);
                                    CamProcedures.SetFramegrabberParameter(AcqHandleCam, "GainRaw", PersistentVariables.GainCam1);

                                    HOperatorSet.GetFramegrabberParam(AcqHandleCam, new HTuple("image_available"), out HTuple imageAvailable);

                                    
                                        HOperatorSet.GrabImageAsync(out HObject image, AcqHandleCam, new HTuple(-1));
                                        Message.Image = image;
                                        Consumer.Enqueue(Message);

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


                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                        }

                        break;

                    case CameraState.Exception:
                        try
                        {
                            CameraState = CameraState.Initialization;
                            if(AcqHandleCam != -1)
                            {
                                CamProcedures.CloseFramegrabber(AcqHandleCam);
                            }
                        }

                        catch (Exception ex )
                        {
                            Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                        }
                        break;
                }

            }
            try
            {
                if(AcqHandleCam != null)
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
    }
}
