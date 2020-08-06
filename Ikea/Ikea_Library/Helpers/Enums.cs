using System;

namespace Ikea_Library.Helpers
{
    public enum CameraState
    {
        Initialization,
        ConnectCamera,
        GrabImage,
        DisconnectCamera,
        Exception
    }

}
