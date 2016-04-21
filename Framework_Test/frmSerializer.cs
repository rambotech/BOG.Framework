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
        List<List<string>> Massive = new List<List<string>>();

        public frmSerializer()
        {
            InitializeComponent();
        }

        private void btnBuild3Gb_Click(object sender, EventArgs e)
        {
            this.lblFileName.Text = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), Path.GetTempFileName());
            PhraseGenerator pg = new PhraseGenerator();
            Massive.Clear();
            long TotalSize = 0;
            while (TotalSize < 2500000000L)
            {
                long ThisSize = 0;
                List<string> Localized = new List<string>();
                while (ThisSize < 10000000L)
                {
                    foreach (string Phrase in pg.GetPhrase(1000))
                    {
                        Localized.Add(Phrase);
                        ThisSize += (long)Phrase.Length;
                    }
                }
                Massive.Add(Localized);
                TotalSize += ThisSize;
            }
            this.lblFileSize.Text = string.Format("{0} bytes", TotalSize);

            ObjectXMLSerializer<List<List<string>>>.SaveDocumentFormat(Massive, this.lblFileName.Text);
            Massive = null;
            GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            this.btnLoadDocument.Enabled = true;
        }

        private void btnLoadDocument_Click(object sender, EventArgs e)
        {
            Massive = ObjectXMLSerializer<List<List<string>>>.LoadDocumentFormat(this.lblFileName.Text);
        }
    }
}
