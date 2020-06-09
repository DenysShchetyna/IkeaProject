using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;

namespace Ikea_Library.HDevProcedures
{
    public class HDevProc
    {
        HDevProgram Program;

        HDevProcedure FindHole;
        HDevProcedureCall FindHole_Call;

        public HDevProc(string path)
        {
            Program = new HDevProgram(path);
            InitializeProcedures();
        }

        private void InitializeProcedures()
        {
            FindHole = new HDevProcedure(Program, "FindHole");
            FindHole_Call = new HDevProcedureCall(FindHole);
        }

        public void FindHoleFunc(HObject image, out HTuple rows, out HTuple columns, out HTuple radius)
        {
            FindHole_Call.SetInputIconicParamObject("Image", image);
            FindHole_Call.Execute();
            rows = FindHole_Call.GetOutputCtrlParamTuple("Rows");
            columns = FindHole_Call.GetOutputCtrlParamTuple("Columns");
            radius = FindHole_Call.GetOutputCtrlParamTuple("Radius");
        }
    }
}
