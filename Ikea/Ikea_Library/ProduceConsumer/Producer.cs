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

        private bool Run;
        private Thread ProducerThread;
        public HDevProcedure HDevProcedures;
        public CamProcedures CamProcedures;
        public HTuple AcqHandleCam;
        private CameraState CameraState;

        public Producer(string name, string camName)
        {
            _name = name;
            _camName = camName;
        }

        private bool Initialize()
        {
            try
            {
                HDevProcedures = new HDevProcedure(GlobalVariables.CameraProcedures);
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

                                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Initialization", "|OK|");
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
                            CamProcedures.OpenFramegrabber("CAM1", 600, 0, 2048, 50, 5000, out AcqHandleCam);

                            if (AcqHandleCam != -1)
                            {
                                switch (_camName)
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
                            }
                        }

                        catch
                        {

                        }

                        break;

                    case CameraState.GrabImage:
                        break;

                    case CameraState.DisconnectCamera:
                        break;

                    case CameraState.Exception:
                        break;
                }
            }
        }

        public void Start()
        {
            Run = true;
            CameraState = CameraState.Initialization;

            ProducerThread = new Thread(MainFunction)
            {
                Name = "ImageProcessing",
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
        }
    }
}
