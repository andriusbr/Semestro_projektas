using CarRental.Web.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;

namespace CarRental.Web.Controllers.Web
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            Car car = new Car(1, "http://cdn.rcstatic.com/images/car_images/new_images/kia/rio_lrg.jpg", "Kia", "Rio");
            Car car2 = new Car(2, "http://www.carstoti.com/wp-content/uploads/2014/08/white-2015-volkswagen-polo.jpg", "Volkswagen", "Polo");
            List<Car> cars = new List<Car>();
            cars.Add(car); cars.Add(car2);
            Cars model = new Cars(cars, new DateTime(2016, 4, 4), new DateTime(2016, 4, 7)); 
            return View(model);
        }
    }
}
