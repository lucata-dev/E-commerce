using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
    }
}
