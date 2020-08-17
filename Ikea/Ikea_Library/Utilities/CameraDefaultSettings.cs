using HalconDotNet;
using Ikea_Library.HdevProcedures;
using Ikea_Library.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ikea_Library.Utilities
{
    public class CameraDefaultSettings
    {


        public static void SetoneCameraDefaultSettingsFromFile(string procedurePath, string camName, DrawingVariables drawingVariables)
        {
            WriteCameraParametersProcedure camera = new WriteCameraParametersProcedure(procedurePath);
            camera.LFunction_PfsWriteCameraParameters_Func(camName, drawingVariables.IntSurfaceTypeFromDrawing, out HTuple h_mix_arrException);
            Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, $"Default setting for camera {camName}", "|OK|");
        }

        public static void SetAllCamerasDefaultSettingsFromFile(string path, DrawingVariables drawingVariables)
        {
            try
            {
                //if (drawingVariables.Real_arrXPositionMmTopFromDrawing.Length > 0)
                //{
                //    WriteCameraParametersProcedure Cam1 = new WriteCameraParametersProcedure(path);
                //    Cam1.LFunction_PfsWriteCameraParameters_Func("Cam1LsTopL", drawingVariables.IntSurfaceTypeFromDrawing, out HTuple exception1);
                //    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam1LsTopL", "|OK|");

                //    WriteCameraParametersProcedure Cam2 = new WriteCameraParametersProcedure(path);
                //    Cam2.LFunction_PfsWriteCameraParameters_Func("Cam2LsTopR", drawingVariables.IntSurfaceTypeFromDrawing, out HTuple exception2);
                //    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam2LsTopR", "|OK|");

                //    WriteCameraParametersProcedure Cam11 = new WriteCameraParametersProcedure(path);
                //    Cam11.LFunction_PfsWriteCameraParameters_Func("Cam11ArTopL", drawingVariables.IntSurfaceTypeFromDrawing, out HTuple exception11);
                //    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam11ArTopL", "|OK|");


                //    WriteCameraParametersProcedure Cam12 = new WriteCameraParametersProcedure(path);
                //    Cam12.LFunction_PfsWriteCameraParameters_Func("Cam12ArTopR", drawingVariables.IntSurfaceTypeFromDrawing, out HTuple exception12);
                //    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam12ArTopR", "|OK|");
                //}

                //if (drawingVariables.Real_arrXPositionMmBottomFromDrawing.Length > 0)
                //{
                //    WriteCameraParametersProcedure Cam3 = new WriteCameraParametersProcedure(path);
                //    Cam3.LFunction_PfsWriteCameraParameters_Func("Cam3LsBottomL", drawingVariables.IntSurfaceTypeFromDrawing, out HTuple exception3);
                //    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam3LsBottomL", "|OK|");

                //    WriteCameraParametersProcedure Cam4 = new WriteCameraParametersProcedure(path);
                //    Cam4.LFunction_PfsWriteCameraParameters_Func("Cam4LsBottomR", drawingVariables.IntSurfaceTypeFromDrawing, out HTuple exception4);
                //    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam4LsBottomR", "|OK|");

                //    WriteCameraParametersProcedure Cam13 = new WriteCameraParametersProcedure(path);
                //    Cam13.LFunction_PfsWriteCameraParameters_Func("Cam13ArBottomL", drawingVariables.IntSurfaceTypeFromDrawing, out HTuple exception13);
                //    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam13ArBottomL", "|OK|");

                //    WriteCameraParametersProcedure Cam14 = new WriteCameraParametersProcedure(path);
                //    Cam14.LFunction_PfsWriteCameraParameters_Func("Cam14ArBottomR", drawingVariables.IntSurfaceTypeFromDrawing, out HTuple exception14);
                //    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam14ArBottomR", "|OK|");
                //}

                //if (drawingVariables.Real_arrXPositionMmLeftFromDrawing.Length > 0)
                //{
                //    WriteCameraParametersProcedure Cam5 = new WriteCameraParametersProcedure(path);
                //    Cam5.LFunction_PfsWriteCameraParameters_Func("Cam5LsLeft", drawingVariables.IntSurfaceTypeFromDrawing, out HTuple exception5);
                //    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam5LsLeft", "|OK|");

                //}

                //if (drawingVariables.Real_arrXPositionMmRightFromDrawing.Length > 0)
                //{
                //    WriteCameraParametersProcedure Cam6 = new WriteCameraParametersProcedure(path);
                //    Cam6.LFunction_PfsWriteCameraParameters_Func("Cam6LsRight", drawingVariables.IntSurfaceTypeFromDrawing, out HTuple exception6);
                //    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam6LsRight", "|OK|");
                //}

                //if (drawingVariables.Real_arrXPositionMmFrontFromDrawing.Length > 0)
                //{
                //    WriteCameraParametersProcedure Cam7 = new WriteCameraParametersProcedure(path);
                //    Cam7.LFunction_PfsWriteCameraParameters_Func("Cam7ArFrontL", drawingVariables.IntSurfaceTypeFromDrawing, out HTuple exception7);
                //    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam7ArFrontL", "|OK|");


                //    WriteCameraParametersProcedure Cam8 = new WriteCameraParametersProcedure(path);
                //    Cam8.LFunction_PfsWriteCameraParameters_Func("Cam8ArFrontR", drawingVariables.IntSurfaceTypeFromDrawing, out HTuple exception8);
                //    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam8ArFrontR", "|OK|");

                //}

                //if (drawingVariables.Real_arrXPositionMmBackFromDrawing.Length > 0)
                //{
                //    WriteCameraParametersProcedure Cam9 = new WriteCameraParametersProcedure(path);
                //    Cam9.LFunction_PfsWriteCameraParameters_Func("Cam9ArBackL", drawingVariables.IntSurfaceTypeFromDrawing, out HTuple exception9);
                //    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam9ArBackL", "|OK|");


                //    WriteCameraParametersProcedure Cam10 = new WriteCameraParametersProcedure(path);
                //    Cam10.LFunction_PfsWriteCameraParameters_Func("Cam10ArBackR", drawingVariables.IntSurfaceTypeFromDrawing, out HTuple exception10);
                //    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam10ArBackR", "|OK|");
                //}
            }

            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }
        }
    }
}
