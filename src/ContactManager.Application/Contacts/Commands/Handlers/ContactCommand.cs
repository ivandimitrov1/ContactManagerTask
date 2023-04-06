using ContactManager.Domain.Contacts;

namespace ContactManager.Application.Contacts.Commands.Handlers
{
    public static class ContactCommand
    {
        public static Contact CreateOrUpdate(int contactId, Commands.ContactCommand source)
        {
            Contact contact = new Contact(contactId, source.FirstName, source.Surname);

            contact.SetPhoneNumber(source.PhoneNumber);
            contact.SetBirthDate(source.BirthDate);
            contact.SetIBAN(source.IBAN);

            if (source.Address != null)
            {
                Address address = new Address(
                              source.Address.Street,
                              source.Address.City,
                              source.Address.Country,
                              source.Address.Postcode);
                contact.SetAddress(address);
            }

            return contact;
        }
    }
}
