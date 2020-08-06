using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library.Events
{
    public class TileImageReadyEventArgs : EventArgs
    {
        public HObject TileImageCam1_2 { get; set; }
        public HObject TileImageCam3_4 { get; set; }
        public HObject TileImageCam5 { get; set; }
        public HObject TileImageCam6 { get; set; }
        public HObject TileImageCam7_8 { get; set; }
        public HObject TileImageCam9_10 { get; set; }
        public HObject TileImageCam11_12 { get; set; }
        public HObject TileImageCam13_14 { get; set; }

        public string CamNames { get; set; }

        public TileImageReadyEventArgs(string camName, HObject tileImage)
        {
            switch (camName)
            {
                case "Cam1LsTopL_Cam2LsTopR":
                    TileImageCam1_2 = tileImage;
                    CamNames = camName;
                    break;


                case "Cam3LsBottomL_Cam4LsBottomR":
                    TileImageCam3_4 = tileImage;
                    CamNames = camName;
                    break;


                case "Cam5LsLeft":
                    TileImageCam5 = tileImage;
                    CamNames = camName;

                    break;

                case "Cam6LsRight":
                    TileImageCam6 = tileImage;
                    CamNames = camName;

                    break;

                case "Cam7ArFrontL_Cam8ArFrontR":
                    TileImageCam7_8 = tileImage;
                    CamNames = camName;

                    break;

                case "Cam9ArRearL_Cam10ArRearR":
                    TileImageCam9_10 = tileImage;
                    CamNames = camName;

                    break;

                case "Cam11ArTopL_Cam12ArTopR":
                    TileImageCam11_12 = tileImage;
                    CamNames = camName;

                    break;

                case "Cam13ArBottomL_Cam14ArBottomR":
                    TileImageCam13_14 = tileImage;
                    CamNames = camName;

                    break;

            }
        }
    }
}
