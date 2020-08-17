using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library
{
    public class Hole
    {


        public string CreationTime { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Diameter { get; set; }
        public bool Status { get; set; }

        public Hole(string timeStamp, double x, double y, double diameter, bool status)
        {
            CreationTime = timeStamp;
            X = x;
            Y = y;
            Diameter = diameter;
            Status = status;
        }
        public Hole()
        {

        }
    }

}
