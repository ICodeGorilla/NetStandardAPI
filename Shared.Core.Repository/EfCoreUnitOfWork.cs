using Shared.Core.Repository.Contract;

namespace Shared.Core.Repository
{
    public class EfCoreUnitOfWork<T> : IUnitOfWork where T : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly IEfCoreDatabaseFactory<T> _databaseFactory;
        private T _dataContext;

        public EfCoreUnitOfWork(IEfCoreDatabaseFactory<T> databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        protected Microsoft.EntityFrameworkCore.DbContext DataContext => _dataContext ?? (_dataContext = _databaseFactory.Get());

        public void Commit()
        {
            DataContext.SaveChanges();
        }
    }
}