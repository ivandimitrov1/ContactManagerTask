namespace ContactManager.Application.Contacts.Commands
{
    public class ContactCommand
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public AddressCommand? Address { get; set; }
        public string PhoneNumber { get; set; }
        public string IBAN { get; set; }
    }
}
