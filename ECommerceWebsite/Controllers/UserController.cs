using ECommerceWebsite.Models;
using ECommerceWebsite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices services;
        public UserController(IUserServices services)
        {
            this.services = services;
        }
        // GET: UserController
        public ActionResult Index()
        {
            return View(services.GetAllUser());
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
           var user= services.GetUserById(id);
            return View(user);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
               int result= services.AddUser(user);
                if(result == 1)
                return RedirectToAction(nameof(Login));
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            var user = services.GetUserById(id);
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            try
            {
                int result = services.UpdateUser(user);
                if (result == 1)
                    return RedirectToAction(nameof(Login));
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            var user = services.GetUserById(id);
            return View(user);
          
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = services.DeleteUser(id);
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
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            var list = services.GetAllUser();
            try
            {
                foreach (var l in list)
                {
                    if (l.RoleId == 1)
                    {
                        if ((l.Email == user.Email) && (l.Password == user.Password))
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                    else
                    {
                        if ((l.Email == user.Email) && (l.Password == user.Password))
                        {
                            return RedirectToAction("Index", "Product");
                        }
                    }

                }
            }
            catch
            {
                return View();
            }
            return View();


        }
    }
}
