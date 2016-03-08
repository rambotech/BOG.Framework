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
    public partial class frmFuse : Form
    {
        Fuse f = null;
        int ActivityCount = 0;

        public frmFuse()
        {
            InitializeComponent();
            foreach (string name in Enum.GetNames(typeof(Fuse.FuseBehavior)))
            {
                this.cbxFuseBehaviorType.Items.Add(name);
            }
            this.cbxFuseBehaviorType.SelectedIndex = 1;
        }

        private void ControlEnabling (bool Starting)
        {
            this.btnStartActivity.Enabled = !Starting;
            this.btnEndActivity.Enabled = Starting;
            this.cbxFuseBehaviorType.Enabled = !Starting;
            this.chkAutoReset.Enabled = !Starting;
            this.btnStartActivity.Enabled = !Starting;
            this.btnEndActivity.Enabled = Starting;
            this.nudActivityIntervalMs.Enabled = !Starting;
            this.nudHitThreshold.Enabled = !Starting;
            this.nudVolThreshold.Enabled = !Starting;
            this.nudTimeframeMs.Enabled = !Starting;
            this.nudVolumePerInterval.Enabled = !Starting;
        }

        private void btnStartActivity_Click(object sender, EventArgs e)
        {
            ControlEnabling(true);
            if (f == null)
            {
                f = new Fuse(
                    (Fuse.FuseBehavior)Enum.Parse(typeof(Fuse.FuseBehavior), this.cbxFuseBehaviorType.Items[this.cbxFuseBehaviorType.SelectedIndex].ToString()),
                    (int)this.nudHitThreshold.Value, (int)this.nudVolThreshold.Value,
                    new TimeSpan(0, 0, 0, 0, (int)this.nudTimeframeMs.Value), this.chkAutoReset.Checked);
            }
            tmrActivityMaker.Interval = (int)this.nudActivityIntervalMs.Value;
            tmrActivityMaker.Enabled = true;
            tmrActivityMaker.Start();
        }

        private void btnEndActivity_Click(object sender, EventArgs e)
        {
            tmrActivityMaker.Stop();
            tmrActivityMaker.Enabled = false;
            ControlEnabling(false);
        }

        private void tmrActivityMaker_Tick(object sender, EventArgs e)
        {
            ActivityCount++;
            Fuse.FuseTrip result = f.RecordFuseEvent((float)this.nudVolumePerInterval.Value);
            this.lbxFuseStream.Items.Add(string.Format(
                "Activity Count:{0:#,000} Result:{1:-10} HitVal: {2:#,000} HitPct:{3:#,000.00} VolVal: {4:#,000} VolPct {5:#,000.00}",
                ActivityCount,
                Enum.GetName(typeof(Fuse.FuseTrip), result),
                f.Hits,
                f.HitPercentage * 100.0,
                f.Volume,
                f.VolumePercentage * 100.0));
            this.lbxFuseStream.SelectedIndex = this.lbxFuseStream.Items.Count - 1;
        }

        private void btnClearActivity_Click(object sender, EventArgs e)
        {
            this.lbxFuseStream.Items.Clear();
            ActivityCount = 0;
            f = new Fuse(
                (Fuse.FuseBehavior)Enum.Parse(typeof(Fuse.FuseBehavior), this.cbxFuseBehaviorType.Items[this.cbxFuseBehaviorType.SelectedIndex].ToString()),
                (int)this.nudHitThreshold.Value, (int)this.nudVolThreshold.Value,
                new TimeSpan(0, 0, 0, 0, (int)this.nudTimeframeMs.Value), this.chkAutoReset.Checked);
        }
    }
}
