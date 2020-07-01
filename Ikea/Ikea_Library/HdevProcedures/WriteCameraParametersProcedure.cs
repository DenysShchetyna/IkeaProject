using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;

namespace Ikea_Library.HdevProcedures
{
    public class WriteCameraParametersProcedure
    {
        HDevProgram Program;
        HDevProcedure LFunction_PfsWriteCameraParameters;
        HDevProcedureCall LFunction_PfsWriteCameraParameters_Call;

        public WriteCameraParametersProcedure(string path)
        {
            Program = new HDevProgram(path);
            Initialize();
        }
        private void Initialize()
        {
            LFunction_PfsWriteCameraParameters = new HDevProcedure(Program, "LFunction_PfsWriteCameraParameters");
            LFunction_PfsWriteCameraParameters_Call = new HDevProcedureCall(LFunction_PfsWriteCameraParameters);
        }
        public void LFunction_PfsWriteCameraParameters_Func(HTuple h_strCamName, HTuple h_strPfsPath, out HTuple exception)
        {
            LFunction_PfsWriteCameraParameters_Call.SetInputCtrlParamTuple("h_strCamName", h_strCamName);
            LFunction_PfsWriteCameraParameters_Call.SetInputCtrlParamTuple("h_strPfsPath", h_strPfsPath);
            LFunction_PfsWriteCameraParameters_Call.Execute();
            exception =  LFunction_PfsWriteCameraParameters_Call.GetOutputCtrlParamTuple("Exception");
        }
    }
}
