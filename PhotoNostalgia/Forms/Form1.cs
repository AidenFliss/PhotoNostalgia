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
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace PhotoNostalgia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            string[] args = Environment.GetCommandLineArgs();

            PhotoNostalgiaSettings settings = LoadSettings();

            if (settings.CheckForUpdatesOnStart && !args.Contains("-forceSkipUpdateCheck"))
            {
                CheckForUpdates();
            }

            InitializeComponent();
        }

        string SettingsPath = Environment.CurrentDirectory + "\\settings.json";

        static string DatabaseLocation = Environment.CurrentDirectory + "\\database.json";
        static string DatabaseBackupLocation = Environment.CurrentDirectory + "\\database_backup.json";

        public static Dictionary<string, string[]> TagDatabase = new Dictionary<string, string[]>();

        VistaFolderBrowserDialog fbd;
        PictureViewer pictureViewer = null;
        About aboutWindow = null;

        bool checkForUpdates = true;
        string photoPath;

        int offset = 0;
        int page = 1;

        int totalPhotos;
        int totalPages;
        int totalOffset;

        List<string> selectedTags = new List<string>();

        List<string> photoPaths = new List<string>();
        List<string> currentPhotos = new List<string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            if (photoPath == null || !Directory.Exists(photoPath))
            {
                //TODO: Localize.
                DialogResult result = MessageBox.Show("Please select the \"FastFoto\" folder",
                    "Select the Photo Folder.",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Cancel)
                {
                    Application.Exit();
                    return;
                }

                while (true)
                {
                    fbd = new VistaFolderBrowserDialog();
                    fbd.Description = "Please select the \"FastFoto\" folder.";
                    fbd.UseDescriptionForTitle = true;
                    fbd.ShowDialog();

                    if (!Directory.Exists(fbd.SelectedPath) || fbd.SelectedPath == null)
                    {
                        //TODO: Localize.
                        DialogResult result2 = MessageBox.Show("Invalid Path!",
                            "Error",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Error);
                        if (result2 == DialogResult.Cancel)
                        {
                            Application.Exit();
                            return;
                        }
                        continue;
                    }
                    else
                    {
                        photoPath = fbd.SelectedPath;
                        break;
                    }
                }
            }

            foreach (string filePath in Directory.EnumerateFiles(photoPath))
            {
                if (!filePath.EndsWith("_a.jpg") && filePath.EndsWith(".jpg"))
                {
                    photoPaths.Add(filePath);
                    currentPhotos.Add(filePath);
                }
            }

            if (!File.Exists(DatabaseLocation) && File.Exists(DatabaseBackupLocation))
            {
                File.Copy(DatabaseBackupLocation, DatabaseLocation);
            }

            if (!File.Exists(DatabaseLocation) && !File.Exists(DatabaseBackupLocation))
            {
                File.WriteAllText(DatabaseLocation, "{}");
            }

            if (File.Exists(DatabaseLocation))
            {
                string data = File.ReadAllText(DatabaseLocation);
                TagDatabase = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(data);
            }

            CheckBox[] tagBoxes = { tag1, tag2, tag3, tag4, tag5, tag6 };

            foreach (CheckBox tagCheckBox in tagBoxes)
            {
                tagCheckBox.Appearance = Appearance.Button;
                tagCheckBox.TextAlign = ContentAlignment.MiddleCenter;
            }

            ToolStripItemCollection languageItems = languageToolStripMenuItem.DropDownItems;

            foreach (ToolStripMenuItem languageItem in languageItems)
            {
                string languageCode = (languageItem.Tag as string);

                if (languageCode != null)
                {
                    languageItem.Checked = false;

                    if (languageCode == CultureInfo.CurrentCulture.TwoLetterISOLanguageName)
                    {
                        languageItem.Checked = true;
                    }
                }
            }

            UpdatePictureGrid();
        }

        void CheckForUpdates()
        {
            var latestRelease = AutoUpdater.CheckForUpdates();

            if (latestRelease != null)
            {
                string currentDir = AppDomain.CurrentDomain.BaseDirectory;
                string oldVersionDir = Path.Combine(currentDir, "PhotoNostalgia_old");
                string newVersionPath = Path.Combine(currentDir, $"PhotoNostalgia_v{latestRelease.TagName}.exe");

                //TODO: Localize.
                DialogResult updatePrompt = MessageBox.Show(
                    //new ResourceManager.GetString("hi"),
                    "A new update is available! Would you like to download it?",
                    "Update Available",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (updatePrompt == DialogResult.Yes)
                {
                    string updatePath = AutoUpdater.DownloadLatestUpdate();

                    if (!string.IsNullOrEmpty(updatePath))
                    {
                        if (!Directory.Exists(oldVersionDir))
                        {
                            Directory.CreateDirectory(oldVersionDir);
                        }

                        foreach (string file in Directory.GetFiles(currentDir))
                        {
                            string fileName = Path.GetFileName(file);
                            string destFile = Path.Combine(oldVersionDir, fileName);

                            if (File.Exists(destFile))
                            {
                                File.Delete(destFile);
                            }

                            File.Move(file, destFile);
                        }

                        foreach (string file in Directory.GetFiles(updatePath))
                        {
                            string fileName = Path.GetFileName(file);
                            string destFile = Path.Combine(currentDir, fileName);
                            File.Move(file, destFile);
                        }

                        Process.Start(Path.Combine(currentDir, "PhotoNostalgia.exe"));
                        Application.Exit();
                    }
                    else
                    {
                        //TODO: Localize.
                        MessageBox.Show("Failed to download the update.",
                            "Update Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                CheckForDatabaseUpdate();
            }
        }

        PhotoNostalgiaSettings LoadSettings()
        {
            PhotoNostalgiaSettings settings;

            if (File.Exists(SettingsPath))
            {
                string data = File.ReadAllText(SettingsPath);
                settings = JsonConvert.DeserializeObject<PhotoNostalgiaSettings>(data);
            }
            else
            {
                settings = new PhotoNostalgiaSettings();
            }

            photoPath = settings.FastFotoPath;
            checkForUpdates = settings.CheckForUpdatesOnStart;

            CultureInfo.CurrentCulture = new CultureInfo(settings.Language);
            CultureInfo.CurrentUICulture = new CultureInfo(settings.Language);

            return settings;
        }

        void SaveSettings()
        {
            PhotoNostalgiaSettings settings = new PhotoNostalgiaSettings();

            settings.Version = 1;
            settings.FastFotoPath = photoPath;
            settings.CheckForUpdatesOnStart = checkForUpdates;
            settings.Language = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

            File.WriteAllText(SettingsPath, JsonConvert.SerializeObject(settings));
        }

        void CheckForDatabaseUpdate()
        {
            string workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string latestDatabaseFile = AutoUpdater.DownloadDatabaseUpdate();

            if (string.IsNullOrEmpty(latestDatabaseFile))
            {
                //TODO: Localize.
                MessageBox.Show("Database failed updating!",
                    "Update Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            if (((sender as PictureBox).Tag as string) == "[IGNORE]")
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
                    if (!TagDatabase.ContainsKey(Path.GetFileName(photo)))
                    {
                        continue;
                    }
                    string[] imageTags = TagDatabase[Path.GetFileName(photo)];
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
                    if (!TagDatabase.ContainsKey(Path.GetFileName(photo)))
                    {
                        continue;
                    }
                    string[] imageTags = TagDatabase[Path.GetFileName(photo)];
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
            string json = JsonConvert.SerializeObject(TagDatabase, Formatting.Indented);
            File.WriteAllText(DatabaseLocation, json);
        }

        public static void BackupDatabase()
        {
            string json = JsonConvert.SerializeObject(TagDatabase, Formatting.Indented);
            File.WriteAllText(DatabaseBackupLocation, json);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveDatabase();
            BackupDatabase();
            SaveSettings();
        }

        private void SetCulture(string cultureCode)
        {
            CultureInfo culture = new CultureInfo(cultureCode);

            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;

            SaveSettings();
            Close();

            Process.Start(Application.ExecutablePath, "-forceSkipUpdateCheck");
        }

        private void languageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (sender as ToolStripMenuItem);

            if (menuItem.Tag != null)
            {
                SetCulture(menuItem.Tag.ToString());
            }
        }

        private void aboutButton1_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItem3.Checked == false)
            {
                if (aboutWindow == null)
                {
                    aboutWindow = new About();
                    aboutWindow.Show(this);
                    toolStripMenuItem3.Checked = true;
                }
            }
            else
            {
                aboutWindow.Close();
                aboutWindow = null;
                toolStripMenuItem3.Checked = false;
            }
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkForUpdates == true)
            {
                checkForUpdatesToolStripMenuItem.Checked = false;
                checkForUpdates = false;
            }
            else
            {
                checkForUpdatesToolStripMenuItem.Checked = true;
                checkForUpdates = true;
            }
            SaveSettings();
        }

        private void checkForUpdatesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CheckForUpdates();
        }
    }
}
