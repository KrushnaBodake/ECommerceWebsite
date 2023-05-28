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
        // GET: ProductController/Index
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

                string[] str = oldimageurl.Split("/");    // ~   images   img.jpg
                string str1 = (str[str.Length - 1]);      // img.jpg
                string path = env.WebRootPath + "\\Images\\" + str1;    // img.jpg
                System.IO.File.Delete(path);     // img.jpg
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
