using ContactManager.Domain.Contacts;
using MediatR;

namespace ContactManager.Application.Contacts.Queries
{
    public class GetContactByIdQuery : IRequest<ContactRead?>
    {
        public int ContactId { get; set; }
    }
}
