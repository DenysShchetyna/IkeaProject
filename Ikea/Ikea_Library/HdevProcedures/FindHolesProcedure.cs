using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library.HdevProcedures
{
    class FindHolesProcedure
    {
        private HDevProgram Program;
        private HDevProcedureCall Function_A0670_HolesDetectionAndMeasureViaLaserScannerMethod_Call;

        public FindHolesProcedure(string programPath)
        {
            Program = new HDevProgram(programPath);
            Initialize();
        }

        private void Initialize()
        {
            HDevProcedure function_A0670_HolesDetectionAndMeasureViaLaserScannerMethod = new HDevProcedure("Function_A0670_HolesDetectionAndMeasureViaLaserScannerMethod");
            Function_A0670_HolesDetectionAndMeasureViaLaserScannerMethod_Call = new HDevProcedureCall(function_A0670_HolesDetectionAndMeasureViaLaserScannerMethod);
        }

        public void Function_A0670_HolesDetectionAndMeasureViaLaserScannerMethod(
           HTuple h_img_b_arrImageLaserLine,
           HTuple h_reg_arrRoiTopPartLargeHolesForArCameras,
           HTuple h_intOfflineProcessing,
           HTuple h_realXResolutionMmPerIncrementalPuls,
           HTuple h_realYResolutionMmPerPix,
           out HTuple h_int_arrHoleNumber,
           out HTuple h_real_arrXpositionHolePix,
           out HTuple h_real_arrYpositionHolePix,
           out HTuple h_real_arrDiameterXaxesHolePix,
           out HTuple h_real_arrDiameterYaxesHolePix,
           out HTuple h_real_arrDistanceHoleEdgesPix,
           out HTuple h_real_arrPositionHolePix,
           out HTuple h_realDurationMs,
           out HTuple h_mix_arrException)
        {
            Function_A0670_HolesDetectionAndMeasureViaLaserScannerMethod_Call.SetInputCtrlParamTuple("h_img_b_arrImageLaserLine", h_img_b_arrImageLaserLine);
            Function_A0670_HolesDetectionAndMeasureViaLaserScannerMethod_Call.SetInputCtrlParamTuple("h_reg_arrRoiTopPartLargeHolesForArCameras", h_reg_arrRoiTopPartLargeHolesForArCameras);
            Function_A0670_HolesDetectionAndMeasureViaLaserScannerMethod_Call.SetInputCtrlParamTuple("h_intOfflineProcessing", h_intOfflineProcessing);
            Function_A0670_HolesDetectionAndMeasureViaLaserScannerMethod_Call.SetInputCtrlParamTuple("h_realXResolutionMmPerIncrementalPuls", h_realXResolutionMmPerIncrementalPuls);
            Function_A0670_HolesDetectionAndMeasureViaLaserScannerMethod_Call.SetInputCtrlParamTuple("h_realYResolutionMmPerPix", h_realYResolutionMmPerPix);
            Function_A0670_HolesDetectionAndMeasureViaLaserScannerMethod_Call.Execute();
            h_int_arrHoleNumber = Function_A0670_HolesDetectionAndMeasureViaLaserScannerMethod_Call.GetOutputCtrlParamTuple("h_int_arrHoleNumber");
            h_real_arrXpositionHolePix = Function_A0670_HolesDetectionAndMeasureViaLaserScannerMethod_Call.GetOutputCtrlParamTuple("h_real_arrXpositionHolePix");
            h_real_arrYpositionHolePix = Function_A0670_HolesDetectionAndMeasureViaLaserScannerMethod_Call.GetOutputCtrlParamTuple("h_real_arrYpositionHolePix");
            h_real_arrDiameterXaxesHolePix = Function_A0670_HolesDetectionAndMeasureViaLaserScannerMethod_Call.GetOutputCtrlParamTuple("h_real_arrDiameterXaxesHolePix");
            h_real_arrDiameterYaxesHolePix = Function_A0670_HolesDetectionAndMeasureViaLaserScannerMethod_Call.GetOutputCtrlParamTuple("h_real_arrDiameterYaxesHolePix");
            h_real_arrDistanceHoleEdgesPix = Function_A0670_HolesDetectionAndMeasureViaLaserScannerMethod_Call.GetOutputCtrlParamTuple("h_real_arrDistanceHoleEdgesPix");
            h_real_arrPositionHolePix = Function_A0670_HolesDetectionAndMeasureViaLaserScannerMethod_Call.GetOutputCtrlParamTuple("h_real_arrPositionHolePix");
            h_realDurationMs = Function_A0670_HolesDetectionAndMeasureViaLaserScannerMethod_Call.GetOutputCtrlParamTuple("h_realDurationMs");
            h_mix_arrException = Function_A0670_HolesDetectionAndMeasureViaLaserScannerMethod_Call.GetOutputCtrlParamTuple("h_mix_arrException");
        }
    }
}
