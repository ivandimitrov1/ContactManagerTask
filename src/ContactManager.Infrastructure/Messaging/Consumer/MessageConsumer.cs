using Microsoft.Extensions.Hosting;

namespace ContactManager.Infrastructure.Messaging.Consumer
{
    /// <summary>
    /// serves as a backround service, where you definde start and stop actions
    /// </summary>
    public class MessageConsumer : IHostedService, IDisposable
    {
        private readonly IMessageConsumerService _messageConsumerService;
        public MessageConsumer(IMessageConsumerService messageConsumerService)
        {
            _messageConsumerService = messageConsumerService;
        }

        public void Dispose()
        {
            _messageConsumerService.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return _messageConsumerService.StartAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _messageConsumerService.Stop();
            return Task.CompletedTask;
        }
    }
}
