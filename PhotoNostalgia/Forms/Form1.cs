using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Resources;
using System.Diagnostics;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Generic;
using PhotoNostalgia.Properties;
using PhotoNostalgia.Classes;
using Ookii.Dialogs.WinForms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Octokit;

namespace PhotoNostalgia.Forms
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
        About aboutWindow = null;

        List<PictureViewer> pictureViewers = new List<PictureViewer>();

        bool checkForUpdates = true;
        string photoPath;

        int offset = 0;
        int page = 1;

        int totalPhotos;
        int totalPages;
        int totalOffset;

        static bool saving = false;

        List<string> validTags = new List<string>();
        List<string> selectedTags = new List<string>();

        List<string> photoPaths = new List<string>();
        List<string> currentPhotos = new List<string>();

        List<CheckBox> tagBoxes = new List<CheckBox>();

        public ResourceManager resourceManager;

        private void Form1_Load(object sender, EventArgs e)
        {
            if (photoPath == null || !Directory.Exists(photoPath))
            {
                DialogResult result = MessageBox.Show(
                    resourceManager.GetString("selectFolder"),
                    resourceManager.GetString("selectFolderTitle"),
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Cancel)
                {
                    System.Windows.Forms.Application.Exit();
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
                        DialogResult result2 = MessageBox.Show(
                            resourceManager.GetString("invalidPath"),
                            resourceManager.GetString("invalidPathTitle"),
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Error);
                        if (result2 == DialogResult.Cancel)
                        {
                            System.Windows.Forms.Application.Exit();
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

            ToolStripItemCollection languageItems = languageToolStripMenuItem.DropDownItems;

            foreach (ToolStripMenuItem languageItem in languageItems)
            {
                string languageCode = (languageItem.Tag as string);

                if (!String.IsNullOrEmpty(languageCode))
                {
                    languageItem.Checked = false;

                    if (languageCode == CultureInfo.CurrentCulture.TwoLetterISOLanguageName)
                    {
                        languageItem.Checked = true;
                    }
                }
            }

            resourceManager = new ResourceManager("PhotoNostalgia.Forms.Form1", typeof(Program).Assembly);

            UpdateTagButtons();
            UpdatePictureGrid();
        }

        void CheckForUpdates()
        {
            Release latestRelease = AutoUpdater.CheckForUpdates();

            if (latestRelease != null)
            {
                string currentDir = AppDomain.CurrentDomain.BaseDirectory;
                string oldVersionDir = Path.Combine(currentDir, "PhotoNostalgia_old");

                DialogResult updatePrompt = MessageBox.Show(
                    resourceManager.GetString("updateAvalible"),
                    resourceManager.GetString("updateAvalibleTitle"),
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
                        System.Windows.Forms.Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show(
                            resourceManager.GetString("failUpdate"),
                            resourceManager.GetString("failUpdateTitle"),
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
            if (saving)
            {
                return;
            }
            saving = true;
            PhotoNostalgiaSettings settings = new PhotoNostalgiaSettings();

            settings.Version = 1;
            settings.FastFotoPath = photoPath;
            settings.CheckForUpdatesOnStart = checkForUpdates;
            settings.Language = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

            File.WriteAllText(SettingsPath, JsonConvert.SerializeObject(settings));
            saving = false;
        }

        void CheckForDatabaseUpdate()
        {
            string workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string latestDatabaseFile = AutoUpdater.DownloadDatabaseUpdate();

            if (string.IsNullOrEmpty(latestDatabaseFile))
            {
                MessageBox.Show(
                    resourceManager.GetString("databaseFail"),
                    resourceManager.GetString("databaseFailTitle"),
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
            /*
            foreach (PictureViewer view in pictureViewers)
            {
                if (view.pictureDisplay1.ImageLocation == (sender as PictureBox).ImageLocation)
                {
                    return;
                }
            }
            */
            PictureViewer viewer = new PictureViewer();
            pictureViewers.Add(viewer);
            viewer.PictureViewer_LoadImage((sender as PictureBox).ImageLocation, this);
            viewer.Show(this);
        }

        public void NullifyPictureViewer(PictureViewer viewer)
        {
            if (viewer != null)
            {
                pictureViewers.Remove(viewer);
            }
        }

        public void UpdateTagButtons()
        {
            string jsonText = File.ReadAllText(DatabaseLocation);
            JObject data = JsonConvert.DeserializeObject<JObject>(jsonText);

            HashSet<string> uniqueValues = new HashSet<string>();

            foreach (CheckBox checkBox in tagBoxes)
            {
                checkBox.Dispose();
            }

            flowLayoutPanel1.Controls.Clear();

            validTags.Clear();

            foreach (var entry in data)
            {
                var values = entry.Value as JArray;
                if (values != null)
                {
                    foreach (var value in values)
                    {
                        uniqueValues.Add(value.ToString());
                    }
                }
            }

            validTags = new List<string>(uniqueValues);
            validTags.Sort((x, y) =>
            {
                bool isXNumeric = int.TryParse(x, out int numX);
                bool isYNumeric = int.TryParse(y, out int numY);

                if (isXNumeric && isYNumeric)
                    return numX.CompareTo(numY);

                if (isXNumeric) return -1;
                if (isYNumeric) return 1;

                return x.CompareTo(y);
            });

            foreach (string tag in validTags)
            {
                CheckBox tagButton = new CheckBox();
                tagButton.Text = tag;
                tagButton.Tag = tag;
                tagButton.AutoSize = true;
                tagButton.Font = new Font("Microsoft Sans Serif", 7F);
                tagButton.MaximumSize = new Size(99999, 20);
                tagButton.TextAlign = ContentAlignment.MiddleCenter;
                tagButton.Appearance = Appearance.Button;
                tagButton.Click += tagButton_Click;
                flowLayoutPanel1.Controls.Add(tagButton);
            }

            noTagsFoundLabel1.Visible = validTags.Count == 0;
        }

        void UpdatePictureGrid()
        {
            PictureBox[] photoBoxes = { photoBox1, photoBox2, photoBox3, photoBox4, photoBox5, photoBox6 };
            int photoCount = currentPhotos.Count;

            for (int i = 0; i < photoBoxes.Length; i++)
            {
                int photoIndex = offset + i;

                if (photoIndex < photoCount)
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

            totalPhotos = photoCount;
            totalPages = (int)Math.Ceiling(totalPhotos / 6.0);
            totalOffset = totalPages * 6;
            page = (offset / 6);

            maxPagesLabel1.Text = "/ " + totalPages;
            selectNumeric1.Maximum = totalPages;
            selectNumeric1.Value = page + 1;

            prevPageButton1.Enabled = offset > 0;
            firstPageButton1.Enabled = offset > 0;
            nextPageButton1.Enabled = offset < totalOffset - 6;
            lastPageButton1.Enabled = offset < totalOffset - 6;
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
            string tag = (tagClicked.Tag as string);

            if (tagClicked.Checked)
            {
                selectedTags.Add(tag);
            }
            else
            {
                selectedTags.Remove(tag);
            }

            currentPhotos.Clear();

            if (selectedTags.Count == 0)
            {
                currentPhotos.AddRange(photoPaths);
                UpdatePictureGrid();
                return;
            }

            HashSet<string> selectedTagSet = new HashSet<string>(selectedTags);

            foreach (string photo in photoPaths)
            {
                string fileName = Path.GetFileName(photo);

                if (!TagDatabase.ContainsKey(fileName))
                {
                    continue;
                }

                string[] imageTags = TagDatabase[fileName];

                bool intersects = selectedTagSet.All(tg => imageTags.Contains(tg));

                if (intersects)
                {
                    currentPhotos.Add(photo);
                }
            }

            offset = 0;

            UpdatePictureGrid();
        }

        public static void SaveDatabase()
        {
            if (saving == true)
            {
                return;
            }
            saving = true;
            string json = JsonConvert.SerializeObject(TagDatabase, Formatting.Indented);
            File.WriteAllText(DatabaseLocation, json);
            saving = false;
        }

        public static void BackupDatabase()
        {
            if (saving == true)
            {
                return;
            }
            saving = true;
            string json = JsonConvert.SerializeObject(TagDatabase, Formatting.Indented);
            File.WriteAllText(DatabaseBackupLocation, json);
            saving = false;
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

            Process.Start(System.Windows.Forms.Application.ExecutablePath, "-forceSkipUpdateCheck");
        }

        private void languageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (sender as ToolStripMenuItem);

            if (menuItem.Checked == true)
            {
                return;
            }

            if (!String.IsNullOrEmpty(menuItem.Tag as string))
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

        private void closeAllPictureViewersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (PictureViewer pictureViewer in pictureViewers)
            {
                pictureViewer.shouldRemoveSelf = false;
                pictureViewer.Close();
                pictureViewer.Dispose();
            }
            pictureViewers.Clear();
        }
    }
}
