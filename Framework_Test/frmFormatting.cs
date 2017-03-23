using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOG.Framework;

namespace BOG.Framework_Test
{
	public partial class frmFormatting : Form
	{
		public frmFormatting()
		{
			InitializeComponent();
		}

		private void frmFormatting_Load(object sender, EventArgs e)
		{
			this.lbxKZdatatype.SelectedIndex = 0;
		}

		private void btnTestKiloToZeta_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.lbxKZdatatype.SelectedIndex == 0)
				{
					this.txtKZresult.Text = Formatting.KiloToYotta(double.Parse(this.txtKZsource.Text));
				}
				else
				{
					this.txtKZresult.Text = Formatting.KiloToYotta(long.Parse(this.txtKZsource.Text));
				}
			}
			catch (Exception err)
			{
				MessageBox.Show(DetailedException.WithUserContent(ref err));
			}
		}

		private void btnWCMtest_Click(object sender, EventArgs e)
		{
			try
			{
				this.txtWCMresult.Text = Formatting.CurrencyWrittenAmount(decimal.Parse(this.txtWCMsource.Text));
			}
			catch (Exception err)
			{
				MessageBox.Show(DetailedException.WithUserContent(ref err));
			}
		}
	}
}
