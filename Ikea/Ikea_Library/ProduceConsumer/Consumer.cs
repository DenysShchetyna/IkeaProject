using HalconDotNet;
using Ikea_Library.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ikea_Library.ProduceConsumer
{
    public class Consumer
    {
        private string CamName { get; set; }

        public event EventHandler<TileImageReadyEventArgs> TileImageReady;

        private bool Run;
        private Thread ConsumerThread;
        private BlockingCollection<Message> Messages = new BlockingCollection<Message>(10);

        private Message Message;


        HObject ImagesBuffer = new HObject();
        private HTuple ImgWidth;
        HObject ImagePartial;
        private int CamImgHeight = 512;



        public Consumer(string camName)
        {
            CamName = camName;
        }

        public void Enqueue(Message message)
        {
            Messages.Add(message);
        }

        private void MainFunction()
        {
            ImagesBuffer.GenEmptyObj();
            HOperatorSet.GenEmptyObj(out ImagePartial);


            Message = new Message();


            while (Run == true)
            {
                switch (CamName)
                {
                    case "Cam5LsLeft":

                        Message = Messages.Take();


                        if (Message.LastImage == false)
                        {
                            HOperatorSet.GetImageSize(Message.Image, out ImgWidth, out HTuple imgHeight);
                            Console.WriteLine(imgHeight.ToString() + "first");

                            if ((imgHeight < CamImgHeight) && (imgHeight > 0))
                            {
                                ImagePartial = Message.Image;
                            }
                            else
                            {
                                HOperatorSet.ConcatObj(ImagesBuffer, Message.Image, out ImagesBuffer);
                            }
                        }

                        else if (Message.LastImage == true)
                        {
                            AfterLastImageFunc();
                        }

                        break;

                    case "Cam6LsRight":
                        Message = Messages.Take();


                        if (Message.LastImage == false)
                        {
                            HOperatorSet.GetImageSize(Message.Image, out ImgWidth, out HTuple imgHeight);
                            Console.WriteLine(imgHeight.ToString() + "first");

                            if ((imgHeight < CamImgHeight) && (imgHeight > 0))
                            {
                                ImagePartial = Message.Image;
                            }
                            else
                            {
                                HOperatorSet.ConcatObj(ImagesBuffer, Message.Image, out ImagesBuffer);
                            }
                        }

                        else if (Message.LastImage == true)
                        {

                            AfterLastImageFunc();
                        }
                        break;
                }
            }
        }

        public void Start()
        {
            Run = true;

            ConsumerThread = new Thread(MainFunction)
            {
                Name = $"ConsumerThread {CamName}",
                IsBackground = true,
                Priority = ThreadPriority.Normal
            };
            ConsumerThread.Start();
        }

        public void AbortThread()
        {
            Run = false;
            ConsumerThread.Join(5000);
            ConsumerThread.Abort();
            Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"Aborted Thread {ConsumerThread.Name}", "|OK|");
        }

        public void AfterLastImageFunc()
        {
            HOperatorSet.GenImageConst(out HObject emptyImage1, "byte", ImgWidth, CamImgHeight);
            if (ImagePartial != null)
            {
                HOperatorSet.ConcatObj(emptyImage1, ImagePartial, out HObject concatedPartial);
                HOperatorSet.TileImagesOffset(concatedPartial, out HObject PartialTiledImages, new HTuple(0, 0), new HTuple(0, 0), new HTuple(-1, -1), new HTuple(-1, -1), new HTuple(-1, -1), new HTuple(-1, -1), ImgWidth, CamImgHeight);

                HOperatorSet.ConcatObj(ImagesBuffer, PartialTiledImages, out HObject concatedFull);

                HOperatorSet.TileImages(concatedFull, out HObject bigImage, 1, "vertical");


                string filePath2 = @"C:\Trifid\A0670\SW\photos\" + DateTime.Now.ToString("MM_dd_yyyy__HH_mm_ss_ff") + "__" + CamName;
                HOperatorSet.WriteImage(bigImage, "tiff", 0, filePath2);
                concatedPartial.GenEmptyObj();
                concatedFull.GenEmptyObj();
                emptyImage1.GenEmptyObj();
            }
            else
            {
                HOperatorSet.TileImages(ImagesBuffer, out HObject bigImage, 1, "vertical");

                string filePath2 = @"C:\Trifid\A0670\SW\photos\" + DateTime.Now.ToString("MM_dd_yyyy__HH_mm_ss_ff") + "__" + CamName;
                HOperatorSet.WriteImage(bigImage, "tiff", 0, filePath2);
            }


            ImagesBuffer.Dispose();
            ImagesBuffer.GenEmptyObj();
        }
    }

}
