using Ecommerce.Business;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.MVCWebApplication.Controllers
{
    public class CategoryController : Controller
    {
        private Service service = new Service();

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                service.AddCategory(category);
            }
            catch (Exception)
            {

                throw;
            }

            return View();
        }

        public ActionResult Categories()
        {
            var cat = service.GetAllCategories();

            return View(cat);
        }
    }
}