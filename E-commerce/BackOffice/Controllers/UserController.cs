using Ecommerce.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackOffice.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private Service _service;

        public UserController()
        {
            _service = new Service();
        }

        // GET: User
        public ActionResult Index()
        {
            var users = _service.GetAdminUsers();
            return View();
        }
    }
}