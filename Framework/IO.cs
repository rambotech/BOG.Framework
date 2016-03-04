using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BOG.Framework
{
    public static class IO
    {
        /// <summary>
        /// Returns a path for temp files, which is the drive with the largest free space.  If it is the drive for the TEMP environment variable,
        /// that TEMP environment variable value is returned.
        /// </summary>
        /// <returns></returns>
        public static string GetBestLocalTempStoragePath()
        {
            Int64 FreeSpace = 0;
            string DriveToUse = string.Empty;
            string OSTempDrive = Path.GetTempPath().Split(Path.VolumeSeparatorChar)[0];
            // find the local fixed disk with the most free space and use it
            foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                if (di.DriveType == DriveType.Fixed)
                {
                    if (di.AvailableFreeSpace > FreeSpace)
                    {
                        DriveToUse = di.Name;
                        FreeSpace = di.AvailableFreeSpace;
                    }
                }
            }
            return (DriveToUse != string.Empty && DriveToUse.Split(Path.VolumeSeparatorChar)[0] != OSTempDrive) ? DriveToUse : Path.GetTempPath();
        }
    }
}
