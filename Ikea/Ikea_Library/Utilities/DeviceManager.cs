using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library.Utilities
{
    public class DeviceManager
    {
        public static List<bool> PingCamera(List<string> cameras)
        {
            List<bool> status = new List<bool>();

            try
            {
                using (Ping ping = new Ping())
                {
                    for(int i = 0; i < cameras.Count; i++)
                    {
                        PingReply pingReply = ping.Send(cameras[i], 3000);

                        if (pingReply.Status == IPStatus.Success)
                        {
                            status.Add(true);
                        }
                        else
                        {
                            status.Add(false);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }

            return status;
        }
        public List<bool> ReadAdamCoils()
        {
            List<bool> dsff = new List<bool>();
            //AdamModbus.Modbus().ReadCoilStatus(1, 16, out bool[] statusCoil);
            return dsff;
        }
    }
}
