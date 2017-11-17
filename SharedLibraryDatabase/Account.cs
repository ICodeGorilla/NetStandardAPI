using System;
using System.Collections.Generic;

namespace SharedLibraryDatabase
{
    public partial class Account
    {
        public Account()
        {
            Contact = new HashSet<Contact>();
        }

        public int AccountId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string AccountReference { get; set; }

        public ICollection<Contact> Contact { get; set; }
    }
}
