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
        private string Ip { get; set; }
        private AdamSocket Adam { get; set; }
        public DeviceManager(string ip)
        {
            Ip = ip;
            Initialization();
        }

        private void Initialization()
        {
            Adam = new AdamSocket();
            Adam.Connect(Ip, ProtocolType.Tcp, 502);
        }

        public List<bool> ReadAdamCoils(int totalCoils)
        {
            bool[] statusCoil = new bool[totalCoils];
            try
            {
                if (Adam.Connected == true)
                {
                    if (Ip == "192.168.200.22") 
                    {
                        Adam.Modbus().ReadCoilStatus(17, totalCoils, out statusCoil);
                    }
                    else if (Ip == "192.168.200.21")
                    {
                        Adam.Modbus().ReadCoilStatus(1, totalCoils, out statusCoil);
                    }
                }
                return statusCoil.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
                return statusCoil.ToList();
            }

        }
        public void WriteAdamCoils(int coilNum, bool status, out bool resultStatus)
        {
            try
            {
                if (Adam.Connected == true)
                {
                    resultStatus = Adam.Modbus().ForceSingleCoil(coilNum, status);
                }
                else
                {
                    resultStatus = false;
                }
            }

            catch (Exception ex)
            {
                resultStatus = false;
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }
        }
    }
}
