using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Resources;
using System.Net.Http;
using Newtonsoft.Json;

namespace PhotoNostalgia.Classes
{
    public static class AutoUpdater
    {
        public static async Task<bool> Update()
        {
            var resourceManager = new ResourceManager("PhotoNostalgia.Forms.Form1", typeof(Program).Assembly);

            try
            {
                string versionInfoUrl = "https://raw.githubusercontent.com/AidenFliss/PhotoNostalgia/master/PhotoNostalgia/Resources/PhotoNostalgiaVersion.json";

                var client = new HttpClient();
                string updatedJson = await client.GetStringAsync(versionInfoUrl);
                var updatedVersion = JsonConvert.DeserializeObject<PhotoNostalgiaVersion>(updatedJson);
                var oldVersion = PhotoNostalgiaVersion.GetCurrent();

                if (updatedVersion == null)
                {
                    return false;
                }

                if (oldVersion.Version == updatedVersion.Version)
                {
                    if (await UpdateDB())
                    {
                        MessageBox.Show(
                            resourceManager.GetString("databaseSuccess"),
                            resourceManager.GetString("databaseSuccessTitle"),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    return false;
                }

                string messageText = $"{resourceManager.GetString("updateAvalible")}" +
                    $"{resourceManager.GetString("programName")} {updatedVersion.Version}." +
                    $"\n\n{updatedVersion.Description}\n\n{resourceManager.GetString("downloadPrompt")}";

                DialogResult result = MessageBox.Show(
                    messageText,
                    resourceManager.GetString("updateAvalibleTitle"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    string updatedFileName = $"PhotoNostalgia_{updatedVersion.Version}.zip";
                    string updatedUrl = $"https://github.com/AidenFliss/PhotoNostalgia/releases/download/{updatedVersion.Version}/{updatedFileName}";

                    var tempDir = Path.Combine(Application.StartupPath, "temp");
                    if (!Directory.Exists(tempDir))
                    {
                        Directory.CreateDirectory(tempDir);
                    }

                    string updatedZipFilePath = Path.Combine(tempDir, updatedFileName);

                    using (var zipFileStream = await client.GetStreamAsync(updatedUrl))
                    using (var writer = new BinaryWriter(new FileStream(updatedZipFilePath, FileMode.Create)))
                        zipFileStream.CopyTo(writer.BaseStream);

                    var oldDirPath = Path.Combine(Application.StartupPath, "PhotoNostalgia_old");
                    if (!Directory.Exists(oldDirPath))
                    {
                        Directory.CreateDirectory(oldDirPath);
                    }

                    var fileNames = new string[]
                    {
                        "PhotoNostalgia.exe",
                        "Ookii.Dialogs.WinForms.dll",
                    };

                    foreach (var file in fileNames)
                    {
                        var oldFilePath = Path.Combine(oldDirPath, file);
                        if (File.Exists(oldFilePath))
                        {
                            File.Move(oldFilePath, Path.Combine(oldDirPath, file));
                        }
                    }

                    ZipFile.ExtractToDirectory(updatedZipFilePath, Application.StartupPath);

                    File.Delete(updatedZipFilePath);
                    Directory.Delete(tempDir);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    resourceManager.GetString("failUpdate") + " " + ex.Message,
                    resourceManager.GetString("failUpdateTitle"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return false;
        }

        public static async Task<bool> UpdateDB()
        {
            var resourceManager = new ResourceManager("PhotoNostalgia.Forms.Form1", typeof(Program).Assembly);

            try
            {
                string versionInfoUrl = "https://raw.githubusercontent.com/AidenFliss/PhotoNostalgia/master/PhotoNostalgia/Resources/PhotoNostalgiaVersion.json";

                var client = new HttpClient();
                string updatedJson = await client.GetStringAsync(versionInfoUrl);
                var updatedVersion = JsonConvert.DeserializeObject<PhotoNostalgiaVersion>(updatedJson);
                var oldVersion = PhotoNostalgiaVersion.GetCurrent();

                if (updatedVersion == null || oldVersion.DBVersion == updatedVersion.DBVersion)
                {
                    return false;
                }

                string updatedFileName = "database.json";
                string updatedUrl = $"https://github.com/AidenFliss/PhotoNostalgiaDatabase/releases/download/{updatedVersion.DBVersion}/{updatedFileName}";

                string updatedFilePath = Path.Combine(Application.StartupPath, updatedFileName);

                File.Delete(Path.Combine(Application.StartupPath, "databse.json"));

                using (var fileStream = await client.GetStreamAsync(updatedUrl))
                using (var writer = new BinaryWriter(new FileStream(updatedFilePath, FileMode.Create)))
                    fileStream.CopyTo(writer.BaseStream);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    resourceManager.GetString("databaseFail") + " " + ex.Message,
                    resourceManager.GetString("databaseFailTitle"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return false;
        }
    }
}
