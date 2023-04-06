namespace ContactManager.Domain.Contacts
{
    public class Address
    {
        public Address(
            string street,
            string city,
            string country,
            string postCode)
        {
            SetStreet(street);
            SetCity(city);
            SetCountry(country);
            SetPostcode(postCode);
        }

        public string? Street { get; private set; }
        public string? City { get; private set; }
        public string? Country { get; private set; }
        public string? Postcode { get; private set; }

        public void SetStreet(string street) => Street = street;
        public void SetCity(string city) => City = city;
        public void SetCountry(string country) => Country = country;
        public void SetPostcode(string postCode) => Postcode = postCode;
    }
}
