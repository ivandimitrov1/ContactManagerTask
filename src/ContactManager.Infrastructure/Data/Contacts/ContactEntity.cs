using ContactManager.Infrastructure.Data.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Infrastructure.Data
{
    public class ContactEntity
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

		public bool Deleted { get; set; }
	}
}
