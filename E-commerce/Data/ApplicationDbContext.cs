using Ecommerce.Domain;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Ecommerce.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public ApplicationDbContext()
            : base("EcommerceContext")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
