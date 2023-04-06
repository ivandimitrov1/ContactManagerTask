namespace ContactManager.Infrastructure.Data
{
    public class DatabaseOptions
    {
        public static string DefaultKey { get; } = "Database";

        public string ConnectionString { get; set; }
    }
}
