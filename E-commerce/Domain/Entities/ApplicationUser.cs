using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }

        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [StringLength(50)]
        [Display(Name = "Empresa")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Fecha de registro")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Habilitado")]
        public bool IsAvailable { get; set; }
    }
}
