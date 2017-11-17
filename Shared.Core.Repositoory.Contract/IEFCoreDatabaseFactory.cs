using Microsoft.EntityFrameworkCore;

namespace Shared.Core.Repository.Contract
{
    public interface IEfCoreDatabaseFactory<T> where T: DbContext
    {
        T Get();
    }
}