namespace PhotoNostalgia
{
    partial class PictureViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PictureViewer));
            this.pictureDisplay1 = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tagsBox1 = new System.Windows.Forms.TextBox();
            this.applyTagsButton1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDisplay1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureDisplay1
            // 
            this.pictureDisplay1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureDisplay1.ImageLocation = "C:\\Users\\aiden\\Pictures\\122737.webp";
            this.pictureDisplay1.Location = new System.Drawing.Point(-1, -2);
            this.pictureDisplay1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureDisplay1.Name = "pictureDisplay1";
            this.pictureDisplay1.Size = new System.Drawing.Size(602, 367);
            this.pictureDisplay1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureDisplay1.TabIndex = 0;
            this.pictureDisplay1.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(0, 367);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 19);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Enhancements";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tagsBox1
            // 
            this.tagsBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagsBox1.Location = new System.Drawing.Point(118, 367);
            this.tagsBox1.Name = "tagsBox1";
            this.tagsBox1.Size = new System.Drawing.Size(362, 20);
            this.tagsBox1.TabIndex = 2;
            // 
            // applyTagsButton1
            // 
            this.applyTagsButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyTagsButton1.Location = new System.Drawing.Point(486, 365);
            this.applyTagsButton1.Name = "applyTagsButton1";
            this.applyTagsButton1.Size = new System.Drawing.Size(102, 23);
            this.applyTagsButton1.TabIndex = 3;
            this.applyTagsButton1.Text = "Apply Tags";
            this.applyTagsButton1.UseVisualStyleBackColor = true;
            this.applyTagsButton1.Click += new System.EventHandler(this.applyTagsButton1_Click);
            // 
            // PictureViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 387);
            this.Controls.Add(this.applyTagsButton1);
            this.Controls.Add(this.tagsBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.pictureDisplay1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PictureViewer";
            this.Text = "Picture Viewer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PictureViewer_FormClosed);
            this.Load += new System.EventHandler(this.PictureViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureDisplay1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureDisplay1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox tagsBox1;
        private System.Windows.Forms.Button applyTagsButton1;
    }
}