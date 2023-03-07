using ECommerceWebsite.Models;
using ECommerceWebsite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace ECommerceWebsite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryServices services;
        public CategoryController(ICategoryServices services)
        {
            this.services = services;
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            return View(services.GetAllCategories());
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category =services.GetCategoryById(id);
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                int result = services.AddCategory(category);
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

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var cate = services.GetCategoryById(id);
            return View(cate);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            try
            {
                int result= services.UpdateCategory(category);
                if(result == 1)
                return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
            
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = services.GetCategoryById(id);
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result= services.DeleteCategory(id);
                if(result==1)
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            return View();
        }
    }
}
