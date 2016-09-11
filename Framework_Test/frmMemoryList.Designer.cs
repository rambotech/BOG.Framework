namespace BOG.Framework_Test
{
	partial class frmMemoryList
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.lbxSource = new System.Windows.Forms.ListBox();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.lbxFiltered = new System.Windows.Forms.ListBox();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.cbxRetrievalMethod = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.chkIgnoreCase = new System.Windows.Forms.CheckBox();
			this.chkUnique = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.lbxSource);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(547, 397);
			this.splitContainer1.SplitterDistance = 269;
			this.splitContainer1.TabIndex = 0;
			// 
			// lbxSource
			// 
			this.lbxSource.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbxSource.FormattingEnabled = true;
			this.lbxSource.Location = new System.Drawing.Point(0, 0);
			this.lbxSource.Name = "lbxSource";
			this.lbxSource.Size = new System.Drawing.Size(269, 397);
			this.lbxSource.TabIndex = 0;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.lbxFiltered);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.chkUnique);
			this.splitContainer2.Panel2.Controls.Add(this.chkIgnoreCase);
			this.splitContainer2.Panel2.Controls.Add(this.label1);
			this.splitContainer2.Panel2.Controls.Add(this.cbxRetrievalMethod);
			this.splitContainer2.Panel2.Controls.Add(this.btnRefresh);
			this.splitContainer2.Size = new System.Drawing.Size(274, 397);
			this.splitContainer2.SplitterDistance = 296;
			this.splitContainer2.TabIndex = 0;
			// 
			// lbxFiltered
			// 
			this.lbxFiltered.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbxFiltered.FormattingEnabled = true;
			this.lbxFiltered.Location = new System.Drawing.Point(0, 0);
			this.lbxFiltered.Name = "lbxFiltered";
			this.lbxFiltered.Size = new System.Drawing.Size(274, 296);
			this.lbxFiltered.TabIndex = 1;
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnRefresh.Location = new System.Drawing.Point(191, 69);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(75, 23);
			this.btnRefresh.TabIndex = 0;
			this.btnRefresh.Text = "&Refresh";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// cbxRetrievalMethod
			// 
			this.cbxRetrievalMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbxRetrievalMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxRetrievalMethod.FormattingEnabled = true;
			this.cbxRetrievalMethod.Location = new System.Drawing.Point(113, 5);
			this.cbxRetrievalMethod.Name = "cbxRetrievalMethod";
			this.cbxRetrievalMethod.Size = new System.Drawing.Size(156, 21);
			this.cbxRetrievalMethod.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Retrieval Method";
			// 
			// chkIgnoreCase
			// 
			this.chkIgnoreCase.AutoSize = true;
			this.chkIgnoreCase.Location = new System.Drawing.Point(23, 40);
			this.chkIgnoreCase.Name = "chkIgnoreCase";
			this.chkIgnoreCase.Size = new System.Drawing.Size(83, 17);
			this.chkIgnoreCase.TabIndex = 3;
			this.chkIgnoreCase.Text = "Ignore Case";
			this.chkIgnoreCase.UseVisualStyleBackColor = true;
			// 
			// chkUnique
			// 
			this.chkUnique.AutoSize = true;
			this.chkUnique.Location = new System.Drawing.Point(136, 40);
			this.chkUnique.Name = "chkUnique";
			this.chkUnique.Size = new System.Drawing.Size(119, 17);
			this.chkUnique.TabIndex = 4;
			this.chkUnique.Text = "Unique Entries Only";
			this.chkUnique.UseVisualStyleBackColor = true;
			// 
			// frmMemoryList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(547, 397);
			this.Controls.Add(this.splitContainer1);
			this.Name = "frmMemoryList";
			this.Text = "Memory List";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ListBox lbxSource;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.ListBox lbxFiltered;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.ComboBox cbxRetrievalMethod;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkUnique;
		private System.Windows.Forms.CheckBox chkIgnoreCase;
	}
}