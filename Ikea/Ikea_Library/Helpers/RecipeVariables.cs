using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library.Helpers
{
    public class RecipeVariables
    {
        public string RecipeName { get; set; }
        public string RecipeToleranceDiameter { get; set; }
        public  string RecipeTolerancePosition { get; set; }
        public  string RecipeMaxPositionError { get; set; }
        public  string RecipeMaxDiameterError { get; set; }

        public RecipeVariables(
                HTuple recipeName,
                HTuple h_realTolerancePositionPlusMinusMm,
                HTuple h_realToleranceDiameterPlusMinusMm,
                HTuple h_intMaxAllowedNumberErrorsPosition,
                HTuple h_intMaxAllowedNumberErrorsDiameter)
        {
            RecipeName = recipeName;
            RecipeToleranceDiameter = h_realToleranceDiameterPlusMinusMm.D.ToString();
            RecipeTolerancePosition = h_realTolerancePositionPlusMinusMm.D.ToString();
            RecipeMaxPositionError = h_intMaxAllowedNumberErrorsPosition.D.ToString();
            RecipeMaxDiameterError = h_intMaxAllowedNumberErrorsDiameter.D.ToString();
        }

    }
}
