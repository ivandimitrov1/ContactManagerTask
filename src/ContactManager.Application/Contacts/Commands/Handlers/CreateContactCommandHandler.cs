using ContactManager.Domain.Contacts;
using MediatR;

namespace ContactManager.Application.Contacts.Commands.Handlers
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Contact>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IContactMessagePublisher _contactMessagePublisher;
        public CreateContactCommandHandler(
            IContactRepository contactRepository,
            IContactMessagePublisher contactMessagePublisher)
        {
            _contactRepository = contactRepository;
            _contactMessagePublisher = contactMessagePublisher;

        }

        public async Task<Contact> Handle(
            CreateContactCommand command,
            CancellationToken cancellationToken)
        {
            Contact contact = ContactCommand.CreateOrUpdate(0, command);
            contact = await _contactRepository.AddContactAsync(contact);

            await _contactMessagePublisher.PublishChangeMessage(contact);
            return contact;
        }
    }
}
