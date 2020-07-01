using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library
{
    public class RecipeVariables
    {
        public static double TolerancePosition { get; set; }
        public static double ToleranceDiameter { get; set; }
        public static double MaxPositionErrors { get; set; }
        public static double MaxDiameterErrors { get; set; }

        public static void ReadRecipeValues(string path)
        {
            if(File.Exists(path) == true)
            {
                List<string> allLines = File.ReadAllLines(path).ToList();
                TolerancePosition = Convert.ToDouble(allLines[1]);
                ToleranceDiameter = Convert.ToDouble(allLines[3]);
                MaxPositionErrors = Convert.ToDouble(allLines[5]);
                MaxDiameterErrors = Convert.ToDouble(allLines[7]);
            }
        }
    }
}
