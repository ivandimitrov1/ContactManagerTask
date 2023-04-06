using ContactManager.Domain.Contacts;

namespace ContactManager.Application.Contacts
{
    public interface IContactMessagePublisher
    {
        Task PublishChangeMessage(Contact message);
        Task PublishDeleteMessage(int contactId);
    }
}
