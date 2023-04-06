namespace ContactManager.Infrastructure.Messaging
{
    public class MessagingOptions
    {
        public static string DefaultKey { get; } = "Messaging";

        public string ConnectionString { get; set; }
        public string ExchangeKey { get; set; } = "contact_manager_exchange";
    }
}
