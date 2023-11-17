namespace KaganWebApi
{
    public interface IDBSettings
    {
        string ConnectionString { get; set; }
        string CollectionName { get; set; }
        string DatabaseName { get; set; }

    }
}
