using Ecommerce.Domain.Entities;
using MVCWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebApplication.Models
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public ResetPasswordViewModel ResetPassword { get; set; }
    }
}