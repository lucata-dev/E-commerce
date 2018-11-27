using Ecommerce.Domain.Entities;
using Microsoft.AspNet.Identity;
using Repository;
using Repository.Entities;
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

        public IEnumerable<Customer> GetCustomerUsers()
        {
            var customerRole = _repository.GetAll<ApplicationRole>().FirstOrDefault(x => x.Name == "Customer");
            var users = _repository.FindBy<ApplicationUser>(x => x.Roles.Any(r => r.RoleId == customerRole.Id));

            var usersId = users.Select(x => x.Id).ToList();

            var customers = _repository
                            .FindBy<Customer>(c => usersId.Contains(c.ApplicationUserId))
                            .ToList();

            return customers;
        }

        public void UpdateUser(ApplicationUser user)
        {
            _repository.Update<ApplicationUser>(user);
        }

        public void AddUser(ApplicationUser user)
        {
            _repository.Add<ApplicationUser>(user);
        }

        public void DeleteUser(ApplicationUser user)
        {
            _repository.Remove<ApplicationUser>(user);
        }

        public ApplicationUser GetApplicationUserById(int id)
        {
            return _repository.Get<ApplicationUser>(id);
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

        public void UpdateProduct(Product product)
        {
            _repository.Update<Product>(product);
        }

        public Product GetProductById(int id)
        {
            return _repository.Get<Product>(id);
        }

        public IEnumerable<Product> GetProductsByCategory(int id)
        {
            var products = new ProductRepository().GetProductByCategory(id);

            return products;
        }

        #endregion

        #region Gallery

        public void AddImage(Image image)
        {
            _repository.Add<Image>(image);
        }

        #endregion

        #region Customers

        public void AddOrUpdateCustomer(Customer customer)
        {
            if (customer.Id == 0)
            {
                _repository.Add<Customer>(customer);
            }
            else
            {
                _repository.Update<Customer>(customer);
            }
        }

        public Customer GetCustomer(string applicationUserId)
        {
            return _repository.FindBy<Customer>(c => c.ApplicationUserId == applicationUserId).FirstOrDefault();
        }

        #endregion

        #region State

        public State GetState(int id)
        {
            return _repository.Get<State>(id);
        }

        public IEnumerable<State> GetStates()
        {
            return _repository.GetAll<State>();
        }

        #endregion

        public void addOrderProducts(Order order, List<Product> products)
        {
            foreach (var item in products)
            {
                order.Products.Add(_repository.Get<Product>(item.Id));
            }
            _repository.Add<Order>(order);
        }

        public IEnumerable<Order> GetOrders()
        {
            return _repository.GetAll<Order>();
        }

        public Order GetOrder(int id)
        {
            return _repository.Get<Order>(id);
        }
    }
}