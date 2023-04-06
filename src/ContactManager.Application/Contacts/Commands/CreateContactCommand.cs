using ContactManager.Domain.Contacts;
using MediatR;

namespace ContactManager.Application.Contacts.Commands
{
    public class CreateContactCommand : ContactCommand, IRequest<Contact>
    {
    }
}
