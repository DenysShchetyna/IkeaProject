using Advantech.Adam;
using HalconDotNet;
using Ikea_Library.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ikea_Library.HdevProcedures
{
    public class MainProgramProcedures
    {
        string ProgramPath = GlobalVariables.HalconEvaluationPath;

        HDevProgram Program;
        HDevProcedure ReadDrawing;
        HDevProcedureCall ReadDrawing_Call;

        HDevProcedure ReadRecipe;
        HDevProcedureCall ReadRecipe_Call;

        HDevProcedure WriteRecipe;
        HDevProcedureCall WriteRecipe_Call;

        HDevProcedure ChangePfsCamParams;
        HDevProcedureCall ChangePfsCamParams_Call;



        HDevProcedure CreateTwoImagesFromOne_Cam3_4;
        HDevProcedureCall CreateTwoImagesFromOne_Cam3_4_Call;

        HDevProcedure TileTwoImagesFromOne_Cam3_4;
        HDevProcedureCall TileTwoImagesFromOne_Cam3_4_Call;

        HDevProcedure PrepareImageForProcessing_Cam3_4;
        HDevProcedureCall PrepareImageForProcessing_Cam3_4_Call;

        HDevProcedure ResizeCroppedImage_Cam3_4;
        HDevProcedureCall ResizeCroppedImage_Cam3_4_Call;

        HDevProcedure MeasureHoles_Cam3_4;
        HDevProcedureCall MeasureHoles_Cam3_4_Call;


        HDevProcedure PrepareImageForProcessing_Cam5;
        HDevProcedureCall PrepareImageForProcessing_Cam5_Call;

        HDevProcedure PrepareImageForProcessing_Cam6;
        HDevProcedureCall PrepareImageForProcessing_Cam6_Call;

        HDevProcedure WriteResultToFile_Cam;
        HDevProcedureCall WriteResultToFile_Call;

        HDevProcedure CalibPathGenerator;
        HDevProcedureCall CalibPathGenerator_Call;

        HDevProcedure ReadExternalOrInternalParametersFromFractionalResults;
        HDevProcedureCall ReadExternalOrInternalParametersFromFractionalResults_Call;

        HDevProcedure MapImage;
        HDevProcedureCall MapImage_Call;

        HDevProcedure PrepareImageCam7Cam8ForProcessing;
        HDevProcedureCall PrepareImageCam7Cam8ForProcessing_Call;

        HDevProcedure ResizeCroppedImageAccordingBoardSizeFromRecipe_COPY_1;
        HDevProcedureCall ResizeCroppedImageAccordingBoardSizeFromRecipe_COPY_1_Call;

        HDevProcedure MeasurementHolesPositionAndDiameter_COPY_1;
        HDevProcedureCall MeasurementHolesPositionAndDiameter_COPY_1_Call;

        HDevProcedure PrepareImageCam1Cam2ForProcessing;
        HDevProcedureCall PrepareImageCam1Cam2ForProcessing_Call;

        HDevProcedure ResultsEvaluation;
        HDevProcedureCall ResultsEvaluation_Call;


        public MainProgramProcedures()
        {
            InitializeProcedures();
        }

        private void InitializeProcedures()
        {
            try
            {
                Program = new HDevProgram(ProgramPath);

                ReadDrawing = new HDevProcedure(Program, "Function_DrawingReader");
                ReadDrawing_Call = new HDevProcedureCall(ReadDrawing);

                ReadRecipe = new HDevProcedure(Program, "Function_RecipeReader");
                ReadRecipe_Call = new HDevProcedureCall(ReadRecipe);

                WriteRecipe = new HDevProcedure(Program, "Function_RecipeWriter");
                WriteRecipe_Call = new HDevProcedureCall(WriteRecipe);

                ChangePfsCamParams = new HDevProcedure(Program, "Function_PfsParametersModify");
                ChangePfsCamParams_Call = new HDevProcedureCall(ChangePfsCamParams);

                CreateTwoImagesFromOne_Cam3_4 = new HDevProcedure(Program, "Function_CreateImageCamL_ImageCamRfromImageCamLCamR");
                CreateTwoImagesFromOne_Cam3_4_Call = new HDevProcedureCall(CreateTwoImagesFromOne_Cam3_4);

                TileTwoImagesFromOne_Cam3_4 = new HDevProcedure(Program, "Function_TileImagesFromCamLCamR");
                TileTwoImagesFromOne_Cam3_4_Call = new HDevProcedureCall(TileTwoImagesFromOne_Cam3_4);

                PrepareImageForProcessing_Cam3_4 = new HDevProcedure(Program, "Function_A0670_PrepareImageCam3Cam4ForProcessing");
                PrepareImageForProcessing_Cam3_4_Call = new HDevProcedureCall(PrepareImageForProcessing_Cam3_4);

                ResizeCroppedImage_Cam3_4 = new HDevProcedure(Program, "Function_A0675_ResizeCroppedImageAccordingBoardSizeFromRecipe");
                ResizeCroppedImage_Cam3_4_Call = new HDevProcedureCall(ResizeCroppedImage_Cam3_4);

                MeasureHoles_Cam3_4 = new HDevProcedure(Program, "Function_A0670_MeasurementHolesPositionAndDiameter");
                MeasureHoles_Cam3_4_Call = new HDevProcedureCall(MeasureHoles_Cam3_4);

                PrepareImageForProcessing_Cam5 = new HDevProcedure(Program, "Function_A0670_PrepareImageCam5ForProcessing");
                PrepareImageForProcessing_Cam5_Call = new HDevProcedureCall(PrepareImageForProcessing_Cam5);

                PrepareImageForProcessing_Cam6 = new HDevProcedure(Program, "Function_A0670_PrepareImageCam6ForProcessing");
                PrepareImageForProcessing_Cam6_Call = new HDevProcedureCall(PrepareImageForProcessing_Cam6);

                WriteResultToFile_Cam = new HDevProcedure(Program, "Function_WriteResultsToFile");
                WriteResultToFile_Call = new HDevProcedureCall(WriteResultToFile_Cam);

                CalibPathGenerator = new HDevProcedure(Program, "Function_A0670_CalibPathGenerator");
                CalibPathGenerator_Call = new HDevProcedureCall(CalibPathGenerator);

                ReadExternalOrInternalParametersFromFractionalResults = new HDevProcedure(Program, "Function_A0670_ReadExternalOrInternalParametersFromFractionalResults");
                ReadExternalOrInternalParametersFromFractionalResults_Call = new HDevProcedureCall(ReadExternalOrInternalParametersFromFractionalResults);

                MapImage = new HDevProcedure(Program, "Function_A0670_MapImage");
                MapImage_Call = new HDevProcedureCall(MapImage);

                PrepareImageCam7Cam8ForProcessing = new HDevProcedure(Program, "Function_A0670_PrepareImageCam7Cam8ForProcessing");
                PrepareImageCam7Cam8ForProcessing_Call = new HDevProcedureCall(PrepareImageCam7Cam8ForProcessing);

                ResizeCroppedImageAccordingBoardSizeFromRecipe_COPY_1 = new HDevProcedure(Program, "Function_A0675_ResizeCroppedImageAccordingBoardSizeFromRecipe_COPY_1");
                ResizeCroppedImageAccordingBoardSizeFromRecipe_COPY_1_Call = new HDevProcedureCall(ResizeCroppedImageAccordingBoardSizeFromRecipe_COPY_1);

                MeasurementHolesPositionAndDiameter_COPY_1 = new HDevProcedure(Program, "Function_A0670_MeasurementHolesPositionAndDiameter_COPY_1");
                MeasurementHolesPositionAndDiameter_COPY_1_Call = new HDevProcedureCall(MeasurementHolesPositionAndDiameter_COPY_1);

                PrepareImageCam1Cam2ForProcessing = new HDevProcedure(Program, "Function_A0670_PrepareImageCam1Cam2ForProcessing");
                PrepareImageCam1Cam2ForProcessing_Call = new HDevProcedureCall(PrepareImageCam1Cam2ForProcessing);

                ResultsEvaluation = new HDevProcedure(Program, "Function_ResultsEvaluation");
                ResultsEvaluation_Call = new HDevProcedureCall(ResultsEvaluation);
            }

            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }
        }
        public void ResultsEvaluationFunc(
             HTuple h_realRecipeThickessOfBoardMm,
           HTuple  h_realRecipeLengthOfBoardMm,
           HTuple h_realRecipeWidthOfBoardMm,
           HTuple h_real_arrXPositionMmFromDrawing,
          HTuple h_real_arrYPositionMmFromDrawing,
            HTuple h_real_arrDiameterMmFromDrawing,
            HTuple h_real_arrXPositionMmFromMeasurement,
           HTuple  h_real_arrYPositionMmFromMeasurement,
           HTuple  h_real_arrDiameterMmFromMeasurement,
           HTuple  h_realTolerancePositionPlusMinusMm,
           HTuple  h_realToleranceDiameterPlusMinusMm, 
          out HTuple h_int_arrXPositionOutOfLimit,
            out HTuple h_int_arrYPositionOutOfLimit,
            out HTuple h_int_arrDiameterOutOfLimit,
            out HTuple h_int_arrPositionDiameterResult,
            out HTuple h_mix_arrException)
        {
            ResultsEvaluation_Call.SetInputCtrlParamTuple("h_realRecipeThickessOfBoardMm", h_realRecipeThickessOfBoardMm);
            ResultsEvaluation_Call.SetInputCtrlParamTuple("h_realRecipeLengthOfBoardMm", h_realRecipeLengthOfBoardMm);
            ResultsEvaluation_Call.SetInputCtrlParamTuple("h_realRecipeWidthOfBoardMm", h_realRecipeWidthOfBoardMm);
            ResultsEvaluation_Call.SetInputCtrlParamTuple("h_real_arrXPositionMmFromDrawing", h_real_arrXPositionMmFromDrawing);
            ResultsEvaluation_Call.SetInputCtrlParamTuple("h_real_arrYPositionMmFromDrawing", h_real_arrYPositionMmFromDrawing);
            ResultsEvaluation_Call.SetInputCtrlParamTuple("h_real_arrDiameterMmFromDrawing", h_real_arrDiameterMmFromDrawing);
            ResultsEvaluation_Call.SetInputCtrlParamTuple("h_real_arrXPositionMmFromMeasurement", h_real_arrXPositionMmFromMeasurement);
            ResultsEvaluation_Call.SetInputCtrlParamTuple("h_real_arrYPositionMmFromMeasurement", h_real_arrYPositionMmFromMeasurement);
            ResultsEvaluation_Call.SetInputCtrlParamTuple("h_real_arrDiameterMmFromMeasurement", h_real_arrDiameterMmFromMeasurement);
            ResultsEvaluation_Call.SetInputCtrlParamTuple("h_realTolerancePositionPlusMinusMm", h_realTolerancePositionPlusMinusMm);
            ResultsEvaluation_Call.SetInputCtrlParamTuple("h_realToleranceDiameterPlusMinusMm", h_realToleranceDiameterPlusMinusMm);
            ResultsEvaluation_Call.Execute();
            h_int_arrXPositionOutOfLimit = ResultsEvaluation_Call.GetOutputCtrlParamTuple("h_int_arrXPositionOutOfLimit");
            h_int_arrYPositionOutOfLimit = ResultsEvaluation_Call.GetOutputCtrlParamTuple("h_int_arrYPositionOutOfLimit");
            h_int_arrDiameterOutOfLimit = ResultsEvaluation_Call.GetOutputCtrlParamTuple("h_int_arrDiameterOutOfLimit");
            h_int_arrPositionDiameterResult = ResultsEvaluation_Call.GetOutputCtrlParamTuple("h_int_arrPositionDiameterResult");
            h_mix_arrException = ResultsEvaluation_Call.GetOutputCtrlParamTuple("h_mix_arrException");
        }


        public void PrepareImageCam1Cam2ForProcessingFunc(
            HObject h_img_bImageCam1Cam2Top,
            out HObject h_img_bImageCam1Cam2ForProcessing,
            out HObject h_img_bImageCam1Cam2Cropped,
            HTuple h_intSurfaceTypeFromDrawing,
            out HTuple h_realLeftTopCornerRowPix,
            out HTuple h_realLeftTopCornerColumnPix,
            out HTuple h_realRightBottomCornerRowPix,
            out HTuple h_realRightBottomCornerColumnPix,
            out HTuple h_mix_arrException)
        {
            PrepareImageCam1Cam2ForProcessing_Call.SetInputIconicParamObject("h_img_bImageCam1Cam2Top", h_img_bImageCam1Cam2Top);
            PrepareImageCam1Cam2ForProcessing_Call.SetInputCtrlParamTuple("h_intSurfaceTypeFromDrawing", h_intSurfaceTypeFromDrawing);
            PrepareImageCam1Cam2ForProcessing_Call.Execute();
            h_img_bImageCam1Cam2ForProcessing = PrepareImageCam1Cam2ForProcessing_Call.GetOutputIconicParamObject("h_img_bImageCam1Cam2ForProcessing");
            h_img_bImageCam1Cam2Cropped = PrepareImageCam1Cam2ForProcessing_Call.GetOutputIconicParamObject("h_img_bImageCam1Cam2Cropped");
            h_realLeftTopCornerRowPix = PrepareImageCam1Cam2ForProcessing_Call.GetOutputCtrlParamTuple("h_realLeftTopCornerRowPix");
            h_realLeftTopCornerColumnPix = PrepareImageCam1Cam2ForProcessing_Call.GetOutputCtrlParamTuple("h_realLeftTopCornerColumnPix");
            h_realRightBottomCornerRowPix = PrepareImageCam1Cam2ForProcessing_Call.GetOutputCtrlParamTuple("h_realRightBottomCornerRowPix");
            h_realRightBottomCornerColumnPix = PrepareImageCam1Cam2ForProcessing_Call.GetOutputCtrlParamTuple("h_realRightBottomCornerColumnPix");
            h_mix_arrException = PrepareImageCam1Cam2ForProcessing_Call.GetOutputCtrlParamTuple("h_mix_arrException");
        }


        public void MeasurementHolesPositionAndDiameter_COPY_1Func(
            HObject h_img_bImage0point1Mm,
            out HObject h_reg_arrCircleRegions,
            out HObject h_con_arrCross,
            out HObject h_con_arrContCircle,
            HTuple h_real_arrYPositionMmFromDrawing,
            HTuple h_real_arrXPositionMmFromDrawing,
            HTuple h_real_arrDiameterMmFromDrawing,
            HTuple h_realResizeFactorRegionDiameterForHolesLookingFor,
            HTuple h_realFractionFactorHoleDiameterForScratchRejection,
            out HTuple h_real_arrXPositionMmFromMeasurement,
            out HTuple h_real_arrYPositionMmFromMeasurement,
            out HTuple h_real_arrDiameterMmFromMeasurement,
            out HTuple h_mix_arrException)
        {
            MeasurementHolesPositionAndDiameter_COPY_1_Call.SetInputIconicParamObject("h_img_bImage0point1Mm", h_img_bImage0point1Mm);
            MeasurementHolesPositionAndDiameter_COPY_1_Call.SetInputCtrlParamTuple("h_real_arrYPositionMmFromDrawing", h_real_arrYPositionMmFromDrawing);
            MeasurementHolesPositionAndDiameter_COPY_1_Call.SetInputCtrlParamTuple("h_real_arrXPositionMmFromDrawing", h_real_arrXPositionMmFromDrawing);
            MeasurementHolesPositionAndDiameter_COPY_1_Call.SetInputCtrlParamTuple("h_real_arrDiameterMmFromDrawing", h_real_arrDiameterMmFromDrawing);
            MeasurementHolesPositionAndDiameter_COPY_1_Call.SetInputCtrlParamTuple("h_realResizeFactorRegionDiameterForHolesLookingFor", h_realResizeFactorRegionDiameterForHolesLookingFor);
            MeasurementHolesPositionAndDiameter_COPY_1_Call.SetInputCtrlParamTuple("h_realFractionFactorHoleDiameterForScratchRejection", h_realFractionFactorHoleDiameterForScratchRejection);
            MeasurementHolesPositionAndDiameter_COPY_1_Call.Execute();
            h_reg_arrCircleRegions = MeasurementHolesPositionAndDiameter_COPY_1_Call.GetOutputIconicParamObject("h_reg_arrCircleRegions");
            h_con_arrCross = MeasurementHolesPositionAndDiameter_COPY_1_Call.GetOutputIconicParamObject("h_con_arrCross");
            h_con_arrContCircle = MeasurementHolesPositionAndDiameter_COPY_1_Call.GetOutputIconicParamObject("h_con_arrContCircle");
            h_real_arrXPositionMmFromMeasurement = MeasurementHolesPositionAndDiameter_COPY_1_Call.GetOutputCtrlParamTuple("h_real_arrXPositionMmFromMeasurement");
            h_real_arrYPositionMmFromMeasurement = MeasurementHolesPositionAndDiameter_COPY_1_Call.GetOutputCtrlParamTuple("h_real_arrYPositionMmFromMeasurement");
            h_real_arrDiameterMmFromMeasurement = MeasurementHolesPositionAndDiameter_COPY_1_Call.GetOutputCtrlParamTuple("h_real_arrDiameterMmFromMeasurement");
            h_mix_arrException = MeasurementHolesPositionAndDiameter_COPY_1_Call.GetOutputCtrlParamTuple("h_mix_arrException");
        }

        public void ResizeCroppedImageAccordingBoardSizeFromRecipe_COPY_1Func(
            HObject h_img_bImageCam7Cam8ForProcessing,
            out HObject h_img_bImage0point1Mm,
            HTuple h_realSizeForColumnScaleFactorMm,
            HTuple h_realSizeForRowScaleFactorMm,
            out HTuple h_realColumnScaleFactorMm,
            out HTuple h_realRowScaleFactorMm,
            out HTuple h_mix_realException)
        {
            ResizeCroppedImageAccordingBoardSizeFromRecipe_COPY_1_Call.SetInputIconicParamObject("h_img_bImage", h_img_bImageCam7Cam8ForProcessing);
            ResizeCroppedImageAccordingBoardSizeFromRecipe_COPY_1_Call.SetInputCtrlParamTuple("h_realSizeForColumnScaleFactorMm", h_realSizeForColumnScaleFactorMm);
            ResizeCroppedImageAccordingBoardSizeFromRecipe_COPY_1_Call.SetInputCtrlParamTuple("h_realSizeForRowScaleFactorMm", h_realSizeForRowScaleFactorMm);
            ResizeCroppedImageAccordingBoardSizeFromRecipe_COPY_1_Call.Execute();
            h_img_bImage0point1Mm = ResizeCroppedImageAccordingBoardSizeFromRecipe_COPY_1_Call.GetOutputIconicParamObject("h_img_bImage0point1Mm");
            h_realColumnScaleFactorMm = ResizeCroppedImageAccordingBoardSizeFromRecipe_COPY_1_Call.GetOutputCtrlParamTuple("h_realColumnScaleFactorMm");
            h_realRowScaleFactorMm = ResizeCroppedImageAccordingBoardSizeFromRecipe_COPY_1_Call.GetOutputCtrlParamTuple("h_realRowScaleFactorMm");
            h_mix_realException = ResizeCroppedImageAccordingBoardSizeFromRecipe_COPY_1_Call.GetOutputCtrlParamTuple("h_mix_realException");
        }


        public void PrepareImageCam7Cam8ForProcessingFunc(
            HObject h_img_bImageCam7Cam8FrontMaped,
            out HObject h_img_bImageCam7Cam8ForProcessing,
            out HObject h_img_bImageCam7Cam8Cropped,
            HTuple h_intSurfaceTypeFromDrawing,
            out HTuple h_realLeftTopCornerRowPix,
            out HTuple h_realLeftTopCornerColumnPix,
            out HTuple h_realRightBottomCornerRowPix,
            out HTuple h_realRightBottomCornerColumnPix,
            out HTuple h_mix_arrException)
        {
            PrepareImageCam7Cam8ForProcessing_Call.SetInputIconicParamObject("h_img_bImageCam7Cam8FrontMaped", h_img_bImageCam7Cam8FrontMaped);
            PrepareImageCam7Cam8ForProcessing_Call.SetInputCtrlParamTuple("h_intSurfaceTypeFromDrawing", h_intSurfaceTypeFromDrawing);
            PrepareImageCam7Cam8ForProcessing_Call.Execute();
            h_img_bImageCam7Cam8ForProcessing = PrepareImageCam7Cam8ForProcessing_Call.GetOutputIconicParamObject("h_img_bImageCam7Cam8ForProcessing");
            h_img_bImageCam7Cam8Cropped = PrepareImageCam7Cam8ForProcessing_Call.GetOutputIconicParamObject("h_img_bImageCam7Cam8Cropped");
            h_realLeftTopCornerRowPix = PrepareImageCam7Cam8ForProcessing_Call.GetOutputCtrlParamTuple("h_realLeftTopCornerRowPix");
            h_realLeftTopCornerColumnPix = PrepareImageCam7Cam8ForProcessing_Call.GetOutputCtrlParamTuple("h_realLeftTopCornerColumnPix");
            h_realRightBottomCornerRowPix = PrepareImageCam7Cam8ForProcessing_Call.GetOutputCtrlParamTuple("h_realRightBottomCornerRowPix");
            h_realRightBottomCornerColumnPix = PrepareImageCam7Cam8ForProcessing_Call.GetOutputCtrlParamTuple("h_realRightBottomCornerColumnPix");
            h_mix_arrException = PrepareImageCam7Cam8ForProcessing_Call.GetOutputCtrlParamTuple("h_mix_arrException");
        }


        public void MapImageFunc(
            HObject h_img_bImage,
            out HObject h_img_bImageCam7Cam8FrontMaped,
            out HTuple h_real_arrPose,
            out HTuple h_real_arrCamParam,
            out HTuple h_mix_arrException)
        {
            MapImage_Call.SetInputIconicParamObject("h_img_bImage", h_img_bImage);
            MapImage_Call.Execute();
            h_img_bImageCam7Cam8FrontMaped = MapImage_Call.GetOutputIconicParamObject("h_img_bImageCam7Cam8FrontMaped");
            h_real_arrPose = MapImage_Call.GetOutputCtrlParamTuple("h_real_arrPose");
            h_real_arrCamParam = MapImage_Call.GetOutputCtrlParamTuple("h_real_arrCamParam");
            h_mix_arrException = MapImage_Call.GetOutputCtrlParamTuple("h_mix_arrException");
        }

        public void ReadExternalOrInternalParametersFromFractionalResultsFunc(
            HTuple h_strPathFractionalCalibResults,
            HTuple h_strCameraIDName,
            HTuple h_strTypeFractionalCalibResult,
            HTuple value,
            out HTuple parameter,
            out HTuple h_mix_arrException)
        {

            ReadExternalOrInternalParametersFromFractionalResults_Call.SetInputCtrlParamTuple("h_strPathFractionalCalibResults", h_strPathFractionalCalibResults);
            ReadExternalOrInternalParametersFromFractionalResults_Call.SetInputCtrlParamTuple("h_strCameraIDName", h_strCameraIDName);
            ReadExternalOrInternalParametersFromFractionalResults_Call.SetInputCtrlParamTuple("h_strTypeFractionalCalibResult", h_strTypeFractionalCalibResult);
            ReadExternalOrInternalParametersFromFractionalResults_Call.Execute();
            parameter = ReadExternalOrInternalParametersFromFractionalResults_Call.GetOutputCtrlParamTuple($"{value}");
            h_mix_arrException = ReadExternalOrInternalParametersFromFractionalResults_Call.GetOutputCtrlParamTuple("h_mix_arrException");
        }


        public void CalibPathGeneratorFunc(
            HTuple h_strPathCalib,
            HTuple h_strCameraIDName,
            out HTuple h_strPathCalibPhotos,
            out HTuple h_strPathFractionalCalibResults,
            out HTuple h_strPathCalibrationResultsArchive,
            out HTuple h_strPathCalibPlate,
            out HTuple h_mix_arrException)
        {
            CalibPathGenerator_Call.SetInputCtrlParamTuple("h_strDxfName", h_strPathCalib);
            CalibPathGenerator_Call.SetInputCtrlParamTuple("h_strCameraIDName", h_strCameraIDName);
            CalibPathGenerator_Call.Execute();
            h_strPathCalibPhotos = CalibPathGenerator_Call.GetOutputCtrlParamTuple("h_strPathFractionalCalibResults");
            h_strPathCalibrationResultsArchive = CalibPathGenerator_Call.GetOutputCtrlParamTuple("h_strPathCalibrationResultsArchive");
            h_strPathFractionalCalibResults = CalibPathGenerator_Call.GetOutputCtrlParamTuple("h_strPathFractionalCalibResults");
            h_strPathCalibPlate = CalibPathGenerator_Call.GetOutputCtrlParamTuple("h_strPathCalibPlate");
            h_mix_arrException = CalibPathGenerator_Call.GetOutputCtrlParamTuple("h_mix_arrException");
        }


        public void WriteResultsFunc(
           HTuple h_strDxfName,
          HTuple  h_realRecipeThickessOfBoardMm, 
           HTuple h_realRecipeLengthOfBoardMm, 
           HTuple h_realRecipeWitdhOfBoardMm, 
           HTuple h_real_arrXPositionMmRightFromDrawing, 
           HTuple h_real_arrYPositionMmRightFromDrawing, 
           HTuple h_real_arrDiameterMmRightFromDrawing, 
           HTuple h_real_arrXPositionMmFrontFromDrawing, 
           HTuple h_real_arrYPositionMmFrontFromDrawing, 
           HTuple h_real_arrDiameterMmFrontFromDrawing, 
           HTuple h_real_arrXPositionMmBottomFromDrawing, 
           HTuple h_real_arrYPositionMmBottomFromDrawing, 
           HTuple h_real_arrDiameterMmBottomFromDrawing, 
           HTuple h_real_arrXPositionMmBackFromDrawing, 
           HTuple h_real_arrYPositionMmBackFromDrawing, 
           HTuple h_real_arrDiameterMmBackFromDrawing, 
           HTuple h_real_arrXPositionMmTopFromDrawing, 
           HTuple h_real_arrYPositionMmTopFromDrawing, 
           HTuple h_real_arrDiameterMmTopFromDrawing, 
           HTuple h_real_arrXPositionMmLeftFromDrawing, 
           HTuple h_real_arrYPositionMmLeftFromDrawing, 
           HTuple h_real_arrDiameterMmLeftFromDrawing, 
           HTuple h_real_arrXPositionMmRightFromMeasurement, 
           HTuple h_real_arrYPositionMmRightFromMeasurement, 
           HTuple h_real_arrDiameterMmRightFromMeasurement, 
           HTuple h_real_arrXPositionMmFrontFromMeasurement, 
           HTuple h_real_arrYPositionMmFrontFromMeasurement,
           HTuple h_real_arrDiameterMmFrontFromMeasurement, 
           HTuple h_real_arrXPositionMmBottomFromMeasurement, 
           HTuple h_real_arrYPositionMmBottomFromMeasurement, 
           HTuple h_real_arrDiameterMmBottomFromMeasurement, 
           HTuple h_real_arrXPositionMmBackFromMeasurement, 
           HTuple h_real_arrYPositionMmBackFromMeasurement, 
           HTuple h_real_arrDiameterMmBackFromMeasurement, 
           HTuple h_real_arrXPositionMmTopFromMeasurement, 
           HTuple h_real_arrYPositionMmTopFromMeasurement, 
           HTuple h_real_arrDiameterMmTopFromMeasurement, 
           HTuple h_real_arrXPositionMmLeftFromMeasurement, 
           HTuple h_real_arrYPositionMmLeftFromMeasurement, 
           HTuple h_real_arrDiameterMmLeftFromMeasurement, 
           HTuple h_realTolerancePositionPlusMinusMm, 
           HTuple h_realToleranceDiameterPlusMinusMm, 
          out HTuple h_mix_arrException)
        {
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_strDxfName", h_strDxfName);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_realRecipeThickessOfBoardMm", h_realRecipeThickessOfBoardMm);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_realRecipeLengthOfBoardMm", h_realRecipeLengthOfBoardMm);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_realRecipeWidthOfBoardMm", h_realRecipeWitdhOfBoardMm);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrXPositionMmRightFromDrawing", h_real_arrXPositionMmRightFromDrawing);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrYPositionMmRightFromDrawing", h_real_arrYPositionMmRightFromDrawing);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrDiameterMmRightFromDrawing", h_real_arrDiameterMmRightFromDrawing);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrXPositionMmFrontFromDrawing", h_real_arrXPositionMmFrontFromDrawing);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrYPositionMmFrontFromDrawing", h_real_arrYPositionMmFrontFromDrawing);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrDiameterMmFrontFromDrawing", h_real_arrDiameterMmFrontFromDrawing);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrXPositionMmBottomFromDrawing", h_real_arrXPositionMmBottomFromDrawing);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrYPositionMmBottomFromDrawing", h_real_arrYPositionMmBottomFromDrawing);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrDiameterMmBottomFromDrawing", h_real_arrDiameterMmBottomFromDrawing);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrXPositionMmBackFromDrawing", h_real_arrXPositionMmBackFromDrawing);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrYPositionMmBackFromDrawing", h_real_arrYPositionMmBackFromDrawing);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrDiameterMmBackFromDrawing", h_real_arrDiameterMmBackFromDrawing);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrXPositionMmTopFromDrawing", h_real_arrXPositionMmTopFromDrawing);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrYPositionMmTopFromDrawing", h_real_arrYPositionMmTopFromDrawing);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrDiameterMmTopFromDrawing", h_real_arrDiameterMmTopFromDrawing);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrXPositionMmLeftFromDrawing", h_real_arrXPositionMmLeftFromDrawing);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrYPositionMmLeftFromDrawing", h_real_arrYPositionMmLeftFromDrawing);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrDiameterMmLeftFromDrawing", h_real_arrDiameterMmLeftFromDrawing);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrXPositionMmRightFromMeasurement", h_real_arrXPositionMmRightFromMeasurement);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrYPositionMmRightFromMeasurement", h_real_arrYPositionMmRightFromMeasurement);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrDiameterMmRightFromMeasurement", h_real_arrDiameterMmRightFromMeasurement);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrXPositionMmFrontFromMeasurement", h_real_arrXPositionMmFrontFromMeasurement);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrYPositionMmFrontFromMeasurement", h_real_arrYPositionMmFrontFromMeasurement);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrDiameterMmFrontFromMeasurement", h_real_arrDiameterMmFrontFromMeasurement);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrXPositionMmBottomFromMeasurement", h_real_arrXPositionMmBottomFromMeasurement);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrYPositionMmBottomFromMeasurement", h_real_arrYPositionMmBottomFromMeasurement);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrDiameterMmBottomFromMeasurement", h_real_arrDiameterMmBottomFromMeasurement);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrXPositionMmBackFromMeasurement", h_real_arrXPositionMmBackFromMeasurement);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrYPositionMmBackFromMeasurement", h_real_arrYPositionMmBackFromMeasurement);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrDiameterMmBackFromMeasurement", h_real_arrDiameterMmBackFromMeasurement);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrXPositionMmTopFromMeasurement", h_real_arrXPositionMmTopFromMeasurement);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrYPositionMmTopFromMeasurement", h_real_arrYPositionMmTopFromMeasurement);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrDiameterMmTopFromMeasurement", h_real_arrDiameterMmTopFromMeasurement);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrXPositionMmLeftFromMeasurement", h_real_arrXPositionMmLeftFromMeasurement);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrYPositionMmLeftFromMeasurement", h_real_arrYPositionMmLeftFromMeasurement);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_real_arrDiameterMmLeftFromMeasurement", h_real_arrDiameterMmLeftFromMeasurement);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_realTolerancePositionPlusMinusMm", h_realTolerancePositionPlusMinusMm);
            WriteResultToFile_Call.SetInputCtrlParamTuple("h_realToleranceDiameterPlusMinusMm", h_realToleranceDiameterPlusMinusMm);
            WriteResultToFile_Call.Execute();
            h_mix_arrException = WriteResultToFile_Call.GetOutputCtrlParamTuple("h_mix_arrException");
        }



        public void Function_A0670_PrepareImageForProcessingCam6(
               HObject h_img_bImageCam6Right,
               HTuple h_intSurfaceTypeFromDrawing,
               out HObject h_img_bImageCam6ForProcessing,
               out HObject h_img_bImageCam6Cropped,
               out HTuple h_realLeftTopCornerRowPix,
               out HTuple h_realLeftTopCornerColumnPix,
               out HTuple h_realRightBottomCornerRowPix,
               out HTuple h_realRightBottomCornerColumnPix,
               out HTuple h_mix_arrException
           )
        {
            PrepareImageForProcessing_Cam6_Call.SetInputIconicParamObject("h_img_bImageCam6Right", h_img_bImageCam6Right);
            PrepareImageForProcessing_Cam6_Call.SetInputCtrlParamTuple("h_intSurfaceTypeFromDrawing", h_intSurfaceTypeFromDrawing);
            PrepareImageForProcessing_Cam6_Call.Execute();
            h_img_bImageCam6ForProcessing = PrepareImageForProcessing_Cam6_Call.GetOutputIconicParamObject("h_img_bImageCam6ForProcessing");
            h_img_bImageCam6Cropped = PrepareImageForProcessing_Cam6_Call.GetOutputIconicParamObject("h_img_bImageCam6Cropped");
            h_realLeftTopCornerRowPix = PrepareImageForProcessing_Cam6_Call.GetOutputCtrlParamTuple("h_realLeftTopCornerRowPix");
            h_realLeftTopCornerColumnPix = PrepareImageForProcessing_Cam6_Call.GetOutputCtrlParamTuple("h_realLeftTopCornerColumnPix");
            h_realRightBottomCornerRowPix = PrepareImageForProcessing_Cam6_Call.GetOutputCtrlParamTuple("h_realRightBottomCornerRowPix");
            h_realRightBottomCornerColumnPix = PrepareImageForProcessing_Cam6_Call.GetOutputCtrlParamTuple("h_realRightBottomCornerColumnPix");
            h_mix_arrException = PrepareImageForProcessing_Cam6_Call.GetOutputCtrlParamTuple("h_mix_arrException");
        }
        public void Function_A0670_PrepareImageForProcessingCam5(
               HObject h_img_bImageCam5Left,
               HTuple h_intSurfaceTypeFromDrawing,
               out HObject h_img_bImageCam5ForProcessing,
               out HObject h_img_bImageCam5Cropped,
               out HTuple h_realLeftTopCornerRowPix,
               out HTuple h_realLeftTopCornerColumnPix,
               out HTuple h_realRightBottomCornerRowPix,
               out HTuple h_realRightBottomCornerColumnPix,
               out HTuple h_mix_arrException
           )
        {
            PrepareImageForProcessing_Cam5_Call.SetInputIconicParamObject("h_img_bImageCam5Left", h_img_bImageCam5Left);
            PrepareImageForProcessing_Cam5_Call.SetInputCtrlParamTuple("h_intSurfaceTypeFromDrawing", h_intSurfaceTypeFromDrawing);
            PrepareImageForProcessing_Cam5_Call.Execute();
            h_img_bImageCam5ForProcessing = PrepareImageForProcessing_Cam5_Call.GetOutputIconicParamObject("h_img_bImageCam5ForProcessing");
            h_img_bImageCam5Cropped = PrepareImageForProcessing_Cam5_Call.GetOutputIconicParamObject("h_img_bImageCam5Cropped");
            h_realLeftTopCornerRowPix = PrepareImageForProcessing_Cam5_Call.GetOutputCtrlParamTuple("h_realLeftTopCornerRowPix");
            h_realLeftTopCornerColumnPix = PrepareImageForProcessing_Cam5_Call.GetOutputCtrlParamTuple("h_realLeftTopCornerColumnPix");
            h_realRightBottomCornerRowPix = PrepareImageForProcessing_Cam5_Call.GetOutputCtrlParamTuple("h_realRightBottomCornerRowPix");
            h_realRightBottomCornerColumnPix = PrepareImageForProcessing_Cam5_Call.GetOutputCtrlParamTuple("h_realRightBottomCornerColumnPix");
            h_mix_arrException = PrepareImageForProcessing_Cam5_Call.GetOutputCtrlParamTuple("h_mix_arrException");
        }


        public void Function_CreateImageCamL_ImageCamRfromImageCam(
             HObject h_img_bImage,
            out HObject h_img_bImageL,
            out HObject h_img_bImageR,
            out HTuple h_mix_arrException)
        {
            CreateTwoImagesFromOne_Cam3_4_Call.SetInputIconicParamObject("h_img_bImage", h_img_bImage);
            CreateTwoImagesFromOne_Cam3_4_Call.Execute();
            h_img_bImageL = CreateTwoImagesFromOne_Cam3_4_Call.GetOutputIconicParamObject("h_img_bImageL");
            h_img_bImageR = CreateTwoImagesFromOne_Cam3_4_Call.GetOutputIconicParamObject("h_img_bImageR");
            h_mix_arrException = CreateTwoImagesFromOne_Cam3_4_Call.GetOutputCtrlParamTuple("h_mix_arrException");
        }

        public void Function_TileImagesFromCam3_4(
                HObject h_img_bImageL,
                HObject h_img_bImageR,
                HTuple h_realJointPointLPix,
                HTuple h_realJointPointRPix,
                HTuple h_realAngleCamerasSlopeDeg,
                out HObject h_img_bTiledImage
            )
        {
            TileTwoImagesFromOne_Cam3_4_Call.SetInputIconicParamObject("h_img_bImageL", h_img_bImageL);
            TileTwoImagesFromOne_Cam3_4_Call.SetInputIconicParamObject("h_img_bImageR", h_img_bImageR);
            TileTwoImagesFromOne_Cam3_4_Call.SetInputCtrlParamTuple("h_realJointPointLPix", h_realJointPointLPix);
            TileTwoImagesFromOne_Cam3_4_Call.SetInputCtrlParamTuple("h_realJointPointRPix", h_realJointPointRPix);
            TileTwoImagesFromOne_Cam3_4_Call.SetInputCtrlParamTuple("h_realAngleCamerasSlopeDeg", h_realAngleCamerasSlopeDeg);
            TileTwoImagesFromOne_Cam3_4_Call.Execute();
            h_img_bTiledImage = TileTwoImagesFromOne_Cam3_4_Call.GetOutputIconicParamObject("h_img_bTiledImage");
        }

        public void Function_A0670_PrepareImageForProcessingCam3_4(
                HObject h_img_bImageCam3Cam4Bottom,
                HTuple h_intSurfaceTypeFromDrawing,
                out HObject h_img_bImageCam3Cam4ForProcessing,
                out HObject h_img_bImageCam3Cam4Cropped,
                out HTuple h_realLeftTopCornerRowPix,
                out HTuple h_realLeftTopCornerColumnPix,
                out HTuple h_realRightBottomCornerRowPix,
                out HTuple h_realRightBottomCornerColumnPix,
                out HTuple h_mix_arrException
            )
        {
            PrepareImageForProcessing_Cam3_4_Call.SetInputIconicParamObject("h_img_bImageCam3Cam4Bottom", h_img_bImageCam3Cam4Bottom);
            PrepareImageForProcessing_Cam3_4_Call.SetInputCtrlParamTuple("h_intSurfaceTypeFromDrawing", h_intSurfaceTypeFromDrawing);
            PrepareImageForProcessing_Cam3_4_Call.Execute();
            h_img_bImageCam3Cam4ForProcessing = PrepareImageForProcessing_Cam3_4_Call.GetOutputIconicParamObject("h_img_bImageCam3Cam4ForProcessing");
            h_img_bImageCam3Cam4Cropped = PrepareImageForProcessing_Cam3_4_Call.GetOutputIconicParamObject("h_img_bImageCam3Cam4Cropped");
            h_realLeftTopCornerRowPix = PrepareImageForProcessing_Cam3_4_Call.GetOutputCtrlParamTuple("h_realLeftTopCornerRowPix");
            h_realLeftTopCornerColumnPix = PrepareImageForProcessing_Cam3_4_Call.GetOutputCtrlParamTuple("h_realLeftTopCornerColumnPix");
            h_realRightBottomCornerRowPix = PrepareImageForProcessing_Cam3_4_Call.GetOutputCtrlParamTuple("h_realRightBottomCornerRowPix");
            h_realRightBottomCornerColumnPix = PrepareImageForProcessing_Cam3_4_Call.GetOutputCtrlParamTuple("h_realRightBottomCornerColumnPix");
            h_mix_arrException = PrepareImageForProcessing_Cam3_4_Call.GetOutputCtrlParamTuple("h_mix_arrException");
        }

        public void Function_A0675_ResizeCroppedImageAccordingBoardSizeFromRecipeCam(
                HObject h_img_bImage,
                HTuple h_realSizeForColumnScaleFactorMm,
                HTuple h_realSizeForRowScaleFactorMm,
                out HObject h_img_bImage0point1Mm,
                out HTuple h_realColumnScaleFactorMm,
                out HTuple h_realRowScaleFactorMm,
                out HTuple h_mix_realException
            )
        {
            ResizeCroppedImage_Cam3_4_Call.SetInputIconicParamObject("h_img_bImage", h_img_bImage);
            ResizeCroppedImage_Cam3_4_Call.SetInputCtrlParamTuple("h_realSizeForColumnScaleFactorMm", h_realSizeForColumnScaleFactorMm);
            ResizeCroppedImage_Cam3_4_Call.SetInputCtrlParamTuple("h_realSizeForRowScaleFactorMm", h_realSizeForRowScaleFactorMm);
            ResizeCroppedImage_Cam3_4_Call.Execute();
            h_img_bImage0point1Mm = ResizeCroppedImage_Cam3_4_Call.GetOutputIconicParamObject("h_img_bImage0point1Mm");
            h_realColumnScaleFactorMm = ResizeCroppedImage_Cam3_4_Call.GetOutputCtrlParamTuple("h_realColumnScaleFactorMm");
            h_realRowScaleFactorMm = ResizeCroppedImage_Cam3_4_Call.GetOutputCtrlParamTuple("h_realRowScaleFactorMm");
            h_mix_realException = ResizeCroppedImage_Cam3_4_Call.GetOutputCtrlParamTuple("h_mix_realException");
        }
        public void Function_A0670_MeasurementHolesPositionAndDiameterCam(
                HObject h_img_bImage0point1Mm,
                HTuple h_real_arrXPositionMmFromDrawing,
                HTuple h_real_arrYPositionMmFromDrawing,
                HTuple h_real_arrDiameterMmFromDrawing,
                HTuple h_realResizeFactorRegionDiameterForHolesLookingFor,
                HTuple h_realFractionFactorHoleDiameterForScratchRejection,
                out HObject h_reg_arrCircleRegions,
                out HObject h_con_arrCross,
                out HObject h_con_arrContCircle,
                out HTuple h_real_arrXPositionMmFromMeasurement,
                out HTuple h_real_arrYPositionMmFromMeasurement,
                out HTuple h_real_arrDiameterMmFromMeasurement,
                out HTuple h_mix_arrException
            )
        {
            MeasureHoles_Cam3_4_Call.SetInputIconicParamObject("h_img_bImage0point1Mm", h_img_bImage0point1Mm);
            MeasureHoles_Cam3_4_Call.SetInputCtrlParamTuple("h_real_arrXPositionMmFromDrawing", h_real_arrXPositionMmFromDrawing);
            MeasureHoles_Cam3_4_Call.SetInputCtrlParamTuple("h_real_arrYPositionMmFromDrawing", h_real_arrYPositionMmFromDrawing);
            MeasureHoles_Cam3_4_Call.SetInputCtrlParamTuple("h_real_arrDiameterMmFromDrawing", h_real_arrDiameterMmFromDrawing);
            MeasureHoles_Cam3_4_Call.SetInputCtrlParamTuple("h_realResizeFactorRegionDiameterForHolesLookingFor", h_realResizeFactorRegionDiameterForHolesLookingFor);
            MeasureHoles_Cam3_4_Call.SetInputCtrlParamTuple("h_realFractionFactorHoleDiameterForScratchRejection", h_realFractionFactorHoleDiameterForScratchRejection);
            MeasureHoles_Cam3_4_Call.Execute();
            h_reg_arrCircleRegions = MeasureHoles_Cam3_4_Call.GetOutputIconicParamObject("h_reg_arrCircleRegions");
            h_con_arrCross = MeasureHoles_Cam3_4_Call.GetOutputIconicParamObject("h_con_arrCross");
            h_con_arrContCircle = MeasureHoles_Cam3_4_Call.GetOutputIconicParamObject("h_con_arrContCircle");
            h_real_arrXPositionMmFromMeasurement = MeasureHoles_Cam3_4_Call.GetOutputCtrlParamTuple("h_real_arrXPositionMmFromMeasurement");
            h_real_arrYPositionMmFromMeasurement = MeasureHoles_Cam3_4_Call.GetOutputCtrlParamTuple("h_real_arrYPositionMmFromMeasurement");
            h_real_arrDiameterMmFromMeasurement = MeasureHoles_Cam3_4_Call.GetOutputCtrlParamTuple("h_real_arrDiameterMmFromMeasurement");
            h_mix_arrException = MeasureHoles_Cam3_4_Call.GetOutputCtrlParamTuple("h_mix_arrException");
        }

        public void Function_PfsParametersModify(
            HTuple h_intSurfaceTypeFromDrawing,
            HTuple h_strCamName,
            HTuple h_intNewExposureTime,
            HTuple h_intNewGain,
            out HTuple h_mix_arrException)
        {
            ChangePfsCamParams_Call.SetInputCtrlParamTuple("h_intSurfaceTypeFromDrawing", h_intSurfaceTypeFromDrawing);
            ChangePfsCamParams_Call.SetInputCtrlParamTuple("h_strCamName", h_strCamName);
            ChangePfsCamParams_Call.SetInputCtrlParamTuple("h_intNewExposureTime", h_intNewExposureTime);
            ChangePfsCamParams_Call.SetInputCtrlParamTuple("h_intNewGain", h_intNewGain);
            ChangePfsCamParams_Call.Execute();
            h_mix_arrException = ChangePfsCamParams_Call.GetOutputCtrlParamTuple("h_mix_arrException");
        }

        public void Function_RecipeWriter(
            HTuple recipeName,
             HTuple h_realTolerancePositionPlusMinusMm,
             HTuple h_realToleranceDiameterPlusMinusMm,
             HTuple h_intMaxAllowedNumberErrorsPosition,
             HTuple h_intMaxAllowedNumberErrorsDiameter,
            HTuple h_realToleranceThicknessPlusMinusMm,
            HTuple h_realToleranceWidthPlusMinusMm,
            HTuple h_realToleranceLengthPlusMinusMm,
             out HTuple h_mix_arrException)
        {
            WriteRecipe_Call.SetInputCtrlParamTuple("h_strDxfName", recipeName);
            WriteRecipe_Call.SetInputCtrlParamTuple("h_realTolerancePositionPlusMinusMm", h_realTolerancePositionPlusMinusMm);
            WriteRecipe_Call.SetInputCtrlParamTuple("h_realToleranceDiameterPlusMinusMm", h_realToleranceDiameterPlusMinusMm);
            WriteRecipe_Call.SetInputCtrlParamTuple("h_intMaxAllowedNumberErrorsPosition", h_intMaxAllowedNumberErrorsPosition);
            WriteRecipe_Call.SetInputCtrlParamTuple("h_intMaxAllowedNumberErrorsDiameter", h_intMaxAllowedNumberErrorsDiameter);
            WriteRecipe_Call.SetInputCtrlParamTuple("h_realToleranceThicknessPlusMinusMm", h_realToleranceThicknessPlusMinusMm);
            WriteRecipe_Call.SetInputCtrlParamTuple("h_realToleranceWidthPlusMinusMm", h_realToleranceWidthPlusMinusMm);
            WriteRecipe_Call.SetInputCtrlParamTuple("h_realToleranceLengthPlusMinusMm", h_realToleranceLengthPlusMinusMm);

            WriteRecipe_Call.Execute();
            h_mix_arrException = WriteRecipe_Call.GetOutputCtrlParamTuple("h_mix_arrException");
        }

        public RecipeVariables Function_RecipeReader(
            HTuple recipeName,
            out HTuple h_realTolerancePositionPlusMinusMm,
            out HTuple h_realToleranceDiameterPlusMinusMm,
            out HTuple h_intMaxAllowedNumberErrorsPosition,
            out HTuple h_intMaxAllowedNumberErrorsDiameter,
            out HTuple h_realToleranceThicknessPlusMinusMm,
            out HTuple h_realToleranceLengthPlusMinusMm,
            out HTuple h_realToleranceWidthPlusMinusMm,
            out HTuple h_mix_arrException)
        {
            ReadRecipe_Call.SetInputCtrlParamTuple("h_strDxfName", recipeName);
            ReadRecipe_Call.Execute();
            h_realTolerancePositionPlusMinusMm = ReadRecipe_Call.GetOutputCtrlParamTuple("h_realTolerancePositionPlusMinusMm");
            h_realToleranceDiameterPlusMinusMm = ReadRecipe_Call.GetOutputCtrlParamTuple("h_realToleranceDiameterPlusMinusMm");
            h_intMaxAllowedNumberErrorsPosition = ReadRecipe_Call.GetOutputCtrlParamTuple("h_intMaxAllowedNumberErrorsPosition");
            h_intMaxAllowedNumberErrorsDiameter = ReadRecipe_Call.GetOutputCtrlParamTuple("h_intMaxAllowedNumberErrorsDiameter");
            h_realToleranceThicknessPlusMinusMm = ReadRecipe_Call.GetOutputCtrlParamTuple("h_realToleranceThicknessPlusMinusMm");
            h_realToleranceLengthPlusMinusMm = ReadRecipe_Call.GetOutputCtrlParamTuple("h_realToleranceLengthPlusMinusMm");
            h_realToleranceWidthPlusMinusMm = ReadRecipe_Call.GetOutputCtrlParamTuple("h_realToleranceWidthPlusMinusMm");
            h_mix_arrException = ReadRecipe_Call.GetOutputCtrlParamTuple("h_mix_arrException");

            if (h_mix_arrException.Length < 1)
            {
                RecipeVariables recipeVariables = new RecipeVariables(
                     recipeName,
                     h_realTolerancePositionPlusMinusMm,
                     h_realToleranceDiameterPlusMinusMm,
                     h_intMaxAllowedNumberErrorsPosition,
                     h_intMaxAllowedNumberErrorsDiameter,
                     h_realToleranceThicknessPlusMinusMm,
                     h_realToleranceLengthPlusMinusMm,
                     h_realToleranceWidthPlusMinusMm);

                return recipeVariables;
            }
            return null;
        }

        public DrawingVariables Function_ReadDrawing(
            HTuple recipeName,
            HTuple h_intOfflineImageProcessing,
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
            out HTuple h_mix_arrException,
            out HTuple h_strDxfName)
        {

            ReadDrawing_Call.SetInputCtrlParamTuple("h_strDxfName", recipeName);
            ReadDrawing_Call.SetInputCtrlParamTuple("h_intOfflineImageProcessing", h_intOfflineImageProcessing);
            ReadDrawing_Call.Execute();
            h_reg_arrRoiMmTopPartSmallHolesForLsCameras = ReadDrawing_Call.GetOutputIconicParamObject("h_reg_arrRoiMmTopPartSmallHolesForLsCameras");
            h_reg_arrRoiMmTopPartLargeHolesForArCameras = ReadDrawing_Call.GetOutputIconicParamObject("h_reg_arrRoiMmTopPartLargeHolesForArCameras");
            h_reg_arrRoiMmBottomPartSmallHolesForLsCameras = ReadDrawing_Call.GetOutputIconicParamObject("h_reg_arrRoiMmBottomPartSmallHolesForLsCameras");
            h_reg_arrRoiMmBottomPartLargeHolesForArCameras = ReadDrawing_Call.GetOutputIconicParamObject("h_reg_arrRoiMmBottomPartLargeHolesForArCameras");
            h_reg_arrRoiMmLeftPartHolesForLsCameras = ReadDrawing_Call.GetOutputIconicParamObject("h_reg_arrRoiMmLeftPartHolesForLsCameras");
            h_reg_arrRoiMmRightPartHolesForLsCameras = ReadDrawing_Call.GetOutputIconicParamObject("h_reg_arrRoiMmRightPartHolesForLsCameras");
            h_reg_arrRoiMmFrontPartHolesForArCameras = ReadDrawing_Call.GetOutputIconicParamObject("h_reg_arrRoiMmFrontPartHolesForArCameras");
            h_reg_arrRoiMmBackPartHolesForArCameras = ReadDrawing_Call.GetOutputIconicParamObject("h_reg_arrRoiMmBackPartHolesForArCameras");
            RegionRight = ReadDrawing_Call.GetOutputIconicParamObject("RegionRight");
            RegionFront = ReadDrawing_Call.GetOutputIconicParamObject("RegionFront");
            RegionBottom = ReadDrawing_Call.GetOutputIconicParamObject("RegionBottom");
            RegionBack = ReadDrawing_Call.GetOutputIconicParamObject("RegionBack");
            RegionTop = ReadDrawing_Call.GetOutputIconicParamObject("RegionTop");
            RegionLeft = ReadDrawing_Call.GetOutputIconicParamObject("RegionLeft");
            CirclesInRegionRight = ReadDrawing_Call.GetOutputIconicParamObject("CirclesInRegionRight");
            CirclesInRegionFront = ReadDrawing_Call.GetOutputIconicParamObject("CirclesInRegionFront");
            CirclesInRegionBottom = ReadDrawing_Call.GetOutputIconicParamObject("CirclesInRegionBottom");
            CirclesInRegionBack = ReadDrawing_Call.GetOutputIconicParamObject("CirclesInRegionBack");
            CirclesInRegionTop = ReadDrawing_Call.GetOutputIconicParamObject("CirclesInRegionTop");
            CirclesInRegionLeft = ReadDrawing_Call.GetOutputIconicParamObject("CirclesInRegionLeft");
            h_intSurfaceTypeFromDrawing = ReadDrawing_Call.GetOutputCtrlParamTuple("h_intSurfaceTypeFromDrawing");
            h_realRecipeLengthOfBoardMm = ReadDrawing_Call.GetOutputCtrlParamTuple("h_realRecipeLengthOfBoardMm");
            h_realRecipeWitdhOfBoardMm = ReadDrawing_Call.GetOutputCtrlParamTuple("h_realRecipeWitdhOfBoardMm");
            h_realRecipeThickessOfBoardMm = ReadDrawing_Call.GetOutputCtrlParamTuple("h_realRecipeThickessOfBoardMm");
            h_real_arrXPositionMmRightFromDrawing = ReadDrawing_Call.GetOutputCtrlParamTuple("h_real_arrXPositionMmRightFromDrawing");
            h_real_arrYPositionMmRightFromDrawing = ReadDrawing_Call.GetOutputCtrlParamTuple("h_real_arrYPositionMmRightFromDrawing");
            h_real_arrDiameterMmRightFromDrawing = ReadDrawing_Call.GetOutputCtrlParamTuple("h_real_arrDiameterMmRightFromDrawing");
            h_real_arrXPositionMmFrontFromDrawing = ReadDrawing_Call.GetOutputCtrlParamTuple("h_real_arrXPositionMmFrontFromDrawing");
            h_real_arrYPositionMmFrontFromDrawing = ReadDrawing_Call.GetOutputCtrlParamTuple("h_real_arrYPositionMmFrontFromDrawing");
            h_real_arrDiameterMmFrontFromDrawing = ReadDrawing_Call.GetOutputCtrlParamTuple("h_real_arrDiameterMmFrontFromDrawing");
            h_real_arrXPositionMmBottomFromDrawing = ReadDrawing_Call.GetOutputCtrlParamTuple("h_real_arrXPositionMmBottomFromDrawing");
            h_real_arrYPositionMmBottomFromDrawing = ReadDrawing_Call.GetOutputCtrlParamTuple("h_real_arrYPositionMmBottomFromDrawing");
            h_real_arrDiameterMmBottomFromDrawing = ReadDrawing_Call.GetOutputCtrlParamTuple("h_real_arrDiameterMmBottomFromDrawing");
            h_real_arrXPositionMmBackFromDrawing = ReadDrawing_Call.GetOutputCtrlParamTuple("h_real_arrXPositionMmBackFromDrawing");
            h_real_arrYPositionMmBackFromDrawing = ReadDrawing_Call.GetOutputCtrlParamTuple("h_real_arrYPositionMmBackFromDrawing");
            h_real_arrDiameterMmBackFromDrawing = ReadDrawing_Call.GetOutputCtrlParamTuple("h_real_arrDiameterMmBackFromDrawing");
            h_real_arrXPositionMmTopFromDrawing = ReadDrawing_Call.GetOutputCtrlParamTuple("h_real_arrXPositionMmTopFromDrawing");
            h_real_arrYPositionMmTopFromDrawing = ReadDrawing_Call.GetOutputCtrlParamTuple("h_real_arrYPositionMmTopFromDrawing");
            h_real_arrDiameterMmTopFromDrawing = ReadDrawing_Call.GetOutputCtrlParamTuple("h_real_arrDiameterMmTopFromDrawing");
            h_real_arrXPositionMmLeftFromDrawing = ReadDrawing_Call.GetOutputCtrlParamTuple("h_real_arrXPositionMmLeftFromDrawing");
            h_real_arrYPositionMmLeftFromDrawing = ReadDrawing_Call.GetOutputCtrlParamTuple("h_real_arrYPositionMmLeftFromDrawing");
            h_real_arrDiameterMmLeftFromDrawing = ReadDrawing_Call.GetOutputCtrlParamTuple("h_real_arrDiameterMmLeftFromDrawing");
            h_strDxfName = recipeName;
            h_mix_arrException = ReadDrawing_Call.GetOutputCtrlParamTuple("h_mix_arrException");

            if (h_mix_arrException.Length < 1)
            {
                DrawingVariables drawingVariables = new DrawingVariables(
               h_reg_arrRoiMmTopPartSmallHolesForLsCameras,
               h_reg_arrRoiMmTopPartLargeHolesForArCameras,
               h_reg_arrRoiMmBottomPartSmallHolesForLsCameras,
               h_reg_arrRoiMmBottomPartLargeHolesForArCameras,
               h_reg_arrRoiMmLeftPartHolesForLsCameras,
               h_reg_arrRoiMmRightPartHolesForLsCameras,
               h_reg_arrRoiMmFrontPartHolesForArCameras,
               h_reg_arrRoiMmBackPartHolesForArCameras,
               RegionRight,
               RegionFront,
               RegionBottom,
               RegionBack,
               RegionTop,
               RegionLeft,
               CirclesInRegionRight,
               CirclesInRegionFront,
               CirclesInRegionBottom,
               CirclesInRegionBack,
               CirclesInRegionTop,
               CirclesInRegionLeft,
               h_intSurfaceTypeFromDrawing,
               h_realRecipeLengthOfBoardMm,
               h_realRecipeWitdhOfBoardMm,
               h_realRecipeThickessOfBoardMm,
               h_real_arrXPositionMmRightFromDrawing,
               h_real_arrYPositionMmRightFromDrawing,
               h_real_arrDiameterMmRightFromDrawing,
               h_real_arrXPositionMmFrontFromDrawing,
               h_real_arrYPositionMmFrontFromDrawing,
               h_real_arrDiameterMmFrontFromDrawing,
               h_real_arrXPositionMmBottomFromDrawing,
               h_real_arrYPositionMmBottomFromDrawing,
               h_real_arrDiameterMmBottomFromDrawing,
               h_real_arrXPositionMmBackFromDrawing,
               h_real_arrYPositionMmBackFromDrawing,
               h_real_arrDiameterMmBackFromDrawing,
               h_real_arrXPositionMmTopFromDrawing,
               h_real_arrYPositionMmTopFromDrawing,
               h_real_arrDiameterMmTopFromDrawing,
               h_real_arrXPositionMmLeftFromDrawing,
               h_real_arrYPositionMmLeftFromDrawing,
               h_real_arrDiameterMmLeftFromDrawing,
               h_strDxfName);
                return drawingVariables;
            }
            return null;
        }
    }
}
