using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [StringLength(50)]
        [Display(Name = "Teléfono")]
        [Phone]
        public string Phone { get; set; }

        [StringLength(50)]
        [Display(Name = "Código postal")]
        public string ZipCode { get; set; }

        [StringLength(50)]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [StringLength(50)]
        [Display(Name = "Provincia")]
        public string Province { get; set; }

        [StringLength(50)]
        [Display(Name = "Ciudad")]
        public string City { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
