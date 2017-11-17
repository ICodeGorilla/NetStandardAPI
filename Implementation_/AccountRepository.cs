using System.Linq;
using Microsoft.EntityFrameworkCore;
using Repositories.Contract;
using Shared.Core.Repository;
using SharedLibraryDatabase;

namespace Repositories.Implementation
{
    public class AccountRepository : EfCoreRepositoryBase<Account, SharedlibraryContext, int>,IAccountRepository
    {
        public AccountRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory, entity => entity.AccountId)
        {
        }

        public override Account GetById(int id)
        {
            return this.DataContext.Set<Account>().Include(x => x.Contact).Single(x => x.AccountId == id);
        }
    }
}
