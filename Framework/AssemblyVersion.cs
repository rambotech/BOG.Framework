using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

// Primarily for console applications to determine executable file name, version
// build date, and processor info.  For build date, reads the linker timestamp embedded
// in the assembly.  Technique borrowed from Jeff Atwood, reference:
// http://www.codinghorror.com/blog/archives/000264.html

namespace BOG.Framework
{
    /// <summary>
    /// A set of five properties to describe the executable, or an assembly.  The information
    /// comes from either executing components, or specific files.  See ReflectiveSetup() methods.
    /// </summary>
    public class AssemblyVersion : IDisposable
    {
        private string _processor = string.Empty;
        private string _name = string.Empty;
        private string _fullpath = string.Empty;
        private string _version = string.Empty;
        private string _builddate = string.Empty;

        /// <summary>
        /// The processor supported by the build.
        /// </summary>
        public string Processor
        {
            get { return _processor; }
        }

        /// <summary>
        /// The name of the assembly or executable.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// The full path of the executable file or assembly file.
        /// </summary>
        public string FullPath
        {
            get { return _fullpath; }
        }

        /// <summary>
        /// The version of the executable file or assembly file.
        /// </summary>
        public string Version
        {
            get { return _version; }
        }

        /// <summary>
        /// The build date of the executable file or assembly file.
        /// </summary>
        public string BuildDate
        {
            get { return _builddate; }
        }

        private DateTime RetrieveLinkerTimestamp(string filePath)
        {
            const int PeHeaderOffset = 60;
            const int LinkerTimestampOffset = 8;

            byte[] b = new byte[2048];
            Stream s = default(Stream);
            try
            {
                s = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                s.Read(b, 0, 2048);
            }
            finally
            {
                if ((s != null)) s.Close();
            }

            int i = BitConverter.ToInt32(b, PeHeaderOffset);

            int SecondsSince1970 = BitConverter.ToInt32(b, i + LinkerTimestampOffset);
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
            dt = dt.AddSeconds(SecondsSince1970);
            dt = dt.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours);
            return dt;
        }

        private void ReflectiveSetup(System.Reflection.Assembly specificAssembly)
        {
            string ThisExecutableFile = specificAssembly.CodeBase;

            if (ThisExecutableFile.IndexOf("file:///") >= 0)
            {
                ThisExecutableFile = specificAssembly.CodeBase.Replace("file:///", string.Empty).Replace('/', '\\');
            }
            else // network path is file://server/share/path, so leave the double slashes to get \\server\share\path
            {
                ThisExecutableFile = specificAssembly.CodeBase.Replace("file:", string.Empty).Replace('/', '\\');
            }

            _version = specificAssembly.GetName().Version.ToString();
            _name = specificAssembly.ManifestModule.Name;
            _fullpath = ThisExecutableFile;
            _processor = Enum.GetNames(typeof(System.Reflection.ProcessorArchitecture))[(int)specificAssembly.GetName().ProcessorArchitecture];
            _builddate = RetrieveLinkerTimestamp(ThisExecutableFile).ToString();
        }

        /// <summary>
        /// Initializes the class with information for the active assembly.
        /// </summary>
        public AssemblyVersion()
        {
            ReflectiveSetup(System.Reflection.Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Initializes the class with information for the entry assembly or executable
        /// </summary>
        public AssemblyVersion(bool forTheEntryAssembly)
        {
            if (forTheEntryAssembly)
            {
                ReflectiveSetup(System.Reflection.Assembly.GetEntryAssembly());
            }
            else
            {
                ReflectiveSetup(System.Reflection.Assembly.GetExecutingAssembly());
            }
        }

        /// <summary>
        /// Initializes the class with information for an assembly or executable specified by filename.
        /// </summary>
        public AssemblyVersion(string AssemblyPath)
        {
            ReflectiveSetup(System.Reflection.Assembly.LoadFile(AssemblyPath));
        }

        /// <summary>
        /// Initializes the class with information for an assembly or executable specified by object.
        /// </summary>
        public AssemblyVersion(System.Reflection.Assembly a)
        {
            ReflectiveSetup(a);
        }

        /// <summary>
        /// Creates a line string with the assembly information for display or logging.
        /// </summary>
        public string DisplayString()
        {
            return string.Format("{0}, Ver. {1}, {2} ( {3} )", _name, _version, _builddate, _processor);
        }

        /// <summary>
        /// Standard disposal method.
        /// </summary>
        public void Dispose()
        {
        }
    }
}
