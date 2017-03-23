namespace BOG.Framework_Test
{
	partial class frmAssemblyInfo
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dgvAssemblyInfo = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize) (this.dgvAssemblyInfo)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvAssemblyInfo
			// 
			this.dgvAssemblyInfo.AllowUserToAddRows = false;
			this.dgvAssemblyInfo.AllowUserToDeleteRows = false;
			this.dgvAssemblyInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvAssemblyInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvAssemblyInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvAssemblyInfo.Location = new System.Drawing.Point(0, 0);
			this.dgvAssemblyInfo.Name = "dgvAssemblyInfo";
			this.dgvAssemblyInfo.Size = new System.Drawing.Size(664, 440);
			this.dgvAssemblyInfo.TabIndex = 1;
			// 
			// frmAssemblyInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(664, 440);
			this.Controls.Add(this.dgvAssemblyInfo);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "frmAssemblyInfo";
			this.Text = "AssemblyInfo";
			((System.ComponentModel.ISupportInitialize) (this.dgvAssemblyInfo)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvAssemblyInfo;
	}
}