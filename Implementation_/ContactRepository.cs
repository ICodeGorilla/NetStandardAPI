using Repositories.Contract;
using Shared.Core.Repository;
using SharedLibraryDatabase;

namespace Repositories.Implementation
{
    public class ContactRepository : EfCoreRepositoryBase<Contact, SharedlibraryContext, int>, IContactRepository
    {
        public ContactRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory, entity => entity.AccountId)
        {
        }
    }
}