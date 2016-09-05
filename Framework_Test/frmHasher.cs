using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOG.Framework;

namespace BOG.Framework_Test
{
	public partial class frmHasher : Form
	{
		public frmHasher()
		{
			InitializeComponent();
			foreach (Hasher.HashMethod method in Enum.GetValues(typeof(Hasher.HashMethod)))
			{
				this.cbxHashMethod.Items.Add(method.ToString());
			}
			this.cbxHashMethod.SelectedIndex = 0;

			this.cbxEncoding.Items.Add("DEFAULT");
			foreach (EncodingInfo encodingMethod in Encoding.GetEncodings())
			{
				this.cbxEncoding.Items.Add(encodingMethod.Name);
			}
			if (this.cbxEncoding.SelectedIndex < 0)
			{
				this.cbxEncoding.SelectedIndex = 0;
			}

			this.txtSourceText.Text =
				"<?xml version=\"1.0\" encoding=\"UTF-8\"?> " + "\r\n" +
				"<settings> " + "\r\n" +
				"<ClipboardMunger.ScriptFolder>C:\\Users\\user\\Documents\\ClipboardMungerScripts</ClipboardMunger.ScriptFolder> " + "\r\n" +
				"<Tester.EventColor.DEFAULT.CustomColors.00>5953504</Tester.EventColor.DEFAULT.CustomColors.00> " + "\r\n" +
				"<Tester.EventColor.DEFAULT.CustomColors.01>16777215</Tester.EventColor.DEFAULT.CustomColors.01> " + "\r\n" +
				"<Tester.EventColor.DEFAULT.CustomColors.02>16777215</Tester.EventColor.DEFAULT.CustomColors.02> " + "\r\n" +
				"<Tester.EventColor.DEFAULT.CustomColors.03>16777215</Tester.EventColor.DEFAULT.CustomColors.03> " + "\r\n" +
				"<Tester.EventColor.DEFAULT.CustomColors.04>16777215</Tester.EventColor.DEFAULT.CustomColors.04> " + "\r\n" +
				"<Tester.EventColor.DEFAULT.CustomColors.05>16777215</Tester.EventColor.DEFAULT.CustomColors.05> " + "\r\n" +
				"<Tester.EventColor.DEFAULT.CustomColors.06>16777215</Tester.EventColor.DEFAULT.CustomColors.06> " + "\r\n" +
				"<Tester.EventColor.DEFAULT.CustomColors.07>16777215</Tester.EventColor.DEFAULT.CustomColors.07> " + "\r\n" +
				"<Tester.EventColor.DEFAULT.CustomColors.08>16777215</Tester.EventColor.DEFAULT.CustomColors.08> " + "\r\n" +
				"<Tester.EventColor.DEFAULT.CustomColors.09>16777215</Tester.EventColor.DEFAULT.CustomColors.09> " + "\r\n" +
				"<Tester.EventColor.DEFAULT.CustomColors.10>16777215</Tester.EventColor.DEFAULT.CustomColors.10> " + "\r\n" +
				"<Tester.EventColor.DEFAULT.CustomColors.11>16777215</Tester.EventColor.DEFAULT.CustomColors.11> " + "\r\n" +
				"<Tester.EventColor.DEFAULT.CustomColors.12>16777215</Tester.EventColor.DEFAULT.CustomColors.12> " + "\r\n" +
				"<Tester.EventColor.DEFAULT.CustomColors.13>16777215</Tester.EventColor.DEFAULT.CustomColors.13> " + "\r\n" +
				"<Tester.EventColor.DEFAULT.CustomColors.14>16777215</Tester.EventColor.DEFAULT.CustomColors.14> " + "\r\n" +
				"<Tester.EventColor.DEFAULT.CustomColors.15>16777215</Tester.EventColor.DEFAULT.CustomColors.15> " + "\r\n" +
				"<ManagerMDI.FileMenu.MRU.0.FileName>C:\\Users\\user\\Documents\\TempEnv.wkconf</ManagerMDI.FileMenu.MRU.0.FileName> " + "\r\n" +
				"<ManagerMDI.FileMenu.MRU.0.DateTime>12/4/2015 6:42:18 PM</ManagerMDI.FileMenu.MRU.0.DateTime> " + "\r\n" +
				"</settings> " + "\r\n";
		}

		private void AdjustObjectEnabling(bool isEnabled)
		{
			this.cbxHashMethod.Enabled = isEnabled;
			this.txtResult.Enabled = isEnabled;
			this.txtSourceText.Enabled = isEnabled;
			this.btnRunTest.Enabled = isEnabled;
		}

		private void btnRunTest_Click(object sender, EventArgs e)
		{
			AdjustObjectEnabling(false);
			this.Refresh();
			try
			{
				Hasher.HashMethod thisMethod = (Hasher.HashMethod) Enum.Parse(
					typeof(Hasher.HashMethod),
					(string) this.cbxHashMethod.Items[this.cbxHashMethod.SelectedIndex]);
				string encodingSelected = (string) this.cbxEncoding.Items[this.cbxEncoding.SelectedIndex];
				Encoding thisEncoding = string.Compare(encodingSelected, "DEFAULT", true) == 0 ? Encoding.Default : Encoding.GetEncoding(encodingSelected);
				if (this.chkFromFile.Checked)
				{
					string tempfile = Path.GetTempFileName();
					File.WriteAllText(tempfile, this.txtSourceText.Text);
					this.txtResult.Text = Hasher.GetHashFromFileContent(tempfile, thisEncoding, thisMethod);
					File.Delete(tempfile);
				}
				else
				{
					this.txtResult.Text = Hasher.GetHashFromStringContent(this.txtSourceText.Text, thisEncoding, thisMethod);
				}
			}
			catch (Exception err)
			{
				MessageBox.Show(DetailedException.WithUserContent(ref err), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			AdjustObjectEnabling(true);
		}
	}
}
