using MVCWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebApplication.Models
{
    public class LoginRegisterViewModel
    {
        public RegisterViewModel RegisterViewModel { get; set; }
        public LoginViewModel LoginViewModel { get; set; }
    }
}