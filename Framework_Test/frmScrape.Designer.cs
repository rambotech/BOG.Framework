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
			this.nudMaximumMatches = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
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
			this.tabHarvestExample = new System.Windows.Forms.TabPage();
			this.cbxYear = new System.Windows.Forms.ComboBox();
			this.tabControl4 = new System.Windows.Forms.TabControl();
			this.tabActivity = new System.Windows.Forms.TabPage();
			this.lstFullExampleActivity = new System.Windows.Forms.ListBox();
			this.tabResult = new System.Windows.Forms.TabPage();
			this.dgvFullExample = new System.Windows.Forms.DataGridView();
			this.txtFullExampleResult = new System.Windows.Forms.TextBox();
			this.btnFullExample = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabRetrieveURL.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.tabRegExChunk.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) (this.nudMaximumMatches)).BeginInit();
			this.tabControl2.SuspendLayout();
			this.tabSourceREC.SuspendLayout();
			this.tabResultREC.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) (this.nudMaxChunkLength)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) (this.nudEndIteration)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) (this.nudStartIteration)).BeginInit();
			this.tabRegFind.SuspendLayout();
			this.tabControl3.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) (this.nudIterationRF)).BeginInit();
			this.tabHarvestExample.SuspendLayout();
			this.tabControl4.SuspendLayout();
			this.tabActivity.SuspendLayout();
			this.tabResult.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) (this.dgvFullExample)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabRetrieveURL);
			this.tabControl1.Controls.Add(this.tabRegExChunk);
			this.tabControl1.Controls.Add(this.tabRegFind);
			this.tabControl1.Controls.Add(this.tabHarvestExample);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1116, 586);
			this.tabControl1.TabIndex = 0;
			// 
			// tabRetrieveURL
			// 
			this.tabRetrieveURL.Controls.Add(this.groupBox1);
			this.tabRetrieveURL.Controls.Add(this.txtURL);
			this.tabRetrieveURL.Controls.Add(this.btnTestHttpCaptureText);
			this.tabRetrieveURL.Controls.Add(this.statusStrip1);
			this.tabRetrieveURL.Location = new System.Drawing.Point(4, 25);
			this.tabRetrieveURL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabRetrieveURL.Name = "tabRetrieveURL";
			this.tabRetrieveURL.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabRetrieveURL.Size = new System.Drawing.Size(1108, 557);
			this.tabRetrieveURL.TabIndex = 0;
			this.tabRetrieveURL.Text = "RetrieveURL";
			this.tabRetrieveURL.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.txtCaptureRURL);
			this.groupBox1.Location = new System.Drawing.Point(11, 39);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox1.Size = new System.Drawing.Size(1084, 480);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Waiting for button push...";
			// 
			// txtCaptureRURL
			// 
			this.txtCaptureRURL.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.txtCaptureRURL.Location = new System.Drawing.Point(8, 23);
			this.txtCaptureRURL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtCaptureRURL.Multiline = true;
			this.txtCaptureRURL.Name = "txtCaptureRURL";
			this.txtCaptureRURL.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtCaptureRURL.Size = new System.Drawing.Size(1067, 448);
			this.txtCaptureRURL.TabIndex = 8;
			// 
			// txtURL
			// 
			this.txtURL.Location = new System.Drawing.Point(11, 7);
			this.txtURL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtURL.Name = "txtURL";
			this.txtURL.Size = new System.Drawing.Size(940, 22);
			this.txtURL.TabIndex = 6;
			this.txtURL.Text = "http://www.palottery.state.pa.us/Games/Print-Past-Winning-Numbers.aspx?id=12&year" +
	"=2016&print=1";
			// 
			// btnTestHttpCaptureText
			// 
			this.btnTestHttpCaptureText.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTestHttpCaptureText.Location = new System.Drawing.Point(960, 5);
			this.btnTestHttpCaptureText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnTestHttpCaptureText.Name = "btnTestHttpCaptureText";
			this.btnTestHttpCaptureText.Size = new System.Drawing.Size(137, 28);
			this.btnTestHttpCaptureText.TabIndex = 5;
			this.btnTestHttpCaptureText.Text = "Retrieve URL";
			this.btnTestHttpCaptureText.UseVisualStyleBackColor = true;
			this.btnTestHttpCaptureText.Click += new System.EventHandler(this.btnTestHttpCaptureText_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(4, 531);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
			this.statusStrip1.Size = new System.Drawing.Size(1100, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 17);
			this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
			// 
			// tabRegExChunk
			// 
			this.tabRegExChunk.Controls.Add(this.nudMaximumMatches);
			this.tabRegExChunk.Controls.Add(this.label2);
			this.tabRegExChunk.Controls.Add(this.tabControl2);
			this.tabRegExChunk.Controls.Add(this.nudMaxChunkLength);
			this.tabRegExChunk.Controls.Add(this.label1);
			this.tabRegExChunk.Controls.Add(this.groupBox2);
			this.tabRegExChunk.Controls.Add(this.btnRegExChunkTest);
			this.tabRegExChunk.Controls.Add(this.groupBox3);
			this.tabRegExChunk.Location = new System.Drawing.Point(4, 25);
			this.tabRegExChunk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabRegExChunk.Name = "tabRegExChunk";
			this.tabRegExChunk.Size = new System.Drawing.Size(1108, 557);
			this.tabRegExChunk.TabIndex = 1;
			this.tabRegExChunk.Text = "RegExChunk";
			this.tabRegExChunk.UseVisualStyleBackColor = true;
			// 
			// nudMaximumMatches
			// 
			this.nudMaximumMatches.Location = new System.Drawing.Point(827, 33);
			this.nudMaximumMatches.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.nudMaximumMatches.Maximum = new decimal(new int[] {
			10248,
			0,
			0,
			0});
			this.nudMaximumMatches.Name = "nudMaximumMatches";
			this.nudMaximumMatches.Size = new System.Drawing.Size(125, 22);
			this.nudMaximumMatches.TabIndex = 27;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(823, 14);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 17);
			this.label2.TabIndex = 26;
			this.label2.Text = "Max Matches";
			// 
			// tabControl2
			// 
			this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl2.Controls.Add(this.tabSourceREC);
			this.tabControl2.Controls.Add(this.tabResultREC);
			this.tabControl2.Location = new System.Drawing.Point(11, 111);
			this.tabControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(1091, 439);
			this.tabControl2.TabIndex = 25;
			// 
			// tabSourceREC
			// 
			this.tabSourceREC.Controls.Add(this.txtSourceTextREC);
			this.tabSourceREC.Location = new System.Drawing.Point(4, 25);
			this.tabSourceREC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabSourceREC.Name = "tabSourceREC";
			this.tabSourceREC.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabSourceREC.Size = new System.Drawing.Size(1083, 410);
			this.tabSourceREC.TabIndex = 0;
			this.tabSourceREC.Text = "Source Text (from RetrieveURL)";
			this.tabSourceREC.UseVisualStyleBackColor = true;
			// 
			// txtSourceTextREC
			// 
			this.txtSourceTextREC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtSourceTextREC.Location = new System.Drawing.Point(4, 4);
			this.txtSourceTextREC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtSourceTextREC.Multiline = true;
			this.txtSourceTextREC.Name = "txtSourceTextREC";
			this.txtSourceTextREC.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtSourceTextREC.Size = new System.Drawing.Size(1075, 402);
			this.txtSourceTextREC.TabIndex = 22;
			this.txtSourceTextREC.DoubleClick += new System.EventHandler(this.txtSourceTextREC_DoubleClick);
			// 
			// tabResultREC
			// 
			this.tabResultREC.Controls.Add(this.lstMatchResultsREC);
			this.tabResultREC.Controls.Add(this.txtMatchTextREC);
			this.tabResultREC.Location = new System.Drawing.Point(4, 25);
			this.tabResultREC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabResultREC.Name = "tabResultREC";
			this.tabResultREC.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabResultREC.Size = new System.Drawing.Size(1083, 410);
			this.tabResultREC.TabIndex = 1;
			this.tabResultREC.Text = "Result";
			this.tabResultREC.UseVisualStyleBackColor = true;
			// 
			// lstMatchResultsREC
			// 
			this.lstMatchResultsREC.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.lstMatchResultsREC.FormattingEnabled = true;
			this.lstMatchResultsREC.ItemHeight = 16;
			this.lstMatchResultsREC.Location = new System.Drawing.Point(8, 7);
			this.lstMatchResultsREC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.lstMatchResultsREC.Name = "lstMatchResultsREC";
			this.lstMatchResultsREC.Size = new System.Drawing.Size(1063, 84);
			this.lstMatchResultsREC.TabIndex = 23;
			this.lstMatchResultsREC.SelectedIndexChanged += new System.EventHandler(this.lstMatchResultsREC_SelectedIndexChanged);
			// 
			// txtMatchTextREC
			// 
			this.txtMatchTextREC.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtMatchTextREC.Location = new System.Drawing.Point(8, 95);
			this.txtMatchTextREC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtMatchTextREC.Multiline = true;
			this.txtMatchTextREC.Name = "txtMatchTextREC";
			this.txtMatchTextREC.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtMatchTextREC.Size = new System.Drawing.Size(1063, 299);
			this.txtMatchTextREC.TabIndex = 22;
			// 
			// nudMaxChunkLength
			// 
			this.nudMaxChunkLength.Location = new System.Drawing.Point(827, 76);
			this.nudMaxChunkLength.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.nudMaxChunkLength.Maximum = new decimal(new int[] {
			10248,
			0,
			0,
			0});
			this.nudMaxChunkLength.Name = "nudMaxChunkLength";
			this.nudMaxChunkLength.Size = new System.Drawing.Size(125, 22);
			this.nudMaxChunkLength.TabIndex = 24;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(823, 57);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(125, 17);
			this.label1.TabIndex = 23;
			this.label1.Text = "Max Chunk Length";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.nudEndIteration);
			this.groupBox2.Controls.Add(this.chkEndIgnoreCase);
			this.groupBox2.Controls.Add(this.txtRegExEnd);
			this.groupBox2.Location = new System.Drawing.Point(415, 9);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox2.Size = new System.Drawing.Size(396, 94);
			this.groupBox2.TabIndex = 22;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = " Ending Pattern ";
			// 
			// nudEndIteration
			// 
			this.nudEndIteration.Location = new System.Drawing.Point(283, 55);
			this.nudEndIteration.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.nudEndIteration.Name = "nudEndIteration";
			this.nudEndIteration.Size = new System.Drawing.Size(105, 22);
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
			this.chkEndIgnoreCase.Location = new System.Drawing.Point(68, 55);
			this.chkEndIgnoreCase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.chkEndIgnoreCase.Name = "chkEndIgnoreCase";
			this.chkEndIgnoreCase.Size = new System.Drawing.Size(106, 21);
			this.chkEndIgnoreCase.TabIndex = 7;
			this.chkEndIgnoreCase.Text = "Ignore Case";
			this.chkEndIgnoreCase.UseVisualStyleBackColor = true;
			// 
			// txtRegExEnd
			// 
			this.txtRegExEnd.Location = new System.Drawing.Point(20, 23);
			this.txtRegExEnd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtRegExEnd.Name = "txtRegExEnd";
			this.txtRegExEnd.Size = new System.Drawing.Size(367, 22);
			this.txtRegExEnd.TabIndex = 6;
			this.txtRegExEnd.Text = "</tr>";
			// 
			// btnRegExChunkTest
			// 
			this.btnRegExChunkTest.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.btnRegExChunkTest.Location = new System.Drawing.Point(981, 9);
			this.btnRegExChunkTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnRegExChunkTest.Name = "btnRegExChunkTest";
			this.btnRegExChunkTest.Size = new System.Drawing.Size(113, 94);
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
			this.groupBox3.Location = new System.Drawing.Point(11, 9);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox3.Size = new System.Drawing.Size(396, 94);
			this.groupBox3.TabIndex = 20;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = " Starting Pattern ";
			// 
			// nudStartIteration
			// 
			this.nudStartIteration.Location = new System.Drawing.Point(283, 54);
			this.nudStartIteration.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.nudStartIteration.Name = "nudStartIteration";
			this.nudStartIteration.Size = new System.Drawing.Size(105, 22);
			this.nudStartIteration.TabIndex = 14;
			// 
			// chkStartIgnoreCase
			// 
			this.chkStartIgnoreCase.AutoSize = true;
			this.chkStartIgnoreCase.Checked = true;
			this.chkStartIgnoreCase.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkStartIgnoreCase.Location = new System.Drawing.Point(61, 55);
			this.chkStartIgnoreCase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.chkStartIgnoreCase.Name = "chkStartIgnoreCase";
			this.chkStartIgnoreCase.Size = new System.Drawing.Size(106, 21);
			this.chkStartIgnoreCase.TabIndex = 13;
			this.chkStartIgnoreCase.Text = "Ignore Case";
			this.chkStartIgnoreCase.UseVisualStyleBackColor = true;
			// 
			// txtRegExStart
			// 
			this.txtRegExStart.Location = new System.Drawing.Point(13, 23);
			this.txtRegExStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtRegExStart.Name = "txtRegExStart";
			this.txtRegExStart.Size = new System.Drawing.Size(373, 22);
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
			this.tabRegFind.Location = new System.Drawing.Point(4, 25);
			this.tabRegFind.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabRegFind.Name = "tabRegFind";
			this.tabRegFind.Size = new System.Drawing.Size(1108, 557);
			this.tabRegFind.TabIndex = 2;
			this.tabRegFind.Text = "RegFind";
			this.tabRegFind.UseVisualStyleBackColor = true;
			// 
			// tabControl3
			// 
			this.tabControl3.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl3.Controls.Add(this.tabPage1);
			this.tabControl3.Controls.Add(this.tabPage2);
			this.tabControl3.Location = new System.Drawing.Point(4, 105);
			this.tabControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabControl3.Name = "tabControl3";
			this.tabControl3.SelectedIndex = 0;
			this.tabControl3.Size = new System.Drawing.Size(1091, 439);
			this.tabControl3.TabIndex = 26;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.txtCaptureTextRF);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabPage1.Size = new System.Drawing.Size(1083, 410);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Source Text (from RegExChunk/Result)";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// txtCaptureTextRF
			// 
			this.txtCaptureTextRF.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtCaptureTextRF.Location = new System.Drawing.Point(4, 4);
			this.txtCaptureTextRF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtCaptureTextRF.Multiline = true;
			this.txtCaptureTextRF.Name = "txtCaptureTextRF";
			this.txtCaptureTextRF.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtCaptureTextRF.Size = new System.Drawing.Size(1075, 402);
			this.txtCaptureTextRF.TabIndex = 22;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.lstRegExFindRF);
			this.tabPage2.Controls.Add(this.txtRegExFindResultsRF);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabPage2.Size = new System.Drawing.Size(1083, 410);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Result";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// lstRegExFindRF
			// 
			this.lstRegExFindRF.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.lstRegExFindRF.FormattingEnabled = true;
			this.lstRegExFindRF.ItemHeight = 16;
			this.lstRegExFindRF.Location = new System.Drawing.Point(8, 7);
			this.lstRegExFindRF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.lstRegExFindRF.Name = "lstRegExFindRF";
			this.lstRegExFindRF.Size = new System.Drawing.Size(1063, 84);
			this.lstRegExFindRF.TabIndex = 23;
			this.lstRegExFindRF.SelectedIndexChanged += new System.EventHandler(this.lstRegExFindRF_SelectedIndexChanged);
			// 
			// txtRegExFindResultsRF
			// 
			this.txtRegExFindResultsRF.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtRegExFindResultsRF.Location = new System.Drawing.Point(8, 95);
			this.txtRegExFindResultsRF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtRegExFindResultsRF.Multiline = true;
			this.txtRegExFindResultsRF.Name = "txtRegExFindResultsRF";
			this.txtRegExFindResultsRF.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtRegExFindResultsRF.Size = new System.Drawing.Size(1063, 299);
			this.txtRegExFindResultsRF.TabIndex = 22;
			// 
			// btnRegExFindRF
			// 
			this.btnRegExFindRF.Location = new System.Drawing.Point(995, 12);
			this.btnRegExFindRF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnRegExFindRF.Name = "btnRegExFindRF";
			this.btnRegExFindRF.Size = new System.Drawing.Size(100, 28);
			this.btnRegExFindRF.TabIndex = 21;
			this.btnRegExFindRF.Text = "Pattern Test";
			this.btnRegExFindRF.UseVisualStyleBackColor = true;
			this.btnRegExFindRF.Click += new System.EventHandler(this.btnRegExTestRF_Click);
			// 
			// nudIterationRF
			// 
			this.nudIterationRF.Location = new System.Drawing.Point(253, 47);
			this.nudIterationRF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.nudIterationRF.Name = "nudIterationRF";
			this.nudIterationRF.Size = new System.Drawing.Size(83, 22);
			this.nudIterationRF.TabIndex = 20;
			// 
			// chkIgnoreCaseRF
			// 
			this.chkIgnoreCaseRF.AutoSize = true;
			this.chkIgnoreCaseRF.Location = new System.Drawing.Point(59, 47);
			this.chkIgnoreCaseRF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.chkIgnoreCaseRF.Name = "chkIgnoreCaseRF";
			this.chkIgnoreCaseRF.Size = new System.Drawing.Size(106, 21);
			this.chkIgnoreCaseRF.TabIndex = 19;
			this.chkIgnoreCaseRF.Text = "Ignore Case";
			this.chkIgnoreCaseRF.UseVisualStyleBackColor = true;
			// 
			// txtRegExFindRF
			// 
			this.txtRegExFindRF.Location = new System.Drawing.Point(11, 15);
			this.txtRegExFindRF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtRegExFindRF.Name = "txtRegExFindRF";
			this.txtRegExFindRF.Size = new System.Drawing.Size(975, 22);
			this.txtRegExFindRF.TabIndex = 18;
			this.txtRegExFindRF.Text = "\\d[\\d]?.\\s+&nbsp;";
			// 
			// tabHarvestExample
			// 
			this.tabHarvestExample.Controls.Add(this.cbxYear);
			this.tabHarvestExample.Controls.Add(this.tabControl4);
			this.tabHarvestExample.Controls.Add(this.btnFullExample);
			this.tabHarvestExample.Location = new System.Drawing.Point(4, 25);
			this.tabHarvestExample.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabHarvestExample.Name = "tabHarvestExample";
			this.tabHarvestExample.Size = new System.Drawing.Size(1108, 557);
			this.tabHarvestExample.TabIndex = 3;
			this.tabHarvestExample.Text = "Harvest Example";
			this.tabHarvestExample.UseVisualStyleBackColor = true;
			// 
			// cbxYear
			// 
			this.cbxYear.FormattingEnabled = true;
			this.cbxYear.Items.AddRange(new object[] {
			"2016",
			"2015",
			"2014",
			"2013"});
			this.cbxYear.Location = new System.Drawing.Point(21, 523);
			this.cbxYear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cbxYear.Name = "cbxYear";
			this.cbxYear.Size = new System.Drawing.Size(121, 24);
			this.cbxYear.TabIndex = 24;
			// 
			// tabControl4
			// 
			this.tabControl4.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl4.Controls.Add(this.tabActivity);
			this.tabControl4.Controls.Add(this.tabResult);
			this.tabControl4.Location = new System.Drawing.Point(3, 2);
			this.tabControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabControl4.Name = "tabControl4";
			this.tabControl4.SelectedIndex = 0;
			this.tabControl4.Size = new System.Drawing.Size(1101, 513);
			this.tabControl4.TabIndex = 23;
			// 
			// tabActivity
			// 
			this.tabActivity.Controls.Add(this.lstFullExampleActivity);
			this.tabActivity.Location = new System.Drawing.Point(4, 25);
			this.tabActivity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabActivity.Name = "tabActivity";
			this.tabActivity.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabActivity.Size = new System.Drawing.Size(1093, 484);
			this.tabActivity.TabIndex = 0;
			this.tabActivity.Text = "Activity";
			this.tabActivity.UseVisualStyleBackColor = true;
			// 
			// lstFullExampleActivity
			// 
			this.lstFullExampleActivity.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.lstFullExampleActivity.FormattingEnabled = true;
			this.lstFullExampleActivity.ItemHeight = 16;
			this.lstFullExampleActivity.Location = new System.Drawing.Point(5, 6);
			this.lstFullExampleActivity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lstFullExampleActivity.Name = "lstFullExampleActivity";
			this.lstFullExampleActivity.Size = new System.Drawing.Size(1085, 452);
			this.lstFullExampleActivity.TabIndex = 0;
			// 
			// tabResult
			// 
			this.tabResult.Controls.Add(this.dgvFullExample);
			this.tabResult.Controls.Add(this.txtFullExampleResult);
			this.tabResult.Location = new System.Drawing.Point(4, 25);
			this.tabResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabResult.Name = "tabResult";
			this.tabResult.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabResult.Size = new System.Drawing.Size(1093, 484);
			this.tabResult.TabIndex = 1;
			this.tabResult.Text = "Result";
			this.tabResult.UseVisualStyleBackColor = true;
			// 
			// dgvFullExample
			// 
			this.dgvFullExample.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvFullExample.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvFullExample.Location = new System.Drawing.Point(3, 2);
			this.dgvFullExample.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dgvFullExample.Name = "dgvFullExample";
			this.dgvFullExample.RowTemplate.Height = 24;
			this.dgvFullExample.Size = new System.Drawing.Size(1087, 480);
			this.dgvFullExample.TabIndex = 3;
			this.dgvFullExample.Visible = false;
			// 
			// txtFullExampleResult
			// 
			this.txtFullExampleResult.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtFullExampleResult.Location = new System.Drawing.Point(5, 6);
			this.txtFullExampleResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtFullExampleResult.Multiline = true;
			this.txtFullExampleResult.Name = "txtFullExampleResult";
			this.txtFullExampleResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtFullExampleResult.Size = new System.Drawing.Size(1081, 472);
			this.txtFullExampleResult.TabIndex = 2;
			// 
			// btnFullExample
			// 
			this.btnFullExample.Location = new System.Drawing.Point(491, 523);
			this.btnFullExample.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnFullExample.Name = "btnFullExample";
			this.btnFullExample.Size = new System.Drawing.Size(100, 28);
			this.btnFullExample.TabIndex = 22;
			this.btnFullExample.Text = "Do It";
			this.btnFullExample.UseVisualStyleBackColor = true;
			this.btnFullExample.Click += new System.EventHandler(this.btnFullExample_Click);
			// 
			// frmScrape
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1116, 586);
			this.Controls.Add(this.tabControl1);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
			((System.ComponentModel.ISupportInitialize) (this.nudMaximumMatches)).EndInit();
			this.tabControl2.ResumeLayout(false);
			this.tabSourceREC.ResumeLayout(false);
			this.tabSourceREC.PerformLayout();
			this.tabResultREC.ResumeLayout(false);
			this.tabResultREC.PerformLayout();
			((System.ComponentModel.ISupportInitialize) (this.nudMaxChunkLength)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize) (this.nudEndIteration)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize) (this.nudStartIteration)).EndInit();
			this.tabRegFind.ResumeLayout(false);
			this.tabRegFind.PerformLayout();
			this.tabControl3.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize) (this.nudIterationRF)).EndInit();
			this.tabHarvestExample.ResumeLayout(false);
			this.tabControl4.ResumeLayout(false);
			this.tabActivity.ResumeLayout(false);
			this.tabResult.ResumeLayout(false);
			this.tabResult.PerformLayout();
			((System.ComponentModel.ISupportInitialize) (this.dgvFullExample)).EndInit();
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
		private System.Windows.Forms.TabPage tabHarvestExample;
		private System.Windows.Forms.Button btnFullExample;
		private System.Windows.Forms.TabControl tabControl4;
		private System.Windows.Forms.TabPage tabActivity;
		private System.Windows.Forms.TabPage tabResult;
		private System.Windows.Forms.TextBox txtFullExampleResult;
		private System.Windows.Forms.ListBox lstFullExampleActivity;
		private System.Windows.Forms.ComboBox cbxYear;
		private System.Windows.Forms.DataGridView dgvFullExample;
		private System.Windows.Forms.NumericUpDown nudMaximumMatches;
		private System.Windows.Forms.Label label2;
	}
}