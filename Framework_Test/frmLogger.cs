using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOG.Framework;

namespace BOG.Framework_Test
{
	public partial class frmLogger : Form
	{
		Logger fileLog;
		int Counter = 0;

		public frmLogger()
		{
			InitializeComponent();
			txtLogFilePath.Text = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments),
				"MyCompany", "MyApplication", "MyAppLogs");
			txtLogFileNamePattern.Text = "Log_{0:yyyyMMdd_HHmmss}.txt";
		}

		private void btnLog_Click(object sender, EventArgs e)
		{
			if (fileLog == null)
			{
				btnLog.Text = "&Stop";
				lbxLoggedContents.Items.Clear();
				fileLog = new Logger();
				fileLog.MessageFilePath = txtLogFilePath.Text;
				fileLog.MessageFilePattern = txtLogFileNamePattern.Text;
				fileLog.MaxSizeThreshold = 10240L;
				fileLog.MaxSecondsThreshold = 60;
				Counter = 0;
				timer1.Interval = 100;
				timer1.Enabled = true;
				timer1.Start();
			}
			else
			{
				timer1.Stop();
				timer1.Enabled = false;
				btnLog.Text = "&Start";
				fileLog = null;
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			string message = string.Format("{0} line in the file", Counter++);
			fileLog.CommitMessageLineToFile(message);
			lbxLoggedContents.Items.Add(message);
			lbxLoggedContents.SelectedIndex = lbxLoggedContents.Items.Count - 1;
		}
	}
}
