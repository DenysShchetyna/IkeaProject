using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library.Helpers
{
    public static class JsonFunctions
    {
        public static PersistentVariables ReadJsonFunc(string path)
        {
            string textFromJason = File.ReadAllText(GlobalVariables.JsonPersistenCamSettingsPath);
            return JsonConvert.DeserializeObject<PersistentVariables>(textFromJason);
        }

        public static void WriteJsonFunc(PersistentVariables persistentVariables)
        {
            string jsonString = JsonConvert.SerializeObject(persistentVariables);
            File.WriteAllText(GlobalVariables.JsonPersistenCamSettingsPath, jsonString);
        }

        public static void CamExposureTimeSet(PersistentVariables persistentVariables, string cameraName, int value)
        {
            switch (cameraName)
            {
                case "Cam1":
                    persistentVariables.ExposureTimeCam1 = value;
                    break;

                case "Cam2":
                    persistentVariables.ExposureTimeCam2 = value;
                    break;

                case "Cam3":
                    persistentVariables.ExposureTimeCam3 = value;
                    break;

                case "Cam4":
                    persistentVariables.ExposureTimeCam4 = value;
                    break;

                case "Cam5":
                    persistentVariables.ExposureTimeCam5 = value;
                    break;

                case "Cam6":
                    persistentVariables.ExposureTimeCam6 = value;
                    break;

                case "Cam7":
                    persistentVariables.ExposureTimeCam7 = value;
                    break;

                case "Cam8":
                    persistentVariables.ExposureTimeCam8 = value;
                    break;

                case "Cam9":
                    persistentVariables.ExposureTimeCam9 = value;
                    break;

                case "Cam10":
                    persistentVariables.ExposureTimeCam10 = value;
                    break;

                case "Cam11":
                    persistentVariables.ExposureTimeCam11 = value;
                    break;

                case "Cam12":
                    persistentVariables.ExposureTimeCam12 = value;
                    break;

                case "Cam13":
                    persistentVariables.ExposureTimeCam13 = value;
                    break;

                case "Cam14":
                    persistentVariables.ExposureTimeCam14 = value;
                    break;
            }

            WriteJsonFunc(persistentVariables);
        }

        public static void CamGainSet(PersistentVariables persistentVariables, string cameraName, int value)
        {
            switch (cameraName)
            {
                case "Cam1":
                    persistentVariables.GainCam1 = value;
                    break;

                case "Cam2":
                    persistentVariables.GainCam2 = value;
                    break;

                case "Cam3":
                    persistentVariables.GainCam3 = value;
                    break;

                case "Cam4":
                    persistentVariables.GainCam4 = value;
                    break;

                case "Cam5":
                    persistentVariables.GainCam5 = value;
                    break;

                case "Cam6":
                    persistentVariables.GainCam6 = value;
                    break;

                case "Cam7":
                    persistentVariables.GainCam7 = value;
                    break;

                case "Cam8":
                    persistentVariables.GainCam8 = value;
                    break;

                case "Cam9":
                    persistentVariables.GainCam9 = value;
                    break;

                case "Cam10":
                    persistentVariables.GainCam10 = value;
                    break;

                case "Cam11":
                    persistentVariables.GainCam11 = value;
                    break;

                case "Cam12":
                    persistentVariables.GainCam12 = value;
                    break;

                case "Cam13":
                    persistentVariables.GainCam13 = value;
                    break;

                case "Cam14":
                    persistentVariables.GainCam14 = value;
                    break;
            }
            WriteJsonFunc(persistentVariables);

        }
    }


}
