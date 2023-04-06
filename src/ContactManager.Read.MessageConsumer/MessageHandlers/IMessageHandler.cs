namespace ContactManager.Read.MessageConsumer.MessageHandlers
{
    public interface IMessageHandler<T> where T : class
    {
        public string RoutingKey { get; set; }

        public void HandleMessage(T message);
    }
}
