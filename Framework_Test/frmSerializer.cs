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
        SerializableDictionary<int, SerializableDictionary<int, string>> Massive = new SerializableDictionary<int, SerializableDictionary<int, string>>();
        SerializableDictionary<int, SerializableDictionary<int, string>> MassiveRead = new SerializableDictionary<int, SerializableDictionary<int, string>>();
        bool AbortRequested = false;
        SettingsDictionary config = new SettingsDictionary();
        Stack<string> TempFilesCreated = new Stack<string>();

        public frmSerializer()
        {
            InitializeComponent();
            config.ConfigurationFile =
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BOG.Framework.usersettings.xml");
            config.LoadSettings();
            this.lblFileName.Text = (string)config.GetSetting("LastTempFileCreated", (object)string.Empty);
            this.btnLoadDocument.Enabled = false;
            if (File.Exists(this.lblFileName.Text))
            {
                this.btnLoadDocument.Enabled = File.Exists(this.lblFileName.Text);
                TempFilesCreated.Push(this.lblFileName.Text);
            }
        }

        private bool CompareMassives()
        {
            bool Result = Massive.Keys.Count == MassiveRead.Keys.Count;
            if (Result)
            {
                foreach (int outerKey in Massive.Keys)
                {
                    if (!MassiveRead.ContainsKey(outerKey) || Massive[outerKey].Count != MassiveRead[outerKey].Count)
                    {
                        Result = false;
                        break;
                    }
                    if (Result)
                    {
                        foreach (int innerKey in Massive[outerKey].Keys)
                        {
                            if (!MassiveRead[outerKey].ContainsKey(innerKey))
                            {
                                Result = false;
                                break;
                            }
                            if (string.Compare(Massive[outerKey][innerKey], MassiveRead[outerKey][innerKey], false) != 0)
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

        private void btnBuild3Gb_Click(object sender, EventArgs e)
        {
            this.btnAbort.Text = "&Abort";
            this.btnAbort.Visible = true;
            this.btnAbort.Enabled = true;
            this.Refresh();
            this.lblFileName.Text = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), Path.GetTempFileName());
            config.SetSetting("LastTempFileCreated", (object)this.lblFileName.Text);
            config.SaveSettings();
            TempFilesCreated.Push(this.lblFileName.Text);
            PhraseGenerator pg = new PhraseGenerator();
            Massive.Clear();
            long TotalSize = 0;
            int OuterIndex = 0;
            while (!AbortRequested && TotalSize < 25000000L)
            {
                OuterIndex++;
                this.lblFileSize.Text = string.Format("{0} bytes and still working", Formatting.KiloToYotta(TotalSize));
                this.lblFileSize.Refresh();
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
                        ThisSize += (long)Phrase.Length;
                    }
                }
                Massive.Add(OuterIndex, Localized);
                TotalSize += ThisSize;
            }
            if (!AbortRequested)
            {
                this.lblFileSize.Text = string.Format("{0} bytes..Saving XML file", Formatting.KiloToYotta(TotalSize));
                this.lblFileSize.Refresh();
                ObjectXMLSerializer<SerializableDictionary<int, SerializableDictionary<int, string>>>.SaveDocumentFormat(Massive, this.lblFileName.Text);
                this.lblFileSize.Text = string.Format("{0} bytes..Saving XML GZ file", Formatting.KiloToYotta(TotalSize));
                this.lblFileSize.Refresh();
                ObjectXMLSerializer<SerializableDictionary<int, SerializableDictionary<int, string>>>.SaveCompressedDocumentFormat(Massive, this.lblFileName.Text + ".gz");
                this.lblFileSize.Text = "Save Complete";
                this.lblFileSize.Refresh();
            }
            this.btnLoadDocument.Enabled = !AbortRequested;
            this.btnBuild3Gb.Enabled = !this.btnLoadDocument.Enabled;
            this.btnAbort.Visible = false;
            this.lblFileSize.Text = "Idle";
            AbortRequested = true;
        }

        private void btnLoadDocument_Click(object sender, EventArgs e)
        {
            this.lblFileSize.Text = "Deserializing the XML file";
            this.lblFileSize.Refresh();

            MassiveRead = ObjectXMLSerializer<SerializableDictionary<int, SerializableDictionary<int, string>>>.LoadDocumentFormat(this.lblFileName.Text);
            this.lblFileSize.Text = "Comparing deserialized XML file content against original";
            this.lblFileSize.Refresh();
            if (!CompareMassives())
            {
                MessageBox.Show("The XML deserialized object does not match the original.");
            }
            MassiveRead = null;
            this.lblFileSize.Text = "Deserializing the XML GZ file";
            this.lblFileSize.Refresh();
            MassiveRead = ObjectXMLSerializer<SerializableDictionary<int, SerializableDictionary<int, string>>>.LoadCompressedDocumentFormat(this.lblFileName.Text + ".gz");
            this.lblFileSize.Text = "Comparing deserialized XML GZ file content against original";
            this.lblFileSize.Refresh();
            if (! CompareMassives())
            {
                MessageBox.Show("The XML GZ deserialized object does not match the original.");
            }
            this.lblFileSize.Text = "Forcing garbage collection";
            this.lblFileSize.Refresh();
            MassiveRead = null;
            this.lblFileSize.Text = "Idle";
            this.lblFileSize.Refresh();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            AbortRequested = true;
            this.btnAbort.Text = "Aborting...";
            this.btnAbort.Enabled = false;
        }

        private void frmSerializer_FormClosing(object sender, FormClosingEventArgs e)
        {
            while (TempFilesCreated.Count > 0)
            {
                string filename = TempFilesCreated.Pop();
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
