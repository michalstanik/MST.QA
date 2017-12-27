namespace MST.WPFApp.Infrastructure.Interfaces
{
    public interface IGlobalConfigService
    {
        object Get(string SettingName);
        void Update(string SettingName, object value);
    }
}