using CarRental.Web.Models;
using Microsoft.AspNet.Mvc;

namespace CarRental.Web.Controllers.Web
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            Car model = new Car("Volkswagen", "Polo"); 
            return View();
        }
    }
}
