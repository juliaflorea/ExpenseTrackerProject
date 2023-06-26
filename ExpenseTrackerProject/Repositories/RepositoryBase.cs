using ExpenseTrackerProject.Models;

namespace ExpenseTrackerProject.Repositories
{
    public abstract class RepositoryBase<T> where T : class
    {
        protected readonly ExpenseTrackerDbContext _dbContext;

        public RepositoryBase(ExpenseTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public virtual T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public virtual void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }
    }

}
