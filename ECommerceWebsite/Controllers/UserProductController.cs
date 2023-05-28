using ECommerceWebsite.Models;
using ECommerceWebsite.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace ECommerceWebsite.Controllers
{
    public class UserProductController : Controller
    {
        private readonly IUserServices services;
        private readonly IProductServices prodservice;
        private readonly ICategoryServices catservice;
        private readonly ICartServices cartservice;
        private readonly IUserServices userservices;
        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment env;
        public UserProductController(IUserServices userservices,ICartServices cartservice, IUserServices services, IProductServices prodservice, ICategoryServices catservice, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            this.userservices= userservices;
            this.services = services;
            this.prodservice = prodservice;
            this.catservice = catservice;
            this.cartservice = cartservice;
            this.env = env;
        }
        // GET: UserProductController1
        public ActionResult Index()
        {
            return View(prodservice.GetAllProduct());
        }
        public ActionResult CartById()
        {
            return View( cartservice.GetCartByUserid(Convert.ToInt32(HttpContext.Session.GetString("Id"))));
                                 
        }
        public ActionResult Addtocart(int id)
        {
            /* return View(cartservice.GetAllCart());*/
            var product = prodservice.GetProductById(id);
            Cart carts = new Cart();
            carts.Prodid = id;
            carts.Id = Convert.ToInt32(HttpContext.Session.GetString("Id"));
            ViewBag.userid = HttpContext.Session.GetString("Id");



            try
            {
                int result = cartservice.AddCart(carts);
                if (result == 1)
                    return RedirectToAction(nameof(CartById));
                else
                    return View();

            }
            catch
            {
                return View();
            }
        }
       
        // GET: UserProductController1/Details/5
        public ActionResult Details(int id)
        {

            var Plist = prodservice.GetAllProduct();
            var Clist = catservice.GetAllCategories();
            foreach (Product item in Plist)
            {
                if (item.Prodid == id)
                {
                    foreach (Category item1 in Clist)
                    {
                        if (item1.Catid == item.Catid)
                        {
                            ViewData["Name"] = item1.Catname;
                        }
                    }
                }
            }

            var product = prodservice.GetProductById(id);


            return View(product);

        }
      

        // GET: UserProductController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserProductController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: UserProductController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserProductController1/Edit/5
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

        // GET: UserProductController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserProductController1/Delete/5
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
        public ActionResult cart(int id)
        {

            var product = prodservice.GetProductById(id);
            return View(product);
        }
        
        public ActionResult CartIndex()
        {
            return View(cartservice.GetAllCart());
        }

    }

}   
