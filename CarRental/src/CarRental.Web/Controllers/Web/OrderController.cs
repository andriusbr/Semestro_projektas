using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CarRental.Web.Models;

namespace CarRental.Web.Controllers.Web
{
    public class OrderController : Controller
    {
        public IActionResult OrderIndex()
        {
            ViewData["Title"] = "Užsakymai";
            return View();
        }

        public IActionResult OrderCreate()
        {
            ViewData["Title"] = "Naujas užsakymas";
            return View();
        }

        public IActionResult OrderDelete(int id)
        {
            ViewData["Title"] = "Užsakymo pašalinimas";
            ViewBag.orderId = id;
            return View();
        }

        public IActionResult OrderDetails(int id)
        {
            ViewData["Title"] = "Užsakymas detaliau";
            ViewBag.orderId = id;
            return View();
        }

        public IActionResult OrderEdit(int id)
        {
            ViewData["Title"] = "Užsakymo redagavimas";
            ViewBag.orderId = id;
            return View();
        }


        public IActionResult OrderSubmit(int id)
        {
            ViewData["Title"] = "Užsakymas";
            ViewBag.orderId = id;
            return View();
        }

        [HttpPost]
        public IActionResult OrderSubmit(OrderSubmit model)
        {
            
            return View(model);
        }
    }
}
