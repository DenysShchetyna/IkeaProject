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
    public class ReadDrawingsProcedure
    {
        HDevProgram Program;
        HDevProcedure ReadDrawing;
        HDevProcedureCall ReadDrawing_Call;
        string ProgramPath = @"C:\Trifid\IKEA\ImageAquisition\Function_DrawingReader.hdev";

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

        public ReadDrawingsProcedure()
        {
            InitializeProcedures();
        }
        private bool InitializeProcedures()
        {
            bool ok;
            try
            {
                Program = new HDevProgram(ProgramPath);
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

        public void Function_ReadDrawing(
            string recipeName,
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
            out HObject ContourOnlyFromCircles,
            out HTuple Recipe_LengthOfBoardMm,
            out HTuple Recipe_WitdhOfBoardMm,
            out HTuple Recipe_ThickessOfBoardMm,
            out HTuple h_mix_arrException)
        {
                ReadDrawing_Call.SetInputCtrlParamTuple("h_strDxfPath", recipeName);
                ReadDrawing_Call.Execute();
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
            ContourOnlyFromCircles = ReadDrawing_Call.GetOutputIconicParamObject("ContourOnlyFromCircles");
                Recipe_WitdhOfBoardMm = ReadDrawing_Call.GetOutputCtrlParamTuple("Recipe_WitdhOfBoardMm");
                Recipe_ThickessOfBoardMm = ReadDrawing_Call.GetOutputCtrlParamTuple("Recipe_ThickessOfBoardMm");
                Recipe_LengthOfBoardMm = ReadDrawing_Call.GetOutputCtrlParamTuple("Recipe_LengthOfBoardMm");
                h_mix_arrException = ReadDrawing_Call.GetOutputCtrlParamTuple("h_mix_arrException");

            //catch (Exception ex)
            //{
            //    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            //}
        }


    }
}
