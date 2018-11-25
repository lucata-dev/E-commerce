using Ecommerce.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GenericRepository : IGenericRepository
    {
        protected DbContext _dbContext;

        public GenericRepository()
        {
            _dbContext = ApplicationDbContext.Create();
        }

        public void Add<T>(T entity) where T : class
        {
            try
            {
                _dbContext.Set<T>().Add(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Remove<T>(T entity) where T : class
        {
            try
            {
                _dbContext.Set<T>().Attach(entity);
                _dbContext.Set<T>().Remove(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public T Get<T>(int id) where T : class
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return _dbContext.Set<T>().ToList();
        }

        public IEnumerable<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _dbContext.Set<T>().Where(predicate).ToList();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Update<T>(T entity) where T : class
        {
            try
            {
                _dbContext.Set<T>().Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
