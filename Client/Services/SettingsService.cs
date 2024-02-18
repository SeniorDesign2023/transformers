using Client.Models;
using System.Text.Json;

namespace Client.Services 
{
    public class SettingsService
    {
        private readonly string settingsFile = ".\\settings.json";
        public SettingsService()
        {
            if(!File.Exists(settingsFile)) 
            {
                var settings = new Settings
                {
                    Path = ".\\",
                    M = 1
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

        public void SetSettings(string path = ".\\", int m = 1)
        {
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