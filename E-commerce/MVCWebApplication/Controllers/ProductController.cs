using Ecommerce.Business;
using Ecommerce.Domain.Entities;
using Ecommerce.MVCWebApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.MVCWebApplication.Controllers
{
    public class ProductController : Controller
    {
        public readonly Service _service;

        public ProductController()
        {
            _service = new Service();

            ViewBag.Categories = _service.GetAllCategories();
        }
        // GET: Product
        public ActionResult Index(int id)
        {
            var productos = _service.GetProductsByCategory(id);
            return View(productos);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View(_service.GetProductById(id));
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
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

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
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

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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

        [HttpPost]
        public ActionResult AddToCart(int idProduct, int quantity)
        {
            var product = _service.GetProductById(idProduct);

            if (product != null)
            {
                var cartItems = GetItemsCart();

                cartItems.Add(new CartItemViewModel
                {
                    Product = product,
                    Quantity = quantity,
                    Total = quantity * Convert.ToInt32(product.UnitPrice)
                });

                var jsonCartItems = JsonConvert.SerializeObject(cartItems, Formatting.None,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

                HttpCookie cartItemCookie = new HttpCookie("cartItemsCookie", jsonCartItems);

                Response.Cookies.Add(cartItemCookie);

                return RedirectToAction("Cart");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Cart()
        {
            var products = GetItemsCart();

            if (products.Count > 0)
            {
                return View(products);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult CheckOut()
        {
            try
            {
                var productsView = GetItemsCart();
                var products = new List<Product>();
                var total = 0;

                var order = new Order
                {
                    State = _service.GetState(1),
                    CreatedAt = DateTime.Now,
                };

                foreach (var item in productsView)
                {
                    total += (int)item.Product.UnitPrice * item.Quantity;
                    products.Add(item.Product);
                }

                order.TotalPrice = total;

                _service.addOrderProducts(order, products);
                clearCart();

                TempData["CompraOk"] = "Gracias por confiar en nosotros, nos comunicaremos por su pedido a la brevedad";
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View("Cart");
            }
        }

        private List<CartItemViewModel> GetItemsCart()
        {
            if (Request.Cookies["cartItemsCookie"] != null)
            {
                var itemsCart = new List<CartItemViewModel>();

                var json = Request.Cookies["cartItemsCookie"].Value;

                var products = JsonConvert.DeserializeObject<List<CartItemViewModel>>(json);

                return products;
            }
            else
            {
                return new List<CartItemViewModel>();
            }
        }

        private void clearCart()
        {
            if (Request.Cookies["cartItemsCookie"] != null)
            {
                HttpCookie myCookie = new HttpCookie("cartItemsCookie");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }
        }
    }
}
