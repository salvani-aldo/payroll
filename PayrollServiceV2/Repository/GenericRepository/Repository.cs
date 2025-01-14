using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace Repository.GenericRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _entitySet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _entitySet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbContext.Add(entity);
        }

        public T Find(Expression<Func<T, bool>> expression)
        {
            var result = _entitySet.Find(expression);

            return result;
        }

        public IEnumerable<T> GetAll()
        {
            return _entitySet.ToList();
        }

        public void Remove(T entity)
        {
            _dbContext.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
        }
    }
}
