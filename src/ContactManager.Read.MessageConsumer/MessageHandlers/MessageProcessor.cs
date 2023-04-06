using ContactManager.Application.Contacts;
using ContactManager.Infrastructure.Messaging;
using ContactManager.Infrastructure.Messaging.Consumer;
using ContactManager.Infrastructure.Messaging.Contacts;

namespace ContactManager.Read.MessageConsumer.MessageHandlers
{
    public class MessageProcessor : IMessageProcessor
    {
        private readonly IContactReadRepository _contactReadRepository;
        public MessageProcessor(IContactReadRepository contactReadRepository)
        {
            _contactReadRepository = contactReadRepository;
        }

        public IList<string> RoutingKeys => RoutingKey.ContactKeys;

        public async Task HandleMessage(string routingKey, byte[] data)
        {
            switch (routingKey)
            {
                case var key when key.Contains(RoutingKey.ContactChange, StringComparison.OrdinalIgnoreCase):
                    ContactChangeMessage changeMessage = System.Text.Json.JsonSerializer.Deserialize<ContactChangeMessage>(data);
                    await HandleContactChange(changeMessage);
                    return;

                case var key when key.Contains(RoutingKey.ContactDelete, StringComparison.OrdinalIgnoreCase):
                    ContactDeleteMessage deleteMessage = System.Text.Json.JsonSerializer.Deserialize<ContactDeleteMessage>(data);
                    await HandleContactDelete(deleteMessage);
                    return;

                default:
                    throw new ArgumentException("Not implemented message handler");
            }
        }

        private async Task HandleContactChange(ContactChangeMessage message)
        {
            var readModel = ContactChangeMessage.MapToReadModel(message);
            await _contactReadRepository.AddOrUpdateContactReadAsync(readModel);
        }

        private async Task HandleContactDelete(ContactDeleteMessage message)
        {
            await _contactReadRepository.DeteteContactReadAsync(message.Id);
        }
    }
}
