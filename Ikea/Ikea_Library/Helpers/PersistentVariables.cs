using HalconDotNet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library.Helpers
{
    public  class PersistentVariables
    {
        public  int ExposureTimeCam1LsTopL { get; set; }

        public  int GainCam1LsTopL { get; set; } 

        public  int ExposureTimeCam2LsTopR { get; set; } 
        public  int GainCam2LsTopR { get; set; } 

        public  int ExposureTimeCam3LsBottomL { get; set; }
        public  int GainCam3LsBottomL { get; set; }

        public  int ExposureTimeCam4LsBottomR { get; set; }
        public  int GainCam4LsBottomR { get; set; } 

        public  int ExposureTimeCam5LsLeft { get; set; } 
        public  int GainCam5LsLeft { get; set; } 

        public  int ExposureTimeCam6LsRight { get; set; } 
        public  int GainCam6LsRight { get; set; } 

        public  int ExposureTimeCam7ArFrontL { get; set; } 
        public  int GainCam7ArFrontL { get; set; } 

        public  int ExposureTimeCam8ArFrontR { get; set; } 
        public  int GainCam8ArFrontR { get; set; } 

        public  int ExposureTimeCam9ArRearL { get; set; } 
        public  int GainCam9ArRearL { get; set; }

        public  int ExposureTimeCam10ArRearR { get; set; }
        public  int GainCam10ArRearR { get; set; } 

        public  int ExposureTimeCam11ArTopL { get; set; } 
        public  int GainCam11ArTopL { get; set; }

        public  int ExposureTimeCam12ArTopR { get; set; }
        public  int GainCam12ArTopR { get; set; } 

        public  int ExposureTimeCam13ArBottomL { get; set; } 
        public  int GainCam13ArBottomL { get; set; } 

        public  int ExposureTimeCam14ArBottomR { get; set; }
        public  int GainCam14ArBottomR { get; set; }

        
    }
}
