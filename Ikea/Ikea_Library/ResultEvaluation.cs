using HalconDotNet;
using Ikea_Library.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library
{
    public class ResultEvaluation
    {

        public bool ResultEvaluationFunc(Material plank, RecipeVariables recipeVariables,DrawingVariables drawingVariables)
        {
            int badHolesFromPosition = 0;
            int badHolesFromDiameter = 0;

            for (int i = 0; i < plank.DrawingSides.Count; i++)
            {
                for (int j = 0; j < plank.DrawingSides[i].HolesList.Count; j++)
                {
                    switch (plank.DrawingSides[i].SideName)
                    {
                        case "Bottom":
                            HTuple upperLimitXpos = drawingVariables.Real_arrXPositionMmBottomFromDrawing[j].D + Convert.ToDouble(recipeVariables.RecipeTolerancePosition);
                            HTuple upperLimitYpos = drawingVariables.Real_arrYPositionMmBottomFromDrawing[j].D + Convert.ToDouble(recipeVariables.RecipeTolerancePosition);
                            HTuple upperLimitDiameter = drawingVariables.Real_arrDiameterMmBottomFromDrawing[j].D + Convert.ToDouble(recipeVariables.RecipeToleranceDiameter);

                            HTuple lowerLimitXpos = drawingVariables.Real_arrXPositionMmBottomFromDrawing[j].D - Convert.ToDouble(recipeVariables.RecipeTolerancePosition);
                            HTuple lowerLimitYpos = drawingVariables.Real_arrYPositionMmBottomFromDrawing[j].D - Convert.ToDouble(recipeVariables.RecipeTolerancePosition);
                            HTuple lowerLimitDiameter = drawingVariables.Real_arrDiameterMmBottomFromDrawing[j].D - Convert.ToDouble(recipeVariables.RecipeToleranceDiameter);

                            if (plank.DrawingSides[i].HolesList[j].X < lowerLimitXpos
                                || plank.DrawingSides[i].HolesList[j].X >upperLimitXpos
                                || plank.DrawingSides[i].HolesList[j].Y < lowerLimitYpos
                                || plank.DrawingSides[i].HolesList[j].Y > upperLimitYpos)
                            {
                                badHolesFromPosition++;
                            }
                            if(plank.DrawingSides[i].HolesList[j].Diameter < lowerLimitDiameter
                                || plank.DrawingSides[i].HolesList[j].Diameter > upperLimitDiameter)
                            {
                                badHolesFromDiameter++;
                            }

                            break;
                    }
                }
            }

            if (badHolesFromDiameter >= Convert.ToInt32(recipeVariables.RecipeMaxDiameterError)
                || badHolesFromPosition>=Convert.ToInt32(recipeVariables.RecipeMaxPositionError))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
