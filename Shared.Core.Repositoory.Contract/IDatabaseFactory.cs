using Microsoft.EntityFrameworkCore;

namespace Shared.Core.Repository.Contract
{
    public interface IDatabaseFactory<T> where T: DbContext
    {
        T Get();
    }
}