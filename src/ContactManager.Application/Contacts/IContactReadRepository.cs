using ContactManager.Domain.Contacts;

namespace ContactManager.Application.Contacts
{
    public interface IContactReadRepository
    {
        Task<ContactRead> GetByIdAsync(int contactId);
        Task AddOrUpdateContactReadAsync(ContactRead contactRead);
        Task DeteteContactReadAsync(int contactId);
    }
}
