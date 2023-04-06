using ContactManager.Application.Contacts;
using ContactManager.Domain.Contacts;
using ContactManager.Infrastructure.Data.Contacts;

namespace ContactManager.Infrastructure.Data
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ContactRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Contact?> GetByIdAsync(int contactId)
        {
            ContactEntity entity = await _dbContext.Contacts.FindAsync(contactId);

            if (entity == null)
            {
                return null;
            }

            return ContactEntityMapper.MapToModel(entity);
        }

        public async Task<Contact> AddContactAsync(Contact contact)
        {
            if (contact == null)
            {
                return null;
            }

            ContactEntity @new = new ContactEntity();
            ContactEntityMapper.MapToEntity(contact, @new);
            _dbContext.Contacts.Add(@new);
            await _dbContext.SaveChangesAsync();

            return ContactEntityMapper.MapToModel(@new);
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            if (contact == null)
            {
                return;
            }

            ContactEntity entity = await _dbContext.Contacts.FindAsync(contact.Id);
            if (entity == null)
            {
                throw new InvalidOperationException("update operation failed because of not found contact id");
            }

            ContactEntityMapper.MapToEntity(contact, entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeteteContactAsync(int contactId)
        {
            ContactEntity entity = await _dbContext.Contacts.FindAsync(contactId);

            if (entity == null) return;

            entity.Deleted = true;
            await _dbContext.SaveChangesAsync();
        }
    }
}
