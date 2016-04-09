using CarRental.DataAccess;
using CarRental.DataAccess.Entities;
using CarRental.Services;
using CarRental.Web.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Security;

namespace CarRental.Web.Controllers.Web
{
    public class AccountController : Controller
    {
        //public object FormsAuthentication { get; private set; }
        private static LoginService service = new LoginService(new LoginDbContext());

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
        public ActionResult Login(Account user)
        {
            if (ModelState.IsValid)
            {
                string message = new LoginService(new LoginDbContext()).VerifyAccount(user.UserName, user.Password);
                if (message.Equals("Success"))
                {
                    //FormsAuthentication.SetAuthCookie(user.UserName, false/*user.RememberMe*/);
                    return RedirectToAction("Index", "Home");
                }
                else if (message.Equals(UserStatus.Admin))
                {
                    //FormsAuthentication.SetAuthCookie(user.UserName, false/*user.RememberMe*/);
                    return RedirectToAction("Admin", "Account");
                }
                else if (message.Equals(UserStatus.Master))
                {      
                    /*FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1,
                            user.UserName,
                            DateTime.Now,
                            DateTime.Now.AddHours(2),
                            false,
                            string.Empty);

                    // add cookie to response stream         
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    System.Web.HttpCookie authCookie = new System.Web.HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    if (authTicket.IsPersistent)
                    {
                        authCookie.Expires = authTicket.Expiration;
                    }
                    System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);*/
                    //FormsAuthentication.SetAuthCookie(user.UserName, false/*user.RememberMe*/);
                    return RedirectToAction("Master", "Account");
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
        public ActionResult Register(Register register)
        {
            if (ModelState.IsValid)
            {
                //new LoginService(new LoginDbContext())
                string message = new LoginService(new LoginDbContext()).AddUser(register.Email, register.UserName, register.Password);
                if (message.Equals("Success"))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", message);
                }
            }
            return View(register);
        }

        public IActionResult Admin()
        {
            return View();
        }

        

        public IActionResult Master()
        {
            //LoginService service = new LoginService(new LoginDbContext());
            //IList<User> list = service.GetAll();
            return View(/*service.GetAll()*/);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePassword change)
        {
            /*if (ModelState.IsValid)
            {
                if (service.ChangePassword(change.CurrentPassword,change.NewPassword))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect password");
                }
            }*/
            return View();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return service.GetAll();
        }
        
        public void ChangeUserStatus(int id, string value)
        {
            service.ChangeStatus(id, value);
            
        }


        public void RemoveUser(int id)
        {
            service.RemoveUser(id);
        }

        public IEnumerable<User> SearchUsers(string SearchQuery)
        {
            IEnumerable<User> list = service.SearchUsers(SearchQuery);
            return list;
        }


        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
