using Ecommerce.Business;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.BackOffice.Controllers
{
    public class CategoryController : GeneralController
    {
        // GET: Category
        public ActionResult Index()
        {
            var categories = _service.GetAllCategories();

            return View(categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create      Llamado al servidor/ver formulario
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create   Mandas informacion/llenar formulario
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                _service.AddCategory(category);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _service.GetCategoryById(id);

            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                _service.UpdateCategory(category);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var category = _service.GetCategoryById(id);

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(Category category)
        {
            try
            {
                _service.DeleteCategory(category);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
