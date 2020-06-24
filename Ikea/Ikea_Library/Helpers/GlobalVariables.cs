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
        public static string HalconEvaluationPath = @"C:\Trifid\IKEA\ImageAquisition\FindHoles.hdev";
        public static string CameraProcedures = @"C:\Trifid\IKEA\ImageAquisition\Halcon test cam.hdev";
        public static string SaveImagesPath = @"C:\Trifid\IKEA\SavedImages\";
        public static string JsonPersistentCamSettingsPath = @"C:\Trifid\IKEA\IkeaProject\Ikea\Ikea_Library\Helpers\json1.json";



        public static string ConnectionStringId = "Ikea";

        public static string ImagesDiscC = "C";
        public static string ImagesDiscD = "D";
        public static string ImagesDiscE = "E";

        public static string ImagesFolderPath = @"C:\Trifid\IKEA\SavedImages";
        public static int DiscManagementDays = 90; // older files will be deleted
        public static int DiscManagementGigabytes = 20;

        //all camera names
        public static List<string> CameraAdresses = new List<string>()
        {
            "192.168.20.203",
            "192.168.20.203",
            "192.168.20.203",
            "192.168.20.203",
            "192.168.20.203",
            "192.168.20.203",
            "192.168.20.203",
            "192.168.20.203",
            "192.168.20.203",
            "192.168.20.203",
            "192.168.20.203",
            "192.168.20.203",
            "192.168.20.203",
            "192.168.20.203",
        };

        public static string SqliteUsersDatabasePath = @"Data Source = C:\Trifid\Ikea\IkeaProject\Ikea\Users.db";
        public static string DrawingsPath = @"C:/Trifid/IKEA/Vykresy";
    }
}
