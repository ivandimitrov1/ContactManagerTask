using ContactManager.Domain.Contacts;
using ContactManager.Infrastructure.Data.ContactReads;

namespace ContactManager.Infrastructure.Messaging.Contacts
{
    public class ContactChangeMessage
    {
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string Surname { get; set; }

		public DateTime? BirthDate { get; set; }

		public string? PhoneNumber { get; set; }

		public string? IBAN { get; set; }

		// Address data
		public string? Street { get; set; }

		public string? City { get; set; }

		public string? Country { get; set; }

		public string? Postcode { get; set; }

        public static ContactChangeMessage MapToMessage(Contact source)
        {
            var target = new ContactChangeMessage();
            target.Id = source.Id;
            target.FirstName = source.FirstName;
            target.Surname = source.Surname;
            target.PhoneNumber = source.PhoneNumber;
            target.IBAN = source.IBAN;
            target.BirthDate = source.BirthDate;

            target.Street = source.Address?.Street;
            target.City = source.Address?.City;
            target.Country = source.Address?.Country;
            target.Postcode = source.Address?.Postcode;
            return target;
        }

        public static ContactRead MapToReadModel(ContactChangeMessage source)
        {
            var target = new ContactRead();
            target.ContactId = source.Id;
            target.FirstName = source.FirstName;
            target.Surname = source.Surname;
            target.PhoneNumber = source.PhoneNumber;
            target.IBAN = source.IBAN;
            target.BirthDate = source.BirthDate;

            target.Street = source.Street;
            target.City = source.City;
            target.Country = source.Country;
            target.Postcode = source.Postcode;
            return target;
        }
    }
}
