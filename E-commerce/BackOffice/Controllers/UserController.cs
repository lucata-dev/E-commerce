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

        public ActionResult Create(ApplicationUser user)
        {
            try
            {
                _service.UpdateUser(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var user = _service.GetApplicationUserById(id);

            return View(user);
        }

        public ActionResult Edit(ApplicationUser user)
        {
            try
            {
                _service.UpdateUser(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var user = _service.GetApplicationUserById(id);

            return View(user);
        }

        public ActionResult Delete(ApplicationUser user)
        {
            try
            {
                _service.DeleteUser(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }








            //public ActionResult Edit(string id)
            //{
            //    var user = _service.GetUser(Conventid);

            //    var userViewModel = new UserViewModel
            //    {
            //        Id = user.Id,
            //        Email = user.Email,
            //        Enabled = user.IsAvailable
            //    };

            //    return RedirectToAction("Edit", "Account", userViewModel);
            //}
        }
}