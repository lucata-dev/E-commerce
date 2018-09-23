using Ecommerce.Domain.Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business
{
    public class Service
    {
        protected GenericRepository _repository;

        public Service()
        {
            _repository = new GenericRepository();
        }

        public void AddCategory(Category category)
        {
            _repository.Add<Category>(category);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _repository.GetAll<Category>();
        }
    }
}
