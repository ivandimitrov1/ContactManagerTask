using ContactManager.Domain.Contacts;
using MediatR;

namespace ContactManager.Application.Contacts.Queries
{
    public class GetContactByIdHandler : IRequestHandler<GetContactByIdQuery, ContactRead?>
    {
        private readonly IContactReadRepository _contactReadRepository;

        public GetContactByIdHandler(IContactReadRepository contactReadRepository)
        {
            _contactReadRepository = contactReadRepository;
        }

        public async Task<ContactRead?> Handle(GetContactByIdQuery query, CancellationToken cancellationToken)
        {
            return await _contactReadRepository.GetByIdAsync(query.ContactId);
        }
    }
}
