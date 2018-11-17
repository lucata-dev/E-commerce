﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public decimal UnitPrice { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public virtual Category Category { get; set; }

        public ICollection<Image> Images { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
