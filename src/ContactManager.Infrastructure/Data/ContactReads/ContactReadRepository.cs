using ContactManager.Application.Contacts;
using ContactManager.Domain.Contacts;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Infrastructure.Data.ContactReads
{
    public class ContactReadRepository : IContactReadRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ContactReadRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ContactRead> GetByIdAsync(int contactId)
        {
            return await _dbContext.ContactReads.FirstOrDefaultAsync(x => x.ContactId == contactId);
        }

        public async Task AddOrUpdateContactReadAsync(ContactRead contactRead)
        {
            if (contactRead == null)
            {
                return;
            }

            var readModel = await _dbContext.ContactReads.FirstOrDefaultAsync(x => x.ContactId == contactRead.ContactId);
            if (readModel == null)
            {
                _dbContext.ContactReads.Add(contactRead);
                await _dbContext.SaveChangesAsync();
                return;
            }

            readModel.ContactId = contactRead.Id;
            readModel.FirstName = contactRead.FirstName;
            readModel.Surname = contactRead.Surname;
            readModel.PhoneNumber = contactRead.PhoneNumber;
            readModel.IBAN = contactRead.IBAN;
            readModel.BirthDate = contactRead.BirthDate;

            readModel.Street = contactRead.Street;
            readModel.City = contactRead.City;
            readModel.Country = contactRead.Country;
            readModel.Postcode = contactRead.Postcode;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeteteContactReadAsync(int contactId)
        {
            ContactRead entity = await _dbContext.ContactReads.FirstOrDefaultAsync(x => x.ContactId == contactId);

            if (entity == null) return;

            entity.Deleted = true;

            await _dbContext.SaveChangesAsync();
        }
    }
}
