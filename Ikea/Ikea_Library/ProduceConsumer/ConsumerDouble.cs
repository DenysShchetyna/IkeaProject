using HalconDotNet;
using Ikea_Library.Events;
using Ikea_Library.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ikea_Library.ProduceConsumer
{
    public class ConsumerDouble
    {
        private string CamNames { get; set; }
        private string CamName1 { get; set; }
        private string CamName2 { get; set; }

        public event EventHandler<TileImageReadyEventArgs> TileImageReady;

        private bool Run;
        private Thread ConsumerThread;

        public BlockingCollection<Message> MessagesCam1 = new BlockingCollection<Message>();
        public BlockingCollection<Message> MessagesCam2 = new BlockingCollection<Message>();


        private Message Message1;
        private Message Message2;
        private int Cam1ImgHeight = 512;
        private int Cam2ImgHeight = 512;

        private HTuple Img1Width;
        private HTuple Img2Width;

        bool ProcessingLastImage = false;
        HObject ImagePartial1;
        HObject ImagePartial2;

        HObject ImagesBuffer1 = new HObject();
        HObject ImagesBuffer2 = new HObject();

        private int CountOfSegments;

        public ConsumerDouble(string camName1, string camName2, int countOfSegments)
        {
            CamName1 = camName1;
            CamName2 = camName2;
            CamNames = camName1 + "_" + camName2;
            CountOfSegments = countOfSegments;
        }

        public void Enqueue1(Message message)
        {
            MessagesCam1.Add(message);
        }
        public void Enqueue2(Message message)
        {
            MessagesCam2.Add(message);
        }
        private void MainFunction()
        {

            HOperatorSet.GenEmptyObj(out ImagesBuffer1);
            HOperatorSet.GenEmptyObj(out ImagesBuffer2);

            Message1 = new Message();
            Message2 = new Message();

            HObject bigImage1;
            HObject bigImage2;

            HOperatorSet.GenEmptyObj(out bigImage1);
            HOperatorSet.GenEmptyObj(out bigImage2);

            HOperatorSet.GenEmptyObj(out ImagePartial1);
            HOperatorSet.GenEmptyObj(out ImagePartial2);


            bool firstImageReady = false;
            bool secondImageReady = false;


            while (Run == true)
            {

                switch (CamNames)
                {
                    case "Cam1LsTopL_Cam2LsTopR":


                        Message1 = MessagesCam1.Take();
                        Message2 = MessagesCam2.Take();


                        if (Message1.LastImage == false)
                        {
                            HOperatorSet.GetImageSize(Message1.Image, out Img1Width, out HTuple img1Height);
                            Console.WriteLine(img1Height.ToString() + "first");
                            HOperatorSet.GetImageSize(Message2.Image, out Img2Width, out HTuple img2Height);
                            Console.WriteLine(img2Height.ToString() + "second");

                            if ((img1Height < Cam1ImgHeight) && (img1Height > 0))
                            {
                                ImagePartial1 = Message1.Image;
                                ImagePartial2 = Message2.Image;
                            }
                            else
                            {
                                HOperatorSet.ConcatObj(ImagesBuffer1, Message1.Image, out ImagesBuffer1);
                                HOperatorSet.ConcatObj(ImagesBuffer2, Message2.Image, out ImagesBuffer2);
                            }
                        }

                        else if (Message1.LastImage == true)
                        {

                            AfterLastImageFunc();
                        }


                        //string filePath1 = @"C:\Trifid\A0670\SW\photos\" + DateTime.Now.ToString("MM_dd_yyyy__HH_mm_ss_ff") + "__" + CamName1;
                        //HOperatorSet.WriteImage(Message1.Image, "tiff", 0, filePath1);
                        //string filePath2 = @"C:\Trifid\A0670\SW\photos\" + DateTime.Now.ToString("MM_dd_yyyy__HH_mm_ss_ff") + "__" + CamName2;
                        //HOperatorSet.WriteImage(Message2.Image, "tiff", 0, filePath2);


                        break;

                    case "Cam3LsBottomL_Cam4LsBottomR":

                        Message1 = MessagesCam1.Take();
                        Message2 = MessagesCam2.Take();

                       

                        if (Message1.LastImage == false)
                        {
                            string filePath1 = @"C:\Trifid\A0670\SW\photos\test\" + DateTime.Now.ToString("MM_dd_yyyy__HH_mm_ss_ff") + "__" + CamName1;
                            HOperatorSet.WriteImage(Message1.Image, "tiff", 0, filePath1);
                            string filePath2 = @"C:\Trifid\A0670\SW\photos\test\" + DateTime.Now.ToString("MM_dd_yyyy__HH_mm_ss_ff") + "__" + CamName2;
                            HOperatorSet.WriteImage(Message2.Image, "tiff", 0, filePath2);

                            HOperatorSet.GetImageSize(Message1.Image, out Img1Width, out HTuple img1Height);
                            Console.WriteLine(img1Height.ToString() + "first");
                            HOperatorSet.GetImageSize(Message2.Image, out Img2Width, out HTuple img2Height);
                            Console.WriteLine(img2Height.ToString() + "second");

                            if ((img1Height < Cam1ImgHeight) && (img1Height > 0))
                            {
                                ImagePartial1 = Message1.Image;
                                ImagePartial2 = Message2.Image;
                            }
                            else
                            {
                                HOperatorSet.ConcatObj(ImagesBuffer1, Message1.Image, out ImagesBuffer1);
                                HOperatorSet.ConcatObj(ImagesBuffer2, Message2.Image, out ImagesBuffer2);
                            }
                        }

                        else if (Message1.LastImage == true)
                        {

                            AfterLastImageFunc();
                        }

                        break;
                    case "Cam5LsLeft_Cam6LsRight":

                        Message1 = MessagesCam1.Take();
                        Message2 = MessagesCam2.Take();

                        try
                        {
                            if (Message1.LastImage == false)
                            {

                                string filePath1 = @"C:\Trifid\A0670\SW\photos\test\" + DateTime.Now.ToString("MM_dd_yyyy__HH_mm_ss_ff") + "__" + CamName1;
                                HOperatorSet.WriteImage(Message1.Image, "tiff", 0, filePath1);
                                string filePath2 = @"C:\Trifid\A0670\SW\photos\test\" + DateTime.Now.ToString("MM_dd_yyyy__HH_mm_ss_ff") + "__" + CamName2;
                                HOperatorSet.WriteImage(Message2.Image, "tiff", 0, filePath2);

                                HOperatorSet.GetImageSize(Message1.Image, out Img1Width, out HTuple img1Height);
                                Console.WriteLine(img1Height.ToString() + "first");
                                HOperatorSet.GetImageSize(Message2.Image, out Img2Width, out HTuple img2Height);
                                Console.WriteLine(img2Height.ToString() + "second");

                                if ((img1Height < Cam1ImgHeight) && (img1Height > 0))
                                {
                                    ImagePartial1 = Message1.Image;
                                    ImagePartial2 = Message2.Image;
                                }
                                else
                                {
                                    HOperatorSet.ConcatObj(ImagesBuffer1, Message1.Image, out ImagesBuffer1);
                                    HOperatorSet.ConcatObj(ImagesBuffer2, Message2.Image, out ImagesBuffer2);
                                }
                            }

                            else if (Message1.LastImage == true)
                            {

                                AfterLastImageFunc();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                        }
                        

                        break;

                    case "Cam7ArFrontL_Cam8ArFrontR":

                        Message1 = MessagesCam1.Take();
                        Message2 = MessagesCam2.Take();

                        try
                        {
                            HOperatorSet.ConcatObj(Message1.Image, Message2.Image, out ImagesBuffer1);
                            HOperatorSet.TileImages(ImagesBuffer1, out bigImage1, 2, "horizontal");

                            string filePath7 = @"C:\Trifid\A0670\SW\photos\" + DateTime.Now.ToString("MM_dd_yyyy__HH_mm_ss_ff") + "__" + CamName1 + "_" + CamName2;
                            HOperatorSet.WriteImage(bigImage1, "tiff", 0, filePath7);

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                        }
                       

                        break;

                    case "Cam9ArBackL_Cam10ArBackR":

                        Message1 = MessagesCam1.Take();
                        Message2 = MessagesCam2.Take();

                        try
                        {
                            HOperatorSet.ConcatObj(Message1.Image, Message2.Image, out ImagesBuffer1);
                            HOperatorSet.TileImages(ImagesBuffer1, out bigImage1, 2, "horizontal");

                            string filePath3 = @"C:\Trifid\A0670\SW\photos\" + DateTime.Now.ToString("MM_dd_yyyy__HH_mm_ss_ff") + "__" + CamName1 + "_" + CamName2;
                            HOperatorSet.WriteImage(bigImage1, "tiff", 0, filePath3);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                        }

                        break;

                    case "Cam11ArTopL_Cam12ArTopR":
                        Message1 = MessagesCam1.Take();
                        Message2 = MessagesCam2.Take();


                        if (Message1.LastImage == false)
                        {
                                HOperatorSet.ConcatObj(ImagesBuffer1, Message1.Image, out ImagesBuffer1);
                                HOperatorSet.ConcatObj(ImagesBuffer2, Message2.Image, out ImagesBuffer2);
                        }

                        else if (Message1.LastImage == true)
                        {

                            AfterLastImagewFuncLasers();
                        }

                        break;

                    case "Cam13ArBottomL_Cam14ArBottomR":
                        Message1 = MessagesCam1.Take();
                        Message2 = MessagesCam2.Take();


                        if (Message1.LastImage == false)
                        {
                            HOperatorSet.ConcatObj(ImagesBuffer1, Message1.Image, out ImagesBuffer1);
                            HOperatorSet.ConcatObj(ImagesBuffer2, Message2.Image, out ImagesBuffer2);
                        }

                        else if (Message1.LastImage == true)
                        {
                            AfterLastImagewFuncLasers();
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
                Name = $"ConsumerThread {CamNames}",
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

        // End of events
        public void AfterLastImagewFuncLasers()
        {
            try
            {
                HOperatorSet.TileImages(ImagesBuffer1, out HObject bigImage1, 1, "vertical");
                HOperatorSet.TileImages(ImagesBuffer2, out HObject bigImage2, 1, "vertical");

                HOperatorSet.ConcatObj(bigImage1, bigImage2, out HObject concatedBig);
                HOperatorSet.TileImages(concatedBig, out HObject fullImage, 2, "horizontal");

                string filePath2 = @"C:\Trifid\A0670\SW\photos\" + DateTime.Now.ToString("MM_dd_yyyy__HH_mm_ss_ff") + "__" + CamName1 + "_" + CamName2;
                HOperatorSet.WriteImage(fullImage, "tiff", 0, filePath2);

                bigImage1.GenEmptyObj();
                bigImage2.GenEmptyObj();
                fullImage.GenEmptyObj();
                concatedBig.GenEmptyObj();
                fullImage.GenEmptyObj();
                ImagesBuffer1.Dispose();
                ImagesBuffer2.Dispose();

                ImagesBuffer1.GenEmptyObj();
                ImagesBuffer2.GenEmptyObj();

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message + "|Error|");
            }
        }
        public void AfterLastImageFunc()
        {
            try
            {
               
                if (ImagePartial1 != null)
                {
                    HOperatorSet.GenImageConst(out HObject emptyImage1, "byte", Img1Width, Cam1ImgHeight);
                    HOperatorSet.GenImageConst(out HObject emptyImage2, "byte", Img1Width, Cam2ImgHeight);
                    HOperatorSet.ConcatObj(emptyImage1, ImagePartial1, out HObject concatedPartial1);
                    HOperatorSet.ConcatObj(emptyImage2, ImagePartial2, out HObject concatedPartial2);
                    HOperatorSet.TileImagesOffset(concatedPartial1, out HObject PartialTiledImages1, new HTuple(0, 0), new HTuple(0, 0), new HTuple(-1, -1), new HTuple(-1, -1), new HTuple(-1, -1), new HTuple(-1, -1), Img1Width, Cam1ImgHeight);
                    HOperatorSet.TileImagesOffset(concatedPartial2, out HObject PartialTiledImages2, new HTuple(0, 0), new HTuple(0, 0), new HTuple(-1, -1), new HTuple(-1, -1), new HTuple(-1, -1), new HTuple(-1, -1), Img2Width, Cam2ImgHeight);

                    HOperatorSet.ConcatObj(ImagesBuffer1, PartialTiledImages1, out HObject concatedFull1);
                    HOperatorSet.ConcatObj(ImagesBuffer2, PartialTiledImages2, out HObject concatedFull2);

                    HOperatorSet.TileImages(concatedFull1, out HObject bigImage1, 1, "vertical");
                    HOperatorSet.TileImages(concatedFull2, out HObject bigImage2, 1, "vertical");

                    HOperatorSet.ConcatObj(bigImage1, bigImage2, out HObject concatedBig);
                    HOperatorSet.TileImages(concatedBig, out HObject fullImage, 2, "horizontal");

                    string filePath2 = @"C:\Trifid\A0670\SW\photos\" + DateTime.Now.ToString("MM_dd_yyyy__HH_mm_ss_ff") + "__" + CamName1 + "_" + CamName2;
                    HOperatorSet.WriteImage(fullImage, "tiff", 0, filePath2);

                    concatedPartial1.GenEmptyObj();
                    concatedPartial2.GenEmptyObj();
                    concatedFull1.GenEmptyObj();
                    concatedFull2.GenEmptyObj();
                    fullImage.GenEmptyObj();
                    emptyImage1.GenEmptyObj();
                    emptyImage2.GenEmptyObj();
                }
                else
                {
                    HOperatorSet.TileImages(ImagesBuffer1, out HObject bigImage1, 1, "vertical");
                    HOperatorSet.TileImages(ImagesBuffer2, out HObject bigImage2, 1, "vertical");

                    HOperatorSet.ConcatObj(bigImage1, bigImage2, out HObject concatedBig);
                    HOperatorSet.TileImages(concatedBig, out HObject fullImage, 2, "horizontal");

                    string filePath2 = @"C:\Trifid\A0670\SW\photos\" + DateTime.Now.ToString("MM_dd_yyyy__HH_mm_ss_ff") + "__" + CamName1 + "_" + CamName2;
                    HOperatorSet.WriteImage(fullImage, "tiff", 0, filePath2);

                    bigImage1.GenEmptyObj();
                    bigImage2.GenEmptyObj();
                    fullImage.GenEmptyObj();
                    concatedBig.GenEmptyObj();
                    fullImage.GenEmptyObj();

                }
            }
            catch (Exception)
            {
                
            }

            ImagesBuffer1.Dispose();
            ImagesBuffer2.Dispose();

            ImagesBuffer1.GenEmptyObj();
            ImagesBuffer2.GenEmptyObj();
        }
    }
}
