using ContactManager.Domain.Contacts;

namespace ContactManager.Write.WebApi.ViewModels
{
    public class ContactViewModel
    {
        public ContactViewModel()
        {
            // for JSON serialization
        }

        public ContactViewModel(Contact contact)
        {
            Id = contact.Id;
            FirstName = contact.FirstName;
            Surname = contact.Surname;
            BirthDate = contact.BirthDate;

            if (contact.Address != null)
            {
                Address = new AddressViewModel(contact.Address);
            }

            PhoneNumber = contact.PhoneNumber;
            IBAN = contact.IBAN;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public DateTime? BirthDate { get; set; }

        public AddressViewModel? Address { get; set; }

        public string? PhoneNumber { get; set; }

        public string? IBAN { get; set; }
    }
}
