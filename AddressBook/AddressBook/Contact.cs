using System;
using System.Collections.Generic;

#nullable disable

namespace AddressBookModel
{
    public partial class Contact
    {
        public Contact()
        {
            UserContacts = new HashSet<UserContact>();
        }

        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string HomeNo { get; set; }
        public string WorkNo { get; set; }
        public string Email { get; set; }
        public int? AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<UserContact> UserContacts { get; set; }
    }
}
