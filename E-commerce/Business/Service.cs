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

        #region Categories
        public void AddCategory(Category category)
        {
            _repository.Add<Category>(category);
        }

        public void DeleteCategory(Category cat1)
        {
            _repository.Remove<Category>(cat1);
        }

        public Category getInCategory(int id)
        {
            return _repository.Get<Category>(id);
        } 

        public IEnumerable<Category> GetAllCategories()
        {
            return _repository.GetAll<Category>();
        }

        public string GetCategorieId()
        {
            return _repository.FindBy<Category>(x => x.Name == "Ropa").FirstOrDefault().Id.ToString();
        }

        #endregion

        #region Users

        public IEnumerable<ApplicationUser> Users()
        {
            return _repository.GetAll<ApplicationUser>();
        }

        #endregion
    }
}
