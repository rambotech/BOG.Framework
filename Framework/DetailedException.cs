using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets;

namespace BOG.Framework
{
    /// <summary>
    /// Provides standard ways of formatting exception data for users, machine-level logs and enterprise-level logs.
    /// Also provides masking of credential information in URI's and connection strings, to prevent compromise when
    /// logging exceptions.
    /// </summary>
    public static class DetailedException
    {
        // These two static variables are a cache... do not use them directly.
        // Call method GetLocalIPAddresses()
        static List<string> myIpAddressInfo = new List<string>();
        static DateTime myIpAddressInfoExpires = DateTime.MinValue;

        /// <summary>
        /// Attempts to remove username and/or password in a URL or connection string
        /// and substitute the values with "[contents:hidden]" (for URLs) or 
        /// [contents hidden] for a connection string.  Allows URL or connection strings
        /// with embedded credentials to be included in a log entry, and not introduce
        /// a possible compromise of security because of the entry.
        /// 
        /// Example: 
        /// https://bob:hispassword@server.com/webinfo1    would be written in the detailed exception as
        ///  https://[contents:hidden]@server.com/webinfo1
        /// </summary>
        /// <param name="value">The string to examine.</param>
        /// <param name="delimiter">for connection strings, or other token=value representation only:
        /// represents a list of the character(s) which delimit each token=value entry.</param>
        /// <returns>The value with any detected credentials overwritten.</returns>
        public static string StripUidPwd(string value, string delimiter)
        {
            System.Text.RegularExpressions.Regex oRegExp;
            string sValue = value;

            try
            {
                if (delimiter != null && delimiter.Trim().Length > 0)
                {
                    // Generic connection strings

                    oRegExp = new Regex(@"(^|" + delimiter + @")*\s*((uid|user\s*id|user|username|pwd|pass|password)\s*=\s*)([^" + delimiter + @"|$]+)", RegexOptions.IgnoreCase);
                    sValue = oRegExp.Replace(sValue, "$1$2[contents hidden]");
                }
                // URI embedded username and password
                oRegExp = new System.Text.RegularExpressions.Regex(@"([A-Za-z]+)(://)((.*?)@)*([^\s]+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                sValue = oRegExp.Replace(sValue, "$1$2[contents:hidden]@$5");
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                oRegExp = null;
            }

            return sValue;
        }

        public static string GetLocalIPAddresses(string formatString, string firstLine)
        {
            StringBuilder result = new StringBuilder();
            if (myIpAddressInfoExpires < DateTime.Now)
            {
                myIpAddressInfo.Clear();
                try
                {
                    var host = Dns.GetHostEntry(Dns.GetHostName());
                    foreach (IPAddress ip in host.AddressList)
                    {
                        string output = string.Empty;
                        switch (ip.AddressFamily)
                        {
                            case AddressFamily.InterNetwork:
                                myIpAddressInfo.Add(string.Format("(IPv4) {0}", ip.ToString()));
                                break;
                            case AddressFamily.InterNetworkV6:
                                myIpAddressInfo.Add(
                                    string.Format("(IPv6{1}) {0}", ip.ToString(),
                                        ip.IsIPv6LinkLocal ? " LinkLocal" : (
                                        ip.IsIPv6Multicast ? " Multicast" : (
                                        ip.IsIPv6SiteLocal ? " SiteLocal" : (
                                        ip.IsIPv6Teredo ? " Teredo" : string.Empty)))));
                                break;
                        }
                    }
                    myIpAddressInfoExpires = DateTime.Now.AddMinutes(15);
                }
                catch (Exception err)
                {
                    myIpAddressInfo.Add(string.Format(
                        "Error determining all IP address(es): {0}", err.Message));
                }
            }
            for (int index = 0; index < myIpAddressInfo.Count; index++)
                result.Append(string.Format(formatString, 
                    (index == 0 ? firstLine : string.Empty),
                    myIpAddressInfo[index]));
            return result.ToString();
        }

        /// <summary>
        /// WithEnterpriseContent() is a method for providing full detail on the application and 
        /// system environment, and is best suited when reporting an exception to a
        /// central server, or via general distribution, where the hostname reporting the error 
        /// can not be assumed.
        /// </summary>
        /// <param name="ReportException">a reference to the exception onject.</param>
        /// <param name="headerMessage">optional text to prefix to the error report.</param>
        /// <param name="footerMessage">optional text to suffix to the error report.</param>
        /// <returns>The formatted error description</returns>
        public static string WithEnterpriseContent(ref Exception ReportException, string headerMessage, string footerMessage)
        {
            DateTime Timestamp = DateTime.Now;
            try
            {
                string ApplicationFile = "{undefined}";
                string ApplicationVersion = "{undefined}";
                System.Diagnostics.Process oProcess = System.Diagnostics.Process.GetCurrentProcess();

                ApplicationFile = oProcess.MainModule.FileName;
                ApplicationVersion = oProcess.MainModule.FileVersionInfo.FileVersion;

                return
                    "\r\n" +
                    (headerMessage.Trim().Length == 0 ? string.Empty : headerMessage + "\r\n\r\n") +
                    "Launched on:                " + oProcess.StartTime.ToString("dddd, MMM d, yy HH:mm:ss tt") + " (" + oProcess.StartTime.ToUniversalTime().ToString("dddd, MMM d, yy HH:mm:ss UTC") + " )\r\n" +
                    "Exception reported on:      " + Timestamp.ToString("dddd, MMM d, yy HH:mm:ss tt") + " (" + Timestamp.ToUniversalTime().ToString("dddd, MMM d, yy HH:mm:ss UTC") + " )\r\n\r\n" +
                    "---------------- Exception ------------------" + "\r\n\r\n" +
                    StripUidPwd(ReportException.ToString(), @";") + "\r\n\r\n" +
                    "----------- App/System Details --------------\r\n\r\n" +
                    "System Name:                " + System.Environment.MachineName + "\r\n" +
                    //"IP Addr:                    " + GetLocalIPAddresses() + "\r\n" +
                    GetLocalIPAddresses("{0,-28}{1}\r\n", "IP Addr:")  +
                    "Processors:                 " + System.Environment.ProcessorCount.ToString() + "\r\n" +
                    "OS Version:                 " + System.Environment.OSVersion.ToString() + "\r\n" +
                    "User:                       " + System.Environment.UserDomainName.ToString() + @"\" + System.Environment.UserName.ToString() + "\r\n" +
                    "Mode:                       " + (System.Environment.UserInteractive ? "Interactive" : "Non-Interactive") + "\r\n\r\n" +
                    "Command Line:               " + StripUidPwd(System.Environment.CommandLine.ToString(), @";") + "\r\n" +
                    "Current Directory:          " + System.Environment.CurrentDirectory.ToString() + "\r\n\r\n" +
                    "Application file:           " + ApplicationFile + "\r\n" +
                    "Application version:        " + ApplicationVersion + "\r\n" +
                    "Executing Assembly:         " + System.Reflection.Assembly.GetExecutingAssembly().ToString() + "\r\n" +
                    "Process ID:                 " + oProcess.Id.ToString() + "\r\n" +
                    "Base Priority:              " + oProcess.BasePriority.ToString() + "\r\n" +
                    "Program:                    " + oProcess.ProcessName + "\r\n" +
                    "Memory Usage:               " + oProcess.WorkingSet64.ToString() + "\r\n" +
                    "Non-Paged Memory Allocated: " + oProcess.NonpagedSystemMemorySize64.ToString() + "\r\n" +
                    "Paged Memory Allocated:     " + oProcess.PagedMemorySize64.ToString() + "\r\n" +
                    "Virtual Memory Allocated:   " + oProcess.VirtualMemorySize64.ToString() + "\r\n" +
                    "Peak Paged Allocated:       " + oProcess.PeakPagedMemorySize64.ToString() + "\r\n" +
                    "Peak Virtual Allocated:     " + oProcess.PeakVirtualMemorySize64.ToString() + "\r\n" +
                    "Private Memory Allocated:   " + oProcess.PrivateMemorySize64.ToString() + "\r\n" +
                    "Threads:                    " + oProcess.Threads.Count.ToString() + "\r\n" +
                    "ProcessorTime:              " + oProcess.TotalProcessorTime.Seconds.ToString() + "\r\n\r\n" +
                    (footerMessage.Trim().Length == 0 ? string.Empty : footerMessage + "\r\n\r\n");
            }
            catch
            {
                return
                    "\r\n" +
                    (headerMessage.Trim().Length == 0 ? string.Empty : headerMessage + "\r\n\r\n") +
                    "Exception reported on:      " + Timestamp.ToString("dddd, MMM d, yy HH:mm:ss tt") + " (" + Timestamp.ToUniversalTime().ToString("dddd, MMM d, yy hh:mm:ss UTC") + " )\r\n\r\n" +
                    "---------------- Exception ------------------" + "\r\n\r\n" +
                    StripUidPwd(ReportException.ToString(), @";") + "\r\n\r\n" +
                    "----------- App/System Details --------------\r\n\r\n" +
                    "System Name:                " + System.Environment.MachineName + "\r\n" +
                    "Processors:                 " + System.Environment.ProcessorCount.ToString() + "\r\n" +
                    "OS Version:                 " + System.Environment.OSVersion.ToString() + "\r\n" +
                    "User:                       " + System.Environment.UserDomainName.ToString() + @"\" + System.Environment.UserName.ToString() + "\r\n" +
                    "Mode:                       " + (System.Environment.UserInteractive ? "Interactive" : "Non-Interactive") + "\r\n\r\n" +
                    "Command Line:               " + StripUidPwd(System.Environment.CommandLine.ToString(), @";") + "\r\n" +
                    "Current Directory:          " + System.Environment.CurrentDirectory.ToString() + "\r\n\r\n" +
                    "Executing Assembly:         " + System.Reflection.Assembly.GetExecutingAssembly().ToString() + "\r\n\r\n" +
                    (footerMessage.Trim().Length == 0 ? string.Empty : footerMessage + "\r\n\r\n");
            }
        }

        /// <summary>
        /// WithEnterpriseContent() is a method for providing full detail on the application and 
        /// system environment, and is best suited when reporting an exception to a
        /// central server, or via general distribution, where
        /// the system reporting the error can not be assumed.
        /// </summary>
        /// <param name="ReportException">a reference to the exception</param>
        /// <returns></returns>
        public static string WithEnterpriseContent(ref Exception ReportException)
        {
            return WithEnterpriseContent(ref ReportException, string.Empty, string.Empty);
        }

        /// <summary>
        /// WithMachineContent() is a method for providing only application detail, and is best suited when reporting 
        /// an exception is isolated to the event log or a local file on the workstation or server where it occurs.
        /// Unlike WithEnterpriseContent(), it omits system name, OS, processor and memory information.
        /// </summary>
        /// <param name="ReportException">a reference to the exception</param>
        /// <param name="headerMessage">optional text to prefix to the error report.</param>
        /// <param name="footerMessage">optional text to suffix to the error report.</param>
        /// <returns></returns>
        public static string WithMachineContent(ref Exception ReportException, string headerMessage, string footerMessage)
        {
            DateTime Timestamp = DateTime.Now;
            return
                "\r\n" +
                (headerMessage.Trim().Length == 0 ? string.Empty : headerMessage + "\r\n\r\n") +
                "Exception reported on:      " + Timestamp.ToString("dddd, MMM d, yy HH:mm:ss tt") + " (" + Timestamp.ToUniversalTime().ToString("dddd, MMM d, yy HH:mm:ss UTC") + " )\r\n\r\n" +
                "---------------- Exception ------------------" + "\r\n\r\n" +
                ReportException.ToString() + "\r\n\r\n" +
                "----------- App/System Details --------------\r\n\r\n" +
                "User:                       " + System.Environment.UserDomainName.ToString() + @"\" + System.Environment.UserName.ToString() + "\r\n" +
                "Mode:                       " + (System.Environment.UserInteractive ? "Interactive" : "Non-Interactive") + "\r\n\r\n" +
                "Command Line:               " + StripUidPwd(System.Environment.CommandLine.ToString(), @";") + "\r\n" +
                "Current Directory:          " + System.Environment.CurrentDirectory.ToString() + "\r\n\r\n" +
                "Executing Assembly:         " + System.Reflection.Assembly.GetExecutingAssembly().ToString() + "\r\n\r\n" +
                (footerMessage.Trim().Length == 0 ? string.Empty : footerMessage + "\r\n\r\n");
        }

        /// <summary>
        /// WithMachineContent() is a method for providing only application detail, and is best suited when reporting 
        /// an exception is isolated to the event log or a local file on the workstation or server where it occurs.
        /// Unlike WithEnterpriseContent(), it omits system name, OS, processor and memory information.
        /// </summary>
        /// <param name="ReportException">a reference to the exception</param>
        /// <returns></returns>
        public static string WithMachineContent(ref Exception ReportException)
        {
            return WithMachineContent(ref ReportException, string.Empty, string.Empty);
        }

        /// <summary>
        /// WithUserContent() is a method for providing only error detail, and is best suited 
        /// for non-fatal errors or other trapped errors reported on the console or in a dialog
        /// directly to an interactive user.  It also contains no timestamping.
        /// </summary>
        /// <param name="ReportException">a reference to the exception</param>
        /// <param name="headerMessage">optional text to prefix to the error report.</param>
        /// <param name="footerMessage">optional text to suffix to the error report.</param>
        /// <returns></returns>
        public static string WithUserContent(ref Exception ReportException, string headerMessage, string footerMessage)
        {
            DateTime Timestamp = DateTime.Now;
            return
                (headerMessage.Trim().Length == 0 ? string.Empty : headerMessage + "\r\n") +
                ReportException.ToString() + "\r\n" +
                (footerMessage.Trim().Length == 0 ? string.Empty : footerMessage + "\r\n");
        }

        /// <summary>
        /// WithUserContent() is a method for providing only error detail, and is best suited 
        /// for non-fatal errors or other trapped errors reported on the console or in a dialog
        /// directly to an interactive user.  It also contains no timestamping.
        /// </summary>
        /// <param name="ReportException">a reference to the exception</param>
        /// <returns></returns>
        public static string WithUserContent(ref Exception ReportException)
        {
            return WithUserContent(ref ReportException, string.Empty, string.Empty);
        }

    }
}
