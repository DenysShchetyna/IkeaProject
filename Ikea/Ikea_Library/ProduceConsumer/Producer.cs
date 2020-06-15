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
        private string _name { get; set; }
        private string _camName { get; set; }
        private HObject _tileImage { get; set; }

        private HTuple AcqHandleCam;
        private bool Run;
        private Thread ProducerThread;
        public CamProcedures CamProcedures;
        private CameraState CameraState;
        private PersistentVariables _persistentVariables;
        private Consumer _consumer;
        private Message Message;

        public Producer(string name, string camName, PersistentVariables persistentVariables, Consumer consumer)
        {
            _name = name;
            _camName = camName;
            _persistentVariables = persistentVariables;
            _consumer = consumer;
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
                                AcqHandleCam = null;

                                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"Initialization {_camName}", "|OK|");
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
                            Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"Connecting Camera {_camName} with exp:{_persistentVariables.ExposureTimeCam1}, gain:{ _persistentVariables.GainCam1}", "|OK|");
                            CamProcedures.OpenFramegrabber(_camName, 2048, 50, _persistentVariables.ExposureTimeCam1, _persistentVariables.GainCam1, out AcqHandleCam);
                            Message = new Message();
                            Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"{_camName} Camera is connected", "|OK|");

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
                            switch (_camName)
                            {
                                case "CAM1":

                                    CamProcedures.SetFramegrabberParameter(AcqHandleCam, "ExposureTimeAbs", _persistentVariables.ExposureTimeCam1);
                                    CamProcedures.SetFramegrabberParameter(AcqHandleCam, "GainRaw", _persistentVariables.GainCam1);

                                    HOperatorSet.GetFramegrabberParam(AcqHandleCam, new HTuple("image_available"), out HTuple imageAvailable);

                                    //if (imageAvailable.I == 1)
                                    //{
                                        HOperatorSet.GrabImageAsync(out HObject image, AcqHandleCam, new HTuple(-1));
                                        Message.Image = image;
                                        _consumer.Enqueue(Message);
                                        Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"{_camName} Added message to collection", "|OK|");
                                    //}
                                    //else
                                    //{
                                       //Thread.Sleep(1);
                                    //}

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
                        break;
                }

            }
            try
            {
                if(AcqHandleCam != null)
                {
                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"Disconnecting Camera {_camName}", "|OK|");
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
                Name = $"ProducerThread {_camName}",
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
