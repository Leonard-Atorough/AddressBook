using System;
using System.Collections.Generic;

#nullable disable

namespace AddressBookModel
{
    public partial class Address
    {
        public Address()
        {
            Contacts = new HashSet<Contact>();
        }

        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
