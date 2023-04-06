using ContactManager.Domain.Contacts;
using MediatR;

namespace ContactManager.Application.Contacts.Commands.Handlers
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Contact>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IContactMessagePublisher _contactMessagePublisher;
        public UpdateContactCommandHandler(
            IContactRepository contactRepository,
            IContactMessagePublisher contactMessagePublisher)
        {
            _contactRepository = contactRepository;
            _contactMessagePublisher = contactMessagePublisher;
        }

        public async Task<Contact> Handle(UpdateContactCommand command, CancellationToken cancellationToken)
        {
            Contact contact = ContactCommand.CreateOrUpdate(command.Id, command);
            await _contactRepository.UpdateContactAsync(contact);
            await _contactMessagePublisher.PublishChangeMessage(contact);

            return contact;
        }
    }
}
