using MediatR;

namespace ContactManager.Application.Contacts.Commands.Handlers
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IContactMessagePublisher _contactMessagePublisher;
        public DeleteContactCommandHandler(
            IContactRepository contactRepository,
            IContactMessagePublisher contactMessagePublisher)
        {
            _contactRepository = contactRepository;
            _contactMessagePublisher = contactMessagePublisher;
        }

        public async Task Handle(DeleteContactCommand command, CancellationToken cancellationToken)
        {
            await _contactRepository.DeteteContactAsync(command.ContactId);
            await _contactMessagePublisher.PublishDeleteMessage(command.ContactId);
        }
    }
}
