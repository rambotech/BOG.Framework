namespace BOG.Framework_Test
{
    partial class frmTestSelector
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
            this.btnBabbleOn = new System.Windows.Forms.Button();
            this.btnFuse = new System.Windows.Forms.Button();
            this.btnFormatting = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSerializableDictionary = new System.Windows.Forms.Button();
            this.btnStringEx = new System.Windows.Forms.Button();
            this.btnScrape = new System.Windows.Forms.Button();
            this.btnSettingsDictionary = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBabbleOn
            // 
            this.btnBabbleOn.Location = new System.Drawing.Point(13, 13);
            this.btnBabbleOn.Name = "btnBabbleOn";
            this.btnBabbleOn.Size = new System.Drawing.Size(246, 50);
            this.btnBabbleOn.TabIndex = 0;
            this.btnBabbleOn.Text = "BabbleOn";
            this.btnBabbleOn.UseVisualStyleBackColor = true;
            this.btnBabbleOn.Click += new System.EventHandler(this.btnBabbleOn_Click);
            // 
            // btnFuse
            // 
            this.btnFuse.Location = new System.Drawing.Point(13, 69);
            this.btnFuse.Name = "btnFuse";
            this.btnFuse.Size = new System.Drawing.Size(246, 50);
            this.btnFuse.TabIndex = 1;
            this.btnFuse.Text = "Fuse";
            this.btnFuse.UseVisualStyleBackColor = true;
            this.btnFuse.Click += new System.EventHandler(this.btnFuse_Click);
            // 
            // btnFormatting
            // 
            this.btnFormatting.Location = new System.Drawing.Point(12, 125);
            this.btnFormatting.Name = "btnFormatting";
            this.btnFormatting.Size = new System.Drawing.Size(246, 50);
            this.btnFormatting.TabIndex = 2;
            this.btnFormatting.Text = "Formatting";
            this.btnFormatting.UseVisualStyleBackColor = true;
            this.btnFormatting.Click += new System.EventHandler(this.btnFormatting_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(246, 50);
            this.button1.TabIndex = 3;
            this.button1.Text = "DetailedException";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSerializableDictionary
            // 
            this.btnSerializableDictionary.Location = new System.Drawing.Point(12, 237);
            this.btnSerializableDictionary.Name = "btnSerializableDictionary";
            this.btnSerializableDictionary.Size = new System.Drawing.Size(246, 50);
            this.btnSerializableDictionary.TabIndex = 4;
            this.btnSerializableDictionary.Text = "SerializableDictionary";
            this.btnSerializableDictionary.UseVisualStyleBackColor = true;
            this.btnSerializableDictionary.Click += new System.EventHandler(this.btnSerializableDictionary_Click);
            // 
            // btnStringEx
            // 
            this.btnStringEx.Location = new System.Drawing.Point(275, 13);
            this.btnStringEx.Name = "btnStringEx";
            this.btnStringEx.Size = new System.Drawing.Size(246, 50);
            this.btnStringEx.TabIndex = 5;
            this.btnStringEx.Text = "StringEx";
            this.btnStringEx.UseVisualStyleBackColor = true;
            this.btnStringEx.Click += new System.EventHandler(this.btnStringEx_Click);
            // 
            // btnScrape
            // 
            this.btnScrape.Location = new System.Drawing.Point(275, 69);
            this.btnScrape.Name = "btnScrape";
            this.btnScrape.Size = new System.Drawing.Size(246, 50);
            this.btnScrape.TabIndex = 6;
            this.btnScrape.Text = "Scrape";
            this.btnScrape.UseVisualStyleBackColor = true;
            this.btnScrape.Click += new System.EventHandler(this.btnScrape_Click);
            // 
            // btnSettingsDictionary
            // 
            this.btnSettingsDictionary.Location = new System.Drawing.Point(275, 125);
            this.btnSettingsDictionary.Name = "btnSettingsDictionary";
            this.btnSettingsDictionary.Size = new System.Drawing.Size(246, 50);
            this.btnSettingsDictionary.TabIndex = 7;
            this.btnSettingsDictionary.Text = "SettingsDictionary";
            this.btnSettingsDictionary.UseVisualStyleBackColor = true;
            this.btnSettingsDictionary.Click += new System.EventHandler(this.btnSettingsDictionary_Click);
            // 
            // frmTestSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 300);
            this.Controls.Add(this.btnSettingsDictionary);
            this.Controls.Add(this.btnScrape);
            this.Controls.Add(this.btnStringEx);
            this.Controls.Add(this.btnSerializableDictionary);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnFormatting);
            this.Controls.Add(this.btnFuse);
            this.Controls.Add(this.btnBabbleOn);
            this.Name = "frmTestSelector";
            this.Text = "Test Selector";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBabbleOn;
        private System.Windows.Forms.Button btnFuse;
        private System.Windows.Forms.Button btnFormatting;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSerializableDictionary;
        private System.Windows.Forms.Button btnStringEx;
        private System.Windows.Forms.Button btnScrape;
        private System.Windows.Forms.Button btnSettingsDictionary;
    }
}