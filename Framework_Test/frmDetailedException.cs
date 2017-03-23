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
	public partial class frmDetailedException : Form
	{
		public frmDetailedException()
		{
			InitializeComponent();
			this.cbxDetailLevel.SelectedIndex = 0;
		}

		private void btnTestIt_Click(object sender, EventArgs e)
		{
			try
			{
				throw new System.IO.IOException(this.txtErrorMessage.Text);
			}
			catch (Exception err)
			{
				if (this.cbxDetailLevel.SelectedItem.ToString() == "WithUserContent")
				{
					this.txtResultError.Text = DetailedException.WithUserContent(ref err, this.txtHeader.Text, this.txtFooter.Text);
				}
				else if (this.cbxDetailLevel.SelectedItem.ToString() == "WithMachineContent")
				{
					this.txtResultError.Text = DetailedException.WithMachineContent(ref err, this.txtHeader.Text, this.txtFooter.Text);
				}
				else if (this.cbxDetailLevel.SelectedItem.ToString() == "WithEnterpriseContent")
				{
					this.txtResultError.Text = DetailedException.WithEnterpriseContent(ref err, this.txtHeader.Text, this.txtFooter.Text);
				}
			}
		}
	}
}
