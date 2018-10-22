using Ecommerce.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;

namespace MVCWebApplication.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}