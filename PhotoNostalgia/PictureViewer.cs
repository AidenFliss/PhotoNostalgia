using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoNostalgia
{
    public partial class PictureViewer : Form
    {
        public PictureViewer()
        {
            InitializeComponent();
        }

        Form1 mainWindow = null;

        public void PictureViewer_LoadImage(string path, Form1 mainWindw)
        {
            if (path != null)
            {
                pictureDisplay1.ImageLocation = path;
                this.Text = "Picture Viewer [" + Path.GetFileName(path) + "]";
            }
            if (mainWindw != null)
            {
                mainWindow = mainWindw;
            }
            int length = pictureDisplay1.ImageLocation.Length;
            string noExt = pictureDisplay1.ImageLocation.Substring(0, length - 4);
            string newPath = noExt.TrimStart(new char[] { 'f', 'i', 'l', 'e', ':', '/'} ) + "_a.jpg";
            if (File.Exists(newPath))
            {
                checkBox1.Enabled = true;
            }
            else
            {
                checkBox1.Enabled = false;
            }
        }

        private void PictureViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mainWindow != null)
            {
                mainWindow.NullifyPictureViewer();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                int length = pictureDisplay1.ImageLocation.Length;
                string noExt = pictureDisplay1.ImageLocation.Substring(0, length - 4);
                string newPath = noExt + "_a.jpg";
                pictureDisplay1.ImageLocation = newPath;
            }
            else
            {
                int length = pictureDisplay1.ImageLocation.Length;
                string noExt = pictureDisplay1.ImageLocation.Substring(0, length - 6);
                string newPath = noExt + ".jpg";
                pictureDisplay1.ImageLocation = newPath;
            }
        }

        private void PictureViewer_Load(object sender, EventArgs e)
        {
            if (mainWindow != null)
            {
                int length = pictureDisplay1.ImageLocation.Length;
                string path = Path.GetFileName(pictureDisplay1.ImageLocation);
                if (Form1.tagDatabase.ContainsKey(path))
                {
                    string[] tags = Form1.tagDatabase[path];
                    foreach (string tag in tags)
                    {
                        tagsBox1.Text += tag + ", ";
                    }
                    tagsBox1.Text = tagsBox1.Text.TrimEnd(new char[] { ',', ' '});
                }
            }
        }

        private void applyTagsButton1_Click(object sender, EventArgs e)
        {
            string tagBlob = tagsBox1.Text;
            int length = pictureDisplay1.ImageLocation.Length;
            char[] delim = {',', ' '};
            string[] tags = tagBlob.Split(delim, StringSplitOptions.RemoveEmptyEntries);
            if (tags.Length == 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to remove tags on this image?", "Confimation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    Form1.tagDatabase.Remove(Path.GetFileName(pictureDisplay1.ImageLocation));
                    MessageBox.Show("Deleted Tags!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                Form1.tagDatabase[Path.GetFileName(pictureDisplay1.ImageLocation)] = tags;
            }
            Form1.SaveDatabase();
        }
    }
}
