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
        public HObject TileImageCam1 { get; set; }
        public HObject TileImageCam2 { get; set; }
        public HObject TileImageCam3 { get; set; }
        public HObject TileImageCam4 { get; set; }
        public HObject TileImageCam5 { get; set; }
        public HObject TileImageCam6 { get; set; }
        public HObject TileImageCam7 { get; set; }
        public HObject TileImageCam8 { get; set; }
        public HObject TileImageCam9 { get; set; }
        public HObject TileImageCam10 { get; set; }
        public HObject TileImageCam11 { get; set; }
        public HObject TileImageCam12 { get; set; }
        public HObject TileImageCam13 { get; set; }
        public HObject TileImageCam14 { get; set; }

        public string CamName { get; set; }

        public TileImageReadyEventArgs(string camName, HObject tileImage)
        {
            switch (camName)
            {
                case "Cam1LsTopL":
                    TileImageCam1 = tileImage;
                    break;

                case "CAM2":
                    TileImageCam2 = tileImage;
                    break;

                case "CAM3":
                    TileImageCam3 = tileImage;
                    break;

                case "CAM4":
                    TileImageCam4 = tileImage;
                    break;

                case "CAM5":
                    TileImageCam5 = tileImage;
                    break;

                case "CAM6":
                    TileImageCam6 = tileImage;
                    break;

                case "CAM7":
                    TileImageCam7 = tileImage;
                    break;

                case "CAM8":
                    TileImageCam8 = tileImage;
                    break;

                case "CAM9":
                    TileImageCam9 = tileImage;
                    break;

                case "CAM10":
                    TileImageCam10 = tileImage;
                    break;

                case "CAM11":
                    TileImageCam11 = tileImage;
                    break;

                case "CAM12":
                    TileImageCam12 = tileImage;
                    break;

                case "CAM13":
                    TileImageCam13 = tileImage;
                    break;

                case "CAM14":
                    TileImageCam14 = tileImage;
                    break;
            }
        }
    }
}
