namespace BOG.Framework_Test
{
    partial class frmFuse
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbxParameters = new System.Windows.Forms.GroupBox();
            this.chkAutoReset = new System.Windows.Forms.CheckBox();
            this.nudVolumePerInterval = new System.Windows.Forms.NumericUpDown();
            this.lblVolumePerInterval = new System.Windows.Forms.Label();
            this.nudActivityIntervalMs = new System.Windows.Forms.NumericUpDown();
            this.lblActivityInterval = new System.Windows.Forms.Label();
            this.nudTimeframeMs = new System.Windows.Forms.NumericUpDown();
            this.lblTimeFrame = new System.Windows.Forms.Label();
            this.nudVolThreshold = new System.Windows.Forms.NumericUpDown();
            this.nudHitThreshold = new System.Windows.Forms.NumericUpDown();
            this.lblHitThreshold = new System.Windows.Forms.Label();
            this.lblVolThreshold = new System.Windows.Forms.Label();
            this.btnEndActivity = new System.Windows.Forms.Button();
            this.btnStartActivity = new System.Windows.Forms.Button();
            this.lblTripType = new System.Windows.Forms.Label();
            this.cbxFuseBehaviorType = new System.Windows.Forms.ComboBox();
            this.lbxFuseStream = new System.Windows.Forms.ListBox();
            this.tmrActivityMaker = new System.Windows.Forms.Timer(this.components);
            this.btnClearActivity = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbxParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVolumePerInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudActivityIntervalMs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeframeMs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVolThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHitThreshold)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.gbxParameters);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbxFuseStream);
            this.splitContainer1.Size = new System.Drawing.Size(710, 399);
            this.splitContainer1.SplitterDistance = 267;
            this.splitContainer1.TabIndex = 1;
            // 
            // gbxParameters
            // 
            this.gbxParameters.Controls.Add(this.btnClearActivity);
            this.gbxParameters.Controls.Add(this.chkAutoReset);
            this.gbxParameters.Controls.Add(this.nudVolumePerInterval);
            this.gbxParameters.Controls.Add(this.lblVolumePerInterval);
            this.gbxParameters.Controls.Add(this.nudActivityIntervalMs);
            this.gbxParameters.Controls.Add(this.lblActivityInterval);
            this.gbxParameters.Controls.Add(this.nudTimeframeMs);
            this.gbxParameters.Controls.Add(this.lblTimeFrame);
            this.gbxParameters.Controls.Add(this.nudVolThreshold);
            this.gbxParameters.Controls.Add(this.nudHitThreshold);
            this.gbxParameters.Controls.Add(this.lblHitThreshold);
            this.gbxParameters.Controls.Add(this.lblVolThreshold);
            this.gbxParameters.Controls.Add(this.btnEndActivity);
            this.gbxParameters.Controls.Add(this.btnStartActivity);
            this.gbxParameters.Controls.Add(this.lblTripType);
            this.gbxParameters.Controls.Add(this.cbxFuseBehaviorType);
            this.gbxParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxParameters.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxParameters.Location = new System.Drawing.Point(0, 0);
            this.gbxParameters.Name = "gbxParameters";
            this.gbxParameters.Size = new System.Drawing.Size(267, 399);
            this.gbxParameters.TabIndex = 0;
            this.gbxParameters.TabStop = false;
            this.gbxParameters.Text = "Parameters";
            // 
            // chkAutoReset
            // 
            this.chkAutoReset.AutoSize = true;
            this.chkAutoReset.Location = new System.Drawing.Point(31, 132);
            this.chkAutoReset.Name = "chkAutoReset";
            this.chkAutoReset.Size = new System.Drawing.Size(74, 17);
            this.chkAutoReset.TabIndex = 14;
            this.chkAutoReset.Text = "Auto-reset";
            this.chkAutoReset.UseVisualStyleBackColor = true;
            // 
            // nudVolumePerInterval
            // 
            this.nudVolumePerInterval.Location = new System.Drawing.Point(141, 186);
            this.nudVolumePerInterval.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.nudVolumePerInterval.Name = "nudVolumePerInterval";
            this.nudVolumePerInterval.Size = new System.Drawing.Size(120, 20);
            this.nudVolumePerInterval.TabIndex = 13;
            this.nudVolumePerInterval.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblVolumePerInterval
            // 
            this.lblVolumePerInterval.AutoSize = true;
            this.lblVolumePerInterval.Location = new System.Drawing.Point(12, 188);
            this.lblVolumePerInterval.Name = "lblVolumePerInterval";
            this.lblVolumePerInterval.Size = new System.Drawing.Size(97, 13);
            this.lblVolumePerInterval.TabIndex = 12;
            this.lblVolumePerInterval.Text = "Volume per interval";
            // 
            // nudActivityIntervalMs
            // 
            this.nudActivityIntervalMs.Location = new System.Drawing.Point(141, 158);
            this.nudActivityIntervalMs.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.nudActivityIntervalMs.Name = "nudActivityIntervalMs";
            this.nudActivityIntervalMs.Size = new System.Drawing.Size(120, 20);
            this.nudActivityIntervalMs.TabIndex = 11;
            this.nudActivityIntervalMs.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // lblActivityInterval
            // 
            this.lblActivityInterval.AutoSize = true;
            this.lblActivityInterval.Location = new System.Drawing.Point(12, 160);
            this.lblActivityInterval.Name = "lblActivityInterval";
            this.lblActivityInterval.Size = new System.Drawing.Size(101, 13);
            this.lblActivityInterval.TabIndex = 10;
            this.lblActivityInterval.Text = "Activity Interval (ms)";
            // 
            // nudTimeframeMs
            // 
            this.nudTimeframeMs.Location = new System.Drawing.Point(141, 102);
            this.nudTimeframeMs.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.nudTimeframeMs.Name = "nudTimeframeMs";
            this.nudTimeframeMs.Size = new System.Drawing.Size(120, 20);
            this.nudTimeframeMs.TabIndex = 9;
            this.nudTimeframeMs.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // lblTimeFrame
            // 
            this.lblTimeFrame.AutoSize = true;
            this.lblTimeFrame.Location = new System.Drawing.Point(12, 104);
            this.lblTimeFrame.Name = "lblTimeFrame";
            this.lblTimeFrame.Size = new System.Drawing.Size(78, 13);
            this.lblTimeFrame.TabIndex = 8;
            this.lblTimeFrame.Text = "Timeframe (ms)";
            // 
            // nudVolThreshold
            // 
            this.nudVolThreshold.Location = new System.Drawing.Point(141, 78);
            this.nudVolThreshold.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.nudVolThreshold.Name = "nudVolThreshold";
            this.nudVolThreshold.Size = new System.Drawing.Size(120, 20);
            this.nudVolThreshold.TabIndex = 7;
            this.nudVolThreshold.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // nudHitThreshold
            // 
            this.nudHitThreshold.Location = new System.Drawing.Point(141, 54);
            this.nudHitThreshold.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.nudHitThreshold.Name = "nudHitThreshold";
            this.nudHitThreshold.Size = new System.Drawing.Size(120, 20);
            this.nudHitThreshold.TabIndex = 6;
            this.nudHitThreshold.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblHitThreshold
            // 
            this.lblHitThreshold.AutoSize = true;
            this.lblHitThreshold.Location = new System.Drawing.Point(12, 56);
            this.lblHitThreshold.Name = "lblHitThreshold";
            this.lblHitThreshold.Size = new System.Drawing.Size(70, 13);
            this.lblHitThreshold.TabIndex = 5;
            this.lblHitThreshold.Text = "Hit Threshold";
            // 
            // lblVolThreshold
            // 
            this.lblVolThreshold.AutoSize = true;
            this.lblVolThreshold.Location = new System.Drawing.Point(12, 80);
            this.lblVolThreshold.Name = "lblVolThreshold";
            this.lblVolThreshold.Size = new System.Drawing.Size(92, 13);
            this.lblVolThreshold.TabIndex = 4;
            this.lblVolThreshold.Text = "Volume Threshold";
            // 
            // btnEndActivity
            // 
            this.btnEndActivity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEndActivity.Enabled = false;
            this.btnEndActivity.Location = new System.Drawing.Point(4, 353);
            this.btnEndActivity.Name = "btnEndActivity";
            this.btnEndActivity.Size = new System.Drawing.Size(261, 40);
            this.btnEndActivity.TabIndex = 3;
            this.btnEndActivity.Text = "End Activity";
            this.btnEndActivity.UseVisualStyleBackColor = true;
            this.btnEndActivity.Click += new System.EventHandler(this.btnEndActivity_Click);
            // 
            // btnStartActivity
            // 
            this.btnStartActivity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartActivity.Location = new System.Drawing.Point(4, 309);
            this.btnStartActivity.Name = "btnStartActivity";
            this.btnStartActivity.Size = new System.Drawing.Size(261, 40);
            this.btnStartActivity.TabIndex = 2;
            this.btnStartActivity.Text = "Start Activity";
            this.btnStartActivity.UseVisualStyleBackColor = true;
            this.btnStartActivity.Click += new System.EventHandler(this.btnStartActivity_Click);
            // 
            // lblTripType
            // 
            this.lblTripType.AutoSize = true;
            this.lblTripType.Location = new System.Drawing.Point(12, 22);
            this.lblTripType.Name = "lblTripType";
            this.lblTripType.Size = new System.Drawing.Size(77, 13);
            this.lblTripType.TabIndex = 1;
            this.lblTripType.Text = "Trip Conditions";
            // 
            // cbxFuseBehaviorType
            // 
            this.cbxFuseBehaviorType.FormattingEnabled = true;
            this.cbxFuseBehaviorType.Location = new System.Drawing.Point(109, 19);
            this.cbxFuseBehaviorType.Name = "cbxFuseBehaviorType";
            this.cbxFuseBehaviorType.Size = new System.Drawing.Size(152, 21);
            this.cbxFuseBehaviorType.TabIndex = 0;
            // 
            // lbxFuseStream
            // 
            this.lbxFuseStream.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxFuseStream.FormattingEnabled = true;
            this.lbxFuseStream.Location = new System.Drawing.Point(0, 0);
            this.lbxFuseStream.Name = "lbxFuseStream";
            this.lbxFuseStream.Size = new System.Drawing.Size(439, 399);
            this.lbxFuseStream.TabIndex = 1;
            // 
            // tmrActivityMaker
            // 
            this.tmrActivityMaker.Tick += new System.EventHandler(this.tmrActivityMaker_Tick);
            // 
            // btnClearActivity
            // 
            this.btnClearActivity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearActivity.Location = new System.Drawing.Point(4, 263);
            this.btnClearActivity.Name = "btnClearActivity";
            this.btnClearActivity.Size = new System.Drawing.Size(261, 40);
            this.btnClearActivity.TabIndex = 15;
            this.btnClearActivity.Text = "Clear Activity";
            this.btnClearActivity.UseVisualStyleBackColor = true;
            this.btnClearActivity.Click += new System.EventHandler(this.btnClearActivity_Click);
            // 
            // frmFuse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 399);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmFuse";
            this.Text = "Fuse";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbxParameters.ResumeLayout(false);
            this.gbxParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVolumePerInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudActivityIntervalMs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeframeMs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVolThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHitThreshold)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbxParameters;
        private System.Windows.Forms.Label lblTripType;
        private System.Windows.Forms.ComboBox cbxFuseBehaviorType;
        private System.Windows.Forms.ListBox lbxFuseStream;
        private System.Windows.Forms.Button btnStartActivity;
        private System.Windows.Forms.Button btnEndActivity;
        private System.Windows.Forms.Timer tmrActivityMaker;
        private System.Windows.Forms.Label lblHitThreshold;
        private System.Windows.Forms.Label lblVolThreshold;
        private System.Windows.Forms.NumericUpDown nudVolThreshold;
        private System.Windows.Forms.NumericUpDown nudHitThreshold;
        private System.Windows.Forms.Label lblTimeFrame;
        private System.Windows.Forms.NumericUpDown nudTimeframeMs;
        private System.Windows.Forms.Label lblActivityInterval;
        private System.Windows.Forms.NumericUpDown nudActivityIntervalMs;
        private System.Windows.Forms.NumericUpDown nudVolumePerInterval;
        private System.Windows.Forms.Label lblVolumePerInterval;
        private System.Windows.Forms.CheckBox chkAutoReset;
        private System.Windows.Forms.Button btnClearActivity;
    }
}