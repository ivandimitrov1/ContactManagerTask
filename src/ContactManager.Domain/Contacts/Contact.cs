using ContactManager.Domain.Contacts.Exceptions;
using System.Text.RegularExpressions;

namespace ContactManager.Domain.Contacts
{
    public class Contact
    {
        public Contact()
        {
        }

        public Contact(
            int id,
            string firstName,
            string surname)
        {
            Id = id;
            SetName(firstName, surname);
        }

        public Contact(Contact contact)
        {
            Id = contact.Id;
            SetName(contact.FirstName, contact.Surname);
            SetBirthDate(contact.BirthDate);
            SetPhoneNumber(contact.PhoneNumber);
            SetIBAN(contact.IBAN);
            SetAddress(contact.Address);
        }

        public Contact(
            int id,
            string firstName,
            string surname,
            DateTime? birthDate,
            string phoneNumber, 
            string iban,
            Address? address)
        {
            Id = id;
            SetName(firstName, surname);
            SetBirthDate(birthDate);
            SetPhoneNumber(phoneNumber);
            SetIBAN(iban);
            SetAddress(address);
        }

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string Surname { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public Address? Address { get; private set; }
        public string? PhoneNumber { get; private set; }
        public string? IBAN { get; private set; }

        public void SetBirthDate(DateTime? birthDate) => BirthDate = birthDate;
        public void SetName(string firstName, string surname)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(surname))
            {
                throw new InvalidContactException($"Contact {Id} firstname or surname is not valid.");
            }

            FirstName = firstName;
            Surname = surname;
        }

        public void SetAddress(Address? address) => Address = address;

        public void DeleteAddress() => Address = null;

        public void SetPhoneNumber(string phoneNumber)
        {
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                Regex phoneNumberPattern = new Regex("^\\+?[0-9]+(-[0-9]+)*$");
                Match match = phoneNumberPattern.Match(phoneNumber);
                if (match.Success)
                {
                    PhoneNumber = phoneNumber;
                    return;
                }

                throw new InvalidContactException($"Contact {Id} phoneNumber is not valid.");
            }
            else
            {
                PhoneNumber = null;
            }
        }

        public void SetIBAN(string iban)
        {
            if (!string.IsNullOrEmpty(iban))
            {
                Regex ibanPattern = new Regex("^[A-Z0-9]");
                Match match = ibanPattern.Match(iban);
                if (match.Success)
                {
                    IBAN = iban;
                    return;
                }

                throw new InvalidContactException($"Contact {Id} iban is not valid.");
            }
            else
            {
                IBAN = null;
            }
        }
    }
}
