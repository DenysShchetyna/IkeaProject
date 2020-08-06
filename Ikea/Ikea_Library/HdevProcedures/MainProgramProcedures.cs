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
        string ProgramPath = @"C:\Trifid\A0670\SW\Halcon\A0670_HolesInspectionSystem.hdev";

        HDevProgram Program;
        HDevProcedure ReadDrawing;
        HDevProcedureCall ReadDrawing_Call;

        HDevProcedure ReadRecipe;
        HDevProcedureCall ReadRecipe_Call;

        HDevProcedure WriteRecipe;
        HDevProcedureCall WriteRecipe_Call;

        HDevProcedure ChangePfsCamParams;
        HDevProcedureCall ChangePfsCamParams_Call;


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
            }

            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }
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
             out HTuple h_mix_arrException)
        {
            WriteRecipe_Call.SetInputCtrlParamTuple("h_strDxfName", recipeName);
            WriteRecipe_Call.SetInputCtrlParamTuple("h_realTolerancePositionPlusMinusMm", h_realTolerancePositionPlusMinusMm);
            WriteRecipe_Call.SetInputCtrlParamTuple("h_realToleranceDiameterPlusMinusMm", h_realToleranceDiameterPlusMinusMm);
            WriteRecipe_Call.SetInputCtrlParamTuple("h_intMaxAllowedNumberErrorsPosition", h_intMaxAllowedNumberErrorsPosition);
            WriteRecipe_Call.SetInputCtrlParamTuple("h_intMaxAllowedNumberErrorsDiameter", h_intMaxAllowedNumberErrorsDiameter);
            WriteRecipe_Call.Execute();
            h_mix_arrException = WriteRecipe_Call.GetOutputCtrlParamTuple("h_mix_arrException");
        }

        public RecipeVariables Function_RecipeReader(
            HTuple recipeName,
            out HTuple h_realTolerancePositionPlusMinusMm,
            out HTuple h_realToleranceDiameterPlusMinusMm,
            out HTuple h_intMaxAllowedNumberErrorsPosition,
            out HTuple h_intMaxAllowedNumberErrorsDiameter,
            out HTuple h_mix_arrException)
        {
            ReadRecipe_Call.SetInputCtrlParamTuple("h_strDxfName", recipeName);
            ReadRecipe_Call.Execute();
            h_realTolerancePositionPlusMinusMm = ReadRecipe_Call.GetOutputCtrlParamTuple("h_realTolerancePositionPlusMinusMm");
            h_realToleranceDiameterPlusMinusMm = ReadRecipe_Call.GetOutputCtrlParamTuple("h_realToleranceDiameterPlusMinusMm");
            h_intMaxAllowedNumberErrorsPosition = ReadRecipe_Call.GetOutputCtrlParamTuple("h_intMaxAllowedNumberErrorsPosition");
            h_intMaxAllowedNumberErrorsDiameter = ReadRecipe_Call.GetOutputCtrlParamTuple("h_intMaxAllowedNumberErrorsDiameter");
            h_mix_arrException = ReadRecipe_Call.GetOutputCtrlParamTuple("h_mix_arrException");

            if (h_mix_arrException.Length < 1)
            {
                RecipeVariables recipeVariables = new RecipeVariables(
                     recipeName,
                     h_realTolerancePositionPlusMinusMm,
                     h_realToleranceDiameterPlusMinusMm,
                     h_intMaxAllowedNumberErrorsPosition,
                     h_intMaxAllowedNumberErrorsDiameter);
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

            out HTuple h_mix_arrException)
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
               h_real_arrDiameterMmLeftFromDrawing);
                return drawingVariables;
            }
            return null;
        }
    }
}
