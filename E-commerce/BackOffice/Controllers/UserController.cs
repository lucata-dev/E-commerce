using BackOffice.Models;
using Ecommerce.Business;
using Ecommerce.Domain.Entities;
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
            return View(users);
        }

        public ActionResult Create()
        {
            return RedirectToAction("Register", "Account");
        }

        public ActionResult Edit(string id)
        {
            //var user = _service.GetUser(Conventid);s

            return RedirectToAction("Edit", "Account", new { @id = id });
        }

        public ActionResult Delete(string id)
        {
            return RedirectToAction("Delete", "Account", new { @id = id });
        }
    }
}