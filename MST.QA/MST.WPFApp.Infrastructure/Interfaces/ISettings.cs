namespace MST.WPFApp.Infrastructure.Interfaces
{
    public interface ISettings
    {
        object this[string propertyName] { get; set; }

        void Save();
    }
}
