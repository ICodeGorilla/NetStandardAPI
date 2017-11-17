using System;

namespace SharedLibraryDatabase
{
    public partial class CompositeKeyTest
    {
        public int FirstKey { get; set; }
        public string SecondKey { get; set; }
        public string Value { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
