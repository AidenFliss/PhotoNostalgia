using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Octokit;
using System.IO.Compression;
using System.Runtime.InteropServices.WindowsRuntime; // Ensure this is added for ZipFile functionality

namespace PhotoNostalgia
{
    internal class AutoUpdater
    {
        private static readonly string owner = "AidenFliss"; // GitHub repo owner
        private static readonly string repoName = "PhotoNostalgia"; // GitHub repo name for the main app
        private static readonly string dbRepoName = "PhotoNostalgiaDatabase"; // Repo for the database.json file
        private static readonly string oldVersionFolder = "PhotoNostalgia_old"; // Folder for old versions
        private static readonly string workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly DateTime currentVersion = new DateTime(2024, 10, 19); // Update as needed for releases

        private static GitHubClient githubClient = new GitHubClient(new ProductHeaderValue("PhotoNostalgiaUpdater"));

        // Wrapper for the non-async check for updates
        public static Release CheckForUpdates()
        {
            var task = Task.Run(() => CheckForUpdatesAsync());
            task.Wait();
            return task.Result;
        }

        // Wrapper for the non-async download update
        public static string DownloadLatestUpdate()
        {
            var task = Task.Run(() => DownloadLatestUpdateAsync());
            task.Wait();
            return task.Result;
        }

        public static string DownloadDatabaseUpdate()
        {
            var task = Task.Run(() => DownloadDatabaseUpdateAsync());
            task.Wait();
            return task.Result;
        }

