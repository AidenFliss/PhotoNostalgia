using Newtonsoft.Json;

namespace PhotoNostalgia.Classes
{
    public class PhotoNostalgiaVersion
    {
        public string Version { get; set; }

        public string DBVersion { get; set; }

        public string Description { get; set; }

        [JsonConstructor]
        public PhotoNostalgiaVersion()
        {
            Version = "";
            DBVersion = "";
            Description = "";
        }

        public PhotoNostalgiaVersion(string version, string dbVersion, string description)
        {
            Version = version;
            DBVersion = dbVersion;
            Description = description;
        }

        public static PhotoNostalgiaVersion GetCurrent() => new PhotoNostalgiaVersion("v2024.10.30", "v1.0", "");
    }
}
