using ECommerceWebsite.Models;
using ECommerceWebsite.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ECommerceWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductServices prodservice;
        private readonly ICategoryServices catservice;
        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment env;
        public HomeController(IProductServices prodservice, ICategoryServices catservice, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            this.prodservice = prodservice;
            this.catservice = catservice;
            this.env = env;
        }

        public IActionResult Index()
        {
            return View(prodservice.GetAllProduct());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}