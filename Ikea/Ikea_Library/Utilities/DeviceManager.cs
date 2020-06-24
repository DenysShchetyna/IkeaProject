using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ikea_Library.Utilities
{
    public class DeviceManager
    {
        public static bool PingCamera(string camAddress)
        {
            try
            {
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(camAddress, 3000);

                if(pingReply.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }
            return false;
        }

        private static PingReply DoTask(string camAddress)
        {
            Ping ping = new Ping();
            return ping.Send(camAddress, 3000);
        }

        public List<bool> ReadAdamCoils()
        {
            List<bool> dsff = new List<bool>();
            //AdamModbus.Modbus().ReadCoilStatus(1, 16, out bool[] statusCoil);
            return dsff;
        }
    }
}
