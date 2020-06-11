using System;

namespace Ikea_Library.Helpers
{
    public static class Enums
    {
        public enum  UserLevel
        {
            Operator = 0,
            Admin = 1
        }
        //public enum CameraNumber
        //{
        //    Cam1 = "Cam1",
        //    Cam2,
        //    Cam3,
        //    Cam4,
        //    Cam5,
        //    Cam6,
        //    Cam7,
        //    Cam8,
        //    Cam9,
        //    Cam10,
        //    Cam11,
        //    Cam12,
        //    Cam13,
        //    Cam14 = 14
        //}
    }
    public enum CameraState
    {
        Initialization,
        ConnectCamera,
        GrabImage,
        DisconnectCamera,
        Exception
    }
}
