﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library.Helpers
{
    public class GlobalVariables
    {
        public static string HalconEvaluationPath = @"C:\Trifid\Poject ikea\ImageAquisition\FindHoles.hdev";

        public static string ConnectionStringId = "Ikea";

        public static string ImagesDiscC = "C";
        public static string ImagesDiscD = "D";
        public static string ImagesDiscE = "E";

        public static string ImagesFolderPath = @"C:\Trifid\Poject ikea\SavedImages";
        public static int DiscManagementDays = 90; // older files will be deleted
        public static int DiscManagementGigabytes = 20;

    }
}
