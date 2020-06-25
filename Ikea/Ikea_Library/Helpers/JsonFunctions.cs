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
            string textFromJason = File.ReadAllText(GlobalVariables.JsonPersistentCamSettingsPath);
            return JsonConvert.DeserializeObject<PersistentVariables>(textFromJason);
        }

        public static void WriteJsonFunc(PersistentVariables persistentVariables)
        {
            string jsonString = JsonConvert.SerializeObject(persistentVariables);
            File.WriteAllText(GlobalVariables.JsonPersistentCamSettingsPath, jsonString);
        }

        public static void CamExposureTimeSet(PersistentVariables persistentVariables, string cameraName, int value)
        {
            switch (cameraName)
            {
                case "Cam1LsTopL":
                    persistentVariables.ExposureTimeCam1LsTopL = value;
                    break;

                case "Cam2LsTopR":
                    persistentVariables.ExposureTimeCam2LsTopR = value;
                    break;

                case "Cam3LsBottomL":
                    persistentVariables.ExposureTimeCam3LsBottomL = value;
                    break;

                case "Cam4LsBottomR":
                    persistentVariables.ExposureTimeCam4LsBottomR = value;
                    break;

                case "Cam5LsLeft":
                    persistentVariables.ExposureTimeCam5LsLeft = value;
                    break;

                case "Cam6LsRight":
                    persistentVariables.ExposureTimeCam6LsRight = value;
                    break;

                case "Cam7ArFrontL":
                    persistentVariables.ExposureTimeCam7ArFrontL = value;
                    break;

                case "Cam8ArFrontR":
                    persistentVariables.ExposureTimeCam8ArFrontR = value;
                    break;

                case "Cam9ArRearL":
                    persistentVariables.ExposureTimeCam9ArRearL = value;
                    break;

                case "Cam10ArRearR":
                    persistentVariables.ExposureTimeCam10ArRearR = value;
                    break;

                case "Cam11ArTopL":
                    persistentVariables.ExposureTimeCam11ArTopL = value;
                    break;

                case "Cam12ArTopR":
                    persistentVariables.ExposureTimeCam12ArTopR = value;
                    break;

                case "Cam13ArBottomL":
                    persistentVariables.ExposureTimeCam13ArBottomL = value;
                    break;

                case "Cam14ArBottomR":
                    persistentVariables.ExposureTimeCam14ArBottomR = value;
                    break;
            }

            WriteJsonFunc(persistentVariables);
        }

        public static void CamGainSet(PersistentVariables persistentVariables, string cameraName, int value)
        {
            switch (cameraName)
            {
                case "Cam1LsTopL":
                    persistentVariables.GainCam1LsTopL = value;
                    break;

                case "Cam2LsTopR":
                    persistentVariables.GainCam2LsTopR = value;
                    break;

                case "Cam3LsBottomL":
                    persistentVariables.GainCam3LsBottomL = value;
                    break;

                case "Cam4LsBottomR":
                    persistentVariables.GainCam4LsBottomR = value;
                    break;

                case "Cam5LsLeft":
                    persistentVariables.GainCam5LsLeft = value;
                    break;

                case "Cam6LsRight":
                    persistentVariables.GainCam6LsRight = value;
                    break;

                case "Cam7ArFrontL":
                    persistentVariables.GainCam7ArFrontL = value;
                    break;

                case "Cam8ArFrontR":
                    persistentVariables.GainCam8ArFrontR = value;
                    break;

                case "Cam9ArRearL":
                    persistentVariables.GainCam9ArRearL = value;
                    break;

                case "Cam10ArRearR":
                    persistentVariables.GainCam10ArRearR = value;
                    break;

                case "Cam11ArTopL":
                    persistentVariables.GainCam11ArTopL = value;
                    break;

                case "Cam12ArTopR":
                    persistentVariables.GainCam12ArTopR = value;
                    break;

                case "Cam13ArBottomL":
                    persistentVariables.GainCam13ArBottomL = value;
                    break;

                case "Cam14ArBottomR":
                    persistentVariables.GainCam14ArBottomR = value;
                    break;
            }
            WriteJsonFunc(persistentVariables);

        }
    }


}
