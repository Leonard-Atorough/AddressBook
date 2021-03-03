using System;
using System.Collections.Generic;

#nullable disable

namespace AddressBookModel
{
    public partial class UserContact
    {
        public int UserId { get; set; }
        public int ContactId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual User User { get; set; }
    }
}
