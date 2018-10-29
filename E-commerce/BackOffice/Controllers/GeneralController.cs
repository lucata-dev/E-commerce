using Ecommerce.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.BackOffice.Controllers
{
    public abstract class GeneralController : Controller
    {
        protected readonly Service _service;

        public GeneralController()
        {
            _service = new Service();
        }
    }
}