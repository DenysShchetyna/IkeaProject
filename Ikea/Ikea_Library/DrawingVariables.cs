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
        
        public  HObject Reg_arrRoiMmTopPartSmallHolesForLsCameras { get; set; }
        public  HObject Reg_arrRoiMmTopPartLargeHolesForArCameras { get; set; }
        public  HObject Reg_arrRoiMmBottomPartSmallHolesForLsCameras { get; set; }
        public  HObject Reg_arrRoiMmBottomPartLargeHolesForArCameras { get; set; }
        public  HObject Reg_arrRoiMmLeftPartHolesForLsCameras { get; set; }
        public  HObject Reg_arrRoiMmRightPartHolesForLsCameras { get; set; }
        public  HObject Reg_arrRoiMmFrontPartHolesForArCameras { get; set; }
        public  HObject Reg_arrRoiMmBackPartHolesForArCameras { get; set; }
        public  HObject RegionRight { get; set; }
        public  HObject RegionFront { get; set; }
        public  HObject RegionBottom { get; set; }
        public  HObject RegionBack { get; set; }
        public  HObject RegionTop { get; set; }
        public  HObject RegionLeft { get; set; }
        public  HObject CirclesInRegionRight { get; set; }
        public  HObject CirclesInRegionFront { get; set; }
        public  HObject CirclesInRegionBottom { get; set; }
        public  HObject CirclesInRegionBack { get; set; }
        public  HObject CirclesInRegionTop { get; set; }
        public  HObject CirclesInRegionLeft { get; set; }
        public HTuple IntSurfaceTypeFromDrawing { get; set; }
        public HTuple RealRecipeLengthOfBoardMm { get; set; }
        public HTuple RealRecipeWitdhOfBoardMm { get; set; }
        public HTuple RealRecipeThickessOfBoardMm { get; set; }
        public HTuple Real_arrXPositionMmRightFromDrawing { get; set; }
        public HTuple Real_arrYPositionMmRightFromDrawing { get; set; }
        public HTuple Real_arrDiameterMmRightFromDrawing { get; set; }
        public HTuple Real_arrXPositionMmFrontFromDrawing { get; set; }
        public HTuple Real_arrYPositionMmFrontFromDrawing { get; set; }
        public HTuple Real_arrDiameterMmFrontFromDrawing { get; set; }
        public HTuple Real_arrXPositionMmBottomFromDrawing { get; set; }
        public HTuple Real_arrYPositionMmBottomFromDrawing { get; set; }
        public HTuple Real_arrDiameterMmBottomFromDrawing { get; set; }
        public HTuple Real_arrXPositionMmBackFromDrawing { get; set; }
        public HTuple Real_arrYPositionMmBackFromDrawing { get; set; }
        public HTuple Real_arrDiameterMmBackFromDrawing { get; set; }
        public HTuple Real_arrXPositionMmTopFromDrawing { get; set; }
        public HTuple Real_arrYPositionMmTopFromDrawing { get; set; }
        public HTuple Real_arrDiameterMmTopFromDrawing { get; set; }
        public HTuple Real_arrXPositionMmLeftFromDrawing { get; set; }
        public HTuple Real_arrYPositionMmLeftFromDrawing { get; set; }
        public HTuple Real_arrDiameterMmLeftFromDrawing { get; set; }


        public DrawingVariables(
                HObject h_reg_arrRoiMmTopPartSmallHolesForLsCameras,
                HObject h_reg_arrRoiMmTopPartLargeHolesForArCameras, 
                HObject h_reg_arrRoiMmBottomPartSmallHolesForLsCameras,
                HObject h_reg_arrRoiMmBottomPartLargeHolesForArCameras,
                HObject h_reg_arrRoiMmLeftPartHolesForLsCameras, 
                HObject h_reg_arrRoiMmRightPartHolesForLsCameras, 
                HObject h_reg_arrRoiMmFrontPartHolesForArCameras,
                HObject h_reg_arrRoiMmBackPartHolesForArCameras,
                HObject regionRight, 
                HObject regionFront,
                HObject regionBottom,
                HObject regionBack,
                HObject regionTop,
                HObject regionLeft,
                HObject circlesInRegionRight,
                HObject circlesInRegionFront, 
                HObject circlesInRegionBottom,
                HObject circlesInRegionBack, 
                HObject circlesInRegionTop,
                HObject circlesInRegionLeft,
                HTuple h_intSurfaceTypeFromDrawing,
                HTuple h_realRecipeLengthOfBoardMm,
                HTuple h_realRecipeWitdhOfBoardMm,
                HTuple h_realRecipeThickessOfBoardMm,
                HTuple h_real_arrXPositionMmRightFromDrawing, 
                HTuple h_real_arrYPositionMmRightFromDrawing, 
                HTuple h_real_arrDiameterMmRightFromDrawing,
                HTuple h_real_arrXPositionMmFrontFromDrawing,
                HTuple h_real_arrYPositionMmFrontFromDrawing,
                HTuple h_real_arrDiameterMmFrontFromDrawing, 
                HTuple h_real_arrXPositionMmBottomFromDrawing,
                HTuple h_real_arrYPositionMmBottomFromDrawing, 
                HTuple h_real_arrDiameterMmBottomFromDrawing, 
                HTuple h_real_arrXPositionMmBackFromDrawing,
                HTuple h_real_arrYPositionMmBackFromDrawing,
                HTuple h_real_arrDiameterMmBackFromDrawing, 
                HTuple h_real_arrXPositionMmTopFromDrawing,
                HTuple h_real_arrYPositionMmTopFromDrawing, 
                HTuple h_real_arrDiameterMmTopFromDrawing, 
                HTuple h_real_arrXPositionMmLeftFromDrawing,
                HTuple h_real_arrYPositionMmLeftFromDrawing,
                HTuple h_real_arrDiameterMmLeftFromDrawing) 
        {
                Reg_arrRoiMmTopPartSmallHolesForLsCameras = h_reg_arrRoiMmTopPartSmallHolesForLsCameras;
                Reg_arrRoiMmTopPartLargeHolesForArCameras = h_reg_arrRoiMmTopPartLargeHolesForArCameras;
                Reg_arrRoiMmBottomPartSmallHolesForLsCameras = h_reg_arrRoiMmBottomPartSmallHolesForLsCameras;
                Reg_arrRoiMmBottomPartLargeHolesForArCameras = h_reg_arrRoiMmBottomPartLargeHolesForArCameras;
                Reg_arrRoiMmLeftPartHolesForLsCameras = h_reg_arrRoiMmLeftPartHolesForLsCameras;
                Reg_arrRoiMmRightPartHolesForLsCameras = h_reg_arrRoiMmRightPartHolesForLsCameras;
                Reg_arrRoiMmFrontPartHolesForArCameras = h_reg_arrRoiMmFrontPartHolesForArCameras;
                Reg_arrRoiMmBackPartHolesForArCameras = h_reg_arrRoiMmBackPartHolesForArCameras;
                RegionRight = regionRight;
                RegionFront = regionFront;
                RegionBottom = regionBottom;
                RegionBack = regionBack;
                RegionTop = regionTop;
                RegionLeft = regionLeft;
                CirclesInRegionRight = circlesInRegionRight;
                CirclesInRegionFront = circlesInRegionFront;
                CirclesInRegionBottom = circlesInRegionBottom;
                CirclesInRegionBack = circlesInRegionBack;
                CirclesInRegionTop = circlesInRegionTop;
                CirclesInRegionLeft = circlesInRegionLeft;
                IntSurfaceTypeFromDrawing = h_intSurfaceTypeFromDrawing;
                RealRecipeLengthOfBoardMm = h_realRecipeLengthOfBoardMm;
                RealRecipeWitdhOfBoardMm = h_realRecipeWitdhOfBoardMm;
                RealRecipeThickessOfBoardMm = h_realRecipeThickessOfBoardMm;
                Real_arrXPositionMmRightFromDrawing = h_real_arrXPositionMmRightFromDrawing;
                Real_arrYPositionMmRightFromDrawing = h_real_arrYPositionMmRightFromDrawing;
                Real_arrDiameterMmRightFromDrawing = h_real_arrDiameterMmRightFromDrawing;
                Real_arrXPositionMmFrontFromDrawing = h_real_arrXPositionMmFrontFromDrawing;
                Real_arrYPositionMmFrontFromDrawing = h_real_arrYPositionMmFrontFromDrawing;
                Real_arrDiameterMmFrontFromDrawing = h_real_arrDiameterMmFrontFromDrawing;
                Real_arrXPositionMmBottomFromDrawing = h_real_arrXPositionMmBottomFromDrawing;
                Real_arrYPositionMmBottomFromDrawing = h_real_arrYPositionMmBottomFromDrawing;
                Real_arrDiameterMmBottomFromDrawing = h_real_arrDiameterMmBottomFromDrawing;
                Real_arrXPositionMmBackFromDrawing = h_real_arrXPositionMmBackFromDrawing;
                Real_arrYPositionMmBackFromDrawing = h_real_arrYPositionMmBackFromDrawing;
                Real_arrDiameterMmBackFromDrawing = h_real_arrDiameterMmBackFromDrawing;
                Real_arrXPositionMmTopFromDrawing = h_real_arrXPositionMmTopFromDrawing;
                Real_arrYPositionMmTopFromDrawing = h_real_arrYPositionMmTopFromDrawing;
                Real_arrDiameterMmTopFromDrawing = h_real_arrDiameterMmTopFromDrawing;
                Real_arrXPositionMmLeftFromDrawing = h_real_arrXPositionMmLeftFromDrawing;
                Real_arrYPositionMmLeftFromDrawing = h_real_arrYPositionMmLeftFromDrawing;
                Real_arrDiameterMmLeftFromDrawing = h_real_arrDiameterMmLeftFromDrawing;
    }
    }
}
