using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Estado")]
        public int StateId { get; set; }
        public virtual State State { get; set; }

        [Display(Name = "Comentario")]
        public string Comment { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public decimal TotalPrice { get; set; }

        [Required]
        [Display(Name = "Fecha de venta")]
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        
        public Order()
        {
            this.Products = new HashSet<Product>();
        }
    }
}
