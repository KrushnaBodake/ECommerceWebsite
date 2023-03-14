using ECommerceWebsite.Models;
using ECommerceWebsite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices prodservice;
        private readonly ICategoryServices catservice;
        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment env;
        public ProductController(IProductServices prodservice, ICategoryServices catservice, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            this.prodservice = prodservice;
            this.catservice = catservice;
            this.env = env;
        }

        public ActionResult Index()
        {
            var Plist = prodservice.GetAllProduct();
            var Clist= catservice.GetAllCategories();
            foreach (Product p in Plist)
            {
                foreach (Category c in Clist)
                {
                    if(p.Catid== c.Catid)
                    {
                        p.Catname = c.Catname;
                    }                    
                }
            }
            return View(Plist);
        }

       


        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {

            var product = prodservice.GetProductById(id);
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var catagories = catservice.GetAllCategories();
            ViewBag.Catagories = catagories;
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product prod, IFormFile file)
        {
            using (var fs = new FileStream(env.WebRootPath + "\\Images\\" + file.FileName, FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fs);
            }
            prod.ImageUrl = "~/Images/" + file.FileName;
            int res = prodservice.AddProduct(prod);
            if (res == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var prod = prodservice.GetProductById(id);
            var categories = catservice.GetAllCategories();
            ViewBag.Categories = categories;
            HttpContext.Session.SetString("oldImageUrl", prod.ImageUrl);
            return View(prod);

        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product prod, IFormFile file)
        {
            string oldimageurl = HttpContext.Session.GetString("oldImageUrl");
            if (file != null)
            {
                using (var fs = new FileStream(env.WebRootPath + "\\Images\\" + file.FileName, FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fs);
                }
                prod.ImageUrl = "~/Images/" + file.FileName;

                string[] str = oldimageurl.Split("/");
                string str1 = (str[str.Length - 1]);
                string path = env.WebRootPath + "\\Images\\" + str1;
                System.IO.File.Delete(path);
            }
            else
            {
                prod.ImageUrl = oldimageurl;
            }
            int res = prodservice.UpdateProduct(prod);
            if (res == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }



        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = prodservice.GetProductById(id);
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = prodservice.DeleteProduct(id);
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
    }
}
