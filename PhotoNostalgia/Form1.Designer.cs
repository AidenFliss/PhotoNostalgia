namespace PhotoNostalgia
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
            this.selectedPathLabel1 = new System.Windows.Forms.Label();
            this.photoBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tag4 = new System.Windows.Forms.CheckBox();
            this.tag3 = new System.Windows.Forms.CheckBox();
            this.tag2 = new System.Windows.Forms.CheckBox();
            this.tag1 = new System.Windows.Forms.CheckBox();
            this.photoBox2 = new System.Windows.Forms.PictureBox();
            this.photoBox3 = new System.Windows.Forms.PictureBox();
            this.photoBox6 = new System.Windows.Forms.PictureBox();
            this.photoBox5 = new System.Windows.Forms.PictureBox();
            this.photoBox4 = new System.Windows.Forms.PictureBox();
            this.firstPageButton1 = new System.Windows.Forms.Button();
            this.lastPageButton1 = new System.Windows.Forms.Button();
            this.prevPageButton1 = new System.Windows.Forms.Button();
            this.nextPageButton1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.maxPagesLabel1 = new System.Windows.Forms.Label();
            this.selectNumeric1 = new System.Windows.Forms.NumericUpDown();
            this.tag5 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tag6 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectNumeric1)).BeginInit();
            this.SuspendLayout();
            // 
            // selectedPathLabel1
            // 
            this.selectedPathLabel1.AutoSize = true;
            this.selectedPathLabel1.Location = new System.Drawing.Point(9, 7);
            this.selectedPathLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.selectedPathLabel1.Name = "selectedPathLabel1";
            this.selectedPathLabel1.Size = new System.Drawing.Size(127, 15);
            this.selectedPathLabel1.TabIndex = 0;
            this.selectedPathLabel1.Text = "Selected Path: [NULL]";
            // 
            // photoBox1
            // 
            this.photoBox1.ImageLocation = "";
            this.photoBox1.Location = new System.Drawing.Point(9, 109);
            this.photoBox1.Margin = new System.Windows.Forms.Padding(2);
            this.photoBox1.MinimumSize = new System.Drawing.Size(188, 122);
            this.photoBox1.Name = "photoBox1";
            this.photoBox1.Size = new System.Drawing.Size(188, 122);
            this.photoBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.photoBox1.TabIndex = 1;
            this.photoBox1.TabStop = false;
            this.photoBox1.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tag6);
            this.panel1.Controls.Add(this.tag5);
            this.panel1.Controls.Add(this.tag4);
            this.panel1.Controls.Add(this.tag3);
            this.panel1.Controls.Add(this.tag2);
            this.panel1.Controls.Add(this.tag1);
            this.panel1.Location = new System.Drawing.Point(9, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.MinimumSize = new System.Drawing.Size(582, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 81);
            this.panel1.TabIndex = 2;
            // 
            // tag4
            // 
            this.tag4.AutoSize = true;
            this.tag4.Location = new System.Drawing.Point(150, 2);
            this.tag4.Margin = new System.Windows.Forms.Padding(2);
            this.tag4.Name = "tag4";
            this.tag4.Size = new System.Drawing.Size(63, 19);
            this.tag4.TabIndex = 3;
            this.tag4.Text = "2000s";
            this.tag4.UseVisualStyleBackColor = true;
            this.tag4.CheckedChanged += new System.EventHandler(this.tagButton_Click);
            // 
            // tag3
            // 
            this.tag3.AutoSize = true;
            this.tag3.Location = new System.Drawing.Point(100, 2);
            this.tag3.Margin = new System.Windows.Forms.Padding(2);
            this.tag3.Name = "tag3";
            this.tag3.Size = new System.Drawing.Size(63, 19);
            this.tag3.TabIndex = 2;
            this.tag3.Text = "1990s";
            this.tag3.UseVisualStyleBackColor = true;
            this.tag3.CheckedChanged += new System.EventHandler(this.tagButton_Click);
            // 
            // tag2
            // 
            this.tag2.AutoSize = true;
            this.tag2.Location = new System.Drawing.Point(50, 2);
            this.tag2.Margin = new System.Windows.Forms.Padding(2);
            this.tag2.Name = "tag2";
            this.tag2.Size = new System.Drawing.Size(63, 19);
            this.tag2.TabIndex = 1;
            this.tag2.Text = "1970s";
            this.tag2.UseVisualStyleBackColor = true;
            this.tag2.CheckedChanged += new System.EventHandler(this.tagButton_Click);
            // 
            // tag1
            // 
            this.tag1.AutoSize = true;
            this.tag1.Location = new System.Drawing.Point(0, 2);
            this.tag1.Margin = new System.Windows.Forms.Padding(2);
            this.tag1.Name = "tag1";
            this.tag1.Size = new System.Drawing.Size(63, 19);
            this.tag1.TabIndex = 0;
            this.tag1.Text = "1930s";
            this.tag1.UseVisualStyleBackColor = true;
            this.tag1.CheckedChanged += new System.EventHandler(this.tagButton_Click);
            // 
            // photoBox2
            // 
            this.photoBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.photoBox2.ImageLocation = "";
            this.photoBox2.Location = new System.Drawing.Point(206, 109);
            this.photoBox2.Margin = new System.Windows.Forms.Padding(2);
            this.photoBox2.MinimumSize = new System.Drawing.Size(188, 122);
            this.photoBox2.Name = "photoBox2";
            this.photoBox2.Size = new System.Drawing.Size(188, 122);
            this.photoBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.photoBox2.TabIndex = 3;
            this.photoBox2.TabStop = false;
            this.photoBox2.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // photoBox3
            // 
            this.photoBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.photoBox3.ImageLocation = "";
            this.photoBox3.Location = new System.Drawing.Point(404, 109);
            this.photoBox3.Margin = new System.Windows.Forms.Padding(2);
            this.photoBox3.MinimumSize = new System.Drawing.Size(188, 122);
            this.photoBox3.Name = "photoBox3";
            this.photoBox3.Size = new System.Drawing.Size(188, 122);
            this.photoBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.photoBox3.TabIndex = 4;
            this.photoBox3.TabStop = false;
            this.photoBox3.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // photoBox6
            // 
            this.photoBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.photoBox6.ImageLocation = "";
            this.photoBox6.Location = new System.Drawing.Point(404, 234);
            this.photoBox6.Margin = new System.Windows.Forms.Padding(2);
            this.photoBox6.MinimumSize = new System.Drawing.Size(188, 122);
            this.photoBox6.Name = "photoBox6";
            this.photoBox6.Size = new System.Drawing.Size(188, 122);
            this.photoBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.photoBox6.TabIndex = 7;
            this.photoBox6.TabStop = false;
            this.photoBox6.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // photoBox5
            // 
            this.photoBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.photoBox5.ImageLocation = "";
            this.photoBox5.Location = new System.Drawing.Point(206, 234);
            this.photoBox5.Margin = new System.Windows.Forms.Padding(2);
            this.photoBox5.MinimumSize = new System.Drawing.Size(188, 122);
            this.photoBox5.Name = "photoBox5";
            this.photoBox5.Size = new System.Drawing.Size(188, 122);
            this.photoBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.photoBox5.TabIndex = 6;
            this.photoBox5.TabStop = false;
            this.photoBox5.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // photoBox4
            // 
            this.photoBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.photoBox4.ImageLocation = "";
            this.photoBox4.Location = new System.Drawing.Point(9, 234);
            this.photoBox4.Margin = new System.Windows.Forms.Padding(2);
            this.photoBox4.MinimumSize = new System.Drawing.Size(188, 122);
            this.photoBox4.Name = "photoBox4";
            this.photoBox4.Size = new System.Drawing.Size(188, 122);
            this.photoBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.photoBox4.TabIndex = 5;
            this.photoBox4.TabStop = false;
            this.photoBox4.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // firstPageButton1
            // 
            this.firstPageButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.firstPageButton1.Location = new System.Drawing.Point(9, 361);
            this.firstPageButton1.Name = "firstPageButton1";
            this.firstPageButton1.Size = new System.Drawing.Size(94, 23);
            this.firstPageButton1.TabIndex = 8;
            this.firstPageButton1.Text = "<<";
            this.firstPageButton1.UseVisualStyleBackColor = true;
            this.firstPageButton1.Click += new System.EventHandler(this.firstPageButton1_Click);
            // 
            // lastPageButton1
            // 
            this.lastPageButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lastPageButton1.Location = new System.Drawing.Point(498, 361);
            this.lastPageButton1.Name = "lastPageButton1";
            this.lastPageButton1.Size = new System.Drawing.Size(94, 23);
            this.lastPageButton1.TabIndex = 9;
            this.lastPageButton1.Text = ">>";
            this.lastPageButton1.UseVisualStyleBackColor = true;
            this.lastPageButton1.Click += new System.EventHandler(this.lastPageButton1_Click);
            // 
            // prevPageButton1
            // 
            this.prevPageButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prevPageButton1.Location = new System.Drawing.Point(109, 361);
            this.prevPageButton1.Name = "prevPageButton1";
            this.prevPageButton1.Size = new System.Drawing.Size(94, 23);
            this.prevPageButton1.TabIndex = 10;
            this.prevPageButton1.Text = "<";
            this.prevPageButton1.UseVisualStyleBackColor = true;
            this.prevPageButton1.Click += new System.EventHandler(this.prevPageButton1_Click);
            // 
            // nextPageButton1
            // 
            this.nextPageButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextPageButton1.Location = new System.Drawing.Point(398, 361);
            this.nextPageButton1.Name = "nextPageButton1";
            this.nextPageButton1.Size = new System.Drawing.Size(94, 23);
            this.nextPageButton1.TabIndex = 11;
            this.nextPageButton1.Text = ">";
            this.nextPageButton1.UseVisualStyleBackColor = true;
            this.nextPageButton1.Click += new System.EventHandler(this.nextPageButton1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Page: ";
            // 
            // maxPagesLabel1
            // 
            this.maxPagesLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.maxPagesLabel1.AutoSize = true;
            this.maxPagesLabel1.Location = new System.Drawing.Point(350, 366);
            this.maxPagesLabel1.Name = "maxPagesLabel1";
            this.maxPagesLabel1.Size = new System.Drawing.Size(34, 15);
            this.maxPagesLabel1.TabIndex = 13;
            this.maxPagesLabel1.Text = "/ 500";
            // 
            // selectNumeric1
            // 
            this.selectNumeric1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectNumeric1.Location = new System.Drawing.Point(246, 363);
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
            this.selectNumeric1.MinimumSize = new System.Drawing.Size(98, 0);
            this.selectNumeric1.Name = "selectNumeric1";
            this.selectNumeric1.Size = new System.Drawing.Size(98, 20);
            this.selectNumeric1.TabIndex = 14;
            this.selectNumeric1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.selectNumeric1.ValueChanged += new System.EventHandler(this.selectNumeric1_ValueChanged);
            // 
            // tag5
            // 
            this.tag5.AutoSize = true;
            this.tag5.Location = new System.Drawing.Point(200, 2);
            this.tag5.Margin = new System.Windows.Forms.Padding(2);
            this.tag5.Name = "tag5";
            this.tag5.Size = new System.Drawing.Size(68, 19);
            this.tag5.TabIndex = 4;
            this.tag5.Text = "Portrait";
            this.tag5.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Tag Selector:";
            // 
            // tag6
            // 
            this.tag6.AutoSize = true;
            this.tag6.Location = new System.Drawing.Point(250, 2);
            this.tag6.Margin = new System.Windows.Forms.Padding(2);
            this.tag6.Name = "tag6";
            this.tag6.Size = new System.Drawing.Size(60, 19);
            this.tag6.TabIndex = 5;
            this.tag6.Text = "Aiden";
            this.tag6.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 383);
            this.Controls.Add(this.label2);
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
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.selectedPathLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(618, 430);
            this.Name = "Form1";
            this.Text = "Photo Nostalgia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.photoBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photoBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectNumeric1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label selectedPathLabel1;
        private System.Windows.Forms.PictureBox photoBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox photoBox2;
        private System.Windows.Forms.PictureBox photoBox3;
        private System.Windows.Forms.PictureBox photoBox6;
        private System.Windows.Forms.PictureBox photoBox5;
        private System.Windows.Forms.PictureBox photoBox4;
        private System.Windows.Forms.CheckBox tag1;
        private System.Windows.Forms.CheckBox tag2;
        private System.Windows.Forms.Button firstPageButton1;
        private System.Windows.Forms.Button lastPageButton1;
        private System.Windows.Forms.Button prevPageButton1;
        private System.Windows.Forms.Button nextPageButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown selectNumeric1;
        private System.Windows.Forms.Label maxPagesLabel1;
        private System.Windows.Forms.CheckBox tag3;
        private System.Windows.Forms.CheckBox tag4;
        private System.Windows.Forms.CheckBox tag5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox tag6;
    }
}

