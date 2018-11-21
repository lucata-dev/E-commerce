using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.BackOffice.Controllers
{
    public class CustomerController : GeneralController
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customers = _service.GetCustomerUsers();
            return View(customers);
        }

        public ActionResult Available(string id)
        {
            
            return RedirectToAction("Available", "Account", new { @userId = id });
        }
    }
}
