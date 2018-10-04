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
        Service servicio = new Service();


        public ActionResult Index()
        {
            //servicio.AddCategory(new Category {Name="Juguetes"});
            //Category c1=new Category{Name="Juguetes"};

            //servicio.DeleteCategory(c1);

            //servicio.DeleteCategory(servicio.getInCategory(1));

            //Category c2 = new Category();
            //c2.Name = "Animales";

            //Category c3 = new Category();
            //c3.Name = "Estatuas";

            //Category c4 = new Category();
            //c4.Name = "Flores";

            //servicio.AddCategory(c2);
            //servicio.AddCategory(c3);
            //servicio.AddCategory(c4);

            //var objetos = servicio.GetAllCategories();
            return View();
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