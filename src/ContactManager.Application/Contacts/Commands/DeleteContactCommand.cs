using MediatR;

namespace ContactManager.Application.Contacts.Commands
{
    public class DeleteContactCommand : IRequest
    {
        public int ContactId { get; set; }
    }
}
