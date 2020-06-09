using HalconDotNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library.Helpers
{
    public class PersistentVariables
    {
        private static string CamerasSettingsPath = @"C:\Trifid\IKEA\IkeaProject\CameraSettings\CamerasSettings.txt";

        public static int ExposureTimeCam1 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[0].Split(',')[0]);
        public static int GainCam1 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[0].Split(',')[1]);

        public static int ExposureTimeCam2 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[1].Split(',')[0]);
        public static int GainCam2 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[1].Split(',')[1]);

        public static int ExposureTimeCam3 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[2].Split(',')[0]);
        public static int GainCam3 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[2].Split(',')[1]);

        public static int ExposureTimeCam4 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[3].Split(',')[0]);
        public static int GainCam4 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[3].Split(',')[1]);

        public static int ExposureTimeCam5 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[4].Split(',')[0]);
        public static int GainCam5 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[4].Split(',')[1]);

        public static int ExposureTimeCam6 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[5].Split(',')[0]);
        public static int GainCam6 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[5].Split(',')[1]);

        public static int ExposureTimeCam7 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[6].Split(',')[0]);
        public static int GainCam7 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[6].Split(',')[1]);

        public static int ExposureTimeCam8 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[7].Split(',')[0]);
        public static int GainCam8 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[7].Split(',')[1]);

        public static int ExposureTimeCam9 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[8].Split(',')[0]);
        public static int GainCam9 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[8].Split(',')[1]);

        public static int ExposureTimeCam10 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[9].Split(',')[0]);
        public static int GainCam10 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[9].Split(',')[1]);

        public static int ExposureTimeCam11 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[10].Split(',')[0]);
        public static int GainCam11 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[10].Split(',')[1]);

        public static int ExposureTimeCam12 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[11].Split(',')[0]);
        public static int GainCam12 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[11].Split(',')[1]);

        public static int ExposureTimeCam13 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[12].Split(',')[0]);
        public static int GainCam13 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[12].Split(',')[1]);

        public static int ExposureTimeCam14 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[13].Split(',')[0]);
        public static int GainCam14 { get; set; } = Convert.ToInt32(File.ReadAllLines(CamerasSettingsPath)[13].Split(',')[1]);


        public static void CamExposureTimeSet(string cameraName, int value)
        {
            switch (cameraName)
            {
                case "Cam1":
                    ExposureTimeCam1 = value;
                    break;

                case "Cam2":
                    ExposureTimeCam2 = value;
                    break;

                case "Cam3":
                    ExposureTimeCam3 = value;
                    break;

                case "Cam4":
                    ExposureTimeCam4 = value;
                    break;

                case "Cam5":
                    ExposureTimeCam5 = value;
                    break;

                case "Cam6":
                    ExposureTimeCam6 = value;
                    break;

                case "Cam7":
                    ExposureTimeCam7 = value;
                    break;

                case "Cam8":
                    ExposureTimeCam8 = value;
                    break;

                case "Cam9":
                    ExposureTimeCam9 = value;
                    break;

                case "Cam10":
                    ExposureTimeCam10 = value;
                    break;

                case "Cam11":
                    ExposureTimeCam11 = value;
                    break;

                case "Cam12":
                    ExposureTimeCam12 = value;
                    break;

                case "Cam13":
                    ExposureTimeCam13 = value;
                    break;

                case "Cam14":
                    ExposureTimeCam14 = value;
                    break;
            }
        }
        public static void CamGainSet(string cameraName, int value)
        {
            switch (cameraName)
            {
                case "Cam1":
                    GainCam1 = value;
                    break;

                case "Cam2":
                    GainCam2 = value;
                    break;

                case "Cam3":
                    GainCam3 = value;
                    break;

                case "Cam4":
                    GainCam4 = value;
                    break;

                case "Cam5":
                    GainCam5 = value;
                    break;

                case "Cam6":
                    GainCam6 = value;
                    break;

                case "Cam7":
                    GainCam7 = value;
                    break;

                case "Cam8":
                    GainCam8 = value;
                    break;

                case "Cam9":
                    GainCam9 = value;
                    break;

                case "Cam10":
                    GainCam10 = value;
                    break;

                case "Cam11":
                    GainCam11 = value;
                    break;

                case "Cam12":
                    GainCam12 = value;
                    break;

                case "Cam13":
                    GainCam13 = value;
                    break;

                case "Cam14":
                    GainCam14 = value;
                    break;
            }
        }
    }
}
