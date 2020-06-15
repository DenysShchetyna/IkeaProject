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
        public static string JsonPersistenCamSettingsPath = @"C:\Trifid\IKEA\IkeaProject\Ikea\Ikea_Library\Helpers\json1.json";



        public static string ConnectionStringId = "Ikea";

        public static string ImagesDiscC = "C";
        public static string ImagesDiscD = "D";
        public static string ImagesDiscE = "E";

        public static string ImagesFolderPath = @"C:\Trifid\IKEA\SavedImages";
        public static int DiscManagementDays = 90; // older files will be deleted
        public static int DiscManagementGigabytes = 20;

        //all camera names
        public static List<string> CameraNames = new List<string>()
        {
            "Cam1",
            "Cam2",
            "Cam3",
            "Cam4",
            "Cam5",
            "Cam6",
            "Cam7",
            "Cam8",
            "Cam9",
            "Cam10",
            "Cam11",
            "Cam12",
            "Cam13",
            "Cam14",
        };

        public static string SqliteUsersDatabasePath = @"Data Source = C:\Trifid\Ikea\IkeaProject\Ikea\Users.db";
    }
}
