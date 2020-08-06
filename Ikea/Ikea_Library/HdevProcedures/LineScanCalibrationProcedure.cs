using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library.HdevProcedures
{
    public class LineScanCalibrationProcedure
    {
        string ProgramPath = @"C:\Trifid\A0670\SW\Halcon\A0670_HolesInspectionSystem.hdev";

        HDevProgram Program;
        HDevProcedure LineScanCalibration;
        HDevProcedureCall LineScanCalibration_Call;
        public LineScanCalibrationProcedure()
        {
            Initialization();
        }

        private void Initialization()
        {
            Program = new HDevProgram(ProgramPath);

            LineScanCalibration = new HDevProcedure(Program, "Function_LineScanCalibration");
            LineScanCalibration_Call = new HDevProcedureCall(LineScanCalibration);
        }

        public void Function_LineScanCalibration(
            HTuple h_strCamName,
            out HTuple h_realXResolutionMmPerIncrementalPulsCam1LsTopL,
            out HTuple h_realYResolutionMmPerPixCam1LsTopL,
            out HTuple h_real_arrCamParamCam1LsTopL,
            out HTuple h_real_arrPoseCam1LsTopL)
        {
            LineScanCalibration_Call.SetInputCtrlParamTuple("h_strCamName", h_strCamName);
            LineScanCalibration_Call.Execute();
            h_realXResolutionMmPerIncrementalPulsCam1LsTopL =  LineScanCalibration_Call.GetOutputCtrlParamTuple("h_realXResolutionMmPerIncrementalPulsCam1LsTopL");
            h_realYResolutionMmPerPixCam1LsTopL = LineScanCalibration_Call.GetOutputCtrlParamTuple("h_realYResolutionMmPerPixCam1LsTopL");
            h_real_arrCamParamCam1LsTopL = LineScanCalibration_Call.GetOutputCtrlParamTuple("h_real_arrCamParamCam1LsTopL");
            h_real_arrPoseCam1LsTopL = LineScanCalibration_Call.GetOutputCtrlParamTuple("h_real_arrPoseCam1LsTopL");
        }
    }
}
