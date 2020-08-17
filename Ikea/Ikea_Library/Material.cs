using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library
{
    public class Material
    {
        public string RecipeName { get; set; }
        public string CreationTime { get; set; }
        public bool Status { get; set; }
        public List<DrawingSide> DrawingSides { get; set; }

        public Material(string dateTime, string name)
        {
            CreationTime = dateTime;
            RecipeName = name;
        }
        public Material()
        {

        }
    }
}
