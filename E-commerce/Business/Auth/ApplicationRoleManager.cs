using Ecommerce.Data;
using Ecommerce.Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Auth
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> roleStore)
            : base(roleStore) { }

        public static ApplicationRoleManager Create(
            IdentityFactoryOptions<ApplicationRoleManager> options, 
            IOwinContext context)
        {
            var manager = new ApplicationRoleManager(
                new RoleStore<ApplicationRole>(context.Get<ApplicationDbContext>()));

            return manager;
        }
    }
}
