using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class ProductRepository : GenericRepository
    {
        public IEnumerable<Product> GetProductByCategory(int categoryId)
        {
            return _dbContext.Set<Product>().Where(p => p.Category.Id == categoryId).ToList();
        }
    }
}
