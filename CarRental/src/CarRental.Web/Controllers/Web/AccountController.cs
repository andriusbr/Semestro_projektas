using CarRental.DataAccess;
using CarRental.Web.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CarRental.Web.Controllers.Web
{
    public class AccountController : Controller
    {
        //public object FormsAuthentication { get; private set; }

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
        public ActionResult Login(Models.Account user)
        {
            if (ModelState.IsValid)
            {
                string message = user.VerifyAccount(user.UserName, user.Password);
                if (message.Equals("Success"))
                {
                    //FormsAuthentication.SetAuthCookie(user.UserName, user.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else if (message.Equals("Admin"))
                {
                    return RedirectToAction("Admin", "Account");
                }
                else if (message.Equals("Master"))
                {
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
        public ActionResult Register(Models.Register register)
        {
            if (ModelState.IsValid)
            {
                string message = register.addUser(register.Email, register.UserName, register.Password);
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
            //List<User> users = new List<User>();
            //User user = new User { Id = 1, Username = "aa", Password = "aa", Email = "fdg", Status = "g" };
            //users.Add(user);
            return View(LoadValues());
        }

        public List<User> LoadValues()
        {
            List<User> users = new List<User>();
            SqlConnection cn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [User]", cn);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            using (SqlDataReader read = cmd.ExecuteReader())
            {
                while (read.Read())
                {
                    User user = new User();
                    user.Id = (int)read["Id"];
                    user.Username = (read["Username"].ToString());
                    user.Email = (read["Email"].ToString());
                    user.Status = (read["Status"].ToString());
                    users.Add(user);
                }
            }
            return users;
        }

        public ActionResult Logout()
        {
            //FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
