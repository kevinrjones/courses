using System.Data;
using System.Data.Entity;
using System.Linq;

namespace Repository
{
    public abstract class BaseEfRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dataDbContext;
        private readonly IDbSet<T> _dbSet;

        protected BaseEfRepository(DbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
            _dbSet = dataDbContext.Set<T>();
        }

        #region IRepository<T> Members

        public IQueryable<T> Entities
        {
            get { return _dbSet; }
        }

        public T New()
        {
            return _dbSet.Create();
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dataDbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Dispose()
        {
            _dataDbContext.Dispose();
        }

        #endregion

        public void Save()
        {
            _dataDbContext.SaveChanges();
        }
    }
}