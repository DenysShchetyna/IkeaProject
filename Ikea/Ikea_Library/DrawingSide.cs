using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library
{
    public class DrawingSide
    {
        public string Name { get; set; }
        public string TimeStamp { get; set; }
        public bool Status { get; set; }
        public List<Hole> Holes { get; set; }
        public int HolesCount { get; set; }
        public string ImagePath { get; set; }

        public DrawingSide(string name)
        {
            if (name != null)
            {
                Name = name;
            }
            else
            {
                Name = "Default";
            }
        }
        public DrawingSide()
        {
        }

    }
}
