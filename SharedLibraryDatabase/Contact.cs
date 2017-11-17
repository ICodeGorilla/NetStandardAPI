using System;

namespace SharedLibraryDatabase
{
    public partial class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public int AccountId { get; set; }

        public Account Account { get; set; }
    }
}
