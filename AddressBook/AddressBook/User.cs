using System;
using System.Collections.Generic;

#nullable disable

namespace AddressBookModel
{
    public partial class User
    {
        public User()
        {
            UserContacts = new HashSet<UserContact>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }

        public virtual ICollection<UserContact> UserContacts { get; set; }
    }
}
