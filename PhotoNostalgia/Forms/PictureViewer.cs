using System;
using System.IO;
using System.Windows.Forms;

namespace PhotoNostalgia.Forms
{
    public partial class PictureViewer : Form
    {
        public PictureViewer()
        {
            InitializeComponent();
        }

        Form1 mainWindow = null;
        public bool shouldRemoveSelf = true;

        public void PictureViewer_LoadImage(string path, Form1 mainWindw)
        {
            if (mainWindw != null)
            {
                mainWindow = mainWindw;
            }
            if (!String.IsNullOrEmpty(path))
            {
                pictureDisplay1.ImageLocation = path;
                this.Text = mainWindw.resourceManager.GetString("windowTitle") + " [" + Path.GetFileName(path) + "]";
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
            if (mainWindow != null && shouldRemoveSelf == true)
            {
                mainWindow.NullifyPictureViewer(this);
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
                if (Form1.TagDatabase.ContainsKey(path))
                {
                    string[] tags = Form1.TagDatabase[path];
                    foreach (string tag in tags)
                    {
                        tagsBox1.Text += tag + ", ";
                    }
                    tagsBox1.Text = tagsBox1.Text.TrimEnd(new char[] { ',', ' ' });
                }
            }
        }

        private void applyTagsButton1_Click(object sender, EventArgs e)
        {
            string tagBlob = tagsBox1.Text;
            int length = pictureDisplay1.ImageLocation.Length;
            char[] delim = {','};
            string[] tags = tagBlob.Split(delim, StringSplitOptions.RemoveEmptyEntries);
            if (tags.Length == 0)
            {
                DialogResult result = MessageBox.Show(
                    mainWindow.resourceManager.GetString("confirmRemove"),
                    mainWindow.resourceManager.GetString("confirmRemoveTitle"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    Form1.TagDatabase.Remove(Path.GetFileName(pictureDisplay1.ImageLocation));
                    MessageBox.Show(
                        mainWindow.resourceManager.GetString("deleteNotif"),
                        mainWindow.resourceManager.GetString("deleteNotifTitle"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    mainWindow.resourceManager.GetString("applyConfirm") + " " + tagBlob,
                    mainWindow.resourceManager.GetString("applyConfirmTitle"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    Form1.TagDatabase[Path.GetFileName(pictureDisplay1.ImageLocation)] = tags;
                }
            }
            Form1.SaveDatabase();
            mainWindow.UpdateTagButtons();
        }
    }
}
