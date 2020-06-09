using Ikea_Library.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea_Library.Utilities
{
    public class DiscManagement
    {
        private static readonly long ConvertToGigabytes = (long)Math.Pow(1024, 3);

        public static long CheckDiscs(int discSpaceLimit, string path)
        {
            try
            {
                long freeSpace = AvailableFreeDiskSpace(path);

                if (freeSpace < discSpaceLimit && freeSpace != -1)
                {
                    DeleteOldFiles(path);
                    Console.WriteLine(DateTime.Now + " - " + $"Deleted from disc {path}");
                    freeSpace = AvailableFreeDiskSpace(path);
                }
                return freeSpace;
            }

            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + " - " + ex.Message);
                return -1;
            }

        }

        private static long AvailableFreeDiskSpace(string path)
        {
            try
            {
                DriveInfo drive = new DriveInfo(path);

                if (drive.IsReady)
                {
                    return drive.AvailableFreeSpace / ConvertToGigabytes;
                }
                else
                {
                    return -1;
                }
            }

            catch (Exception ex)
            {
                return -1;
            }
        }

        private static void DeleteOldFiles(string path)
        {
            try
            {
                string[] files = GetAllFiles(path);
                DateTime dateTimeToDelete = DateTime.Now.AddDays(-GlobalVariables.DiscManagementDays);

                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo fI = new FileInfo(files[i]);
                    bool isOlder = fI.CreationTimeUtc < dateTimeToDelete;
                    if (isOlder == true)
                    {
                        fI.Delete();
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + " - " + ex.Message);
            }
        }

        private static string[] GetAllFiles(string path)
        {
            return Directory.GetFiles(path, "*", SearchOption.AllDirectories);
        }

    }
}
