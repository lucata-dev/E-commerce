using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.BackOffice.Controllers
{
    public class OrderController : GeneralController
    {
        // GET: Order
        public ActionResult Index()
        {
            var orders = _service.GetOrders();

            return View(orders);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.States = _service.GetStates();

            var order = _service.GetOrder(id);
            return View(order);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
