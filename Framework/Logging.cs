using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace BOG.Framework
{
	/// <summary>
	/// A wrapper for committing entries to Windows event logs (application, system, etc).
	/// </summary>
	public static class Logging
	{
		/// <summary>
		/// Write a string message to an event log
		/// </summary>
		/// <param name="logName">The name of the log</param>
		/// <param name="entryType">The standard Information, Warning, Error, ...</param>
		/// <param name="message">The text of the event log entry to create</param>
		public static void LogToEventLog(string logName, EventLogEntryType entryType, string message)
		{
			EventLog myLog = new EventLog();
			myLog.Source = logName;
			myLog.WriteEntry(message, entryType);
			myLog.Close();
			myLog.Dispose();
		}
	}
}
