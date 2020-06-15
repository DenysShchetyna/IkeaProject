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
        public HObject TileImage { get; set; }
        public string CamName { get; set; }

        public TileImageReadyEventArgs(string camName, HObject tileImage)
        {
            TileImage = tileImage;
            CamName = camName;
        }
    }
}
