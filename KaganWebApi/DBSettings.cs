namespace KaganWebApi
{
    public class DBSettings : IDBSettings
    {
        public string ConnectionString { get; set; }
        public string CollectionName { get; set; }
        public string DatabaseName { get; set; }
    }
}
