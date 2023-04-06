using EasyNetQ;
using EasyNetQ.Topology;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ContactManager.Infrastructure.Messaging.Consumer
{
    /// <summary>
    /// separated from the background service, here you define the actual
    /// behaviour of the message consumer
    /// </summary>
    public class MessageConsumerService : IMessageConsumerService
    {
        private readonly IOptions<MessagingOptions> _options;
        private readonly IServiceProvider _serviceProvider;

        private IAdvancedBus _advancedBus;

        public MessageConsumerService(
            IOptions<MessagingOptions> options,
            IServiceProvider serviceProvider)
        {
            _options = options;
            _serviceProvider = serviceProvider;
        }

        public void Dispose()
        {
            _advancedBus?.Dispose();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var _advancedBus = RabbitHutch.CreateBus(_options.Value.ConnectionString);

            var exchange = await _advancedBus.Advanced.ExchangeDeclareAsync(_options.Value.ExchangeKey, ExchangeType.Topic);
            var queue = await _advancedBus.Advanced.QueueDeclareAsync();


            foreach (var key in RoutingKey.ContactKeys)
            {
                await _advancedBus.Advanced.BindAsync(exchange, queue, key);
            }

            async void Handler(ReadOnlyMemory<byte> bytes, MessageProperties properties, MessageReceivedInfo info)
            {
                await HandleMessage(info.RoutingKey, bytes.ToArray());
            }

            _advancedBus.Advanced.Consume(queue, Handler);
        }

        public void Stop()
        {
            _advancedBus?.Dispose();
        }

        private async Task HandleMessage(string routingKey, byte[] messageData)
        {
            using IServiceScope serviceScope = _serviceProvider.CreateScope();
            IMessageProcessor messageProcessor = serviceScope.ServiceProvider.GetRequiredService<IMessageProcessor>();
            await messageProcessor.HandleMessage(routingKey, messageData);
        }
    }
}