using System.Data;
using System.Data.Entity;
using System.Linq;

namespace Repository
{
    public abstract class BaseEfRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext DataDbContext;
        private readonly IDbSet<T> _dbSet;

        protected BaseEfRepository(DbContext dataDbContext)
        {
            DataDbContext = dataDbContext;
            _dbSet = dataDbContext.Set<T>();
        }

        #region IRepository<T> Members

        public IQueryable<T> Entities
        {
            get
            {
                return _dbSet;
            }
        }

        public T New()
        {
            return _dbSet.Create();
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            DataDbContext.Entry(entity).State = EntityState.Modified;
        }

        public T Create(T entity)
        {
            return _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Dispose()
        {
            DataDbContext.Dispose();
        }

        #endregion

        public void Save()
        {
            DataDbContext.SaveChanges();
        }
    }
}