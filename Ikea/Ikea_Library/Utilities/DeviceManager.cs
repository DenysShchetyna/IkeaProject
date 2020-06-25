using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advantech.Adam;


namespace Ikea_Library.Utilities
{
    public class DeviceManager
    {
        private static AdamSocket Initialization()
        {
            AdamSocket adamModbus = new AdamSocket();
            adamModbus.Connect("192.168.20.201", ProtocolType.Tcp, 502);
            return adamModbus;
        }

        public static List<bool> ReadAdamCoils()
        {
            AdamSocket adamModbus = Initialization();
            adamModbus.Modbus().ReadCoilStatus(1, 16, out bool[] statusCoil);
            return statusCoil.ToList();
        }
        public static void WriteAdamCoils(int coilNum,bool status,out bool resultStatus)
        {
            AdamSocket adamModbus = Initialization();
            resultStatus = adamModbus.Modbus().ForceSingleCoil(coilNum, status);
        }
    }
}
