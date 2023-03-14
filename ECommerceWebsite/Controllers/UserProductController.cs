using ECommerceWebsite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    public class UserProductController : Controller
    {
        private readonly IProductServices prodservice;
        private readonly ICategoryServices catservice;
        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment env;
        public UserProductController(IProductServices prodservice, ICategoryServices catservice, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            this.prodservice = prodservice;
            this.catservice = catservice;
            this.env = env;
        }
        // GET: UserProductController1
        public ActionResult Index()
        {
            return View(prodservice.GetAllProduct());
        }

        // GET: UserProductController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
    }
}
