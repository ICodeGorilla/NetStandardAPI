namespace Shared.Core.Repository.Contract
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}