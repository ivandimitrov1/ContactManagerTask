using ContactManager.Domain.Contacts;

namespace ContactManager.Application.Contacts
{
    public interface IContactRepository
    {
        public Task<Contact?> GetByIdAsync(int contactId);
        public Task<Contact> AddContactAsync(Contact contact);
        public Task UpdateContactAsync(Contact contact);
        public Task DeteteContactAsync(int contactId);
    }
}
