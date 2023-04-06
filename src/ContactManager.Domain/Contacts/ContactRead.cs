namespace ContactManager.Domain.Contacts
{
    public class ContactRead
    {
        public int Id { get; set; }

        public int ContactId { get; set; }

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

        public bool Deleted { get; set; }
    }
}
