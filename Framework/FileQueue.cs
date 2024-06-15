using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOG.Framework
{
    /// <summary>
    /// 
    /// </summary>
    public class FileQueue
    {
        private string _StorageFolder;
        private Queue<string> _Files;
        private Dictionary<string, int> _Folders;
        private object _Lock = new object();

        /// <summary>
        /// Folder must be valid and exist
        /// </summary>
        public FileQueue(string storageFolder)
        {
            if (!Directory.Exists(storageFolder)) throw new ArgumentException("Storage Folder location does not exist)");
            _StorageFolder = storageFolder;
            foreach (string folder in Directory.GetDirectories(_StorageFolder, "*.*", SearchOption.TopDirectoryOnly))
            {
                _Folders.Add(folder, 0);
                if (_Files.Count > 0) continue;
                var fileContent = Directory.GetFiles(folder, "*.*", SearchOption.TopDirectoryOnly);
                foreach (string thisFile in fileContent)
                {
                    if (_Files.Count == 20) break;
                    _Files.Enqueue(thisFile);
                }
            }
        }

        private void Initialize()
        {

        }

        #region  Helpers
        // Now as yyyyJJJHHmmssnnnnnn   (nnnnnn = microseconds, JJJ = julian day number)
        private string CreateSortableUniqueFileName()
        {
            var now = DateTime.Now;
            var r = new Random((1 + now.Millisecond) * (1 + now.Second));
            return string.Format("{0:000#}-{1:00#}-{2:0#}{3:0#}{4:0#}-{5:000#}", 
                now.Year, now.DayOfYear, now.Hour, now.Minute, now.Second, 
                r.Next(0,9999));
        }
        #endregion
    }
}