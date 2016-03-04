using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOG.Framework;

namespace BOG.Framework_Test
{
    public partial class frmBabbleOn : Form
    {
        Dictionary<int, BabbleOn> _BabbleOn = new Dictionary<int, BabbleOn>();
        BabbleFinder _BabbleFinder;
        PhraseGenerator p = new PhraseGenerator();
        Queue<string> _Messages = new Queue<string>();

        public frmBabbleOn()
        {
            InitializeComponent();
            tmrMessageSender.Interval = 1000;
            tmrMessageSender.Enabled = false;
            this.Text = "Not babbling at the moment";
        }

        private void btnStartBabbling_Click(object sender, EventArgs e)
        {
            btnStartBabbling.Enabled = false;
            lbxMessages.Items.Clear();
            this.Refresh();
            _BabbleOn.Clear();
            int lowPort = 70000;
            int highPort = 0;
            for (int listenerIndex = 0; listenerIndex < (int)this.nudListenerCount.Value; listenerIndex++)
            {
                _BabbleOn.Add(listenerIndex, new BabbleOn(20, 86400));
                _BabbleOn[listenerIndex].Start();
                highPort = _BabbleOn[listenerIndex].ListeningPort;
                if (highPort < lowPort) lowPort = highPort;
            }
            this.Text = string.Format("Babbling on port range {0}...{1}", lowPort,highPort);
            btnStartBabbling.Enabled = false;
            btnStopBabbling.Enabled = true;
            tmrMessageSender.Enabled = true;
            tmrMessageSender.Start();
        }

        private void btnStopBabbling_Click(object sender, EventArgs e)
        {
            btnStopBabbling.Enabled = false;
            this.Refresh();
            this.Text = "Not babbling at the moment";
            tmrMessageSender.Stop();
            tmrMessageSender.Enabled = false;
            foreach (int listenerIndex in _BabbleOn.Keys)
                _BabbleOn[listenerIndex].Stop();
            btnStartBabbling.Enabled = true;
            _Messages.Clear();
        }

        private void btnFindBabblers_Click(object sender, EventArgs e)
        {
            this.lbxListeners.Items.Clear();
            this.btnFindBabblers.Enabled = false;
            this.Refresh();
            _BabbleFinder = new BabbleFinder(this.txtHostToSearch.Text);
            List<ScannedPort> PortList = _BabbleFinder.ScanPorts(true);
            int ActivePortCount = 0;
            foreach (ScannedPort p in PortList)
            {
                if (!p.Found) continue;
                ActivePortCount++;
                this.lbxListeners.Items.Add(string.Format(
                    "{0}:Port={1}:ListeningSince={2}:CurrentConnectionCount={3}:MaxConnectionCount{4}:PID={5}:\r\n",
                    p.AppSignature,
                    p.Port,
                    p.StartTime,
                    p.ActiveConnections,
                    p.MaxConnections,
                    p.PID));
            }
            this.btnFindBabblers.Enabled = true;
            this.gbxBabbleFind.Text = string.Format(
                "{0} port{1} scanned, {2} active listener{3}", 
                PortList.Count, PortList.Count != 1 ? "s" : string.Empty,
                ActivePortCount, ActivePortCount != 1 ? "s" : string.Empty);
        }

        private void tmrMessageSender_Tick(object sender, EventArgs e)
        {
            if (_Messages.Count == 0)
                foreach (string s in p.GetPhrase(10)) _Messages.Enqueue(s);
            string m = _Messages.Dequeue();
            foreach (int listenerIndex in _BabbleOn.Keys)
                _BabbleOn[listenerIndex].WriteLine(m);
            this.lbxMessages.Items.Add(m);
            this.lbxMessages.SelectedIndex = this.lbxMessages.Items.Count - 1;
        }

        private void frmBabbleOn_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (int index in _BabbleOn.Keys) _BabbleOn[index].Stop();
        }

        private void lbxListeners_DoubleClick(object sender, EventArgs e)
        {
            if (this.lbxListeners.Items.Count == 0 || this.lbxListeners.SelectedIndex < 0) return;
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@"Port=\d+");
            string[] Values = r.Matches((string)this.lbxListeners.SelectedItem)[0].Value.Split(new char[] { '=' });

            System.Diagnostics.Process.Start(
                Environment.GetEnvironmentVariable("COMSPEC"),
                string.Format("/c telnet {0} {1}", this.txtHostToSearch.Text, Values[1]));
        }
    }
}
