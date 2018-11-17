using Ecommerce.Business;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWebApplication.Controllers
{
    public class HomeController : Controller
    {
        Service _service = new Service();


        public ActionResult Index()
        {
            ViewBag.Categories = _service.GetAllCategories();
           var productos = _service.GetAllProducts().Take(10);

            return View(productos);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}