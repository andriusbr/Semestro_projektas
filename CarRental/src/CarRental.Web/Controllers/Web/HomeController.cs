using Microsoft.AspNet.Mvc;

namespace CarRental.Web.Controllers.Web
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Automobiliai()
        {
            return View();
        }

        public IActionResult AutoCreate()
        {
            return View();
        }
    }
}
