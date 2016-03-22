using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Web.Controllers.Web
{
    public class AccountController : Controller
    {
        public object FormsAuthentication { get; private set; }

        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.User user)
        {
            if (ModelState.IsValid)
            {
                if (user.IsValid(user.UserName, user.Password))
                {
                    //FormsAuthentication.SetAuthCookie(user.UserName, user.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Models.Register register)
        {
            if (ModelState.IsValid)
            {
                if (register.addUser(register.Email, register.UserName, register.Password))
                {
                    //FormsAuthentication.SetAuthCookie(user.UserName, user.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Account already exists!");
                }
            }
            return View(register);
        }

        public ActionResult Logout()
        {
            //FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
