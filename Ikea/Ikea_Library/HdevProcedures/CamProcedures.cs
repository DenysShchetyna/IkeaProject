using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library.HdevProcedures
{
    public class CamProcedures
    {
        HDevProgram Program;

        HDevProcedureCall OpenFramegrabber_Call;
        HDevProcedureCall CloseFramegrabber_Call;
        HDevProcedureCall SetFramegrabberParameter_Call;
        HDevProcedureCall GetFramegrabberParameter_Call;

        public CamProcedures(string programPath)
        {
            Program = new HDevProgram(programPath);

            Initialization();
        }
        public void Initialization()
        {
            HDevProcedure OpenFrameGrabber = new HDevProcedure(Program, "OpenFramegrabber");
            OpenFramegrabber_Call = new HDevProcedureCall(OpenFrameGrabber);

            HDevProcedure CloseFramegrabber = new HDevProcedure(Program, "CloseFramegrabber");
            CloseFramegrabber_Call = new HDevProcedureCall(CloseFramegrabber);

            HDevProcedure SetFramegrabberParameter = new HDevProcedure(Program, "SetFramegrabberParameter");
            SetFramegrabberParameter_Call = new HDevProcedureCall(SetFramegrabberParameter);

            HDevProcedure GetFramegrabberParameter = new HDevProcedure(Program, "GetFramegrabberParameter");
            GetFramegrabberParameter_Call = new HDevProcedureCall(GetFramegrabberParameter);

        }
        public void OpenFramegrabber(HTuple cameraName, HTuple width, HTuple height, HTuple exposureTime, HTuple gain, out HTuple acqHandle)
        {
            OpenFramegrabber_Call.SetInputCtrlParamTuple("cameraName", cameraName);
            OpenFramegrabber_Call.SetInputCtrlParamTuple("Width", width);
            OpenFramegrabber_Call.SetInputCtrlParamTuple("Height", height);
            OpenFramegrabber_Call.SetInputCtrlParamTuple("ExposureTimeAbs", exposureTime);
            OpenFramegrabber_Call.SetInputCtrlParamTuple("Gain", gain);

            OpenFramegrabber_Call.Execute();
            acqHandle = OpenFramegrabber_Call.GetOutputCtrlParamTuple("AcqHandle");
        }

        public void CloseFramegrabber(HTuple acqHandle)
        {
            CloseFramegrabber_Call.SetInputCtrlParamTuple("acqHandle", acqHandle);
            CloseFramegrabber_Call.Execute();
        }

        public void SetFramegrabberParameter(HTuple acqHandle, HTuple parameter, HTuple value)
        {
            SetFramegrabberParameter_Call.SetInputCtrlParamTuple("acqHandle", acqHandle);
            SetFramegrabberParameter_Call.SetInputCtrlParamTuple("parameter", parameter);
            SetFramegrabberParameter_Call.SetInputCtrlParamTuple("value", value);
            SetFramegrabberParameter_Call.Execute();
        }

        public void GetFramegrabberParameter(HTuple acqHandle, HTuple parameter, out HTuple value)
        {
            GetFramegrabberParameter_Call.SetInputCtrlParamTuple("acqHandle", acqHandle);
            GetFramegrabberParameter_Call.SetInputCtrlParamTuple("parameter", parameter);
            GetFramegrabberParameter_Call.Execute();
            value = GetFramegrabberParameter_Call.GetOutputCtrlParamTuple("value");
        }
    }
}