using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library
{
    public class Material
    {
        public string IDMeasurement { get; set; }
        public string TimeStamp { get; set; }
        public string Barcode { get; set; }
        public bool Status { get; set; }
        public int HolesCount { get; set; }
        public List<Hole> Holes { get; set; }
        public string ImagePath { get; set; }
    }
}
