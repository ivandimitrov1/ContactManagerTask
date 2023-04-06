using ContactManager.Domain.Contacts;
using MediatR;

namespace ContactManager.Application.Contacts.Commands
{
    public class UpdateContactCommand : ContactCommand, IRequest<Contact>
    {
        public int Id { get; set; }
    }
}
