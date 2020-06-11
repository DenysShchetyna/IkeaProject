using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ikea_Library.ProduceConsumer
{
    public class Consumer
    {
        private string _name { get; set; }
        private string _camName { get; set; }

        private Thread ConsumerThread;
        public Consumer(string name, string camName)
        {
            _name = name;
            _camName = camName;
        }
    }
}
