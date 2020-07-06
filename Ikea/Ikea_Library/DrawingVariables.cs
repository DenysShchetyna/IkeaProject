using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library
{
    public class DrawingVariables
    {
        public static HTuple h_intSurfaceTypeFromDrawing { get; set; }
        public static HTuple h_realRecipeLengthOfBoardMm { get; set; }
        public static HTuple h_realRecipeWitdhOfBoardMm { get; set; }
        public static HTuple h_realRecipeThickessOfBoardMm { get; set; }
        public static HTuple h_real_arrXPositionMmRightFromDrawing { get; set; }
        public static HTuple h_real_arrYPositionMmRightFromDrawing { get; set; }
        public static HTuple h_real_arrDiameterMmRightFromDrawing { get; set; }
        public static HTuple h_real_arrXPositionMmFrontFromDrawing { get; set; }
        public static HTuple h_real_arrYPositionMmFrontFromDrawing { get; set; }
        public static HTuple h_real_arrDiameterMmFrontFromDrawing { get; set; }
        public static HTuple h_real_arrXPositionMmBottomFromDrawing { get; set; }
        public static HTuple h_real_arrYPositionMmBottomFromDrawing { get; set; }
        public static HTuple h_real_arrDiameterMmBottomFromDrawing { get; set; }
        public static HTuple h_real_arrXPositionMmBackFromDrawing { get; set; }
        public static HTuple h_real_arrYPositionMmBackFromDrawing { get; set; }
        public static HTuple h_real_arrDiameterMmBackFromDrawing { get; set; }
        public static HTuple h_real_arrXPositionMmTopFromDrawing { get; set; }
        public static HTuple h_real_arrYPositionMmTopFromDrawing { get; set; }
        public static HTuple h_real_arrDiameterMmTopFromDrawing { get; set; }
        public static HTuple h_real_arrXPositionMmLeftFromDrawing { get; set; }
        public static HTuple h_real_arrYPositionMmLeftFromDrawing { get; set; }
        public static HTuple h_real_arrDiameterMmLeftFromDrawing { get; set; }
        public static HObject h_reg_arrRoiMmTopPartSmallHolesForLsCameras { get; set; }
        public static HObject h_reg_arrRoiMmTopPartLargeHolesForArCameras { get; set; }
        public static HObject h_reg_arrRoiMmBottomPartSmallHolesForLsCameras { get; set; }
        public static HObject h_reg_arrRoiMmBottomPartLargeHolesForArCameras { get; set; }
        public static HObject h_reg_arrRoiMmLeftPartHolesForLsCameras { get; set; }
        public static HObject h_reg_arrRoiMmRightPartHolesForLsCameras { get; set; }
        public static HObject h_reg_arrRoiMmFrontPartHolesForArCameras { get; set; }
        public static HObject h_reg_arrRoiMmBackPartHolesForArCameras { get; set; }
        public static HObject RegionRight { get; set; }
        public static HObject RegionFront { get; set; }
        public static HObject RegionBottom { get; set; }
        public static HObject RegionBack { get; set; }
        public static HObject RegionTop { get; set; }
        public static HObject RegionLeft { get; set; }
        public static HObject CirclesInRegionRight { get; set; }
        public static HObject CirclesInRegionFront { get; set; }
        public static HObject CirclesInRegionBottom { get; set; }
        public static HObject CirclesInRegionBack { get; set; }
        public static HObject CirclesInRegionTop { get; set; }
        public static HObject CirclesInRegionLeft { get; set; }
        public static HObject ContourOnlyFromCircles { get; set; }
    }
}
