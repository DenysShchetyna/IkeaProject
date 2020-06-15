using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library
{
    public class Material
    {
        public string Name { get; set; }
        public string TimeStamp { get; set; }
        public bool Status { get; set; }
        public List<DrawingSide> DrawingSides { get; set; }
        public int DrawingsCount { get; set; }

        public Material(string name)
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
        public Material()
        {

        }
    }
}
