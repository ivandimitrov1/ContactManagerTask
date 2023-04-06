namespace ContactManager.Infrastructure.Messaging.Consumer
{
    public interface IMessageProcessor
    {
        IList<string> RoutingKeys { get; }

        Task HandleMessage(string routingKey, byte[] data);
    }
}
