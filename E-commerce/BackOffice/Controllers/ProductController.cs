using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.BackOffice.Controllers
{
    public class ProductController : GeneralController
    {
        // GET: Product
        public ActionResult Index()
        {
            var products = _service.GetAllProducts();

            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var product = _service.GetProductById(id);
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.Categories = _service.GetAllCategories();

            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product, int category, HttpPostedFileBase postedFile)
        {
            try
            {
                product.Category = _service.GetCategoryById(category);

                var repositoryPath = Server.MapPath("~/Images");

                var directoryPath = Guid.NewGuid().ToString();

                var fullDirectory = Path.Combine(repositoryPath, directoryPath);

                if (!Directory.Exists(fullDirectory))
                {
                    Directory.CreateDirectory(fullDirectory);
                }

                if (postedFile != null)
                {
                    string fileName = Path.GetFileName(postedFile.FileName);

                    postedFile.SaveAs(Path.Combine(fullDirectory, fileName));

                    var image = new Image { Path = Path.Combine(directoryPath, fileName)};

                    product.Images.Add(image);
                    _service.AddProduct(product);
                }

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _service.GetProductById(id);
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                _service.UpdateProduct(product);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _service.GetProductById(id);
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(Product product)
        {
            try
            {
                var productDelete = _service.GetProductById(product.Id);
                _service.DeleteProduct(productDelete);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}
