using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library.Events
{


    public class ResultsForWritingReadyEventArgs:EventArgs
    {
        public HTuple MeasurementResult { get; set; } = new HTuple();
        public HTuple XValues { get; set; } = new HTuple();
        public HTuple YValues { get; set; } = new HTuple();
        public HTuple DiameterValues { get; set; } = new HTuple();
        public HTuple CamNames { get; set; } = new HTuple();
        public string ImgSavePath { get; set; }

        public ResultsForWritingReadyEventArgs(HTuple camName, HTuple xValues, HTuple yValues, HTuple diameterValues, HTuple measurementResults,string imgSavePath)
        {
            XValues = xValues;
            YValues = yValues;
            DiameterValues = diameterValues;
            MeasurementResult = measurementResults;
            CamNames = camName;
            ImgSavePath = imgSavePath;
        }
    }
}
