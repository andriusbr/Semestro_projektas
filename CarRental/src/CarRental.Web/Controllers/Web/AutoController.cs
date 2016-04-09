using Microsoft.AspNet.Mvc;

namespace CarRental.Web.Controllers.Web
{
    public class AutoController : Controller
    {      
        public IActionResult AutoIndex()
        {
            return View();
        }

        public IActionResult AutoCreate()
        {
            return View();
        }

        public IActionResult AutoDelete(int id)
        {
            ViewBag.autoId = id;
            return View();
        }

        public IActionResult AutoDetails(int id)
        {
            ViewBag.autoId = id;
            return View();
        }

        public IActionResult AutoEdit(int id)
        {
            ViewBag.autoId = id;
            return View();
        }
    }
}
