using HalconDotNet;
using Ikea_Library.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ikea_Library.HdevProcedures
{
    public class ReadDrawingsProcedure
    {
        HDevProgram Program;
        HDevProcedure ReadDrawing;
        HDevProcedureCall ReadDrawing_Call;
        readonly string ProcedurePath = @"C:\Trifid\IKEA\ImageAquisition\read_dxf_v03.hdev";
        
        private string CheckIfDrawingExist(string recipeName)
        {
            List<string> allDrawings = Directory.GetFiles(GlobalVariables.DrawingsPath).ToList();
            for (int i = 0; i < allDrawings.Count; i++)
            {
                if (allDrawings[i].Contains(recipeName) == true)
                {
                    return allDrawings[i];
                }
            }

            return null;
        }
        private bool InitializeProcedures()
        {
            bool ok;
            try
            {
                Program = new HDevProgram(ProcedurePath);
                ReadDrawing = new HDevProcedure(Program, "Function_ReadDrawing");
                ReadDrawing_Call = new HDevProcedureCall(ReadDrawing);
                ok = true;
            }

            catch (Exception ex)
            {
                ok = false;
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }

            return ok;
        }

        public void Function_ReadDrawing(string recipeName, out HXLD ContoursRead, out HXLD Cross)
        {
            ContoursRead = null;
            Cross = null;

            try
            {
                bool ok = InitializeProcedures();
                string drawingPath = CheckIfDrawingExist(recipeName);


                if (ok == true && drawingPath != null)
                {
                    ReadDrawing_Call.SetInputCtrlParamTuple("DrawingPath", drawingPath);
                    ReadDrawing_Call.Execute();
                    ContoursRead = ReadDrawing_Call.GetOutputIconicParamXld("ContoursRead");
                    Cross = ReadDrawing_Call.GetOutputIconicParamXld("Cross");
                }
            }

            catch(Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }
        }

        
    }
}
