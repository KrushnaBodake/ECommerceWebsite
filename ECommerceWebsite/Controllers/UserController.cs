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
            User u = services.GetUserByEmail(user.Email);

            try
            {
                if (u != null)
                {
                    if (user.Password == u.Password)
                    {
                        HttpContext.Session.SetString("RoleId", u.RoleId.ToString());
                        HttpContext.Session.SetString("Id", u.Id.ToString());
                        HttpContext.Session.SetString("UserName",u.Email);
                        TempData["username"]= HttpContext.Session.GetString("UserName");
                        TempData.Keep("username");
                        if (u.RoleId == 1)
                        {
                            return RedirectToAction("Index","Product");
                        }
                        else
                        {
                            return RedirectToAction("Index", "UserProduct");
                        }
                    }
                    else
                    {
                        ViewBag.errormessage = "Username or password is wrong";
                        return View();
                    }
                    
                }
                else
                {
                    ViewBag.errormessag = "you dont have a Account Please Register";
                    return View();
                }
            }
            catch
            {
                return View();
            }
            


        }
        public ActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
    }
}
