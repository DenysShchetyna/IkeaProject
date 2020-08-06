using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library.Helpers
{
    public class GlobalVariables
    {
        public static string HalconEvaluationPath = @"C:\Trifid\A0670\SW\C#\IKEA\IkeaProject\FindHoles.hdev";
        public static string CameraProcedures = @"C:\Trifid\A0670\SW\C#\IKEA\IkeaProject\Halcon test cam.hdev";
        public static string SaveImagesPath = @"C:\Trifid\A0670\SW\C#\IKEA\SavedImages\";
        public static string SavedImagesFromProgramPath = @"C:\Trifid\A0670\SW\C#\IKEA\SavedImagesFromProgram";

        public static string JsonPersistentCamSettingsPath = @"C:\Trifid\A0670\SW\C#\IKEA\IkeaProject\Ikea\Ikea_Library\Helpers\CameraSettings.json";

        public static string SqliteUsersDatabasePath = @"Data Source = C:\Trifid\A0670\SW\C#\IKEA\IkeaProject\Ikea\Users.db";
        public static string DrawingsPath = @"C:\Trifid\A0670\SW\Halcon\Drawings";
        public static string RecipesPath = @"C:\Trifid\A0670\SW\Halcon\Recipes\";
        public static string CamPfsFilesPath = @"C:\Trifid\A0670\SW\Halcon\CamParam\";

        public static string ConnectionStringId = "Ikea";

        public static string ImagesDiscC = "C";
        public static string ImagesDiscD = "D";
        public static string ImagesDiscE = "E";

        public static string ImagesFolderPath = @"C:\Trifid\A0670\SW\C#\IKEA\SavedImages";
        public static int DiscManagementDays = 90; // older files will be deleted
        public static int DiscManagementGigabytes = 20;

        //all camera adresses
        public static List<string> CameraAdresses = new List<string>()
        {
            "192.168.10.101",
            "192.168.20.101",
            "192.168.30.101",
            "192.168.40.101",
            "192.168.50.101",
            "192.168.60.101",
            "192.168.70.101",
            "192.168.80.101",
            "192.168.90.101",
            "192.168.100.101",
            "192.168.110.101",
            "192.168.120.101",
            "192.168.130.101",
            "192.168.140.101",
        };



        public static string SetCamParameteresPFSFilePathProcedure = @"C:\Trifid\A0670\SW\Halcon\A0670_HolesInspectionSystem.hdev";

        public static string Cam5LsLeftParametersFilePath110 = @"C:\Trifid\A0670\SW\Halcon\CamParam\Cam5LsLeft110.pfs";
        public static string Cam7ArFrontLParametersFilePath110 = @"C:\Trifid\A0670\SW\Halcon\CamParam\Cam7ArFrontL110.pfs";
        public static string Cam8ArFrontParametersFilePath110 = @"C:\Trifid\A0670\SW\Halcon\CamParam\Cam8ArFrontR110.pfs";




        public static int CurentValueCam1 = 0;
        public static int PreviousValueCam1 = 0;

        public static int CurentValueCam3 = 0;
        public static int PreviousValueCam3 = 0;
        public static bool SaveImageCam3_4 = false;


        public static bool CurentValueCam11_12 = false;
        public static bool PreviousValueCam11_12 = false;

        public static bool CurentValueCam13_14 = false;
        public static bool PreviousValueCam13_14 = false;

        public static bool SaveImageCam7ArFrontL = false;
        public static bool SaveImageCam8ArFrontR = false;


    }
}
