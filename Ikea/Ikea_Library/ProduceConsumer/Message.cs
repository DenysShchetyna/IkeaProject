using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library.ProduceConsumer
{
    public class Message
    {
        public HObject Image { get; set; }
        public HObject PartialImage { get; set; }
        public bool LastImage { get; set; }

    }
}
