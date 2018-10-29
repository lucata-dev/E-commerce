using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IGenericRepository : IDisposable
    {
        void Add<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;

        T Get<T>(int id) where T : class;

        IEnumerable<T> GetAll<T>() where T : class;
        IEnumerable<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class;
    }
}
