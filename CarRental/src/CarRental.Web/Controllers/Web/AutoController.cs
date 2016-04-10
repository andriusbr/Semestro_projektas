using Microsoft.AspNet.Mvc;

namespace CarRental.Web.Controllers.Web
{
    public class AutoController : Controller
    {      
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
            return View();
        }

        public IActionResult AutoEdit(int id)
        {
            ViewData["Title"] = "Automobilio redagavimas";
            ViewBag.autoId = id;
            return View();
        }
    }
}
