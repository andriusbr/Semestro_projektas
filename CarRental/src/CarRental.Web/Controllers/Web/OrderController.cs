using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;


namespace CarRental.Web.Controllers.Web
{
    public class OrderController : Controller
    {
        public IActionResult OrderIndex()
        {
            return View();
        }

        public IActionResult OrderCreate()
        {
            return View();
        }

        public IActionResult OrderDelete(int id)
        {
            ViewBag.orderId = id;
            return View();
        }

        public IActionResult OrderDetails(int id)
        {
            ViewBag.orderId = id;
            return View();
        }

        public IActionResult OrderEdit(int id)
        {
            ViewBag.orderId = id;
            return View();
        }
    }
}