        // Main method to check both app and database updates
        public static async Task CheckAndUpdateAppAndDatabaseAsync()
        {
            // Check for main app update
            var appUpdateResult = await CheckForUpdatesAsync();
            if (appUpdateResult != null)
            {
                // Ask the user to download and install the app update
                string updateFilePath = await DownloadLatestUpdateAsync();
                if (!string.IsNullOrEmpty(updateFilePath))
                {
                    InstallUpdate(updateFilePath); // Install the main app update
                    return; // If app was updated, no need to check the database
                }
            }
            else
            {
                MessageBox.Show("No app updates available.", "No App Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // If no app update, check for database update
            var dbUpdateResult = await DownloadDatabaseUpdateAsync();
            if (dbUpdateResult != null)
            {
                MessageBox.Show("Database updated successfully.", "Database Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No database updates available.", "No Database Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Check for app updates
        public static async Task<Release> CheckForUpdatesAsync()
        {
            try
            {
                var releases = await githubClient.Repository.Release.GetAll(owner, repoName);
                var latestRelease = releases[0]; // Get the latest release

                DateTime latestReleaseDate = latestRelease.CreatedAt.DateTime;

                if (currentVersion < latestReleaseDate)
                {
                    return latestRelease; // Return the latest release if it's newer
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking for updates: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null; // No new updates
        }

        // Download the latest app update
        public static async Task<string> DownloadLatestUpdateAsync()
        {
            try
            {
                Release latestRelease = await CheckForUpdatesAsync();
                if (latestRelease != null)
                {
                    var asset = latestRelease.Assets.FirstOrDefault(a => a.Name == "PhotoNostalgia.zip"); // Look for the .zip asset
                    if (asset == null)
                    {
                        MessageBox.Show("No update ZIP file found in the latest release.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }

                    string downloadUrl = asset.BrowserDownloadUrl;
                    string updateFilePath = Path.Combine(workingDirectory, $"PhotoNostalgia_v{latestRelease.TagName}_update.zip");

                    // Check if the update has already been downloaded
                    if (File.Exists(updateFilePath))
                    {
                        DialogResult existingUpdatePrompt = MessageBox.Show(
                            $"The new version ({latestRelease.TagName}) has already been downloaded! Would you like to launch it now?",
                            "Update Ready",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (existingUpdatePrompt == DialogResult.Yes)
                        {
                            InstallUpdate(updateFilePath);
                        }
                        return updateFilePath;
                    }

                    using (WebClient webClient = new WebClient())
                    {
                        // Download the update
                        await webClient.DownloadFileTaskAsync(new Uri(downloadUrl), updateFilePath);
                        MessageBox.Show("Update downloaded. Ready to install.", "Update Downloaded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Ask to install the update immediately
                        DialogResult result = MessageBox.Show("Do you want to install the update now?", "Install Update", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            InstallUpdate(updateFilePath);
                        }
                    }

                    return updateFilePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading update: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        // Install the update
        private static void InstallUpdate(string updateFilePath)
        {
            try
            {
                string extractPath = Path.Combine(workingDirectory, "PhotoNostalgia_new");

                // Extract the new version
                if (Directory.Exists(extractPath))
                {
                    Directory.Delete(extractPath, true); // Clean up any existing new version folder
                }

                // Extract ZIP file contents to the new folder
                ZipFile.ExtractToDirectory(updateFilePath, extractPath);

                // Move current version to backup
                string oldVersionPath = Path.Combine(workingDirectory, oldVersionFolder);
                if (Directory.Exists(oldVersionPath))
                {
                    Directory.Delete(oldVersionPath, true); // Clean out old version folder
                }
                Directory.CreateDirectory(oldVersionPath);

                // Move current files to the backup folder
                foreach (var file in Directory.GetFiles(workingDirectory))
                {
                    string fileName = Path.GetFileName(file);

                    if (fileName != "PhotoNostalgia_update.zip" && fileName != oldVersionFolder)
                    {
                        string destination = Path.Combine(oldVersionPath, fileName);
                        File.Move(file, destination);
                    }
                }

                // Move new files to the working directory
                foreach (var file in Directory.GetFiles(extractPath))
                {
                    string fileName = Path.GetFileName(file);
                    string destination = Path.Combine(workingDirectory, fileName);
                    File.Move(file, destination);
                }

                // Clean up
                Directory.Delete(extractPath, true); // Remove the new version folder
                File.Delete(updateFilePath); // Remove the downloaded zip

                MessageBox.Show("Update installed successfully!", "Update Installed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Prompt to launch the new version
                DialogResult launchResult = MessageBox.Show("Do you want to launch the new version?", "Launch Update", MessageBoxButtons.YesNo);
                if (launchResult == DialogResult.Yes)
                {
                    LaunchNewVersion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error installing update: {ex.Message}", "Install Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Launch the newly installed version
        private static void LaunchNewVersion()
        {
            try
            {
                string newExePath = Path.Combine(workingDirectory, "PhotoNostalgia.exe");
                if (File.Exists(newExePath))
                {
                    Process.Start(newExePath);
                    System.Windows.Forms.Application.Exit(); // Fully qualify to avoid ambiguity
                }
                else
                {
                    MessageBox.Show("Failed to launch new version: PhotoNostalgia.exe not found.", "Launch Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error launching new version: {ex.Message}", "Launch Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Download and check the database.json file from the "PhotoNostalgiaDatabase" repository
        public static async Task<string> DownloadDatabaseUpdateAsync()
        {
            try
            {
                var releases = await githubClient.Repository.Release.GetAll(owner, dbRepoName);
                var latestRelease = releases[0]; // Get the latest release for the database

                var asset = latestRelease.Assets.FirstOrDefault(a => a.Name == "database.json");
                if (asset == null)
                {
                    MessageBox.Show("No database.json file found in the latest release.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                // Define paths
                string workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string databaseFilePath = Path.Combine(workingDirectory, "database.json");

                // Get the latest release tag (assuming the release tag is something like 'v1.0.1')
                string latestDbVersionTag = latestRelease.TagName.Replace("v", ""); // Remove 'v' prefix to get the version number

                // Check if the database file already exists
                if (File.Exists(databaseFilePath))
                {
                    // Get the current version from the file's metadata (use the file version or store the version number in the file)
                    string currentDbVersionTag = File.GetLastWriteTime(databaseFilePath).ToString("yyyyMMddHHmmss"); // Use file timestamp as a version stand-in

                    // Compare the current database version with the latest release tag from GitHub
                    if (string.Compare(currentDbVersionTag, latestDbVersionTag) >= 0)
                    {
                        return null; // No need to update if the current version is up-to-date
                    }
                }

                // If an update is needed, download the new database.json
                string latestDatabaseFile = await DownloadDatabaseUpdateAsync();
                if (!string.IsNullOrEmpty(latestDatabaseFile))
                {
                    // Replace the old database file with the new one
                    File.Copy(latestDatabaseFile, databaseFilePath, overwrite: true);
                    MessageBox.Show("Database updated successfully!", "Update Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return databaseFilePath;
                }

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading database.json: {ex.Message}", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
