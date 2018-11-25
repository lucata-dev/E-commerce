using Ecommerce.Business;
using Ecommerce.Business.Auth;
using Ecommerce.Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MVCWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.MVCWebApplication.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomerController : Controller
    {
        private Service _service;
        private ApplicationUserManager _userManager;

        public CustomerController()
        {
            _service = new Service();
        }
        public CustomerController(ApplicationUserManager userManager)
        {
            _service = new Service();
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Customer
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var customer = new CustomerViewModel
            {
                Customer = _service.GetCustomer(userId),
                ResetPassword = new ResetPasswordViewModel { Email = UserManager.FindById(userId).Email }
            };

            return View(customer);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var customerModel = _service.GetCustomer(userId);

                if (customerModel != null)
                {
                    customerModel.Address = customer.Address;
                    customerModel.City = customer.City;
                    customerModel.LastName = customer.LastName;
                    customerModel.Name = customer.Name;
                    customerModel.Phone = customer.Phone;
                    customerModel.Province = customer.Province;
                    customerModel.ZipCode = customer.ZipCode;
                }
                else
                {
                    customerModel = customer;
                    customerModel.ApplicationUserId = userId;
                }
                

                _service.AddOrUpdateCustomer(customerModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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
