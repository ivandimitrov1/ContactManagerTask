namespace ContactManager.Infrastructure.Messaging.Consumer
{
    public interface IMessageConsumerService : IDisposable
    {
        Task StartAsync(CancellationToken cancellationToken);

        void Stop();
    }
}
