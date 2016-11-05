using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BOG.Framework_Test
{
    public partial class frmTestSelector : Form
    {
        public frmTestSelector()
        {
            InitializeComponent();
		}

        private void btnBabbleOn_Click(object sender, EventArgs e)
        {
            frmBabbleOn f = new frmBabbleOn();
            f.ShowDialog(this);
        }

        private void btnFuse_Click(object sender, EventArgs e)
        {
            frmFuse f = new frmFuse();
            f.ShowDialog(this);
        }

        private void btnFormatting_Click(object sender, EventArgs e)
        {
            frmFormatting f = new frmFormatting();
            f.ShowDialog(this);
        }

        private void btnDetailedException_Click(object sender, EventArgs e)
        {
            frmDetailedException f = new frmDetailedException();
            f.ShowDialog(this);
        }

        private void btnSerializableDictionary_Click(object sender, EventArgs e)
        {
            frmSerializableDictionary f = new frmSerializableDictionary();
            f.ShowDialog(this);
        }

        private void btnStringEx_Click(object sender, EventArgs e)
        {
            frmStringEx f = new frmStringEx();
            f.ShowDialog(this);
        }

        private void btnScrape_Click(object sender, EventArgs e)
        {
            frmScrape f = new frmScrape();
            f.ShowDialog(this);
        }

        private void btnSettingsDictionary_Click(object sender, EventArgs e)
        {
            frmSettingsDictionary f = new frmSettingsDictionary();
            f.ShowDialog(this);
        }

        private void btnAssemblyInfo_Click(object sender, EventArgs e)
        {
            frmAssemblyInfo f = new frmAssemblyInfo();
            f.ShowDialog(this);
        }

        private void btnCipherUtility_Click(object sender, EventArgs e)
        {
            frmCipherUtility f = new frmCipherUtility();
            f.ShowDialog(this);
        }

        private void btnLogger_Click(object sender, EventArgs e)
        {
            frmLogger f = new frmLogger();
            f.ShowDialog(this);
        }

        private void btnSerializer_Click(object sender, EventArgs e)
        {
            frmSerializer f = new frmSerializer();
            f.ShowDialog(this);
        }

		private void btnHasher_Click(object sender, EventArgs e)
		{
			frmHasher f = new frmHasher();
			f.ShowDialog(this);
		}

		private void btnMemoryList_Click(object sender, EventArgs e)
		{
			frmMemoryList f = new frmMemoryList();
			f.ShowDialog(this);
		}

		private void btnDynamicScripting_Click(object sender, EventArgs e)
		{
			frmDynamicScripting f = new frmDynamicScripting();
			f.ShowDialog(this);
		}
	}
}
