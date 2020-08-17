using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ikea_Library
{
    public class DrawingSide
    {
        public string SideName { get; set; }
        public string CreationTime { get; set; }
        public bool Status { get; set; }

        public List<Hole> HolesList;
        public string ImagePath { get; set; }


        public DrawingSide(string name,string timeStamp)
        {
            CreationTime = timeStamp;
            SideName = name;
            HolesList = new List<Hole>();
        }
        public DrawingSide()
        {

        }
    }
}
