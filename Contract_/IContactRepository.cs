using Shared.Core.Repository.Contract;
using SharedLibraryDatabase;

namespace Repositories.Contract
{
    public interface IContactRepository : IRepository<Contact, int>
    {
    }
}