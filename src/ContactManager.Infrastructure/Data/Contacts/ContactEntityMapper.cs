using ContactManager.Domain.Contacts;

namespace ContactManager.Infrastructure.Data.Contacts
{
    public static class ContactEntityMapper
    {
        public static Contact MapToModel(ContactEntity source)
        {
            Contact target = new Contact(source.Id, source.FirstName, source.Surname);

            target.SetName(source.FirstName, source.Surname);
            target.SetPhoneNumber(source.PhoneNumber);
            target.SetBirthDate(source.BirthDate);
            target.SetIBAN(source.IBAN);

            Address address = new Address(
                source?.Street,
                source?.City,
                source?.Country,
                source?.Postcode);
            target.SetAddress(address);

            return target;
        }

        public static void MapToEntity(Contact source, ContactEntity target)
        {
            target.FirstName = source.FirstName;
            target.Surname = source.Surname;
            target.PhoneNumber = source.PhoneNumber;
            target.IBAN = source.IBAN;
            target.BirthDate = source.BirthDate;

            target.Street = source.Address?.Street;
            target.City = source.Address?.City;
            target.Country = source.Address?.Country;
            target.Postcode = source.Address?.Postcode;
        }
    }
}
