﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ookii.Dialogs.WinForms;
using PhotoNostalgia.Classes;
using PhotoNostalgia.Properties;
using System.Diagnostics;
using System.Globalization;
using System.Resources;

#pragma warning disable CS8600
#pragma warning disable CS8601
#pragma warning disable CS8602
#pragma warning disable CS8603
#pragma warning disable CS8604
#pragma warning disable CS8622

namespace PhotoNostalgia.Forms
{
    public partial class MainForm : Form
    {
        private static MainForm? _instance;

        public MainForm()
        {
            resourceManager = new ResourceManager("PhotoNostalgia.Forms.MainForm", typeof(Program).Assembly);
            InitializeComponent();
        }

        public static MainForm Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new MainForm();
                }
                return _instance;
            }
        }

        public static readonly string SettingsPath = Environment.CurrentDirectory + "\\settings.json";

        public static readonly string DatabaseLocation = Environment.CurrentDirectory + "\\database.json";
        public static readonly string DatabaseBackupLocation = Environment.CurrentDirectory + "\\database_backup.json";

        public static Dictionary<string, string[]> TagDatabase = [];

        VistaFolderBrowserDialog? fbd;
        About? aboutWindow;
        private readonly List<PictureViewer> pictureViewers = [];

        bool checkForUpdates = true;
        string? photoPath;

        int offset = 0;
        int page = 1;

        int totalPhotos;
        int totalPages;
        int totalOffset;

        List<string> validTags = [];
        List<string> selectedTags = [];

        List<string> photoPaths = [];
        List<string> currentPhotos = [];

        List<CheckBox> tagBoxes = [];

        public ResourceManager resourceManager;

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();

            PhotoNostalgiaSettings settings = LoadSettings();

            if (settings.CheckForUpdatesOnStart && !args.Contains("-forceSkipUpdateCheck"))
            {
                TryUpdate();
            }

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
                    Application.Exit();
                    return;
                }

                while (true)
                {
                    fbd = new VistaFolderBrowserDialog
                    {
                        Description = "Please select the \"FastFoto\" folder.",
                        UseDescriptionForTitle = true
                    };
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

            if (File.Exists(DatabaseLocation))
            {
                string data = File.ReadAllText(DatabaseLocation);
                TagDatabase = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(data);
            }

            ToolStripItemCollection languageItems = languageToolStripMenuItem.DropDownItems;

            foreach (ToolStripMenuItem languageItem in languageItems)
            {
                string? languageCode = languageItem.Tag as string;

                if (!String.IsNullOrEmpty(languageCode))
                {
                    languageItem.Checked = false;

                    if (languageCode == CultureInfo.CurrentCulture.TwoLetterISOLanguageName)
                    {
                        languageItem.Checked = true;
                    }
                }
            }

            checkForUpdatesToolStripMenuItem.Checked = settings.CheckForUpdatesOnStart;

            UpdateTagButtons();
            UpdatePictureGrid();
        }

        private async void TryUpdate()
        {
            if (await AutoUpdater.Update())
            {
                Restart();
            }
        }

        public void Restart()
        {
            Close();
            Process.Start(Application.ExecutablePath, "-forceSkipUpdateCheck");
            Application.Exit();
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

        public void LoadDatabase()
        {
            string data = File.ReadAllText(DatabaseLocation);
            TagDatabase = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(data);
        }

        private void PictureBox_DoubleClick(object sender, EventArgs e)
        {
            if ((sender as PictureBox).Tag as string == "[IGNORE]")
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
            viewer.PictureViewer_LoadImage((sender as PictureBox).ImageLocation);
            viewer.Show(this);
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (sender as PictureBox);
            string tag = (pictureBox.Tag as string);

            if (!String.IsNullOrEmpty(tag))
            {
                if (File.Exists(tag))
                {
                    pictureBox.Image = Resources.PlaceholderImage;
                    pictureBox.ImageLocation = "file:///" + tag;
                }
            }
        }

        private void PictureBox_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                PictureBox pictureBox = (sender as PictureBox);
                pictureBox.Tag = pictureBox.ImageLocation;
                pictureBox.Image = Resources.FailedLoading;
            }
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
            string jsonText;

            if (!File.Exists(DatabaseLocation))
            {
                jsonText = "{}";
            }
            else
            {
                jsonText = File.ReadAllText(DatabaseLocation);
            }

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
                tagButton.MaximumSize = new Size(99999, 25);
                tagButton.TextAlign = ContentAlignment.MiddleCenter;
                tagButton.Appearance = Appearance.Button;
                tagButton.Click += TagButton_Click;
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

        private void FirstPageButton1_Click(object sender, EventArgs e)
        {
            offset = 0;
            UpdatePictureGrid();
        }

        private void LastPageButton1_Click(object sender, EventArgs e)
        {
            offset = totalOffset - 6;
            UpdatePictureGrid();
        }

        private void PrevPageButton1_Click(object sender, EventArgs e)
        {
            if (offset > 0)
            {
                offset -= 6;
            }
            UpdatePictureGrid();
        }

        private void NextPageButton1_Click(object sender, EventArgs e)
        {
            if (offset < totalOffset - 6)
            {
                offset += 6;
            }
            UpdatePictureGrid();
        }

        private void SelectNumeric1_ValueChanged(object sender, EventArgs e)
        {
            page = (int)selectNumeric1.Value - 1;
            offset = page * 6;
            UpdatePictureGrid();
        }

        private void TagButton_Click(object sender, EventArgs e)
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
            string json = JsonConvert.SerializeObject(TagDatabase, Formatting.Indented);
            if (json == "{}" && File.Exists(DatabaseLocation))
            {
                json = File.ReadAllText(DatabaseLocation);
            }
            File.WriteAllText(DatabaseLocation, json);
        }

        public static void BackupDatabase()
        {
            string json = JsonConvert.SerializeObject(TagDatabase, Formatting.Indented);
            if (json == "{}" && File.Exists(DatabaseLocation))
            {
                json = File.ReadAllText(DatabaseLocation);
            }
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
            Restart();
        }

        private void LanguageToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void AboutButton1_Click(object sender, EventArgs e)
        {
            if (aboutToolStripMenuItem.Checked == false)
            {
                aboutWindow = new About();
                aboutWindow.FormClosed += AboutWindow_FormClosed;
                aboutWindow.Show(this);
                aboutToolStripMenuItem.Checked = true;
            }
            else
            {
                aboutWindow.Close();
                aboutWindow = null;
                aboutToolStripMenuItem.Checked = false;
            }
        }

        public void AboutBoxClosed()
        {
            if (aboutWindow != null)
            {
                aboutWindow.Close();
                aboutWindow = null;
            }
            aboutToolStripMenuItem.Checked = false;
        }

        private void AboutWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            aboutWindow = null;
            aboutToolStripMenuItem.Checked = false;
        }

        private void CheckForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void CheckForUpdatesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TryUpdate();
        }

        private void CloseAllPictureViewersToolStripMenuItem_Click(object sender, EventArgs e)
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
