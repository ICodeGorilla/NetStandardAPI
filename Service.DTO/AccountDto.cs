using System;
using System.Collections.Generic;

namespace Service.DTO
{
    public class AccountDto
    {
        public int AccountId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string AccountReference { get; set; }
        public List<ContactDto> Contact { get; set; }
    }

    public class ContactDto
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public int AccountId { get; set; }
    }
}
