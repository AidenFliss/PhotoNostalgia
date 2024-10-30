using System.IO.Compression;
using System.Resources;
using Newtonsoft.Json;
using PhotoNostalgia.Forms;

#pragma warning disable CS8602

namespace PhotoNostalgia.Classes
{
    public static class AutoUpdater
    {
        public static async Task<bool> Update()
        {
            var resourceManager = new ResourceManager("PhotoNostalgia.Forms.MainForm", typeof(Program).Assembly);

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
                    MessageBox.Show(
                        resourceManager.GetString("appUpToDate"),
                        resourceManager.GetString("appUpToDateTitle"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    if (await UpdateDB())
                    {
                        MessageBox.Show(
                            resourceManager.GetString("databaseSuccess"),
                            resourceManager.GetString("databaseSuccessTitle"),
                            MessageBoxButtons.OK,
                          MessageBoxIcon.Information);

                        MainForm.Instance.Restart();
                    }

                    return false;
                }

                string messageText = $"{resourceManager.GetString("updateAvalible")} " +
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

                    using var zipFileStream = await client.GetStreamAsync(updatedUrl);
                    using var outputStream = new FileStream(updatedZipFilePath, FileMode.Create, FileAccess.Write, FileShare.None);
                    
                    await zipFileStream.CopyToAsync(outputStream);
                    
                    var oldDirPath = Path.Combine(Application.StartupPath, "PhotoNostalgia_old");
                    if (!Directory.Exists(oldDirPath))
                    {
                        Directory.CreateDirectory(oldDirPath);
                    }

                    var fileNames = new string[]
                    {
                        "PhotoNostalgia.deps.json",
                        "PhotoNostalgia.dll",
                        "PhotoNostalgia.exe",
                        "PhotoNostalgia.pdb",
                        "PhotoNostalgia.runtimeconfig.json",
                        "Ookii.Dialogs.WinForms.dll",
                        "Newtonsoft.Json.dll"
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

            if (Directory.Exists(Path.Combine(Application.StartupPath, "temp")))
            {
                Directory.Delete(Path.Combine(Application.StartupPath, "temp"), true);
            }

            if (await UpdateDB())
            {
                MessageBox.Show(
                    resourceManager.GetString("databaseSuccess"),
                    resourceManager.GetString("databaseSuccessTitle"),
                    MessageBoxButtons.OK,
                  MessageBoxIcon.Information);

                MainForm.Instance.Restart();
            }
            
            return false;
        }

        public static async Task<bool> UpdateDB()
        {
            var resourceManager = new ResourceManager("PhotoNostalgia.Forms.MainForm", typeof(Program).Assembly);

            try
            {
                string versionInfoUrl = "https://raw.githubusercontent.com/AidenFliss/PhotoNostalgiaDatabase/master/PhotoNostalgiaDBVersion.json";

                var client = new HttpClient();
                string updatedJson = await client.GetStringAsync(versionInfoUrl);
                var updatedVersion = JsonConvert.DeserializeObject<PhotoNostalgiaVersion>(updatedJson);
                var oldVersion = PhotoNostalgiaVersion.GetCurrent();

                if (updatedVersion == null || oldVersion.DBVersion == updatedVersion.DBVersion
                    && File.Exists(MainForm.DatabaseLocation))
                {
                    MessageBox.Show(
                        resourceManager.GetString("databaseUpToDate"),
                        resourceManager.GetString("databaseUpToDateTitle"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return false;
                }

                string updatedUrl = $"https://github.com/AidenFliss/PhotoNostalgiaDatabase/releases/download/{updatedVersion.DBVersion}/database.json";

                string updatedFilePath = Path.Combine(Application.StartupPath, "database.json");

                if (File.Exists(updatedFilePath))
                    File.Delete(updatedFilePath);

                using var fileStream = await client.GetStreamAsync(updatedUrl);
                using var outputStream = new FileStream(updatedFilePath, FileMode.Create, FileAccess.Write, FileShare.None);

                await fileStream.CopyToAsync(outputStream);

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
