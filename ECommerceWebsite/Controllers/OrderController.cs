using ECommerceWebsite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerceWebsite.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace ECommerceWebsite.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderServices orderServices;
        private readonly IProductServices productServices;
        public OrderController(IOrderServices orderServices, IProductServices productServices)
        {
            this.orderServices = orderServices;
            this.productServices = productServices;
        }

        // GET: OrderController
        public ActionResult Index()
        {
            return View(orderServices.GetAllOrders());
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: OrderController/Create
        public ActionResult AddOrder()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrder(int id, IFormCollection form)
        {
            try
            {
                // We Also Use Foreach Loop like used in product Controller
                var product = productServices.GetProductById(id);
                Order orders = new Order();
                orders.ProdId = id;
                orders.Id = Convert.ToInt32(HttpContext.Session.GetString("Id"));
                orders.Qty = Convert.ToInt32(form["Qty"]);
                
                ViewBag.userid = HttpContext.Session.GetString("Id");

               /* product.Stock = (product.Stock - orders.Qty);
                Product prod = new Product();
                prod.Stock= product.Stock;
                prod.Prodid=product.Prodid;
                prod.Catid= product.Catid;
                int result1 = productServices.UpdateProduct(prod);
                if (result1 == 1)
                {
                    return RedirectToAction("Index", "Product");
                }*/

                int result = orderServices.AddOrder(orders);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();

            }
            catch
            {
                return View();
            }
        }
        // GET: OrderController/Create
       /* public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            try
            {
                int result = orderServices.AddOrder(order);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                return View();
            }
            return View();
        }*/

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
