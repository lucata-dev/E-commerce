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

        public void DeleteCategory(Category cat1)
        {
            _repository.Remove<Category>(cat1);
        }

        public Category getInCategory(int id)
        {
            return _repository.Get<Category>(id.ToString());
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

        public IEnumerable<ApplicationUser> GetAdminUsers()
        {
            var adminRole = _repository.GetAll<ApplicationRole>().FirstOrDefault(x => x.Name == "Admin");
            var users = _repository.FindBy<ApplicationUser>(x => x.Roles.Any(r => r.RoleId == adminRole.Id));
            return users;
        }

        public ApplicationUser GetUser(string id)
        {
            return _repository.Get<ApplicationUser>(id);
        }

        #endregion
    }
}