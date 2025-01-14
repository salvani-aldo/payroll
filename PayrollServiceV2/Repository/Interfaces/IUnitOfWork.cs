using Microsoft.EntityFrameworkCore;

namespace Repository.Interfaces
{
    public interface IUnitOfWork<T> : IDisposable where T : class
    {
        void Commit();
        void Rollback();
        IRepository<T> Repository();
    }
}
