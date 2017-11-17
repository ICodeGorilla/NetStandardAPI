using Shared.Core.Repository.Contract;
using Shared.Core.Repository;

namespace SharedLibraryDatabase
{
    public class DatabaseFactory : EfCoreDatabaseFactoryBase<SharedlibraryContext>, IDatabaseFactory
    {
        public DatabaseFactory(string connectionString) : base(connectionString)
        {
        }

        public DatabaseFactory()
        {
            
        }
    }

 
    public interface IDatabaseFactory : IEfCoreDatabaseFactory<SharedlibraryContext>
    {
    }
}
