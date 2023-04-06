using ContactManager.Application.Contacts;
using ContactManager.Domain.Contacts;
using ContactManager.Infrastructure.Messaging.Contacts;
using EasyNetQ;
using EasyNetQ.Topology;
using Microsoft.Extensions.Options;
using System.Text;

namespace ContactManager.Infrastructure.Messaging
{
    public class ContactMessagePublisher : IContactMessagePublisher
    {
        private readonly IOptions<MessagingOptions> _options;
        public ContactMessagePublisher(IOptions<MessagingOptions> options)
        {
            _options = options;
        }

        public async Task PublishChangeMessage(Contact contact)
        {
            var bus = RabbitHutch.CreateBus(_options.Value.ConnectionString).Advanced;
            var exchange = bus.ExchangeDeclare(_options.Value.ExchangeKey, ExchangeType.Topic);

            var message = ContactChangeMessage.MapToMessage(contact);
            string json = System.Text.Json.JsonSerializer.Serialize(message);

            await bus.PublishAsync(exchange, RoutingKey.ContactChange, false, new MessageProperties { DeliveryMode = 2 }, Encoding.UTF8.GetBytes(json));
        }

        public async Task PublishDeleteMessage(int contactId)
        {
            var bus = RabbitHutch.CreateBus(_options.Value.ConnectionString).Advanced;
            var exchange = bus.ExchangeDeclare(_options.Value.ExchangeKey, ExchangeType.Topic);

            ContactDeleteMessage message = new ContactDeleteMessage { Id = contactId };
            string json = System.Text.Json.JsonSerializer.Serialize(message);
            await bus.PublishAsync(exchange, RoutingKey.ContactDelete, false, new MessageProperties { DeliveryMode = 2 }, Encoding.UTF8.GetBytes(json));
        }
    }
}
