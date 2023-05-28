using ECommerceWebsite.Models;
using ECommerceWebsite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductServices prodservice;
        private readonly ICategoryServices catservice;
        private readonly ICartServices cartservice;
        private readonly IUserServices userservice;
        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment env;
        public CartController(IUserServices userservice,IProductServices prodservice, ICategoryServices catservice,ICartServices cartservice, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            this.prodservice = prodservice;
            this.catservice = catservice;
            this.cartservice = cartservice;
            this.userservice = userservice;
            this.env = env;
        }
        // GET: CartController
       

        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
           var cart= cartservice.GetCartById(id);
            return View(cart);
        }

        // GET: CartController/Create
        public ActionResult Create()
        {
            return View();

        }

        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cart cart)
        {
           
            try
            {
                int result = cartservice.AddCart(cart);
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

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
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

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            var cart = cartservice.GetCartById(id);
            return View(cart);
        }

        // POST: CartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = cartservice.DeleteCart(id);
                if (result == 1)
                    return RedirectToAction("CartIndex", "UserProduct");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
       

       
    }
}
