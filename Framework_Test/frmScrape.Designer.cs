namespace BOG.Framework_Test
{
    partial class frmScrape
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabRetrieveURL = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCaptureRURL = new System.Windows.Forms.TextBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnTestHttpCaptureText = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabRegExChunk = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabSourceREC = new System.Windows.Forms.TabPage();
            this.txtSourceTextREC = new System.Windows.Forms.TextBox();
            this.tabResultREC = new System.Windows.Forms.TabPage();
            this.lstMatchResultsREC = new System.Windows.Forms.ListBox();
            this.txtMatchTextREC = new System.Windows.Forms.TextBox();
            this.nudMaxChunkLength = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudEndIteration = new System.Windows.Forms.NumericUpDown();
            this.chkEndIgnoreCase = new System.Windows.Forms.CheckBox();
            this.txtRegExEnd = new System.Windows.Forms.TextBox();
            this.btnRegExChunkTest = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudStartIteration = new System.Windows.Forms.NumericUpDown();
            this.chkStartIgnoreCase = new System.Windows.Forms.CheckBox();
            this.txtRegExStart = new System.Windows.Forms.TextBox();
            this.tabRegFind = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtCaptureTextRF = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lstRegExFindRF = new System.Windows.Forms.ListBox();
            this.txtRegExFindResultsRF = new System.Windows.Forms.TextBox();
            this.btnRegExFindRF = new System.Windows.Forms.Button();
            this.nudIterationRF = new System.Windows.Forms.NumericUpDown();
            this.chkIgnoreCaseRF = new System.Windows.Forms.CheckBox();
            this.txtRegExFindRF = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabRetrieveURL.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabRegExChunk.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabSourceREC.SuspendLayout();
            this.tabResultREC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxChunkLength)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndIteration)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartIteration)).BeginInit();
            this.tabRegFind.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIterationRF)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabRetrieveURL);
            this.tabControl1.Controls.Add(this.tabRegExChunk);
            this.tabControl1.Controls.Add(this.tabRegFind);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(837, 476);
            this.tabControl1.TabIndex = 0;
            // 
            // tabRetrieveURL
            // 
            this.tabRetrieveURL.Controls.Add(this.groupBox1);
            this.tabRetrieveURL.Controls.Add(this.txtURL);
            this.tabRetrieveURL.Controls.Add(this.btnTestHttpCaptureText);
            this.tabRetrieveURL.Controls.Add(this.statusStrip1);
            this.tabRetrieveURL.Location = new System.Drawing.Point(4, 22);
            this.tabRetrieveURL.Name = "tabRetrieveURL";
            this.tabRetrieveURL.Padding = new System.Windows.Forms.Padding(3);
            this.tabRetrieveURL.Size = new System.Drawing.Size(829, 450);
            this.tabRetrieveURL.TabIndex = 0;
            this.tabRetrieveURL.Text = "RetrieveURL";
            this.tabRetrieveURL.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtCaptureRURL);
            this.groupBox1.Location = new System.Drawing.Point(8, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(813, 390);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Waiting for button push...";
            // 
            // txtCaptureRURL
            // 
            this.txtCaptureRURL.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaptureRURL.Location = new System.Drawing.Point(6, 19);
            this.txtCaptureRURL.Multiline = true;
            this.txtCaptureRURL.Name = "txtCaptureRURL";
            this.txtCaptureRURL.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCaptureRURL.Size = new System.Drawing.Size(801, 365);
            this.txtCaptureRURL.TabIndex = 8;
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(8, 6);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(706, 20);
            this.txtURL.TabIndex = 6;
            this.txtURL.Text = "http://www.palottery.state.pa.us/Games/Print-Past-Winning-Numbers.aspx?id=12&year" +
    "=2016&print=1";
            // 
            // btnTestHttpCaptureText
            // 
            this.btnTestHttpCaptureText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestHttpCaptureText.Location = new System.Drawing.Point(720, 4);
            this.btnTestHttpCaptureText.Name = "btnTestHttpCaptureText";
            this.btnTestHttpCaptureText.Size = new System.Drawing.Size(103, 23);
            this.btnTestHttpCaptureText.TabIndex = 5;
            this.btnTestHttpCaptureText.Text = "Retrieve URL";
            this.btnTestHttpCaptureText.UseVisualStyleBackColor = true;
            this.btnTestHttpCaptureText.Click += new System.EventHandler(this.btnTestHttpCaptureText_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(3, 425);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(823, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // tabRegExChunk
            // 
            this.tabRegExChunk.Controls.Add(this.tabControl2);
            this.tabRegExChunk.Controls.Add(this.nudMaxChunkLength);
            this.tabRegExChunk.Controls.Add(this.label1);
            this.tabRegExChunk.Controls.Add(this.groupBox2);
            this.tabRegExChunk.Controls.Add(this.btnRegExChunkTest);
            this.tabRegExChunk.Controls.Add(this.groupBox3);
            this.tabRegExChunk.Location = new System.Drawing.Point(4, 22);
            this.tabRegExChunk.Name = "tabRegExChunk";
            this.tabRegExChunk.Size = new System.Drawing.Size(829, 450);
            this.tabRegExChunk.TabIndex = 1;
            this.tabRegExChunk.Text = "RegExChunk";
            this.tabRegExChunk.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabSourceREC);
            this.tabControl2.Controls.Add(this.tabResultREC);
            this.tabControl2.Location = new System.Drawing.Point(8, 90);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(818, 357);
            this.tabControl2.TabIndex = 25;
            // 
            // tabSourceREC
            // 
            this.tabSourceREC.Controls.Add(this.txtSourceTextREC);
            this.tabSourceREC.Location = new System.Drawing.Point(4, 22);
            this.tabSourceREC.Name = "tabSourceREC";
            this.tabSourceREC.Padding = new System.Windows.Forms.Padding(3);
            this.tabSourceREC.Size = new System.Drawing.Size(810, 331);
            this.tabSourceREC.TabIndex = 0;
            this.tabSourceREC.Text = "Source Text (from RetrieveURL)";
            this.tabSourceREC.UseVisualStyleBackColor = true;
            // 
            // txtSourceTextREC
            // 
            this.txtSourceTextREC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSourceTextREC.Location = new System.Drawing.Point(3, 3);
            this.txtSourceTextREC.Multiline = true;
            this.txtSourceTextREC.Name = "txtSourceTextREC";
            this.txtSourceTextREC.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSourceTextREC.Size = new System.Drawing.Size(804, 325);
            this.txtSourceTextREC.TabIndex = 22;
            this.txtSourceTextREC.DoubleClick += new System.EventHandler(this.txtSourceTextREC_DoubleClick);
            // 
            // tabResultREC
            // 
            this.tabResultREC.Controls.Add(this.lstMatchResultsREC);
            this.tabResultREC.Controls.Add(this.txtMatchTextREC);
            this.tabResultREC.Location = new System.Drawing.Point(4, 22);
            this.tabResultREC.Name = "tabResultREC";
            this.tabResultREC.Padding = new System.Windows.Forms.Padding(3);
            this.tabResultREC.Size = new System.Drawing.Size(810, 331);
            this.tabResultREC.TabIndex = 1;
            this.tabResultREC.Text = "Result";
            this.tabResultREC.UseVisualStyleBackColor = true;
            // 
            // lstMatchResultsREC
            // 
            this.lstMatchResultsREC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMatchResultsREC.FormattingEnabled = true;
            this.lstMatchResultsREC.Location = new System.Drawing.Point(6, 6);
            this.lstMatchResultsREC.Name = "lstMatchResultsREC";
            this.lstMatchResultsREC.Size = new System.Drawing.Size(798, 69);
            this.lstMatchResultsREC.TabIndex = 23;
            this.lstMatchResultsREC.SelectedIndexChanged += new System.EventHandler(this.lstMatchResultsREC_SelectedIndexChanged);
            // 
            // txtMatchTextREC
            // 
            this.txtMatchTextREC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMatchTextREC.Location = new System.Drawing.Point(6, 81);
            this.txtMatchTextREC.Multiline = true;
            this.txtMatchTextREC.Name = "txtMatchTextREC";
            this.txtMatchTextREC.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMatchTextREC.Size = new System.Drawing.Size(798, 244);
            this.txtMatchTextREC.TabIndex = 22;
            // 
            // nudMaxChunkLength
            // 
            this.nudMaxChunkLength.Location = new System.Drawing.Point(626, 42);
            this.nudMaxChunkLength.Maximum = new decimal(new int[] {
            10248,
            0,
            0,
            0});
            this.nudMaxChunkLength.Name = "nudMaxChunkLength";
            this.nudMaxChunkLength.Size = new System.Drawing.Size(94, 20);
            this.nudMaxChunkLength.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(623, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Max Chunk Length";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudEndIteration);
            this.groupBox2.Controls.Add(this.chkEndIgnoreCase);
            this.groupBox2.Controls.Add(this.txtRegExEnd);
            this.groupBox2.Location = new System.Drawing.Point(311, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(297, 76);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Ending Pattern ";
            // 
            // nudEndIteration
            // 
            this.nudEndIteration.Location = new System.Drawing.Point(212, 45);
            this.nudEndIteration.Name = "nudEndIteration";
            this.nudEndIteration.Size = new System.Drawing.Size(79, 20);
            this.nudEndIteration.TabIndex = 8;
            this.nudEndIteration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkEndIgnoreCase
            // 
            this.chkEndIgnoreCase.AutoSize = true;
            this.chkEndIgnoreCase.Checked = true;
            this.chkEndIgnoreCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEndIgnoreCase.Location = new System.Drawing.Point(51, 45);
            this.chkEndIgnoreCase.Name = "chkEndIgnoreCase";
            this.chkEndIgnoreCase.Size = new System.Drawing.Size(83, 17);
            this.chkEndIgnoreCase.TabIndex = 7;
            this.chkEndIgnoreCase.Text = "Ignore Case";
            this.chkEndIgnoreCase.UseVisualStyleBackColor = true;
            // 
            // txtRegExEnd
            // 
            this.txtRegExEnd.Location = new System.Drawing.Point(15, 19);
            this.txtRegExEnd.Name = "txtRegExEnd";
            this.txtRegExEnd.Size = new System.Drawing.Size(276, 20);
            this.txtRegExEnd.TabIndex = 6;
            this.txtRegExEnd.Text = "<strong>PowerPlay:</strong>";
            // 
            // btnRegExChunkTest
            // 
            this.btnRegExChunkTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegExChunkTest.Location = new System.Drawing.Point(736, 7);
            this.btnRegExChunkTest.Name = "btnRegExChunkTest";
            this.btnRegExChunkTest.Size = new System.Drawing.Size(85, 76);
            this.btnRegExChunkTest.TabIndex = 21;
            this.btnRegExChunkTest.Text = "Chunk Test";
            this.btnRegExChunkTest.UseVisualStyleBackColor = true;
            this.btnRegExChunkTest.Click += new System.EventHandler(this.btnRegExChunkTest_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nudStartIteration);
            this.groupBox3.Controls.Add(this.chkStartIgnoreCase);
            this.groupBox3.Controls.Add(this.txtRegExStart);
            this.groupBox3.Location = new System.Drawing.Point(8, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(297, 76);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Starting Pattern ";
            // 
            // nudStartIteration
            // 
            this.nudStartIteration.Location = new System.Drawing.Point(212, 44);
            this.nudStartIteration.Name = "nudStartIteration";
            this.nudStartIteration.Size = new System.Drawing.Size(79, 20);
            this.nudStartIteration.TabIndex = 14;
            // 
            // chkStartIgnoreCase
            // 
            this.chkStartIgnoreCase.AutoSize = true;
            this.chkStartIgnoreCase.Checked = true;
            this.chkStartIgnoreCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStartIgnoreCase.Location = new System.Drawing.Point(46, 45);
            this.chkStartIgnoreCase.Name = "chkStartIgnoreCase";
            this.chkStartIgnoreCase.Size = new System.Drawing.Size(83, 17);
            this.chkStartIgnoreCase.TabIndex = 13;
            this.chkStartIgnoreCase.Text = "Ignore Case";
            this.chkStartIgnoreCase.UseVisualStyleBackColor = true;
            // 
            // txtRegExStart
            // 
            this.txtRegExStart.Location = new System.Drawing.Point(10, 19);
            this.txtRegExStart.Name = "txtRegExStart";
            this.txtRegExStart.Size = new System.Drawing.Size(281, 20);
            this.txtRegExStart.TabIndex = 12;
            this.txtRegExStart.Text = "<tr>\\s+<td>\\d\\d/\\d\\d/\\d\\d\\d\\d</td><td>\\s+\\d[\\d]?\\s+&nbsp;";
            // 
            // tabRegFind
            // 
            this.tabRegFind.Controls.Add(this.tabControl3);
            this.tabRegFind.Controls.Add(this.btnRegExFindRF);
            this.tabRegFind.Controls.Add(this.nudIterationRF);
            this.tabRegFind.Controls.Add(this.chkIgnoreCaseRF);
            this.tabRegFind.Controls.Add(this.txtRegExFindRF);
            this.tabRegFind.Location = new System.Drawing.Point(4, 22);
            this.tabRegFind.Name = "tabRegFind";
            this.tabRegFind.Size = new System.Drawing.Size(829, 450);
            this.tabRegFind.TabIndex = 2;
            this.tabRegFind.Text = "RegFind";
            this.tabRegFind.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl3.Controls.Add(this.tabPage1);
            this.tabControl3.Controls.Add(this.tabPage2);
            this.tabControl3.Location = new System.Drawing.Point(3, 85);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(818, 357);
            this.tabControl3.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtCaptureTextRF);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(810, 331);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Source Text";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtCaptureTextRF
            // 
            this.txtCaptureTextRF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCaptureTextRF.Location = new System.Drawing.Point(3, 3);
            this.txtCaptureTextRF.Multiline = true;
            this.txtCaptureTextRF.Name = "txtCaptureTextRF";
            this.txtCaptureTextRF.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCaptureTextRF.Size = new System.Drawing.Size(804, 325);
            this.txtCaptureTextRF.TabIndex = 22;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lstRegExFindRF);
            this.tabPage2.Controls.Add(this.txtRegExFindResultsRF);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(810, 331);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Result";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lstRegExFindRF
            // 
            this.lstRegExFindRF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRegExFindRF.FormattingEnabled = true;
            this.lstRegExFindRF.Location = new System.Drawing.Point(6, 6);
            this.lstRegExFindRF.Name = "lstRegExFindRF";
            this.lstRegExFindRF.Size = new System.Drawing.Size(798, 69);
            this.lstRegExFindRF.TabIndex = 23;
            this.lstRegExFindRF.SelectedIndexChanged += new System.EventHandler(this.lstRegExFindRF_SelectedIndexChanged);
            // 
            // txtRegExFindResultsRF
            // 
            this.txtRegExFindResultsRF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegExFindResultsRF.Location = new System.Drawing.Point(6, 81);
            this.txtRegExFindResultsRF.Multiline = true;
            this.txtRegExFindResultsRF.Name = "txtRegExFindResultsRF";
            this.txtRegExFindResultsRF.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRegExFindResultsRF.Size = new System.Drawing.Size(798, 244);
            this.txtRegExFindResultsRF.TabIndex = 22;
            // 
            // btnRegExFindRF
            // 
            this.btnRegExFindRF.Location = new System.Drawing.Point(746, 10);
            this.btnRegExFindRF.Name = "btnRegExFindRF";
            this.btnRegExFindRF.Size = new System.Drawing.Size(75, 23);
            this.btnRegExFindRF.TabIndex = 21;
            this.btnRegExFindRF.Text = "Pattern Test";
            this.btnRegExFindRF.UseVisualStyleBackColor = true;
            this.btnRegExFindRF.Click += new System.EventHandler(this.btnRegExTestRF_Click);
            // 
            // nudIterationRF
            // 
            this.nudIterationRF.Location = new System.Drawing.Point(190, 38);
            this.nudIterationRF.Name = "nudIterationRF";
            this.nudIterationRF.Size = new System.Drawing.Size(62, 20);
            this.nudIterationRF.TabIndex = 20;
            // 
            // chkIgnoreCaseRF
            // 
            this.chkIgnoreCaseRF.AutoSize = true;
            this.chkIgnoreCaseRF.Location = new System.Drawing.Point(44, 38);
            this.chkIgnoreCaseRF.Name = "chkIgnoreCaseRF";
            this.chkIgnoreCaseRF.Size = new System.Drawing.Size(83, 17);
            this.chkIgnoreCaseRF.TabIndex = 19;
            this.chkIgnoreCaseRF.Text = "Ignore Case";
            this.chkIgnoreCaseRF.UseVisualStyleBackColor = true;
            // 
            // txtRegExFindRF
            // 
            this.txtRegExFindRF.Location = new System.Drawing.Point(8, 12);
            this.txtRegExFindRF.Name = "txtRegExFindRF";
            this.txtRegExFindRF.Size = new System.Drawing.Size(732, 20);
            this.txtRegExFindRF.TabIndex = 18;
            // 
            // frmScrape
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 476);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmScrape";
            this.Text = "frmScrape";
            this.tabControl1.ResumeLayout(false);
            this.tabRetrieveURL.ResumeLayout(false);
            this.tabRetrieveURL.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabRegExChunk.ResumeLayout(false);
            this.tabRegExChunk.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabSourceREC.ResumeLayout(false);
            this.tabSourceREC.PerformLayout();
            this.tabResultREC.ResumeLayout(false);
            this.tabResultREC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxChunkLength)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndIteration)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartIteration)).EndInit();
            this.tabRegFind.ResumeLayout(false);
            this.tabRegFind.PerformLayout();
            this.tabControl3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIterationRF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabRetrieveURL;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCaptureRURL;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnTestHttpCaptureText;
        private System.Windows.Forms.TabPage tabRegExChunk;
        private System.Windows.Forms.NumericUpDown nudMaxChunkLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudEndIteration;
        private System.Windows.Forms.CheckBox chkEndIgnoreCase;
        private System.Windows.Forms.TextBox txtRegExEnd;
        private System.Windows.Forms.Button btnRegExChunkTest;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nudStartIteration;
        private System.Windows.Forms.CheckBox chkStartIgnoreCase;
        private System.Windows.Forms.TextBox txtRegExStart;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabSourceREC;
        private System.Windows.Forms.TextBox txtSourceTextREC;
        private System.Windows.Forms.TabPage tabResultREC;
        private System.Windows.Forms.ListBox lstMatchResultsREC;
        private System.Windows.Forms.TextBox txtMatchTextREC;
        private System.Windows.Forms.TabPage tabRegFind;
        private System.Windows.Forms.Button btnRegExFindRF;
        private System.Windows.Forms.NumericUpDown nudIterationRF;
        private System.Windows.Forms.CheckBox chkIgnoreCaseRF;
        private System.Windows.Forms.TextBox txtRegExFindRF;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtCaptureTextRF;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox lstRegExFindRF;
        private System.Windows.Forms.TextBox txtRegExFindResultsRF;
    }
}