using Client.Models;
using System.Text.Json;

namespace Client.Services 
{
    public class SettingsService
    {
        private string path = ".\\settings.json";
        public SettingsService()
        {
            if(!File.Exists(path)) 
            {
                var settings = new Settings
                {
                    Path = "",
                    M = 0
                };
                string json = JsonSerializer.Serialize(settings);
                File.WriteAllText(path, json); 
            }
        }

        public Settings GetSettings()
        {
            string json = File.ReadAllText(path);
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

        public void SetSettings(string path, int m)
        {
            
        } 

    }

}