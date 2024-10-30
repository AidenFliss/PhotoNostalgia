#pragma warning disable CS8602

namespace PhotoNostalgia.Forms
{
    public partial class PictureViewer : Form
    {
        public PictureViewer()
        {
            InitializeComponent();
        }

        public bool shouldRemoveSelf = true;

        public void PictureViewer_LoadImage(string path)
        {
            if (!String.IsNullOrEmpty(path))
            {
                pictureDisplay1.ImageLocation = path;
                this.Text = MainForm.Instance.resourceManager.GetString("windowTitle") + " [" + Path.GetFileName(path) + "]";
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
            if (shouldRemoveSelf == true)
            {
                MainForm.Instance.NullifyPictureViewer(this);
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
            if (MainForm.Instance != null)
            {
                int length = pictureDisplay1.ImageLocation.Length;
                string path = Path.GetFileName(pictureDisplay1.ImageLocation);
                if (MainForm.TagDatabase.ContainsKey(path))
                {
                    string[] tags = MainForm.TagDatabase[path];
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
                    MainForm.Instance.resourceManager.GetString("confirmRemove"),
                    MainForm.Instance.resourceManager.GetString("confirmRemoveTitle"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    MainForm.TagDatabase.Remove(Path.GetFileName(pictureDisplay1.ImageLocation));
                    MessageBox.Show(
                        MainForm.Instance.resourceManager.GetString("deleteNotif"),
                        MainForm.Instance.resourceManager.GetString("deleteNotifTitle"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    MainForm.Instance.resourceManager.GetString("applyConfirm") + " " + tagBlob,
                    MainForm.Instance.resourceManager.GetString("applyConfirmTitle"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    MainForm.TagDatabase[Path.GetFileName(pictureDisplay1.ImageLocation)] = tags;
                }
            }
            MainForm.SaveDatabase();
            MainForm.Instance.UpdateTagButtons();
        }
    }
}
