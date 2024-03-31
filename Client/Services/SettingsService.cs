using Client.Models;
using System.Text.Json;

namespace Client.Services 
{
    public class SettingsService
    {
        private readonly string settingsDir = "C:\\temp\\DataFiles";
        private readonly string settingsFile = "C:\\temp\\DataFiles\\settings.json";
        public SettingsService()
        {
            if (!File.Exists(settingsFile))
            {
                if (!Directory.Exists(settingsDir))
                {
                    Directory.CreateDirectory(settingsDir);
                }
                var settings = new Settings
                {
                    Path = "C:\\temp\\DataFiles",
                    M = 5
                };
                string json = JsonSerializer.Serialize(settings);
                File.WriteAllText(settingsFile, json);
            }
        }

        public Settings GetSettings()
        {
            string json = File.ReadAllText(settingsFile);
            return JsonSerializer.Deserialize<Settings>(json);
        }

        public string GetPath()
        {
            var settings = GetSettings();
            return settings.Path;
        }

        public int GetM()
        {
            var settings = GetSettings();
            return settings.M;
        }

        public void SetSettings(string path = null, int m = -1)
        {
            if (string.IsNullOrEmpty(path))
            {
                path = GetPath();
            }

            if (m < 1)
            {
                m = GetM();
            }

            var settings = new Settings
            {
                Path = path,
                M = m
            };
            string json = JsonSerializer.Serialize(settings);
            File.WriteAllText(settingsFile, json); 
        } 

    }

}