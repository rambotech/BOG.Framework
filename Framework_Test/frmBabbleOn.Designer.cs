namespace BOG.Framework_Test
{
    partial class frmBabbleOn
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBabbleOn));
			this.tmrMessageSender = new System.Windows.Forms.Timer(this.components);
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.lbxMessages = new System.Windows.Forms.ListBox();
			this.nudListenerCount = new System.Windows.Forms.NumericUpDown();
			this.btnStopBabbling = new System.Windows.Forms.Button();
			this.btnStartBabbling = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.gbxBabbleFind = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lbxListeners = new System.Windows.Forms.ListBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtHostToSearch = new System.Windows.Forms.TextBox();
			this.btnFindBabblers = new System.Windows.Forms.Button();
			this.gbxHelp = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudListenerCount)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.gbxBabbleFind.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.gbxHelp.SuspendLayout();
			this.SuspendLayout();
			// 
			// tmrMessageSender
			// 
			this.tmrMessageSender.Tick += new System.EventHandler(this.tmrMessageSender_Tick);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1044, 590);
			this.tabControl1.TabIndex = 2;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.gbxHelp);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.lbxMessages);
			this.tabPage1.Controls.Add(this.nudListenerCount);
			this.tabPage1.Controls.Add(this.btnStopBabbling);
			this.tabPage1.Controls.Add(this.btnStartBabbling);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1036, 564);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Listener and Message Generator";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 91);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(222, 13);
			this.label2.TabIndex = 13;
			this.label2.Text = "Change the number for more than one listener";
			// 
			// lbxMessages
			// 
			this.lbxMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbxMessages.FormattingEnabled = true;
			this.lbxMessages.Location = new System.Drawing.Point(251, 17);
			this.lbxMessages.Name = "lbxMessages";
			this.lbxMessages.Size = new System.Drawing.Size(777, 537);
			this.lbxMessages.TabIndex = 10;
			// 
			// nudListenerCount
			// 
			this.nudListenerCount.Location = new System.Drawing.Point(178, 25);
			this.nudListenerCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudListenerCount.Name = "nudListenerCount";
			this.nudListenerCount.Size = new System.Drawing.Size(53, 20);
			this.nudListenerCount.TabIndex = 7;
			this.nudListenerCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// btnStopBabbling
			// 
			this.btnStopBabbling.Enabled = false;
			this.btnStopBabbling.Location = new System.Drawing.Point(8, 55);
			this.btnStopBabbling.Name = "btnStopBabbling";
			this.btnStopBabbling.Size = new System.Drawing.Size(212, 32);
			this.btnStopBabbling.TabIndex = 4;
			this.btnStopBabbling.Text = "Stop Babbling";
			this.btnStopBabbling.UseVisualStyleBackColor = true;
			this.btnStopBabbling.Click += new System.EventHandler(this.btnStopBabbling_Click);
			// 
			// btnStartBabbling
			// 
			this.btnStartBabbling.Location = new System.Drawing.Point(8, 17);
			this.btnStartBabbling.Name = "btnStartBabbling";
			this.btnStartBabbling.Size = new System.Drawing.Size(163, 32);
			this.btnStartBabbling.TabIndex = 2;
			this.btnStartBabbling.Text = "Start Babbling";
			this.btnStartBabbling.UseVisualStyleBackColor = true;
			this.btnStartBabbling.Click += new System.EventHandler(this.btnStartBabbling_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.gbxBabbleFind);
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Controls.Add(this.btnFindBabblers);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(1036, 564);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Who\'s Babbling";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// gbxBabbleFind
			// 
			this.gbxBabbleFind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxBabbleFind.Controls.Add(this.label1);
			this.gbxBabbleFind.Controls.Add(this.lbxListeners);
			this.gbxBabbleFind.Location = new System.Drawing.Point(226, 12);
			this.gbxBabbleFind.Name = "gbxBabbleFind";
			this.gbxBabbleFind.Size = new System.Drawing.Size(802, 544);
			this.gbxBabbleFind.TabIndex = 9;
			this.gbxBabbleFind.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(26, 510);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(349, 13);
			this.label1.TabIndex = 12;
			this.label1.Text = "Double-click on an entry to open a telnet client connection to the listener";
			// 
			// lbxListeners
			// 
			this.lbxListeners.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbxListeners.FormattingEnabled = true;
			this.lbxListeners.Location = new System.Drawing.Point(6, 19);
			this.lbxListeners.Name = "lbxListeners";
			this.lbxListeners.Size = new System.Drawing.Size(790, 472);
			this.lbxListeners.TabIndex = 11;
			this.lbxListeners.DoubleClick += new System.EventHandler(this.lbxListeners_DoubleClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtHostToSearch);
			this.groupBox1.Location = new System.Drawing.Point(8, 50);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(212, 49);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "HostName or IP to search";
			// 
			// txtHostToSearch
			// 
			this.txtHostToSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtHostToSearch.Location = new System.Drawing.Point(6, 19);
			this.txtHostToSearch.Name = "txtHostToSearch";
			this.txtHostToSearch.Size = new System.Drawing.Size(200, 23);
			this.txtHostToSearch.TabIndex = 7;
			this.txtHostToSearch.Text = "localhost";
			// 
			// btnFindBabblers
			// 
			this.btnFindBabblers.Location = new System.Drawing.Point(8, 12);
			this.btnFindBabblers.Name = "btnFindBabblers";
			this.btnFindBabblers.Size = new System.Drawing.Size(212, 32);
			this.btnFindBabblers.TabIndex = 4;
			this.btnFindBabblers.Text = "Find Babblers";
			this.btnFindBabblers.UseVisualStyleBackColor = true;
			this.btnFindBabblers.Click += new System.EventHandler(this.btnFindBabblers_Click);
			// 
			// gbxHelp
			// 
			this.gbxHelp.Controls.Add(this.textBox1);
			this.gbxHelp.Location = new System.Drawing.Point(10, 123);
			this.gbxHelp.Name = "gbxHelp";
			this.gbxHelp.Size = new System.Drawing.Size(229, 431);
			this.gbxHelp.TabIndex = 14;
			this.gbxHelp.TabStop = false;
			this.gbxHelp.Text = "What now?";
			this.gbxHelp.Visible = false;
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Location = new System.Drawing.Point(3, 16);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(223, 412);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = resources.GetString("textBox1.Text");
			// 
			// frmBabbleOn
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1044, 590);
			this.Controls.Add(this.tabControl1);
			this.Name = "frmBabbleOn";
			this.Text = "frmBabbleOn";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBabbleOn_FormClosing);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudListenerCount)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.gbxBabbleFind.ResumeLayout(false);
			this.gbxBabbleFind.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.gbxHelp.ResumeLayout(false);
			this.gbxHelp.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrMessageSender;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnStartBabbling;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnStopBabbling;
        private System.Windows.Forms.Button btnFindBabblers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtHostToSearch;
        private System.Windows.Forms.NumericUpDown nudListenerCount;
        private System.Windows.Forms.ListBox lbxMessages;
        private System.Windows.Forms.GroupBox gbxBabbleFind;
        private System.Windows.Forms.ListBox lbxListeners;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox gbxHelp;
		private System.Windows.Forms.TextBox textBox1;
	}
}