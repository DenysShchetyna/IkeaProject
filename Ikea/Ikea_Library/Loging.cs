using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library
{
    public class Loging
    {
        readonly static string LogsDirectoryPath = @"C:\Trifid\IKEA\IkeaProject\Logs\";
        private static string LogFilePath { get; set; }

        private static bool CreateLogDirectory()
        {
            bool ok;
            try
            {
                if (Directory.Exists(LogsDirectoryPath) == false)
                {
                    Directory.CreateDirectory(LogsDirectoryPath);
                    ok = true;
                }
                else
                {
                    ok = true;
                }
            }
            catch (Exception ex)
            {
                ok = false;
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }

            return ok;
        }

        private static bool CreateLogFile()
        {

            bool ok;
            try
            {
                string dateTime = DateTime.Now.ToString("dd_MM_yyyy");
                LogFilePath = LogsDirectoryPath + dateTime + ".txt";

                if (File.Exists(LogFilePath) == false)
                {
                    File.Create(LogFilePath).Close();
                    ok = true;
                }
                else
                {
                    ok = true;
                }
            }
            catch (Exception ex)
            {
                ok = false;
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }

            return ok;
        }

        public static void MakeLog(DateTime dateTime, string log, string indicator)
        {
            string stringToAppend = string.Format("{0,-30}|{1,-120}{2,-20}", dateTime, log, indicator) + "\r\n";
            try
            {
                if (CreateLogDirectory() == true && CreateLogFile() == true)
                {
                    File.AppendAllText(LogFilePath, stringToAppend);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0,-30}|{1,-120}{2,-20}", DateTime.Now, ex.Message, "|Error|");
            }
        }
    }
}
