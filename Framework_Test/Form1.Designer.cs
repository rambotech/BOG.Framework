namespace Framework_Test
{
    partial class Form1
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
            this.tabTestSets = new System.Windows.Forms.TabControl();
            this.tabHttpCaptureText = new System.Windows.Forms.TabPage();
            this.txtPostData = new System.Windows.Forms.TextBox();
            this.txtWorkText = new System.Windows.Forms.TextBox();
            this.lblCaptureStatus = new System.Windows.Forms.Label();
            this.txtCapture = new System.Windows.Forms.TextBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnTestHttpCaptureText = new System.Windows.Forms.Button();
            this.tabRegExChunk = new System.Windows.Forms.TabPage();
            this.nudMaxChunkLength = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRegExChunkCount = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudEndIteration = new System.Windows.Forms.NumericUpDown();
            this.chkEndIgnoreCase = new System.Windows.Forms.CheckBox();
            this.txtRegExEnd = new System.Windows.Forms.TextBox();
            this.btnRegExChunkTest = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudStartIteration = new System.Windows.Forms.NumericUpDown();
            this.chkStartIgnoreCase = new System.Windows.Forms.CheckBox();
            this.txtRegExStart = new System.Windows.Forms.TextBox();
            this.lstMatchResults = new System.Windows.Forms.ListBox();
            this.txtMatchText = new System.Windows.Forms.TextBox();
            this.tabRegExFind = new System.Windows.Forms.TabPage();
            this.lblRegExFindCount = new System.Windows.Forms.Label();
            this.lstRegExResults = new System.Windows.Forms.ListBox();
            this.txtRegExResults = new System.Windows.Forms.TextBox();
            this.btnRegExTest = new System.Windows.Forms.Button();
            this.nudIteration = new System.Windows.Forms.NumericUpDown();
            this.chkIgnoreCase = new System.Windows.Forms.CheckBox();
            this.txtRegEx = new System.Windows.Forms.TextBox();
            this.tabExtract = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txtXPathExpr = new System.Windows.Forms.TextBox();
            this.chkCleanup = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnExtract = new System.Windows.Forms.Button();
            this.txtResultForExtract = new System.Windows.Forms.TextBox();
            this.txtSourceForExtract = new System.Windows.Forms.TextBox();
            this.tabScript = new System.Windows.Forms.TabPage();
            this.tabDetailedExpection = new System.Windows.Forms.TabPage();
            this.btnTestIt = new System.Windows.Forms.Button();
            this.txtResultError = new System.Windows.Forms.TextBox();
            this.txtErrorMessage = new System.Windows.Forms.TextBox();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.tabStringEx = new System.Windows.Forms.TabPage();
            this.gbxBase64 = new System.Windows.Forms.GroupBox();
            this.btnBase64Decode = new System.Windows.Forms.Button();
            this.btnBase64Encode = new System.Windows.Forms.Button();
            this.txtBase64Encoded = new System.Windows.Forms.TextBox();
            this.txtBase64Decoded = new System.Windows.Forms.TextBox();
            this.tabNTGroup = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGroup = new System.Windows.Forms.TabPage();
            this.tabAccessControl = new System.Windows.Forms.TabPage();
            this.btnRemoveAccess = new System.Windows.Forms.Button();
            this.btnAddAccess = new System.Windows.Forms.Button();
            this.chkInherit = new System.Windows.Forms.CheckBox();
            this.txtFileSystemObject = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabAssemblyInfo = new System.Windows.Forms.TabPage();
            this.dgvAssemblyInfo = new System.Windows.Forms.DataGridView();
            this.tabSettingsResolution = new System.Windows.Forms.TabPage();
            this.txtResolveSettings = new System.Windows.Forms.TextBox();
            this.btnResolve = new System.Windows.Forms.Button();
            this.tabTestSets.SuspendLayout();
            this.tabHttpCaptureText.SuspendLayout();
            this.tabRegExChunk.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxChunkLength)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndIteration)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartIteration)).BeginInit();
            this.tabRegExFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIteration)).BeginInit();
            this.tabExtract.SuspendLayout();
            this.tabDetailedExpection.SuspendLayout();
            this.tabStringEx.SuspendLayout();
            this.gbxBase64.SuspendLayout();
            this.tabNTGroup.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabAccessControl.SuspendLayout();
            this.tabAssemblyInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssemblyInfo)).BeginInit();
            this.tabSettingsResolution.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabTestSets
            // 
            this.tabTestSets.Controls.Add(this.tabHttpCaptureText);
            this.tabTestSets.Controls.Add(this.tabRegExChunk);
            this.tabTestSets.Controls.Add(this.tabRegExFind);
            this.tabTestSets.Controls.Add(this.tabExtract);
            this.tabTestSets.Controls.Add(this.tabScript);
            this.tabTestSets.Controls.Add(this.tabDetailedExpection);
            this.tabTestSets.Controls.Add(this.tabStringEx);
            this.tabTestSets.Controls.Add(this.tabNTGroup);
            this.tabTestSets.Controls.Add(this.tabAssemblyInfo);
            this.tabTestSets.Controls.Add(this.tabSettingsResolution);
            this.tabTestSets.Location = new System.Drawing.Point(3, 2);
            this.tabTestSets.Name = "tabTestSets";
            this.tabTestSets.SelectedIndex = 0;
            this.tabTestSets.Size = new System.Drawing.Size(781, 423);
            this.tabTestSets.TabIndex = 2;
            // 
            // tabHttpCaptureText
            // 
            this.tabHttpCaptureText.Controls.Add(this.txtPostData);
            this.tabHttpCaptureText.Controls.Add(this.txtWorkText);
            this.tabHttpCaptureText.Controls.Add(this.lblCaptureStatus);
            this.tabHttpCaptureText.Controls.Add(this.txtCapture);
            this.tabHttpCaptureText.Controls.Add(this.txtURL);
            this.tabHttpCaptureText.Controls.Add(this.btnTestHttpCaptureText);
            this.tabHttpCaptureText.Location = new System.Drawing.Point(4, 22);
            this.tabHttpCaptureText.Name = "tabHttpCaptureText";
            this.tabHttpCaptureText.Padding = new System.Windows.Forms.Padding(3);
            this.tabHttpCaptureText.Size = new System.Drawing.Size(773, 397);
            this.tabHttpCaptureText.TabIndex = 0;
            this.tabHttpCaptureText.Text = "HttpCaptureText";
            this.tabHttpCaptureText.UseVisualStyleBackColor = true;
            // 
            // txtPostData
            // 
            this.txtPostData.Location = new System.Drawing.Point(18, 198);
            this.txtPostData.Multiline = true;
            this.txtPostData.Name = "txtPostData";
            this.txtPostData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPostData.Size = new System.Drawing.Size(735, 75);
            this.txtPostData.TabIndex = 7;
            // 
            // txtWorkText
            // 
            this.txtWorkText.Location = new System.Drawing.Point(18, 279);
            this.txtWorkText.Multiline = true;
            this.txtWorkText.Name = "txtWorkText";
            this.txtWorkText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtWorkText.Size = new System.Drawing.Size(735, 112);
            this.txtWorkText.TabIndex = 6;
            // 
            // lblCaptureStatus
            // 
            this.lblCaptureStatus.AutoSize = true;
            this.lblCaptureStatus.Location = new System.Drawing.Point(699, 43);
            this.lblCaptureStatus.Name = "lblCaptureStatus";
            this.lblCaptureStatus.Size = new System.Drawing.Size(0, 13);
            this.lblCaptureStatus.TabIndex = 5;
            // 
            // txtCapture
            // 
            this.txtCapture.Location = new System.Drawing.Point(18, 59);
            this.txtCapture.Multiline = true;
            this.txtCapture.Name = "txtCapture";
            this.txtCapture.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCapture.Size = new System.Drawing.Size(735, 133);
            this.txtCapture.TabIndex = 4;
            this.txtCapture.TextChanged += new System.EventHandler(this.txtCapture_TextChanged);
            this.txtCapture.DoubleClick += new System.EventHandler(this.txtCapture_DoubleClick);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(18, 20);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(626, 20);
            this.txtURL.TabIndex = 3;
            this.txtURL.Text = "http://www.google.com";
            // 
            // btnTestHttpCaptureText
            // 
            this.btnTestHttpCaptureText.Location = new System.Drawing.Point(650, 18);
            this.btnTestHttpCaptureText.Name = "btnTestHttpCaptureText";
            this.btnTestHttpCaptureText.Size = new System.Drawing.Size(103, 23);
            this.btnTestHttpCaptureText.TabIndex = 2;
            this.btnTestHttpCaptureText.Text = "Retrieve URL";
            this.btnTestHttpCaptureText.UseVisualStyleBackColor = true;
            this.btnTestHttpCaptureText.Click += new System.EventHandler(this.btnTestHttpCaptureText_Click);
            // 
            // tabRegExChunk
            // 
            this.tabRegExChunk.Controls.Add(this.nudMaxChunkLength);
            this.tabRegExChunk.Controls.Add(this.label1);
            this.tabRegExChunk.Controls.Add(this.lblRegExChunkCount);
            this.tabRegExChunk.Controls.Add(this.groupBox2);
            this.tabRegExChunk.Controls.Add(this.btnRegExChunkTest);
            this.tabRegExChunk.Controls.Add(this.groupBox1);
            this.tabRegExChunk.Controls.Add(this.lstMatchResults);
            this.tabRegExChunk.Controls.Add(this.txtMatchText);
            this.tabRegExChunk.Location = new System.Drawing.Point(4, 22);
            this.tabRegExChunk.Name = "tabRegExChunk";
            this.tabRegExChunk.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegExChunk.Size = new System.Drawing.Size(773, 397);
            this.tabRegExChunk.TabIndex = 1;
            this.tabRegExChunk.Text = "RegExChunk";
            this.tabRegExChunk.UseVisualStyleBackColor = true;
            // 
            // nudMaxChunkLength
            // 
            this.nudMaxChunkLength.Location = new System.Drawing.Point(640, 63);
            this.nudMaxChunkLength.Maximum = new decimal(new int[] {
            10248,
            0,
            0,
            0});
            this.nudMaxChunkLength.Name = "nudMaxChunkLength";
            this.nudMaxChunkLength.Size = new System.Drawing.Size(94, 20);
            this.nudMaxChunkLength.TabIndex = 17;
            this.nudMaxChunkLength.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(637, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Max Chunk Length";
            // 
            // lblRegExChunkCount
            // 
            this.lblRegExChunkCount.AutoSize = true;
            this.lblRegExChunkCount.Location = new System.Drawing.Point(619, 33);
            this.lblRegExChunkCount.Name = "lblRegExChunkCount";
            this.lblRegExChunkCount.Size = new System.Drawing.Size(11, 13);
            this.lblRegExChunkCount.TabIndex = 15;
            this.lblRegExChunkCount.Text = "*";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudEndIteration);
            this.groupBox2.Controls.Add(this.chkEndIgnoreCase);
            this.groupBox2.Controls.Add(this.txtRegExEnd);
            this.groupBox2.Location = new System.Drawing.Point(310, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(297, 76);
            this.groupBox2.TabIndex = 14;
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
            18,
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
            this.txtRegExEnd.Text = "</td>";
            // 
            // btnRegExChunkTest
            // 
            this.btnRegExChunkTest.Location = new System.Drawing.Point(692, 7);
            this.btnRegExChunkTest.Name = "btnRegExChunkTest";
            this.btnRegExChunkTest.Size = new System.Drawing.Size(75, 23);
            this.btnRegExChunkTest.TabIndex = 13;
            this.btnRegExChunkTest.Text = "Chunk Test";
            this.btnRegExChunkTest.UseVisualStyleBackColor = true;
            this.btnRegExChunkTest.Click += new System.EventHandler(this.btnRegExChunkTest_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudStartIteration);
            this.groupBox1.Controls.Add(this.chkStartIgnoreCase);
            this.groupBox1.Controls.Add(this.txtRegExStart);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 76);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Starting Pattern ";
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
            this.txtRegExStart.Text = "(\\d[\\d]?/){2}\\d[\\d]";
            // 
            // lstMatchResults
            // 
            this.lstMatchResults.FormattingEnabled = true;
            this.lstMatchResults.Location = new System.Drawing.Point(7, 90);
            this.lstMatchResults.Name = "lstMatchResults";
            this.lstMatchResults.Size = new System.Drawing.Size(760, 69);
            this.lstMatchResults.TabIndex = 7;
            this.lstMatchResults.Click += new System.EventHandler(this.lstMatchResults_Click);
            this.lstMatchResults.SelectedIndexChanged += new System.EventHandler(this.lstMatchResults_SelectedIndexChanged);
            // 
            // txtMatchText
            // 
            this.txtMatchText.Location = new System.Drawing.Point(6, 164);
            this.txtMatchText.Multiline = true;
            this.txtMatchText.Name = "txtMatchText";
            this.txtMatchText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMatchText.Size = new System.Drawing.Size(761, 227);
            this.txtMatchText.TabIndex = 6;
            this.txtMatchText.DoubleClick += new System.EventHandler(this.txtMatchText_DoubleClick);
            // 
            // tabRegExFind
            // 
            this.tabRegExFind.Controls.Add(this.lblRegExFindCount);
            this.tabRegExFind.Controls.Add(this.lstRegExResults);
            this.tabRegExFind.Controls.Add(this.txtRegExResults);
            this.tabRegExFind.Controls.Add(this.btnRegExTest);
            this.tabRegExFind.Controls.Add(this.nudIteration);
            this.tabRegExFind.Controls.Add(this.chkIgnoreCase);
            this.tabRegExFind.Controls.Add(this.txtRegEx);
            this.tabRegExFind.Location = new System.Drawing.Point(4, 22);
            this.tabRegExFind.Name = "tabRegExFind";
            this.tabRegExFind.Size = new System.Drawing.Size(773, 397);
            this.tabRegExFind.TabIndex = 2;
            this.tabRegExFind.Text = "RexExFind";
            this.tabRegExFind.UseVisualStyleBackColor = true;
            // 
            // lblRegExFindCount
            // 
            this.lblRegExFindCount.AutoSize = true;
            this.lblRegExFindCount.Location = new System.Drawing.Point(702, 49);
            this.lblRegExFindCount.Name = "lblRegExFindCount";
            this.lblRegExFindCount.Size = new System.Drawing.Size(0, 13);
            this.lblRegExFindCount.TabIndex = 18;
            // 
            // lstRegExResults
            // 
            this.lstRegExResults.FormattingEnabled = true;
            this.lstRegExResults.Location = new System.Drawing.Point(21, 71);
            this.lstRegExResults.Name = "lstRegExResults";
            this.lstRegExResults.Size = new System.Drawing.Size(746, 69);
            this.lstRegExResults.TabIndex = 17;
            this.lstRegExResults.Click += new System.EventHandler(this.lstRegExResults_Click);
            this.lstRegExResults.SelectedIndexChanged += new System.EventHandler(this.lstRegExResults_SelectedIndexChanged);
            // 
            // txtRegExResults
            // 
            this.txtRegExResults.Location = new System.Drawing.Point(21, 146);
            this.txtRegExResults.Multiline = true;
            this.txtRegExResults.Name = "txtRegExResults";
            this.txtRegExResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRegExResults.Size = new System.Drawing.Size(746, 232);
            this.txtRegExResults.TabIndex = 16;
            this.txtRegExResults.DoubleClick += new System.EventHandler(this.txtRegExResults_DoubleClick);
            // 
            // btnRegExTest
            // 
            this.btnRegExTest.Location = new System.Drawing.Point(692, 16);
            this.btnRegExTest.Name = "btnRegExTest";
            this.btnRegExTest.Size = new System.Drawing.Size(75, 23);
            this.btnRegExTest.TabIndex = 15;
            this.btnRegExTest.Text = "Pattern Test";
            this.btnRegExTest.UseVisualStyleBackColor = true;
            this.btnRegExTest.Click += new System.EventHandler(this.btnRegExTest_Click);
            // 
            // nudIteration
            // 
            this.nudIteration.Location = new System.Drawing.Point(203, 45);
            this.nudIteration.Name = "nudIteration";
            this.nudIteration.Size = new System.Drawing.Size(62, 20);
            this.nudIteration.TabIndex = 11;
            // 
            // chkIgnoreCase
            // 
            this.chkIgnoreCase.AutoSize = true;
            this.chkIgnoreCase.Location = new System.Drawing.Point(57, 45);
            this.chkIgnoreCase.Name = "chkIgnoreCase";
            this.chkIgnoreCase.Size = new System.Drawing.Size(83, 17);
            this.chkIgnoreCase.TabIndex = 10;
            this.chkIgnoreCase.Text = "Ignore Case";
            this.chkIgnoreCase.UseVisualStyleBackColor = true;
            // 
            // txtRegEx
            // 
            this.txtRegEx.Location = new System.Drawing.Point(21, 19);
            this.txtRegEx.Name = "txtRegEx";
            this.txtRegEx.Size = new System.Drawing.Size(665, 20);
            this.txtRegEx.TabIndex = 9;
            // 
            // tabExtract
            // 
            this.tabExtract.Controls.Add(this.label5);
            this.tabExtract.Controls.Add(this.txtXPathExpr);
            this.tabExtract.Controls.Add(this.chkCleanup);
            this.tabExtract.Controls.Add(this.button2);
            this.tabExtract.Controls.Add(this.btnExtract);
            this.tabExtract.Controls.Add(this.txtResultForExtract);
            this.tabExtract.Controls.Add(this.txtSourceForExtract);
            this.tabExtract.Location = new System.Drawing.Point(4, 22);
            this.tabExtract.Name = "tabExtract";
            this.tabExtract.Size = new System.Drawing.Size(773, 397);
            this.tabExtract.TabIndex = 8;
            this.tabExtract.Text = "ExtractText / StripHTML";
            this.tabExtract.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "XPath expression";
            // 
            // txtXPathExpr
            // 
            this.txtXPathExpr.Location = new System.Drawing.Point(132, 155);
            this.txtXPathExpr.Name = "txtXPathExpr";
            this.txtXPathExpr.Size = new System.Drawing.Size(348, 20);
            this.txtXPathExpr.TabIndex = 19;
            this.txtXPathExpr.Text = "text()";
            // 
            // chkCleanup
            // 
            this.chkCleanup.AutoSize = true;
            this.chkCleanup.Location = new System.Drawing.Point(73, 191);
            this.chkCleanup.Name = "chkCleanup";
            this.chkCleanup.Size = new System.Drawing.Size(100, 17);
            this.chkCleanup.TabIndex = 18;
            this.chkCleanup.Text = "Clean Attributes";
            this.chkCleanup.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(640, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "StripHTML";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnExtract
            // 
            this.btnExtract.Location = new System.Drawing.Point(189, 187);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(75, 23);
            this.btnExtract.TabIndex = 16;
            this.btnExtract.Text = "ExtractText";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // txtResultForExtract
            // 
            this.txtResultForExtract.Location = new System.Drawing.Point(14, 227);
            this.txtResultForExtract.Multiline = true;
            this.txtResultForExtract.Name = "txtResultForExtract";
            this.txtResultForExtract.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResultForExtract.Size = new System.Drawing.Size(735, 133);
            this.txtResultForExtract.TabIndex = 6;
            // 
            // txtSourceForExtract
            // 
            this.txtSourceForExtract.Location = new System.Drawing.Point(14, 15);
            this.txtSourceForExtract.Multiline = true;
            this.txtSourceForExtract.Name = "txtSourceForExtract";
            this.txtSourceForExtract.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSourceForExtract.Size = new System.Drawing.Size(735, 133);
            this.txtSourceForExtract.TabIndex = 5;
            this.txtSourceForExtract.Text = "<td width=11 align=right><font size=2 face=\"helvetica\">-</font></td>";
            // 
            // tabScript
            // 
            this.tabScript.Location = new System.Drawing.Point(4, 22);
            this.tabScript.Name = "tabScript";
            this.tabScript.Size = new System.Drawing.Size(773, 397);
            this.tabScript.TabIndex = 3;
            this.tabScript.Text = "Script";
            this.tabScript.UseVisualStyleBackColor = true;
            // 
            // tabDetailedExpection
            // 
            this.tabDetailedExpection.Controls.Add(this.btnTestIt);
            this.tabDetailedExpection.Controls.Add(this.txtResultError);
            this.tabDetailedExpection.Controls.Add(this.txtErrorMessage);
            this.tabDetailedExpection.Controls.Add(this.lblErrorMessage);
            this.tabDetailedExpection.Location = new System.Drawing.Point(4, 22);
            this.tabDetailedExpection.Name = "tabDetailedExpection";
            this.tabDetailedExpection.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetailedExpection.Size = new System.Drawing.Size(773, 397);
            this.tabDetailedExpection.TabIndex = 5;
            this.tabDetailedExpection.Text = "Detailed Exception";
            this.tabDetailedExpection.UseVisualStyleBackColor = true;
            // 
            // btnTestIt
            // 
            this.btnTestIt.Location = new System.Drawing.Point(342, 101);
            this.btnTestIt.Name = "btnTestIt";
            this.btnTestIt.Size = new System.Drawing.Size(75, 23);
            this.btnTestIt.TabIndex = 3;
            this.btnTestIt.Text = "Test It";
            this.btnTestIt.UseVisualStyleBackColor = true;
            this.btnTestIt.Click += new System.EventHandler(this.btnTestIt_Click);
            // 
            // txtResultError
            // 
            this.txtResultError.Location = new System.Drawing.Point(10, 130);
            this.txtResultError.Multiline = true;
            this.txtResultError.Name = "txtResultError";
            this.txtResultError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultError.Size = new System.Drawing.Size(757, 259);
            this.txtResultError.TabIndex = 2;
            // 
            // txtErrorMessage
            // 
            this.txtErrorMessage.Location = new System.Drawing.Point(10, 24);
            this.txtErrorMessage.Multiline = true;
            this.txtErrorMessage.Name = "txtErrorMessage";
            this.txtErrorMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtErrorMessage.Size = new System.Drawing.Size(757, 70);
            this.txtErrorMessage.TabIndex = 1;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.Location = new System.Drawing.Point(7, 7);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(75, 13);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "Error Message";
            // 
            // tabStringEx
            // 
            this.tabStringEx.Controls.Add(this.gbxBase64);
            this.tabStringEx.Location = new System.Drawing.Point(4, 22);
            this.tabStringEx.Name = "tabStringEx";
            this.tabStringEx.Size = new System.Drawing.Size(773, 397);
            this.tabStringEx.TabIndex = 6;
            this.tabStringEx.Text = "StringEx";
            this.tabStringEx.UseVisualStyleBackColor = true;
            // 
            // gbxBase64
            // 
            this.gbxBase64.Controls.Add(this.btnBase64Decode);
            this.gbxBase64.Controls.Add(this.btnBase64Encode);
            this.gbxBase64.Controls.Add(this.txtBase64Encoded);
            this.gbxBase64.Controls.Add(this.txtBase64Decoded);
            this.gbxBase64.Location = new System.Drawing.Point(15, 14);
            this.gbxBase64.Name = "gbxBase64";
            this.gbxBase64.Size = new System.Drawing.Size(752, 364);
            this.gbxBase64.TabIndex = 0;
            this.gbxBase64.TabStop = false;
            this.gbxBase64.Text = "Base64";
            // 
            // btnBase64Decode
            // 
            this.btnBase64Decode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBase64Decode.Location = new System.Drawing.Point(593, 173);
            this.btnBase64Decode.Name = "btnBase64Decode";
            this.btnBase64Decode.Size = new System.Drawing.Size(75, 23);
            this.btnBase64Decode.TabIndex = 3;
            this.btnBase64Decode.Text = "Decode (^)";
            this.btnBase64Decode.UseVisualStyleBackColor = true;
            this.btnBase64Decode.Click += new System.EventHandler(this.btnBase64Decode_Click);
            // 
            // btnBase64Encode
            // 
            this.btnBase64Encode.Location = new System.Drawing.Point(94, 174);
            this.btnBase64Encode.Name = "btnBase64Encode";
            this.btnBase64Encode.Size = new System.Drawing.Size(75, 23);
            this.btnBase64Encode.TabIndex = 2;
            this.btnBase64Encode.Text = "Encode (v)";
            this.btnBase64Encode.UseVisualStyleBackColor = true;
            this.btnBase64Encode.Click += new System.EventHandler(this.btnBase64Encode_Click);
            // 
            // txtBase64Encoded
            // 
            this.txtBase64Encoded.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBase64Encoded.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBase64Encoded.Location = new System.Drawing.Point(6, 203);
            this.txtBase64Encoded.Multiline = true;
            this.txtBase64Encoded.Name = "txtBase64Encoded";
            this.txtBase64Encoded.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBase64Encoded.Size = new System.Drawing.Size(739, 155);
            this.txtBase64Encoded.TabIndex = 1;
            this.txtBase64Encoded.DoubleClick += new System.EventHandler(this.txtBase64Encoded_DoubleClick);
            // 
            // txtBase64Decoded
            // 
            this.txtBase64Decoded.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBase64Decoded.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBase64Decoded.Location = new System.Drawing.Point(6, 19);
            this.txtBase64Decoded.Multiline = true;
            this.txtBase64Decoded.Name = "txtBase64Decoded";
            this.txtBase64Decoded.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBase64Decoded.Size = new System.Drawing.Size(739, 148);
            this.txtBase64Decoded.TabIndex = 0;
            this.txtBase64Decoded.DoubleClick += new System.EventHandler(this.txtBase64Decoded_DoubleClick);
            // 
            // tabNTGroup
            // 
            this.tabNTGroup.Controls.Add(this.tabControl1);
            this.tabNTGroup.Location = new System.Drawing.Point(4, 22);
            this.tabNTGroup.Name = "tabNTGroup";
            this.tabNTGroup.Size = new System.Drawing.Size(773, 397);
            this.tabNTGroup.TabIndex = 7;
            this.tabNTGroup.Text = "NTGroup";
            this.tabNTGroup.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabGroup);
            this.tabControl1.Controls.Add(this.tabAccessControl);
            this.tabControl1.Location = new System.Drawing.Point(4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(769, 397);
            this.tabControl1.TabIndex = 0;
            // 
            // tabGroup
            // 
            this.tabGroup.Location = new System.Drawing.Point(4, 22);
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroup.Size = new System.Drawing.Size(761, 371);
            this.tabGroup.TabIndex = 0;
            this.tabGroup.Text = "Group";
            this.tabGroup.UseVisualStyleBackColor = true;
            // 
            // tabAccessControl
            // 
            this.tabAccessControl.Controls.Add(this.btnRemoveAccess);
            this.tabAccessControl.Controls.Add(this.btnAddAccess);
            this.tabAccessControl.Controls.Add(this.chkInherit);
            this.tabAccessControl.Controls.Add(this.txtFileSystemObject);
            this.tabAccessControl.Controls.Add(this.txtUserName);
            this.tabAccessControl.Controls.Add(this.txtDomain);
            this.tabAccessControl.Controls.Add(this.label4);
            this.tabAccessControl.Controls.Add(this.label3);
            this.tabAccessControl.Controls.Add(this.label2);
            this.tabAccessControl.Location = new System.Drawing.Point(4, 22);
            this.tabAccessControl.Name = "tabAccessControl";
            this.tabAccessControl.Padding = new System.Windows.Forms.Padding(3);
            this.tabAccessControl.Size = new System.Drawing.Size(761, 371);
            this.tabAccessControl.TabIndex = 1;
            this.tabAccessControl.Text = "Access Control";
            this.tabAccessControl.UseVisualStyleBackColor = true;
            // 
            // btnRemoveAccess
            // 
            this.btnRemoveAccess.Location = new System.Drawing.Point(300, 145);
            this.btnRemoveAccess.Name = "btnRemoveAccess";
            this.btnRemoveAccess.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAccess.TabIndex = 17;
            this.btnRemoveAccess.Text = "Remove Access";
            this.btnRemoveAccess.UseVisualStyleBackColor = true;
            this.btnRemoveAccess.Click += new System.EventHandler(this.btnRemoveAccess_Click);
            // 
            // btnAddAccess
            // 
            this.btnAddAccess.Location = new System.Drawing.Point(143, 145);
            this.btnAddAccess.Name = "btnAddAccess";
            this.btnAddAccess.Size = new System.Drawing.Size(75, 23);
            this.btnAddAccess.TabIndex = 16;
            this.btnAddAccess.Text = "Add Access";
            this.btnAddAccess.UseVisualStyleBackColor = true;
            this.btnAddAccess.Click += new System.EventHandler(this.btnAddAccess_Click);
            // 
            // chkInherit
            // 
            this.chkInherit.AutoSize = true;
            this.chkInherit.Location = new System.Drawing.Point(157, 95);
            this.chkInherit.Name = "chkInherit";
            this.chkInherit.Size = new System.Drawing.Size(55, 17);
            this.chkInherit.TabIndex = 15;
            this.chkInherit.Text = "Inherit";
            this.chkInherit.UseVisualStyleBackColor = true;
            // 
            // txtFileSystemObject
            // 
            this.txtFileSystemObject.Location = new System.Drawing.Point(143, 69);
            this.txtFileSystemObject.Name = "txtFileSystemObject";
            this.txtFileSystemObject.Size = new System.Drawing.Size(495, 20);
            this.txtFileSystemObject.TabIndex = 14;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(143, 38);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(208, 20);
            this.txtUserName.TabIndex = 13;
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(143, 6);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(208, 20);
            this.txtDomain.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "File System Object";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "User Account";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Domain";
            // 
            // tabAssemblyInfo
            // 
            this.tabAssemblyInfo.Controls.Add(this.dgvAssemblyInfo);
            this.tabAssemblyInfo.Location = new System.Drawing.Point(4, 22);
            this.tabAssemblyInfo.Name = "tabAssemblyInfo";
            this.tabAssemblyInfo.Size = new System.Drawing.Size(773, 397);
            this.tabAssemblyInfo.TabIndex = 9;
            this.tabAssemblyInfo.Text = "AssemblyInfo";
            this.tabAssemblyInfo.UseVisualStyleBackColor = true;
            // 
            // dgvAssemblyInfo
            // 
            this.dgvAssemblyInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAssemblyInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssemblyInfo.Location = new System.Drawing.Point(5, 3);
            this.dgvAssemblyInfo.Name = "dgvAssemblyInfo";
            this.dgvAssemblyInfo.Size = new System.Drawing.Size(762, 386);
            this.dgvAssemblyInfo.TabIndex = 0;
            this.dgvAssemblyInfo.Click += new System.EventHandler(this.dgvAssemblyInfo_Click);
            // 
            // tabSettingsResolution
            // 
            this.tabSettingsResolution.Controls.Add(this.txtResolveSettings);
            this.tabSettingsResolution.Controls.Add(this.btnResolve);
            this.tabSettingsResolution.Location = new System.Drawing.Point(4, 22);
            this.tabSettingsResolution.Name = "tabSettingsResolution";
            this.tabSettingsResolution.Size = new System.Drawing.Size(773, 397);
            this.tabSettingsResolution.TabIndex = 10;
            this.tabSettingsResolution.Text = "SettingsResolution";
            this.tabSettingsResolution.UseVisualStyleBackColor = true;
            // 
            // txtResolveSettings
            // 
            this.txtResolveSettings.Location = new System.Drawing.Point(5, 50);
            this.txtResolveSettings.Multiline = true;
            this.txtResolveSettings.Name = "txtResolveSettings";
            this.txtResolveSettings.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResolveSettings.Size = new System.Drawing.Size(762, 339);
            this.txtResolveSettings.TabIndex = 6;
            // 
            // btnResolve
            // 
            this.btnResolve.Location = new System.Drawing.Point(315, 21);
            this.btnResolve.Name = "btnResolve";
            this.btnResolve.Size = new System.Drawing.Size(103, 23);
            this.btnResolve.TabIndex = 5;
            this.btnResolve.Text = "Resolve Settings";
            this.btnResolve.UseVisualStyleBackColor = true;
            this.btnResolve.Click += new System.EventHandler(this.btnResolve_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 425);
            this.Controls.Add(this.tabTestSets);
            this.Name = "Form1";
            this.Text = "Framework Tests";
            this.tabTestSets.ResumeLayout(false);
            this.tabHttpCaptureText.ResumeLayout(false);
            this.tabHttpCaptureText.PerformLayout();
            this.tabRegExChunk.ResumeLayout(false);
            this.tabRegExChunk.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxChunkLength)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndIteration)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartIteration)).EndInit();
            this.tabRegExFind.ResumeLayout(false);
            this.tabRegExFind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIteration)).EndInit();
            this.tabExtract.ResumeLayout(false);
            this.tabExtract.PerformLayout();
            this.tabDetailedExpection.ResumeLayout(false);
            this.tabDetailedExpection.PerformLayout();
            this.tabStringEx.ResumeLayout(false);
            this.gbxBase64.ResumeLayout(false);
            this.gbxBase64.PerformLayout();
            this.tabNTGroup.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabAccessControl.ResumeLayout(false);
            this.tabAccessControl.PerformLayout();
            this.tabAssemblyInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssemblyInfo)).EndInit();
            this.tabSettingsResolution.ResumeLayout(false);
            this.tabSettingsResolution.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabTestSets;
        private System.Windows.Forms.TabPage tabHttpCaptureText;
        private System.Windows.Forms.TextBox txtCapture;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnTestHttpCaptureText;
        private System.Windows.Forms.TabPage tabRegExChunk;
        private System.Windows.Forms.Label lblCaptureStatus;
        private System.Windows.Forms.ListBox lstMatchResults;
        private System.Windows.Forms.TextBox txtMatchText;
        private System.Windows.Forms.TabPage tabRegExFind;
        private System.Windows.Forms.Button btnRegExTest;
        private System.Windows.Forms.NumericUpDown nudIteration;
        private System.Windows.Forms.CheckBox chkIgnoreCase;
        private System.Windows.Forms.TextBox txtRegEx;
        private System.Windows.Forms.ListBox lstRegExResults;
        private System.Windows.Forms.TextBox txtRegExResults;
        private System.Windows.Forms.TabPage tabScript;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudEndIteration;
        private System.Windows.Forms.CheckBox chkEndIgnoreCase;
        private System.Windows.Forms.TextBox txtRegExEnd;
        private System.Windows.Forms.Button btnRegExChunkTest;
        private System.Windows.Forms.NumericUpDown nudStartIteration;
        private System.Windows.Forms.CheckBox chkStartIgnoreCase;
        private System.Windows.Forms.TextBox txtRegExStart;
        private System.Windows.Forms.TextBox txtWorkText;
        private System.Windows.Forms.Label lblRegExChunkCount;
        private System.Windows.Forms.Label lblRegExFindCount;
        private System.Windows.Forms.TextBox txtPostData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudMaxChunkLength;
        private System.Windows.Forms.TabPage tabDetailedExpection;
        private System.Windows.Forms.Button btnTestIt;
        private System.Windows.Forms.TextBox txtResultError;
        private System.Windows.Forms.TextBox txtErrorMessage;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.TabPage tabStringEx;
        private System.Windows.Forms.GroupBox gbxBase64;
        private System.Windows.Forms.Button btnBase64Decode;
        private System.Windows.Forms.Button btnBase64Encode;
        private System.Windows.Forms.TextBox txtBase64Encoded;
        private System.Windows.Forms.TextBox txtBase64Decoded;
        private System.Windows.Forms.TabPage tabNTGroup;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAccessControl;
        private System.Windows.Forms.TabPage tabGroup;
        private System.Windows.Forms.Button btnRemoveAccess;
        private System.Windows.Forms.Button btnAddAccess;
        private System.Windows.Forms.CheckBox chkInherit;
        private System.Windows.Forms.TextBox txtFileSystemObject;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabExtract;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.TextBox txtResultForExtract;
        private System.Windows.Forms.TextBox txtSourceForExtract;
        private System.Windows.Forms.CheckBox chkCleanup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtXPathExpr;
        private System.Windows.Forms.TabPage tabAssemblyInfo;
        private System.Windows.Forms.DataGridView dgvAssemblyInfo;
        private System.Windows.Forms.TabPage tabSettingsResolution;
        private System.Windows.Forms.TextBox txtResolveSettings;
        private System.Windows.Forms.Button btnResolve;

    }
}

