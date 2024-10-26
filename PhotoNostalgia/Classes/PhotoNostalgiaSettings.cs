using Newtonsoft.Json;

namespace PhotoNostalgia.Classes
{
    public class PhotoNostalgiaSettings
    {
        public int Version { get; set; }

        public string FastFotoPath { get; set; }

        public bool CheckForUpdatesOnStart { get; set; }

        public string Language { get; set; }

        [JsonConstructor]
        public PhotoNostalgiaSettings()
        {
            Version = 1;
            FastFotoPath = null;
            CheckForUpdatesOnStart = true;
            Language = "en";
        }
    }
}
