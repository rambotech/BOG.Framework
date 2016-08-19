using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BOG.Framework
{
	/// <summary>
	/// Supports logging to text files in a folder, using timestamped patterns in the file name.
	/// Rollover occurs when the file exceeds a designated size, or a freshness timeframe.
	/// </summary>
	public class Logger
	{
		string _messageFilePath = Environment.GetEnvironmentVariable("TEMP"); 
		string _messageFilePattern = "Log_{0:yyyyMMdd_HHmmss}.txt";
		int _maxSecondsThreshold = 3600;
		long _maxSizeThreshold = 150L * 1024L;

		string CurrentFileName = string.Empty;
		long CurrentFileSize = 0L;
		DateTime CurrentFileCreated = DateTime.MinValue;
		StreamWriter sw = null;

		/// <summary>
		/// The folder where log files are written.
		/// </summary>
		public string MessageFilePath
		{
			get { return _messageFilePath; }
			set { _messageFilePath = value; }
		}

		/// <summary>
		/// The filename pattern to use when creating a new log file name.  The filename is constructed using
		/// string filename = string.Format (MessageFilePattern, DateTime.Now);
		/// E.g.: for "Log_{0:yyyyMMdd_HHmmss}.txt" on 6/26/2016 14:51:16, the filename generated would be
		/// Log_20160616_145116.txt
		/// </summary>
		public string MessageFilePattern
		{
			get { return _messageFilePattern; }
			set { _messageFilePattern = value; }
		}

		/// <summary>
		/// The maximum number of seconds to write to this log file, before rolling to a new file.
		/// Set to zero for unlimited.
		/// </summary>
		public int MaxSecondsThreshold
		{
			get { return _maxSecondsThreshold; }
			set { _maxSecondsThreshold = value; }
		}

		/// <summary>
		/// The maximumnumber of bytes to write into a log file, before rolling to a new file.
		/// Set to zero for unlimited.
		/// </summary>
		public long MaxSizeThreshold
		{
			get { return _maxSizeThreshold; }
			set { _maxSizeThreshold = value; }
		}

		/// <summary>
		/// Initialize with defaults.
		/// </summary>
		public Logger()
		{
		}

		/// <summary>
		/// Initialize with specific arguments
		/// </summary>
		/// <param name="messageFilePath">The folder to store the files.</param>
		/// <param name="messageFilePattern">The pattern to use for string.Format() to create a file name.
		/// Use {0} or {0:...} to format the DateTime.Now argument supplied.  E.g.: MyAppLog_{0:yyyyMMdd_HHmmss}.txt</param>
		/// <param name="maxSeconds">The number of seconds after creation when the current file in use must be closed,
		/// and a new file created.  Use 0 for indefinite, 86400 for  a day.</param>
		/// <param name="maxSize">The number of bytes written to a file which, when exceeeded, closes the file, and a new file is created.  
		/// Use 0L for not size limit.  NOTE: The value is a threshold, and the actual</param>
		public Logger(string messageFilePath, string messageFilePattern, int maxSeconds, long maxSize)
		{
			_messageFilePath = messageFilePath;
			_messageFilePattern = messageFilePattern;
			_maxSecondsThreshold = maxSeconds;
			_maxSizeThreshold = maxSize;
		}

		/// <summary>
		/// Ensures the stream is closed gracefully before dispose.
		/// </summary>
		~Logger()
		{
			if (sw != null)
			{
				try
				{
					sw.Close();
				}
				catch { }
			}
		}

		/// <summary>
		/// Adds a line to the log file, and appends a newline character.
		/// </summary>
		/// <param name="message"></param>
		public void CommitMessageLineToFile (string message)
		{
			CommitMessageToFile(message + "\r\n");
		}

		/// <summary>
		/// Commit a message to the current log file.
		/// </summary>
		/// <param name="message">The string to append to the log file.  BYOCRLF</param>
		public void CommitMessageToFile(string message)
		{
			if ((_maxSizeThreshold > 0L && CurrentFileSize + message.Length > _maxSizeThreshold && message.Length < _maxSizeThreshold) ||
				(_maxSecondsThreshold > 0L &&
					(CurrentFileCreated.AddSeconds(_maxSecondsThreshold) < DateTime.Now || string.IsNullOrEmpty(CurrentFileName))))
			{
				if (sw != null)
				{
					sw.Close();
				}
				CurrentFileCreated = DateTime.Now;
				CurrentFileSize = 0L;
				CurrentFileName = Path.Combine(_messageFilePath, string.Format(_messageFilePattern, CurrentFileCreated));
				if (! Directory.Exists(_messageFilePath))
				{
					Directory.CreateDirectory(_messageFilePath);
				}
				sw = new StreamWriter(CurrentFileName, true);
			}
			CurrentFileSize += message.Length;
			sw.Write(message);
			sw.Flush();
		}
	}
}
