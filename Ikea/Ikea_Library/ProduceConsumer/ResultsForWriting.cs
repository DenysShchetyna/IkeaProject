using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library.ProduceConsumer
{
    public class ResultsForWriting
    {
        public List<HTuple> ResultsTop { get; set; } = new List<HTuple> {new HTuple(),new HTuple(),new HTuple()};
        public List<HTuple> ResultsBottom{ get; set; } = new List<HTuple> { new HTuple(), new HTuple(), new HTuple() };
        public List<HTuple> ResultsLeft { get; set; } = new List<HTuple> { new HTuple(), new HTuple(), new HTuple() };
        public List<HTuple> ResultsRight { get; set; } = new List<HTuple> { new HTuple(), new HTuple(), new HTuple() };
        public List<HTuple> ResultsFront{ get; set; } = new List<HTuple> { new HTuple(), new HTuple(), new HTuple() };
        public List<HTuple> ResultsBack { get; set; } = new List<HTuple> { new HTuple(), new HTuple(), new HTuple() };
        public List<HTuple> ResultsTopLasers { get; set; } = new List<HTuple> { new HTuple(), new HTuple(), new HTuple() };
        public List<HTuple> ResultsBottomLasers { get; set; } = new List<HTuple> { new HTuple(), new HTuple(), new HTuple() };
    }
}
