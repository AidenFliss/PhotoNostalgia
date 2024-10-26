namespace PhotoNostalgia.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.firstPageButton1 = new System.Windows.Forms.Button();
            this.lastPageButton1 = new System.Windows.Forms.Button();
            this.prevPageButton1 = new System.Windows.Forms.Button();
            this.nextPageButton1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.maxPagesLabel1 = new System.Windows.Forms.Label();
            this.selectNumeric1 = new System.Windows.Forms.NumericUpDown();
            this.tagSelectorLabel1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllPictureViewersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.checkForUpdatesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.spanishToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spanishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.photoBox1 = new System.Windows.Forms.PictureBox();
            this.photoBox6 = new System.Windows.Forms.PictureBox();
            this.photoBox5 = new System.Windows.Forms.PictureBox();
            this.photoBox4 = new System.Windows.Forms.PictureBox();
            this.photoBox3 = new System.Windows.Forms.PictureBox();
            this.photoBox2 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.noTagsFoundLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.selectNumeric1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // firstPageButton1
            // 
            resources.ApplyResources(this.firstPageButton1, "firstPageButton1");
            this.firstPageButton1.Name = "firstPageButton1";
            this.firstPageButton1.UseVisualStyleBackColor = true;
            this.firstPageButton1.Click += new System.EventHandler(this.firstPageButton1_Click);
            // 
            // lastPageButton1
            // 
            resources.ApplyResources(this.lastPageButton1, "lastPageButton1");
            this.lastPageButton1.Name = "lastPageButton1";
            this.lastPageButton1.UseVisualStyleBackColor = true;
            this.lastPageButton1.Click += new System.EventHandler(this.lastPageButton1_Click);
            // 
            // prevPageButton1
            // 
            resources.ApplyResources(this.prevPageButton1, "prevPageButton1");
            this.prevPageButton1.Name = "prevPageButton1";
            this.prevPageButton1.UseVisualStyleBackColor = true;
            this.prevPageButton1.Click += new System.EventHandler(this.prevPageButton1_Click);
            // 
            // nextPageButton1
            // 
            resources.ApplyResources(this.nextPageButton1, "nextPageButton1");
            this.nextPageButton1.Name = "nextPageButton1";
            this.nextPageButton1.UseVisualStyleBackColor = true;
            this.nextPageButton1.Click += new System.EventHandler(this.nextPageButton1_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // maxPagesLabel1
            // 
            resources.ApplyResources(this.maxPagesLabel1, "maxPagesLabel1");
            this.maxPagesLabel1.Name = "maxPagesLabel1";
            // 
            // selectNumeric1
            // 
            resources.ApplyResources(this.selectNumeric1, "selectNumeric1");
            this.selectNumeric1.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.selectNumeric1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.selectNumeric1.Name = "selectNumeric1";
            this.selectNumeric1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.selectNumeric1.ValueChanged += new System.EventHandler(this.selectNumeric1_ValueChanged);
            // 
            // tagSelectorLabel1
            // 
            resources.ApplyResources(this.tagSelectorLabel1, "tagSelectorLabel1");
            this.tagSelectorLabel1.Name = "tagSelectorLabel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeAllPictureViewersToolStripMenuItem,
            this.toolStripSeparator3,
            this.checkForUpdatesToolStripMenuItem1,
            this.checkForUpdatesToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.toolStripSeparator2,
            this.aboutToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            // 
            // closeAllPictureViewersToolStripMenuItem
            // 
            this.closeAllPictureViewersToolStripMenuItem.Name = "closeAllPictureViewersToolStripMenuItem";
            resources.ApplyResources(this.closeAllPictureViewersToolStripMenuItem, "closeAllPictureViewersToolStripMenuItem");
            this.closeAllPictureViewersToolStripMenuItem.Click += new System.EventHandler(this.closeAllPictureViewersToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // checkForUpdatesToolStripMenuItem1
            // 
            this.checkForUpdatesToolStripMenuItem1.Name = "checkForUpdatesToolStripMenuItem1";
            resources.ApplyResources(this.checkForUpdatesToolStripMenuItem1, "checkForUpdatesToolStripMenuItem1");
            this.checkForUpdatesToolStripMenuItem1.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem1_Click);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            resources.ApplyResources(this.checkForUpdatesToolStripMenuItem, "checkForUpdatesToolStripMenuItem");
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem1,
            this.spanishToolStripMenuItem1});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // englishToolStripMenuItem1
            // 
            this.englishToolStripMenuItem1.Image = global::PhotoNostalgia.Properties.Resources.en;
            resources.ApplyResources(this.englishToolStripMenuItem1, "englishToolStripMenuItem1");
            this.englishToolStripMenuItem1.Name = "englishToolStripMenuItem1";
            this.englishToolStripMenuItem1.Tag = "en";
            this.englishToolStripMenuItem1.Click += new System.EventHandler(this.languageToolStripMenuItem_Click);
            // 
            // spanishToolStripMenuItem1
            // 
            this.spanishToolStripMenuItem1.Image = global::PhotoNostalgia.Properties.Resources.es;
            resources.ApplyResources(this.spanishToolStripMenuItem1, "spanishToolStripMenuItem1");
            this.spanishToolStripMenuItem1.Name = "spanishToolStripMenuItem1";
            this.spanishToolStripMenuItem1.Tag = "es";
            this.spanishToolStripMenuItem1.Click += new System.EventHandler(this.languageToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutButton1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripSeparator1,
            this.toolStripMenuItem3});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.spanishToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.languageToolStripMenuItem_Click);
            // 
            // spanishToolStripMenuItem
            // 
            this.spanishToolStripMenuItem.Name = "spanishToolStripMenuItem";
            resources.ApplyResources(this.spanishToolStripMenuItem, "spanishToolStripMenuItem");
            this.spanishToolStripMenuItem.Click += new System.EventHandler(this.languageToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            this.toolStripMenuItem3.Click += new System.EventHandler(this.aboutButton1_Click);
            // 
            // photoBox1
            // 
            resources.ApplyResources(this.photoBox1, "photoBox1");
            this.photoBox1.Name = "photoBox1";
            this.photoBox1.TabStop = false;
            this.photoBox1.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // photoBox6
            // 
            resources.ApplyResources(this.photoBox6, "photoBox6");
            this.photoBox6.Name = "photoBox6";
            this.photoBox6.TabStop = false;
            this.photoBox6.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // photoBox5
            // 
            resources.ApplyResources(this.photoBox5, "photoBox5");
            this.photoBox5.Name = "photoBox5";
            this.photoBox5.TabStop = false;
            this.photoBox5.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // photoBox4
            // 
            resources.ApplyResources(this.photoBox4, "photoBox4");
            this.photoBox4.Name = "photoBox4";
            this.photoBox4.TabStop = false;
            this.photoBox4.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // photoBox3
            // 
            resources.ApplyResources(this.photoBox3, "photoBox3");
            this.photoBox3.Name = "photoBox3";
            this.photoBox3.TabStop = false;
            this.photoBox3.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // photoBox2
            // 
            resources.ApplyResources(this.photoBox2, "photoBox2");
            this.photoBox2.Name = "photoBox2";
            this.photoBox2.TabStop = false;
            this.photoBox2.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // noTagsFoundLabel1
            // 
            resources.ApplyResources(this.noTagsFoundLabel1, "noTagsFoundLabel1");
            this.noTagsFoundLabel1.Name = "noTagsFoundLabel1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.noTagsFoundLabel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tagSelectorLabel1);
            this.Controls.Add(this.photoBox1);
            this.Controls.Add(this.selectNumeric1);
            this.Controls.Add(this.maxPagesLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nextPageButton1);
            this.Controls.Add(this.prevPageButton1);
            this.Controls.Add(this.lastPageButton1);
            this.Controls.Add(this.firstPageButton1);
            this.Controls.Add(this.photoBox6);
            this.Controls.Add(this.photoBox5);
            this.Controls.Add(this.photoBox4);
            this.Controls.Add(this.photoBox3);
            this.Controls.Add(this.photoBox2);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.selectNumeric1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox photoBox1;
        private System.Windows.Forms.PictureBox photoBox2;
        private System.Windows.Forms.PictureBox photoBox3;
        private System.Windows.Forms.PictureBox photoBox6;
        private System.Windows.Forms.PictureBox photoBox5;
        private System.Windows.Forms.PictureBox photoBox4;
        private System.Windows.Forms.Button firstPageButton1;
        private System.Windows.Forms.Button lastPageButton1;
        private System.Windows.Forms.Button prevPageButton1;
        private System.Windows.Forms.Button nextPageButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown selectNumeric1;
        private System.Windows.Forms.Label maxPagesLabel1;
        private System.Windows.Forms.Label tagSelectorLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spanishToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem spanishToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeAllPictureViewersToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label noTagsFoundLabel1;
    }
}

