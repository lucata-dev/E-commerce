using Ecommerce.Domain.Entities;
using Microsoft.AspNet.Identity;
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

        public void DeleteCategory(Category category)
        {
            _repository.Remove<Category>(category);
        }

        public void UpdateCategory(Category category)
        {
            _repository.Update<Category>(category);
        }

        public Category GetCategoryById(int id)
        {
            return _repository.Get<Category>(id);
        } 

        public IEnumerable<Category> GetAllCategories()
        {
            return _repository.GetAll<Category>();
        }

        #endregion

        #region Users

        public IEnumerable<ApplicationUser> GetAdminUsers()
        {
            var adminRole = _repository.GetAll<ApplicationRole>().FirstOrDefault(x => x.Name == "Admin");
            var users = _repository.FindBy<ApplicationUser>(x => x.Roles.Any(r => r.RoleId == adminRole.Id));
            return users;
        }

        public void UpdateUser(ApplicationUser user)
        {
            _repository.Update<ApplicationUser>(user);
        }

        #endregion

        #region Products

        public IEnumerable<Product> GetAllProducts()
        {
            return _repository.GetAll<Product>();
        }

        public void AddProduct(Product product)
        {
            _repository.Add<Product>(product);
        }

        public void DeleteProduct(Product product)
        {
            _repository.Remove<Product>(product);
        }

        public void UpdateCategory(Product product)
        {
            _repository.Update<Product>(product);
        }

        public Product GetProductById(int id)
        {
            return _repository.Get<Product>(id);
        }

        #endregion
    }
}