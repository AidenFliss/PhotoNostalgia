namespace PhotoNostalgia.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            firstPageButton1 = new Button();
            lastPageButton1 = new Button();
            prevPageButton1 = new Button();
            nextPageButton1 = new Button();
            label1 = new Label();
            maxPagesLabel1 = new Label();
            selectNumeric1 = new NumericUpDown();
            tagSelectorLabel1 = new Label();
            menuStrip1 = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            closeAllPictureViewersToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            checkForUpdatesToolStripMenuItem1 = new ToolStripMenuItem();
            checkForUpdatesToolStripMenuItem = new ToolStripMenuItem();
            languageToolStripMenuItem = new ToolStripMenuItem();
            englishToolStripMenuItem1 = new ToolStripMenuItem();
            spanishToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            englishToolStripMenuItem = new ToolStripMenuItem();
            spanishToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItem3 = new ToolStripMenuItem();
            flowLayoutPanel1 = new FlowLayoutPanel();
            noTagsFoundLabel1 = new Label();
            photoBox1 = new PictureBox();
            photoBox6 = new PictureBox();
            photoBox5 = new PictureBox();
            photoBox4 = new PictureBox();
            photoBox3 = new PictureBox();
            photoBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)selectNumeric1).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)photoBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)photoBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)photoBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)photoBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)photoBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)photoBox2).BeginInit();
            SuspendLayout();
            // 
            // firstPageButton1
            // 
            resources.ApplyResources(firstPageButton1, "firstPageButton1");
            firstPageButton1.Name = "firstPageButton1";
            firstPageButton1.UseVisualStyleBackColor = true;
            firstPageButton1.Click += firstPageButton1_Click;
            // 
            // lastPageButton1
            // 
            resources.ApplyResources(lastPageButton1, "lastPageButton1");
            lastPageButton1.Name = "lastPageButton1";
            lastPageButton1.UseVisualStyleBackColor = true;
            lastPageButton1.Click += lastPageButton1_Click;
            // 
            // prevPageButton1
            // 
            resources.ApplyResources(prevPageButton1, "prevPageButton1");
            prevPageButton1.Name = "prevPageButton1";
            prevPageButton1.UseVisualStyleBackColor = true;
            prevPageButton1.Click += prevPageButton1_Click;
            // 
            // nextPageButton1
            // 
            resources.ApplyResources(nextPageButton1, "nextPageButton1");
            nextPageButton1.Name = "nextPageButton1";
            nextPageButton1.UseVisualStyleBackColor = true;
            nextPageButton1.Click += nextPageButton1_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // maxPagesLabel1
            // 
            resources.ApplyResources(maxPagesLabel1, "maxPagesLabel1");
            maxPagesLabel1.Name = "maxPagesLabel1";
            // 
            // selectNumeric1
            // 
            resources.ApplyResources(selectNumeric1, "selectNumeric1");
            selectNumeric1.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            selectNumeric1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            selectNumeric1.Name = "selectNumeric1";
            selectNumeric1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            selectNumeric1.ValueChanged += selectNumeric1_ValueChanged;
            // 
            // tagSelectorLabel1
            // 
            resources.ApplyResources(tagSelectorLabel1, "tagSelectorLabel1");
            tagSelectorLabel1.Name = "tagSelectorLabel1";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Name = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { closeAllPictureViewersToolStripMenuItem, toolStripSeparator3, checkForUpdatesToolStripMenuItem1, checkForUpdatesToolStripMenuItem, languageToolStripMenuItem, toolStripSeparator2, aboutToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(settingsToolStripMenuItem, "settingsToolStripMenuItem");
            // 
            // closeAllPictureViewersToolStripMenuItem
            // 
            closeAllPictureViewersToolStripMenuItem.Name = "closeAllPictureViewersToolStripMenuItem";
            resources.ApplyResources(closeAllPictureViewersToolStripMenuItem, "closeAllPictureViewersToolStripMenuItem");
            closeAllPictureViewersToolStripMenuItem.Click += closeAllPictureViewersToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(toolStripSeparator3, "toolStripSeparator3");
            // 
            // checkForUpdatesToolStripMenuItem1
            // 
            checkForUpdatesToolStripMenuItem1.Name = "checkForUpdatesToolStripMenuItem1";
            resources.ApplyResources(checkForUpdatesToolStripMenuItem1, "checkForUpdatesToolStripMenuItem1");
            checkForUpdatesToolStripMenuItem1.Click += checkForUpdatesToolStripMenuItem1_Click;
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            resources.ApplyResources(checkForUpdatesToolStripMenuItem, "checkForUpdatesToolStripMenuItem");
            checkForUpdatesToolStripMenuItem.Click += checkForUpdatesToolStripMenuItem_Click;
            // 
            // languageToolStripMenuItem
            // 
            languageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { englishToolStripMenuItem1, spanishToolStripMenuItem1 });
            resources.ApplyResources(languageToolStripMenuItem, "languageToolStripMenuItem");
            languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            // 
            // englishToolStripMenuItem1
            // 
            resources.ApplyResources(englishToolStripMenuItem1, "englishToolStripMenuItem1");
            englishToolStripMenuItem1.Image = Properties.Resources.en;
            englishToolStripMenuItem1.Name = "englishToolStripMenuItem1";
            englishToolStripMenuItem1.Tag = "en";
            englishToolStripMenuItem1.Click += languageToolStripMenuItem_Click;
            // 
            // spanishToolStripMenuItem1
            // 
            resources.ApplyResources(spanishToolStripMenuItem1, "spanishToolStripMenuItem1");
            spanishToolStripMenuItem1.Image = Properties.Resources.es;
            spanishToolStripMenuItem1.Name = "spanishToolStripMenuItem1";
            spanishToolStripMenuItem1.Tag = "es";
            spanishToolStripMenuItem1.Click += languageToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(aboutToolStripMenuItem, "aboutToolStripMenuItem");
            aboutToolStripMenuItem.Click += aboutButton1_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, toolStripSeparator1, toolStripMenuItem3 });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { englishToolStripMenuItem, spanishToolStripMenuItem });
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // englishToolStripMenuItem
            // 
            englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(englishToolStripMenuItem, "englishToolStripMenuItem");
            englishToolStripMenuItem.Click += languageToolStripMenuItem_Click;
            // 
            // spanishToolStripMenuItem
            // 
            spanishToolStripMenuItem.Name = "spanishToolStripMenuItem";
            resources.ApplyResources(spanishToolStripMenuItem, "spanishToolStripMenuItem");
            spanishToolStripMenuItem.Click += languageToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(toolStripMenuItem3, "toolStripMenuItem3");
            toolStripMenuItem3.Click += aboutButton1_Click;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // noTagsFoundLabel1
            // 
            resources.ApplyResources(noTagsFoundLabel1, "noTagsFoundLabel1");
            noTagsFoundLabel1.Name = "noTagsFoundLabel1";
            // 
            // photoBox1
            // 
            resources.ApplyResources(photoBox1, "photoBox1");
            photoBox1.Name = "photoBox1";
            photoBox1.TabStop = false;
            photoBox1.LoadCompleted += pictureBox_LoadCompleted;
            photoBox1.Click += pictureBox_Click;
            photoBox1.DoubleClick += pictureBox_DoubleClick;
            // 
            // photoBox6
            // 
            resources.ApplyResources(photoBox6, "photoBox6");
            photoBox6.Name = "photoBox6";
            photoBox6.TabStop = false;
            photoBox6.DoubleClick += pictureBox_DoubleClick;
            // 
            // photoBox5
            // 
            resources.ApplyResources(photoBox5, "photoBox5");
            photoBox5.Name = "photoBox5";
            photoBox5.TabStop = false;
            photoBox5.DoubleClick += pictureBox_DoubleClick;
            // 
            // photoBox4
            // 
            resources.ApplyResources(photoBox4, "photoBox4");
            photoBox4.Name = "photoBox4";
            photoBox4.TabStop = false;
            photoBox4.DoubleClick += pictureBox_DoubleClick;
            // 
            // photoBox3
            // 
            resources.ApplyResources(photoBox3, "photoBox3");
            photoBox3.Name = "photoBox3";
            photoBox3.TabStop = false;
            photoBox3.DoubleClick += pictureBox_DoubleClick;
            // 
            // photoBox2
            // 
            resources.ApplyResources(photoBox2, "photoBox2");
            photoBox2.Name = "photoBox2";
            photoBox2.TabStop = false;
            photoBox2.DoubleClick += pictureBox_DoubleClick;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(noTagsFoundLabel1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(tagSelectorLabel1);
            Controls.Add(photoBox1);
            Controls.Add(selectNumeric1);
            Controls.Add(maxPagesLabel1);
            Controls.Add(label1);
            Controls.Add(nextPageButton1);
            Controls.Add(prevPageButton1);
            Controls.Add(lastPageButton1);
            Controls.Add(firstPageButton1);
            Controls.Add(photoBox6);
            Controls.Add(photoBox5);
            Controls.Add(photoBox4);
            Controls.Add(photoBox3);
            Controls.Add(photoBox2);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "MainForm";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)selectNumeric1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)photoBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)photoBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)photoBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)photoBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)photoBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)photoBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
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

