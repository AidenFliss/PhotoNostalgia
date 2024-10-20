using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Ookii.Dialogs.WinForms;
using Newtonsoft.Json;
using PhotoNostalgia.Properties;

namespace PhotoNostalgia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        VistaFolderBrowserDialog fbd;
        PictureViewer pictureViewer = null;

        int offset = 0;
        int page = 1;

        int totalPhotos;
        int totalPages;
        int totalOffset;

        List<string> selectedTags = new List<string>();

        List<string> photoPaths = new List<string>();
        List<string> currentPhotos = new List<string>();

        public static Dictionary<string, string[]> tagDatabase = new Dictionary<string, string[]>();

        static string dbLocation = Directory.GetCurrentDirectory() + "\\database.json";
        static string dbBackupLocation = Directory.GetCurrentDirectory() + "\\database_backup.json";

        private void Form1_Load(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Please select the \"FastFoto\" folder", "Select the Photo Folder.", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Cancel)
            {
                Application.Exit();
            }

            while (true)
            {
                fbd = new VistaFolderBrowserDialog();
                fbd.Description = "Please select the \"FastFoto\" folder.";
                fbd.UseDescriptionForTitle = true;
                fbd.ShowDialog();

                if (!Directory.Exists(fbd.SelectedPath) || fbd.SelectedPath == null)
                {
                    DialogResult result2 = MessageBox.Show("Invalid Path!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    if (result2 == DialogResult.Cancel)
                    {
                        Application.Exit();
                        break;
                    }
                    continue;
                }
                else
                {
                    selectedPathLabel1.Text = "Selected Path: " + fbd.SelectedPath;
                    break;
                }
            }

            ProgressDialog prog = new ProgressDialog();
            prog.ProgressBarStyle = Ookii.Dialogs.WinForms.ProgressBarStyle.MarqueeProgressBar;
            prog.ShowTimeRemaining = true;
            prog.Text = "Getting Photos...";
            prog.WindowTitle = "Processing...";
            prog.CancellationText = "Cancel";
            prog.ShowDialog();

            foreach (string filePath in Directory.EnumerateFiles(fbd.SelectedPath))
            {
                if (!filePath.EndsWith("_a.jpg") && filePath.EndsWith(".jpg"))
                {
                    photoPaths.Add(filePath);
                    currentPhotos.Add(filePath);
                }
            }

            prog.Dispose();

            if (!File.Exists(dbLocation) && File.Exists(dbBackupLocation))
            {
                MessageBox.Show("Restoring database from backup...", "Restoring", MessageBoxButtons.OK, MessageBoxIcon.Information);
                File.Copy(dbBackupLocation, dbLocation);
            }

            if (!File.Exists(dbLocation) && !File.Exists(dbBackupLocation))
            {
                MessageBox.Show("Database not found! Creating a new database...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                File.WriteAllText(dbLocation, "{}");
            }

            if (File.Exists(dbLocation))
            {
                string data = File.ReadAllText(dbLocation);
                tagDatabase = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(data);
            }

            CheckBox[] tagBoxes = { tag1, tag2, tag3, tag4, tag5, tag6 };

            foreach (CheckBox tagCheckBox in tagBoxes)
            {
                tagCheckBox.Appearance = Appearance.Button;
                tagCheckBox.TextAlign = ContentAlignment.MiddleCenter;
            }

            UpdatePictureGrid();
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            if ((sender as PictureBox).Tag == "[IGNORE]")
            {
                return;
            }
            if (pictureViewer == null)
            {
                pictureViewer = new PictureViewer();
                pictureViewer.PictureViewer_LoadImage((sender as PictureBox).ImageLocation, this);
                pictureViewer.Show(this);
            }
        }

        public void NullifyPictureViewer()
        {
            pictureViewer = null;
        }

        void UpdatePictureGrid()
        {
            PictureBox[] photoBoxes = { photoBox1, photoBox2, photoBox3, photoBox4, photoBox5, photoBox6 };
            for (int i = 0; i < photoBoxes.Length; i++)
            {
                int photoIndex = offset + i;
                if (photoIndex < currentPhotos.Count)
                {
                    if (currentPhotos.Any())
                    {
                        photoBoxes[i].Tag = null;
                        photoBoxes[i].ImageLocation = "file:///" + currentPhotos[photoIndex];
                    }
                    else
                    {
                        photoBoxes[i].Tag = "[IGNORE]";
                        photoBoxes[i].Image = Resources.PlaceholderImage;
                    }
                }
                else
                {
                    photoBoxes[i].Tag = "[IGNORE]";
                    photoBoxes[i].Image = Resources.PlaceholderImage;
                }
            }
            totalPhotos = currentPhotos.Count;
            totalPages = (int)Math.Ceiling(totalPhotos / 6.0);
            totalOffset = totalPages * 6;
            maxPagesLabel1.Text = "/ " + totalPages;

            page = (offset / 6);
            selectNumeric1.Maximum = totalPages;
            selectNumeric1.Value = page + 1;

            if (offset <= 0)
            {
                prevPageButton1.Enabled = false;
                firstPageButton1.Enabled = false;
            }
            else
            {
                prevPageButton1.Enabled = true;
                firstPageButton1.Enabled = true;
            }

            if (offset >= totalOffset - 6)
            {
                nextPageButton1.Enabled = false;
                lastPageButton1.Enabled = false;
            }
            else
            {
                nextPageButton1.Enabled = true;
                lastPageButton1.Enabled = true;
            }
        }

        private void firstPageButton1_Click(object sender, EventArgs e)
        {
            offset = 0;
            UpdatePictureGrid();
        }

        private void lastPageButton1_Click(object sender, EventArgs e)
        {
            offset = totalOffset - 6;
            UpdatePictureGrid();
        }

        private void prevPageButton1_Click(object sender, EventArgs e)
        {
            if (offset > 0)
            {
                offset -= 6;
            }
            UpdatePictureGrid();
        }

        private void nextPageButton1_Click(object sender, EventArgs e)
        {
            if (offset < totalOffset - 6)
            {
                offset += 6;
            }
            UpdatePictureGrid();
        }

        private void selectNumeric1_ValueChanged(object sender, EventArgs e)
        {
            page = (int)selectNumeric1.Value - 1;
            offset = page * 6;
            UpdatePictureGrid();
        }

        private void tagButton_Click(object sender, EventArgs e)
        {
            CheckBox tagClicked = (sender as CheckBox);
            string tag = tagClicked.Text;
            if (tagClicked.Checked)
            {
                selectedTags.Add(tag);
                currentPhotos.Clear();
                foreach (string photo in photoPaths)
                {
                    if (!tagDatabase.ContainsKey(Path.GetFileName(photo)))
                    {
                        continue;
                    }
                    string[] imageTags = tagDatabase[Path.GetFileName(photo)];
                    bool intersects = selectedTags.Intersect(imageTags).Any();
                    if (intersects)
                    {
                        currentPhotos.Add(photo);
                    }
                }
                UpdatePictureGrid();
            }
            else
            {
                selectedTags.Remove(tag);
                currentPhotos.Clear();
                if (selectedTags.Count <= 0)
                {
                    foreach (string photo in photoPaths)
                    {
                        currentPhotos.Add(photo);
                    }
                    UpdatePictureGrid();
                    return;
                }
                foreach (string photo in photoPaths)
                {
                    if (!tagDatabase.ContainsKey(Path.GetFileName(photo)))
                    {
                        continue;
                    }
                    string[] imageTags = tagDatabase[Path.GetFileName(photo)];
                    bool intersects = selectedTags.Intersect(imageTags).Any();
                    if (intersects)
                    {
                        currentPhotos.Add(photo);
                    }
                }
                UpdatePictureGrid();
            }
        }

        public static void SaveDatabase()
        {
            string json = JsonConvert.SerializeObject(tagDatabase, Formatting.Indented);
            File.WriteAllText(dbLocation, json);
        }

        public static void BackupDatabase()
        {
            string json = JsonConvert.SerializeObject(tagDatabase, Formatting.Indented);
            File.WriteAllText(dbBackupLocation, json);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveDatabase();
            BackupDatabase();
        }
    }
}
