using ContactManager.Domain.Contacts;

namespace ContactManager.Write.WebApi.ViewModels
{
    public class AddressViewModel
    {
        public AddressViewModel()
        {
            // for json serialization
        }

        public AddressViewModel(Address address)
        {
            Street = address.Street;
            City = address.City;
            Country = address.Country;
            Postcode = address.Postcode;
        }

        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Postcode { get; set; }
    }
}
