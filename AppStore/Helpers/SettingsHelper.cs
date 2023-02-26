using Newtonsoft.Json;
using AppStore.Interfaces;

namespace AppStore.Helpers
{
    public class SettingsHelper : ISettingsHelper
    {
        private string _settingsPath;
        private Dictionary<string, string> _settings;
        public SettingsHelper(string settingsPath)
        {
            if (!Directory.Exists(settingsPath))
            {
                Directory.CreateDirectory(settingsPath);
            }
            if (!File.Exists(Path.Combine(settingsPath, "settings.json")))
            {
                File.Create(Path.Combine(settingsPath, "settings.json"));
                _settings = new Dictionary<string, string>();
                File.WriteAllText(Path.Combine(settingsPath, "settings.json"), JsonConvert.SerializeObject(_settings));
            }
            _settingsPath = settingsPath;
            _settings = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(Path.Combine(settingsPath, "settings.json")!)!)!;

        }
        public string GetProperty(string name)
        {
            if(_settings.ContainsKey(name))
            {
                return _settings[name];
            }
            else
            {
                throw new KeyNotFoundException("Property not found");
            }
        }

        public void RemoveProperty(string name)
        {
            if (_settings.ContainsKey(name))
            {
                _settings.Remove(name);
                File.WriteAllText(Path.Combine(_settingsPath, "settings.json"), JsonConvert.SerializeObject(_settings));
            }
            else
            {
                throw new KeyNotFoundException("Property not found");
            }
        }

        public void SetProperty(string name, string value)
        {
            if (_settings.ContainsKey(name))
            {
                _settings[name] = value;
            }
            else
            {
                _settings.Add(name, value);
            }
            File.WriteAllText(Path.Combine(_settingsPath, "settings.json"), JsonConvert.SerializeObject(_settings));
        }
    }
}
