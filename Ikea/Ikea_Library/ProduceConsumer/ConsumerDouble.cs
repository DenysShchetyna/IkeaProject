using HalconDotNet;
using Ikea_Library.Events;
using Ikea_Library.HdevProcedures;
using Ikea_Library.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Ikea_Library.ProduceConsumer
{
    public class ConsumerDouble
    {
        public event EventHandler<TileImageReadyEventArgs> TileImageReady;
        public event EventHandler<ResultsForWritingReadyEventArgs> ResultsForWritingReady;

        private string CamNames { get; set; }
        private string CamName1 { get; set; }
        private string CamName2 { get; set; }
        DrawingVariables drawingVariables;

        string SaveImagePath;

        private bool Run;
        private Thread ConsumerThread;

        MainProgramProcedures MainProcedures;
        RecipeVariables RecipeVariables;
        private Message Message1;
        private Message Message2;
        private int Cam1ImgHeight = 512;
        private int Cam2ImgHeight = 512;

        private HTuple Img1Width;
        private HTuple Img2Width;

        HObject ImagePartial1;
        HObject ImagePartial2;
        HObject ImagesBuffer1 = new HObject();
        HObject ImagesBuffer2 = new HObject();

        public BlockingCollection<Message> MessagesCam1 = new BlockingCollection<Message>();
        public BlockingCollection<Message> MessagesCam2 = new BlockingCollection<Message>();


        public ConsumerDouble(string camName1, string camName2, DrawingVariables inputDrawing, RecipeVariables recipeVariables)
        {
            CamName1 = camName1;
            CamName2 = camName2;
            CamNames = camName1 + "_" + camName2;
            drawingVariables = inputDrawing;
            MainProcedures = new MainProgramProcedures();
            RecipeVariables = recipeVariables;
           
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
            //For simulation only
            //SaveImagePath = @"D:\Trifid\A0670IMAGES\" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss_ff") + "__" + drawingVariables.H_strDxfName.S.Replace(".DXF", "") + "__" + CamName1 + "_" + CamName2;
            //HOperatorSet.ReadImage(out HObject imagee, @"D:\Trifid\A0670IMAGES\08_10_2020_11_32_59_56__310__Cam3LsBottomL_Cam4LsBottomR.tif");
            //ProcessingCam3_4(imagee);

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

            while (Run == true)
            {
                SaveImagePath = @"D:\Trifid\A0670IMAGES\" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss_ff") + "__" + drawingVariables.H_strDxfName.S.Replace(".DXF", "") + "__" + CamName1 + "_" + CamName2;

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
                            HObject image = AfterLastImageFunc();
                            if (image != null)
                            {
                                ProcessingCam1_2(image);
                            }
                        }

                        break;

                    case "Cam3LsBottomL_Cam4LsBottomR":

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
                            HObject image = AfterLastImageFunc();
                            if (image != null)
                            {
                                //HOperatorSet.ReadImage(out image, @"D:\Trifid\A0670IMAGES08_14_2020_09_51_03_67__FBAxx031_Billy_2_Shelf_80_1.DXF__Cam3LsBottomL_Cam4LsBottomR.tif");
                                ProcessingCam3_4(image);
                            }
                        }

                        break;

                    case "Cam5LsLeft_Cam6LsRight":

                        Message1 = MessagesCam1.Take();
                        Message2 = MessagesCam2.Take();

                        try
                        {
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
                                HObject image = AfterLastImageFunc();
                                if (image != null)
                                {
                                    ProcessingCam5_6(image);
                                }
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
                            HOperatorSet.WriteImage(bigImage1, "tiff", 0, SaveImagePath);
                            ProcessingCam7_8(bigImage1);
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
                            HOperatorSet.WriteImage(bigImage1, "tiff", 0, SaveImagePath);
                            ProcessingCam9_10(bigImage1);
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

                            AfterLastImageFuncLasers();
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
                            AfterLastImageFuncLasers();
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
            Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"Aborted Thread {ConsumerThread.Name}", "|OK|");
        }


        public void AfterLastImageFuncLasers()
        {
            try
            {
                HOperatorSet.TileImages(ImagesBuffer1, out HObject bigImage1, 1, "vertical");
                HOperatorSet.TileImages(ImagesBuffer2, out HObject bigImage2, 1, "vertical");

                HOperatorSet.ConcatObj(bigImage1, bigImage2, out HObject concatedBig);
                HOperatorSet.TileImages(concatedBig, out HObject fullImage, 2, "horizontal");
                //HOperatorSet.WriteImage(fullImage, "tiff", 0, SaveImagePath);

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
                Console.WriteLine(DateTime.Now +  "AfterLastImageFuncLasers" + " | Error|");
            }
        }

        public HObject AfterLastImageFunc()
        {
            HOperatorSet.GenEmptyObj(out HObject fullImage);
            try
            {
                if (ImagePartial1 != null)
                {
                    HOperatorSet.GenImageConst(out HObject emptyImage1, "byte", Img1Width, Cam1ImgHeight);
                    HOperatorSet.GenImageConst(out HObject emptyImage2, "byte", Img2Width, Cam2ImgHeight);
                    HOperatorSet.ConcatObj(emptyImage1, ImagePartial1, out HObject concatedPartial1);
                    HOperatorSet.ConcatObj(emptyImage2, ImagePartial2, out HObject concatedPartial2);
                    HOperatorSet.TileImagesOffset(concatedPartial1, out HObject PartialTiledImages1, new HTuple(0, 0), new HTuple(0, 0), new HTuple(-1, -1), new HTuple(-1, -1), new HTuple(-1, -1), new HTuple(-1, -1), Img1Width, Cam1ImgHeight);
                    HOperatorSet.TileImagesOffset(concatedPartial2, out HObject PartialTiledImages2, new HTuple(0, 0), new HTuple(0, 0), new HTuple(-1, -1), new HTuple(-1, -1), new HTuple(-1, -1), new HTuple(-1, -1), Img2Width, Cam2ImgHeight);

                    HOperatorSet.ConcatObj(ImagesBuffer1, PartialTiledImages1, out HObject concatedFull1);
                    HOperatorSet.ConcatObj(ImagesBuffer2, PartialTiledImages2, out HObject concatedFull2);

                    HOperatorSet.TileImages(concatedFull1, out HObject bigImage1, 1, "vertical");
                    HOperatorSet.TileImages(concatedFull2, out HObject bigImage2, 1, "vertical");

                    HOperatorSet.ConcatObj(bigImage1, bigImage2, out HObject concatedBig);
                    HOperatorSet.TileImages(concatedBig, out fullImage, 2, "horizontal");

                    HOperatorSet.WriteImage(fullImage, "tiff", 0, SaveImagePath);

                    concatedPartial1.GenEmptyObj();
                    concatedPartial2.GenEmptyObj();
                    concatedFull1.GenEmptyObj();
                    concatedFull2.GenEmptyObj();
                    emptyImage1.GenEmptyObj();
                    emptyImage2.GenEmptyObj();
                }

                else
                {
                    HOperatorSet.TileImages(ImagesBuffer1, out HObject bigImage1, 1, "vertical");
                    HOperatorSet.TileImages(ImagesBuffer2, out HObject bigImage2, 1, "vertical");
                    HOperatorSet.ConcatObj(bigImage1, bigImage2, out HObject concatedBig);
                    HOperatorSet.TileImages(concatedBig, out fullImage, 2, "horizontal");

                    HOperatorSet.WriteImage(fullImage, "tiff", 0, SaveImagePath);

                    bigImage1.GenEmptyObj();
                    bigImage2.GenEmptyObj();
                    concatedBig.GenEmptyObj();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                Console.WriteLine(ConsumerThread.Name);

            }

            ImagesBuffer1.Dispose();
            ImagesBuffer2.Dispose();
            ImagesBuffer1.GenEmptyObj();
            ImagesBuffer2.GenEmptyObj();

            return fullImage;
        }

        public void ProcessingCam3_4(HObject image)
        {
            HTuple h_realJointPointLPix = 3700;
            HTuple h_realJointPointRPix = 100;
            HTuple h_realAngleCamerasSlopeDeg = 0;
            HTuple h_realFractionFactorHoleDiameterForScratchRejection = 0.5;
            HTuple h_realResizeFactorRegionDiameterForHolesLookingFor = 4;
            try
            {

                Console.WriteLine("good 1");
                MainProcedures.Function_CreateImageCamL_ImageCamRfromImageCam(image, out HObject imageL, out HObject imageR, out HTuple exception);
                Console.WriteLine("good 2");
                MainProcedures.Function_TileImagesFromCam3_4(imageL, imageR, h_realJointPointLPix, h_realJointPointRPix, h_realAngleCamerasSlopeDeg, out HObject TiledImage);
                Console.WriteLine("good 3");
                MainProcedures.Function_A0670_PrepareImageForProcessingCam3_4(TiledImage, drawingVariables.IntSurfaceTypeFromDrawing, out HObject imageForProcessingCam3_4, out HObject imageCroppedCam3_4,
                    out HTuple leftTopCornerRowPix, out HTuple leftTopCornerColumnPix, out HTuple rightBottomCornerRowPix, out HTuple rightBottomCornerColumnPix, out exception);
                Console.WriteLine("good 4");

                MainProcedures.Function_A0675_ResizeCroppedImageAccordingBoardSizeFromRecipeCam(imageForProcessingCam3_4, drawingVariables.RealRecipeWitdhOfBoardMm, drawingVariables.RealRecipeLengthOfBoardMm,
                    out HObject image0point1Mm, out HTuple columnScaleFactorMm, out HTuple rowScaleFactorMm, out exception);
                Console.WriteLine("good 5");

                HOperatorSet.MirrorImage(image0point1Mm, out image0point1Mm,"row");


                MainProcedures.Function_A0670_MeasurementHolesPositionAndDiameterCam(image0point1Mm, drawingVariables.Real_arrXPositionMmBottomFromDrawing,
                    drawingVariables.Real_arrYPositionMmBottomFromDrawing, drawingVariables.Real_arrDiameterMmBottomFromDrawing, h_realResizeFactorRegionDiameterForHolesLookingFor, h_realFractionFactorHoleDiameterForScratchRejection,
                    out HObject circleRegions, out HObject crosses, out HObject contCircles, out HTuple xPositionsBottomMm, out HTuple yPositionsBottomMm, out HTuple diametersBottomMm, out exception);

                HOperatorSet.RotateImage(image0point1Mm, out image0point1Mm, 90, "constant");

                HOperatorSet.WriteImage(image0point1Mm, "tiff", 0, SaveImagePath);

                TileImageReady?.Invoke(this, new TileImageReadyEventArgs(CamNames, image0point1Mm));

                Console.WriteLine("good 6");

                MainProcedures.ResultsEvaluationFunc(drawingVariables.RealRecipeThickessOfBoardMm, drawingVariables.RealRecipeLengthOfBoardMm, drawingVariables.RealRecipeWitdhOfBoardMm,
                    drawingVariables.Real_arrXPositionMmBottomFromDrawing, drawingVariables.Real_arrYPositionMmBottomFromDrawing, drawingVariables.Real_arrDiameterMmBottomFromDrawing,
                     xPositionsBottomMm, yPositionsBottomMm, diametersBottomMm, RecipeVariables.RecipeTolerancePosition, RecipeVariables.RecipeToleranceDiameter,
                    out HTuple h_int_arrXPositionOutOfLimit, out HTuple h_int_arrYPositionOutOfLimit, out HTuple h_int_arrDiameterOutOfLimit, out HTuple h_int_arrPositionDiameterResult, out HTuple h_mix_arrException);


                ResultsForWritingReady?.Invoke(this, new ResultsForWritingReadyEventArgs(CamNames, xPositionsBottomMm, yPositionsBottomMm, diametersBottomMm, h_int_arrPositionDiameterResult,SaveImagePath));

               

            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + ConsumerThread.Name + "|Error|");
            }
        }

        public void ProcessingCam5_6(HObject image)
        {
            HTuple h_realFractionFactorHoleDiameterForScratchRejection = 0.5;
            HTuple h_realResizeFactorRegionDiameterForHolesLookingFor = 4;

            MainProcedures.Function_CreateImageCamL_ImageCamRfromImageCam(image, out HObject imageL, out HObject imageR, out HTuple exception);

            MainProcedures.Function_A0670_PrepareImageForProcessingCam5(imageL, drawingVariables.IntSurfaceTypeFromDrawing, out HObject imageForProcessingCam5, out HObject imageCroppedCam5,
                out HTuple leftTopCornerRowPix5, out HTuple leftTopCornerColumnPix5, out HTuple rightBottomCornerRowPix5, out HTuple rightBottomCornerColumnPix5, out exception);

            MainProcedures.Function_A0675_ResizeCroppedImageAccordingBoardSizeFromRecipeCam(imageForProcessingCam5, drawingVariables.RealRecipeWitdhOfBoardMm, drawingVariables.RealRecipeLengthOfBoardMm,
               out HObject image0point1Mm5, out HTuple columnScaleFactorMm5, out HTuple rowScaleFactorMm5, out exception);

            TileImageReady?.Invoke(this, new TileImageReadyEventArgs(CamNames, imageForProcessingCam5));

            MainProcedures.Function_A0670_MeasurementHolesPositionAndDiameterCam(image0point1Mm5, drawingVariables.Real_arrXPositionMmLeftFromDrawing,
               drawingVariables.Real_arrYPositionMmLeftFromDrawing, drawingVariables.Real_arrDiameterMmLeftFromDrawing, h_realResizeFactorRegionDiameterForHolesLookingFor, h_realFractionFactorHoleDiameterForScratchRejection,
               out HObject circleRegions5, out HObject crosses5, out HObject contCircles5, out HTuple xPositionsMm5, out HTuple yPositionsMm5, out HTuple diametersMm5, out exception);



            MainProcedures.Function_A0670_PrepareImageForProcessingCam6(imageR, drawingVariables.IntSurfaceTypeFromDrawing, out HObject imageForProcessingCam6, out HObject imageCroppedCam6,
                out HTuple leftTopCornerRowPix6, out HTuple leftTopCornerColumnPix6, out HTuple rightBottomCornerRowPix6, out HTuple rightBottomCornerColumnPix6, out exception);

            MainProcedures.Function_A0675_ResizeCroppedImageAccordingBoardSizeFromRecipeCam(imageForProcessingCam6, drawingVariables.RealRecipeWitdhOfBoardMm, drawingVariables.RealRecipeLengthOfBoardMm,
               out HObject image0point1Mm6, out HTuple columnScaleFactorMm6, out HTuple rowScaleFactorMm6, out exception);

            TileImageReady?.Invoke(this, new TileImageReadyEventArgs(CamNames, imageForProcessingCam6));

            MainProcedures.Function_A0670_MeasurementHolesPositionAndDiameterCam(image0point1Mm5, drawingVariables.Real_arrXPositionMmLeftFromDrawing,
              drawingVariables.Real_arrYPositionMmLeftFromDrawing, drawingVariables.Real_arrDiameterMmLeftFromDrawing, h_realResizeFactorRegionDiameterForHolesLookingFor, h_realFractionFactorHoleDiameterForScratchRejection,
              out HObject circleRegions6, out HObject crosses6, out HObject contCircles6, out HTuple xPositionsMm6, out HTuple yPositionsMm6, out HTuple diametersMm6, out exception);
        }

        public void ProcessingCam1_2(HObject image)
        {
            HTuple h_realFractionFactorHoleDiameterForScratchRejection = 0.5;
            HTuple h_realResizeFactorRegionDiameterForHolesLookingFor = 2.0;

            //MainProcedures.PrepareImageCam1Cam2ForProcessingFunc(image, out HObject h_img_bImageCam1Cam2ForProcessing, out HObject h_img_bImageCam1Cam2Cropped, drawingVariables.IntSurfaceTypeFromDrawing,
            //    out HTuple h_realLeftTopCornerRowPix, out HTuple h_realLeftTopCornerColumnPix, out HTuple h_realRightBottomCornerRowPix, out HTuple h_realRightBottomCornerColumnPix,
            //    out HTuple h_mix_arrException);

            //MainProcedures.ResizeCroppedImageAccordingBoardSizeFromRecipe_COPY_1Func(h_img_bImageCam1Cam2ForProcessing, out HObject h_img_bImage0point1Mm, drawingVariables.RealRecipeWitdhOfBoardMm, drawingVariables.RealRecipeLengthOfBoardMm,
            //   out HTuple columnScaleFactorMm, out HTuple rowScaleFactorMm, out h_mix_arrException);

            //MainProcedures.MeasurementHolesPositionAndDiameter_COPY_1Func(h_img_bImage0point1Mm, out HObject h_reg_arrCircleRegions, out HObject h_con_arrCross, out HObject h_con_arrContCircle,
            //    drawingVariables.Real_arrYPositionMmTopFromDrawing, drawingVariables.Real_arrXPositionMmTopFromDrawing, drawingVariables.Real_arrDiameterMmTopFromDrawing,
            //    h_realResizeFactorRegionDiameterForHolesLookingFor, h_realFractionFactorHoleDiameterForScratchRejection, out HTuple h_real_arrXPositionMmFromMeasurement,
            //    out HTuple h_real_arrYPositionMmFromMeasurement, out HTuple h_real_arrDiameterMmFromMeasurement, out h_mix_arrException);
        }

        public void ProcessingCam7_8(HObject image)
        {
            TileImageReady?.Invoke(this, new TileImageReadyEventArgs(CamNames, image));

            //MainProcedures.CalibPathGeneratorFunc(GlobalVariables.CamCalibrationPath, "CamID7_Cam7ArFronL", out HTuple h_strPathCalibPhotos, out HTuple h_strPathFractionalCalibResults,
            //    out HTuple h_strPathCalibrationResultsArchive, out HTuple h_strPathCalibPlate, out HTuple h_mix_arrException);
            //MainProcedures.MapImageFunc(image, out HObject h_img_bImageCam7Cam8FrontMaped, out HTuple h_real_arrPose, out HTuple h_real_arrCamParam,
            //    out h_mix_arrException);
        }

        public void ProcessingCam9_10(HObject image)
        {
            TileImageReady?.Invoke(this, new TileImageReadyEventArgs(CamNames, image));
        }
    }
}
