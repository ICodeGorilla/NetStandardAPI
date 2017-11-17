using Shared.Core.Repository;
using Shared.Core.Repository.Contract;
using SharedLibraryDatabase;

namespace Repositories
{
    public class EfCoreAccountRepository : EfCoreRepositoryBase<Account, SharedlibraryContext, int>
    {
        public EfCoreAccountRepository(IEfCoreDatabaseFactory<SharedlibraryContext> databaseFactory)
            : base(databaseFactory, entity => entity.AccountId)
        {
        }
    }
}