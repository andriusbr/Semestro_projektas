using CarRental.DataAccess.Entities;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Mvc;
using System.IO;
using System.Web.UI;

namespace CarRental.Web.Controllers.Web
{
    public class AutoController : Controller
    {
        private IHostingEnvironment _environment;


        public AutoController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        [Authorize(Roles = UserStatus.Admin + "," + UserStatus.Master + "," + UserStatus.SuperAdmin)]
        public IActionResult AutoIndex()
        {
            ViewData["Title"] = "Automobiliai";
            return View();
        }

        public IActionResult AutoCreate()
        {
            ViewData["Title"] = "Naujas automobilis";
            return View();
        }

        public IActionResult AutoDelete(int id)
        {
            ViewData["Title"] = "Automobilio pašalinimas";
            ViewBag.autoId = id;
            return View();
        }

        public IActionResult AutoDetails(int id)
        {
            ViewData["Title"] = "Automobilis detaliau";
            ViewBag.autoId = id;
            ViewBag.adress = "/Uploads/";
            return View();
        }

        public IActionResult AutoEdit(int id)
        {
            ViewData["Title"] = "Automobilio redagavimas";
            ViewBag.autoId = id;
            ViewBag.adress = "/Uploads/";
            return View();
        }
    }
}
