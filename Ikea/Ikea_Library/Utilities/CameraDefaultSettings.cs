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
        public static void SetCameraDefaultSettingsFromFile(string path)
        {
            try
            {
                WriteCameraParametersProcedure writeCameraParametersProcedureCam1LsTopL = new WriteCameraParametersProcedure(path);
                writeCameraParametersProcedureCam1LsTopL.LFunction_PfsWriteCameraParameters_Func("Cam1LsTopL", GlobalVariables.Cam1LsTopLParametersFilePath, out HTuple exception);
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, "Default setting for cameras", "|OK|");

            }

            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }
           }
    }
}
