using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library.Events
{
    public class NewPlankEventArgs:EventArgs
    {
        public bool NewPlank { get; set; }
        public string Name { get; set; }

        public NewPlankEventArgs(bool newPlank,string name)
        {
            NewPlank = newPlank;
            Name = name;
        }
    }
}
