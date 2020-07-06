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
        public static string HalconEvaluationPath = @"C:\Trifid\A0670\SW\C#\IKEA\ImageAquisition\FindHoles.hdev";
        public static string CameraProcedures = @"C:\Trifid\A0670\SW\C#\IKEA\ImageAquisition\Halcon test cam.hdev";
        public static string SaveImagesPath = @"C:\Trifid\A0670\SW\C#\IKEA\SavedImages\";
        public static string SavedImagesFromProgramPath = @"C:\Trifid\A0670\SW\C#\IKEA\SavedImagesFromProgram";

        public static string JsonPersistentCamSettingsPath = @"C:\Trifid\A0670\SW\C#\IKEA\IkeaProject\Ikea\Ikea_Library\Helpers\CameraSettings.json";

        public static string SqliteUsersDatabasePath = @"Data Source = C:\Trifid\A0670\SW\C#\IKEA\IkeaProject\Ikea\Users.db";
        public static string DrawingsPath = @"C:\Trifid\A0670\SW\Halcon\Drawings";
        public static string RecipesPath = @"C:\Trifid\A0670\SW\Halcon\Recipes\";

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
            "192.168.20.203",
            "192.168.20.204",
            "192.168.20.205",
            "192.168.10.203",
            "192.168.10.203",
            "192.168.10.203",
            "192.168.10.203",
            "192.168.10.203",
            "192.168.10.203",
            "192.168.10.203",
            "192.168.10.203",
            "192.168.10.203",
            "192.168.10.203",
            "192.168.10.203",
        };

        public static string SetCamParameteresPFSFilePath = @"C:\Trifid\A0670\SW\C#\IKEA\ProceduryHALCON\LFunction_PfsWriteCameraParameters.hdev";
        public static string Cam1LsTopLParametersFilePath = @"C:\Trifid\A0670\SW\C#\IKEA\ImageAquisition\CIC-4000_22534176.pfs";
    }
}
