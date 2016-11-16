using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Windows.Forms;
using BOG.Framework;

namespace BOG.Framework_Test
{
	public partial class frmSerializer : Form
	{
		SerializableDictionary<int, SerializableDictionary<int, string>> MassiveXML = new SerializableDictionary<int, SerializableDictionary<int, string>>();
		SerializableDictionary<int, SerializableDictionary<int, string>> MassiveReadXML = new SerializableDictionary<int, SerializableDictionary<int, string>>();

		SerializableDictionary<int, SerializableDictionary<int, string>> MassiveJSON = new SerializableDictionary<int, SerializableDictionary<int, string>>();
		SerializableDictionary<int, SerializableDictionary<int, string>> MassiveReadJSON = new SerializableDictionary<int, SerializableDictionary<int, string>>();

		bool AbortRequested = false;

		public frmSerializer()
		{
			InitializeComponent();
			this.lblFileNameXML.Text = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ".xml");
			this.lblFileNameJSON.Text = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ".json");
			ObjectEnabling(true);
		}

		private void ObjectEnabling(bool IsIdle)
		{
			this.btnAbort.Visible = !IsIdle;
			this.btnBuild3GbXML.Enabled = IsIdle && !File.Exists(this.lblFileNameXML.Text);
			this.btnLoadDocumentXML.Enabled = IsIdle && File.Exists(this.lblFileNameXML.Text);
			this.btnBuild3GbJSON.Enabled = IsIdle && !File.Exists(this.lblFileNameJSON.Text);
			this.btnLoadDocumentJSON.Enabled = IsIdle && File.Exists(this.lblFileNameJSON.Text);
			if (!IsIdle)
				this.Refresh();
		}

		private bool CompareMassiveXMLs()
		{
			bool Result = MassiveXML.Keys.Count == MassiveReadXML.Keys.Count;
			if (Result)
			{
				foreach (int outerKey in MassiveXML.Keys)
				{
					if (!MassiveReadXML.ContainsKey(outerKey) || MassiveXML[outerKey].Count != MassiveReadXML[outerKey].Count)
					{
						Result = false;
						break;
					}
					if (Result)
					{
						foreach (int innerKey in MassiveXML[outerKey].Keys)
						{
							if (!MassiveReadXML[outerKey].ContainsKey(innerKey))
							{
								Result = false;
								break;
							}
							if (string.Compare(MassiveXML[outerKey][innerKey], MassiveReadXML[outerKey][innerKey], false) != 0)
							{
								Result = false;
								break;
							}
						}
					}
				}
			}
			return Result;
		}

		private bool CompareMassiveJSONs()
		{
			bool Result = MassiveJSON.Keys.Count == MassiveReadJSON.Keys.Count;
			if (Result)
			{
				foreach (int outerKey in MassiveJSON.Keys)
				{
					if (!MassiveReadJSON.ContainsKey(outerKey) || MassiveJSON[outerKey].Count != MassiveReadJSON[outerKey].Count)
					{
						Result = false;
						break;
					}
					if (Result)
					{
						foreach (int innerKey in MassiveJSON[outerKey].Keys)
						{
							if (!MassiveReadJSON[outerKey].ContainsKey(innerKey))
							{
								Result = false;
								break;
							}
							if (string.Compare(MassiveJSON[outerKey][innerKey], MassiveReadJSON[outerKey][innerKey], false) != 0)
							{
								Result = false;
								break;
							}
						}
					}
				}
			}
			return Result;
		}

		private void btnBuild3GbXML_Click(object sender, EventArgs e)
		{
			AbortRequested = false;
			ObjectEnabling(false);
			PhraseGenerator pg = new PhraseGenerator();
			MassiveXML.Clear();
			long TotalSize = 0;
			int OuterIndex = 0;
			while (!AbortRequested && TotalSize < 25000000L)
			{
				OuterIndex++;
				this.lblFileSizeXML.Text = string.Format("{0} bytes and still working", Formatting.KiloToYotta(TotalSize));
				this.lblFileSizeXML.Refresh();
				Application.DoEvents();
				System.Threading.Thread.Sleep(100);
				long ThisSize = 0;
				SerializableDictionary<int, string> Localized = new SerializableDictionary<int, string>();
				int InnerIndex = 0;
				while (!AbortRequested && ThisSize < 10000000L)
				{
					foreach (string Phrase in pg.GetPhrase(1000))
					{
						InnerIndex++;
						Localized.Add(InnerIndex, Phrase);
						ThisSize += (long) Phrase.Length;
					}
					Application.DoEvents();
				}
				MassiveXML.Add(OuterIndex, Localized);
				TotalSize += ThisSize;
			}
			if (!AbortRequested)
			{
				this.lblFileSizeXML.Text = string.Format("{0} bytes..Saving XML file", Formatting.KiloToYotta(TotalSize));
				this.lblFileSizeXML.Refresh();
				ObjectXMLSerializer<SerializableDictionary<int, SerializableDictionary<int, string>>>.SaveDocumentFormat(MassiveXML, this.lblFileNameXML.Text);
				this.lblFileSizeXML.Text = string.Format("{0} bytes..Saving XML GZ file", Formatting.KiloToYotta(TotalSize));
				this.lblFileSizeXML.Refresh();
				ObjectXMLSerializer<SerializableDictionary<int, SerializableDictionary<int, string>>>.SaveCompressedDocumentFormat(MassiveXML, this.lblFileNameXML.Text + ".gz");
				//string rawSize = Formatting.KiloToYotta((double) new FileInfo(this.lblFileNameXML.Text).Length);
				//string gzSize = Formatting.KiloToYotta((double) new FileInfo(this.lblFileNameXML.Text + ".gz").Length);

				this.lblFileSizeXML.Text = string.Format("Save Complete: Memory = {0}, XML = {1}, XML/GZ = {2}",
					TotalSize,
					new FileInfo(this.lblFileNameXML.Text).Length,
					new FileInfo(this.lblFileNameXML.Text + ".gz").Length);
			}
			else
			{
				this.lblFileSizeXML.Text = "Aborted by operator";
			}
			ObjectEnabling(true);
		}

		private void btnLoadDocumentXML_Click(object sender, EventArgs e)
		{
			this.lblFileSizeXML.Text = "Deserializing the XML file";
			AbortRequested = false;
			ObjectEnabling(false);

			MassiveReadXML = ObjectXMLSerializer<SerializableDictionary<int, SerializableDictionary<int, string>>>.LoadDocumentFormat(this.lblFileNameXML.Text);
			this.lblFileSizeXML.Text = "Comparing deserialized XML file content against original";
			this.lblFileSizeXML.Refresh();
			if (!CompareMassiveXMLs())
			{
				MessageBox.Show("The XML deserialized object does not match the original.");
			}
			MassiveReadXML = null;
			this.lblFileSizeXML.Text = "Deserializing the XML GZ file";
			this.lblFileSizeXML.Refresh();
			MassiveReadXML = ObjectXMLSerializer<SerializableDictionary<int, SerializableDictionary<int, string>>>.LoadCompressedDocumentFormat(this.lblFileNameXML.Text + ".gz");
			this.lblFileSizeXML.Text = "Comparing deserialized XML GZ file content against original";
			this.lblFileSizeXML.Refresh();
			if (!CompareMassiveXMLs())
			{
				MessageBox.Show("The XML GZ deserialized object does not match the original.");
			}
			this.lblFileSizeXML.Text = "Forcing garbage collection";
			this.lblFileSizeXML.Refresh();
			MassiveReadXML = null;
			this.lblFileSizeXML.Text = "Idle";
			ObjectEnabling(true);
		}

		private void btnBuild3GbJSON_Click(object sender, EventArgs e)
		{
			AbortRequested = false;
			ObjectEnabling(false);
			PhraseGenerator pg = new PhraseGenerator();
			MassiveXML.Clear();
			long TotalSize = 0;
			int OuterIndex = 0;
			while (!AbortRequested && TotalSize < 25000000L)
			{
				OuterIndex++;
				this.lblFileSizeJSON.Text = string.Format("{0} bytes and still working", Formatting.KiloToYotta(TotalSize));
				this.lblFileSizeJSON.Refresh();
				Application.DoEvents();
				System.Threading.Thread.Sleep(100);
				long ThisSize = 0;
				SerializableDictionary<int, string> Localized = new SerializableDictionary<int, string>();
				int InnerIndex = 0;
				while (!AbortRequested && ThisSize < 10000000L)
				{
					foreach (string Phrase in pg.GetPhrase(1000))
					{
						InnerIndex++;
						Localized.Add(InnerIndex, Phrase);
						ThisSize += (long) Phrase.Length;
					}
					Application.DoEvents();
				}
				MassiveJSON.Add(OuterIndex, Localized);
				TotalSize += ThisSize;
			}
			if (!AbortRequested)
			{
				this.lblFileSizeJSON.Text = string.Format("{0} bytes..Saving JSON file", Formatting.KiloToYotta(TotalSize));
				this.lblFileSizeJSON.Refresh();
				ObjectJsonSerializer<SerializableDictionary<int, SerializableDictionary<int, string>>>.SaveDocumentFormat(MassiveJSON, this.lblFileNameJSON.Text);
				this.lblFileSizeJSON.Text = string.Format("{0} bytes..Saving JSON GZ file", Formatting.KiloToYotta(TotalSize));
				this.lblFileSizeJSON.Refresh();
				ObjectJsonSerializer<SerializableDictionary<int, SerializableDictionary<int, string>>>.SaveCompressedDocumentFormat(MassiveJSON, this.lblFileNameJSON.Text + ".gz");
				//string rawSize = Formatting.KiloToYotta((double) new FileInfo(this.lblFileNameJSON.Text).Length);
				//string gzSize = Formatting.KiloToYotta((double) new FileInfo(this.lblFileNameJSON.Text + ".gz").Length);

				this.lblFileSizeJSON.Text = string.Format("Save Complete: Memory = {0}, JSON = {1}, JSON.GZ = {2}",
					TotalSize,
					new FileInfo(this.lblFileNameJSON.Text).Length,
					new FileInfo(this.lblFileNameJSON.Text + ".gz").Length);
				this.lblFileSizeJSON.Refresh();
			}
			else
			{
				this.lblFileSizeJSON.Text = "Aborted by operator";
			}
			ObjectEnabling(true);
		}

		private void btnLoadDocumentJSON_Click(object sender, EventArgs e)
		{
			this.lblFileSizeJSON.Text = "Deserializing the JSON file";
			AbortRequested = false;
			ObjectEnabling(false);

			MassiveReadJSON = ObjectJsonSerializer<SerializableDictionary<int, SerializableDictionary<int, string>>>.LoadDocumentFormat(this.lblFileNameJSON.Text);
			this.lblFileSizeJSON.Text = "Comparing deserialized JSON file content against original";
			this.lblFileSizeJSON.Refresh();
			if (!CompareMassiveJSONs())
			{
				MessageBox.Show("The JSON deserialized object does not match the original.");
			}
			MassiveReadJSON = null;
			this.lblFileSizeJSON.Text = "Deserializing the JSON GZ file";
			this.lblFileSizeJSON.Refresh();
			MassiveReadJSON = ObjectJsonSerializer<SerializableDictionary<int, SerializableDictionary<int, string>>>.LoadCompressedDocumentFormat(this.lblFileNameJSON.Text + ".gz");
			this.lblFileSizeJSON.Text = "Comparing deserialized JSON GZ file content against original";
			this.lblFileSizeJSON.Refresh();
			if (!CompareMassiveJSONs())
			{
				MessageBox.Show("The JSON GZ deserialized object does not match the original.");
			}
			this.lblFileSizeJSON.Text = "Forcing garbage collection";
			this.lblFileSizeJSON.Refresh();
			MassiveReadXML = null;
			this.lblFileSizeJSON.Text = "Idle";
			ObjectEnabling(true);
		}

		private void btnAbort_Click(object sender, EventArgs e)
		{
			AbortRequested = true;
			this.btnAbort.Text = "Aborting...";
			this.btnAbort.Enabled = false;
		}

		private void frmSerializer_FormClosing(object sender, FormClosingEventArgs e)
		{
			int FileIndex = 0;
			while (FileIndex++ < 2)
			{
				string filename = FileIndex == 1 ? this.lblFileNameXML.Text : this.lblFileNameJSON.Text;
				if (File.Exists(filename))
				{
					try
					{
						File.Delete(filename);
					}
					catch
					{
					}
					try
					{
						File.Delete(filename + ".gz");
					}
					catch
					{
					}
				}
			}
		}
	}
}
