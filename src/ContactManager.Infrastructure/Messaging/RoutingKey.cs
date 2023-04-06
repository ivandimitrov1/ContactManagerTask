namespace ContactManager.Infrastructure.Messaging
{
    public static class RoutingKey
    {
        public const string ContactChange = "contact.change";
        public const string ContactDelete = "contact.delete";

        public static List<string> ContactKeys = new List<string>()
        {
            ContactChange,
            ContactDelete,
        };
    }
}
