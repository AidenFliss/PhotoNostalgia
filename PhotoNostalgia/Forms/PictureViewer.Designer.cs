namespace PhotoNostalgia.Forms
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
            resources.ApplyResources(this.pictureDisplay1, "pictureDisplay1");
            this.pictureDisplay1.Name = "pictureDisplay1";
            this.pictureDisplay1.TabStop = false;
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tagsBox1
            // 
            resources.ApplyResources(this.tagsBox1, "tagsBox1");
            this.tagsBox1.Name = "tagsBox1";
            // 
            // applyTagsButton1
            // 
            resources.ApplyResources(this.applyTagsButton1, "applyTagsButton1");
            this.applyTagsButton1.Name = "applyTagsButton1";
            this.applyTagsButton1.UseVisualStyleBackColor = true;
            this.applyTagsButton1.Click += new System.EventHandler(this.applyTagsButton1_Click);
            // 
            // PictureViewer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.applyTagsButton1);
            this.Controls.Add(this.tagsBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.pictureDisplay1);
            this.Name = "PictureViewer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PictureViewer_FormClosed);
            this.Load += new System.EventHandler(this.PictureViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureDisplay1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox tagsBox1;
        private System.Windows.Forms.Button applyTagsButton1;
        public System.Windows.Forms.PictureBox pictureDisplay1;
    }
}