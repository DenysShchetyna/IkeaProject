using HalconDotNet;
using Ikea_Library.HdevProcedures;
using Ikea_Library.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library.Utilities
{
    public class CameraDefaultSettings
    {
        public static void SetCameraDefaultSettingsFromFile(string path, string recipe)
        {
            Parallel.Invoke(() =>
            {
                try
                {

                    WriteCameraParametersProcedure Cam1LsTopLParametersFilePath110 = new WriteCameraParametersProcedure(path);
                    Cam1LsTopLParametersFilePath110.LFunction_PfsWriteCameraParameters_Func("Cam1LsTopL", recipe, out HTuple exception1);
                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam1LsTopL", "|OK|");

                    WriteCameraParametersProcedure Cam2LsTopRParametersFilePath110 = new WriteCameraParametersProcedure(path);
                    Cam2LsTopRParametersFilePath110.LFunction_PfsWriteCameraParameters_Func("Cam2LsTopR", recipe, out HTuple exception2);
                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam2LsTopR", "|OK|");


                    //WriteCameraParametersProcedure Cam3 = new WriteCameraParametersProcedure(path);
                    //Cam3.LFunction_PfsWriteCameraParameters_Func("Cam3LsBottomL", recipe, out HTuple exception1);
                    //Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam3LsBottomL", "|OK|");


                    //WriteCameraParametersProcedure Cam4 = new WriteCameraParametersProcedure(path);
                    //Cam4.LFunction_PfsWriteCameraParameters_Func("Cam4LsBottomR", recipe, out HTuple exception2);
                    //Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam4LsBottomR", "|OK|");


                    //WriteCameraParametersProcedure Cam5 = new WriteCameraParametersProcedure(path);
                    //Cam5.LFunction_PfsWriteCameraParameters_Func("Cam5LsLeft", recipe, out HTuple exception5);
                    //Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam5", "|OK|");


                    //WriteCameraParametersProcedure Cam6 = new WriteCameraParametersProcedure(path);
                    //Cam6.LFunction_PfsWriteCameraParameters_Func("Cam6LsRight", recipe, out HTuple exception6);
                    //Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam6", "|OK|");


                    //WriteCameraParametersProcedure Cam7ArFrontLParametersFilePath110 = new WriteCameraParametersProcedure(path);
                    //Cam7ArFrontLParametersFilePath110.LFunction_PfsWriteCameraParameters_Func("Cam7ArFrontL", recipe, out HTuple exception7);
                    //Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam7ArFrontL", "|OK|");


                    //WriteCameraParametersProcedure Cam8ArFrontParametersFilePath = new WriteCameraParametersProcedure(path);
                    //Cam8ArFrontParametersFilePath.LFunction_PfsWriteCameraParameters_Func("Cam8ArFrontR", recipe, out HTuple exception8);
                    //Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam8ArFrontR", "|OK|");


                    //WriteCameraParametersProcedure Cam9 = new WriteCameraParametersProcedure(path);
                    //Cam9.LFunction_PfsWriteCameraParameters_Func("Cam9ArBackL", recipe, out HTuple exception7);
                    //Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam9ArBackL", "|OK|");


                    //WriteCameraParametersProcedure Cam10 = new WriteCameraParametersProcedure(path);
                    //Cam10.LFunction_PfsWriteCameraParameters_Func("Cam10ArBackR", recipe, out HTuple exception8);
                    //Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam10ArBackR", "|OK|");


                    //WriteCameraParametersProcedure Cam11 = new WriteCameraParametersProcedure(path);
                    //Cam11.LFunction_PfsWriteCameraParameters_Func("Cam11ArTopL", recipe, out HTuple exception7);
                    //Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam11ArTopL", "|OK|");


                    //WriteCameraParametersProcedure Cam12 = new WriteCameraParametersProcedure(path);
                    //Cam12.LFunction_PfsWriteCameraParameters_Func("Cam12ArTopR", recipe, out HTuple exception8);
                    //Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam12ArTopR", "|OK|");


                    WriteCameraParametersProcedure Cam13 = new WriteCameraParametersProcedure(path);
                    Cam13.LFunction_PfsWriteCameraParameters_Func("Cam13ArBottomL", recipe, out HTuple exception13);
                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam13ArBottomL", "|OK|");

                    WriteCameraParametersProcedure Cam14 = new WriteCameraParametersProcedure(path);
                    Cam14.LFunction_PfsWriteCameraParameters_Func("Cam14ArBottomR", recipe, out HTuple exception14);
                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for camera Cam14ArBottomR", "|OK|");


                }

                catch (Exception ex)
                {
                    Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                }
            });
        }
    }
}
