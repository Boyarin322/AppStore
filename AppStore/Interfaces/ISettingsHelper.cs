namespace AppStore.Interfaces
{
    public interface ISettingsHelper
    {
        public string GetProperty(string name);
        public void SetProperty(string name, string value);
        public void RemoveProperty(string name);
    }
}
