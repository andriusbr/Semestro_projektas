﻿using CarRental.DataAccess;
using CarRental.Services;
using CarRental.ServicesContracts;
using CarRental.Web.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;

namespace CarRental.Web.Controllers.Web
{
    public class HomeController : Controller
    {
        private readonly IAutoService autoService = new AutoService(new CarRentalDbContext());

        [HttpGet]
        public IActionResult Index()
        {
            /*Car car = new Car(1, "http://cdn.rcstatic.com/images/car_images/new_images/kia/rio_lrg.jpg", "Kia", "Rio");
            Car car2 = new Car(2, "http://www.carstoti.com/wp-content/uploads/2014/08/white-2015-volkswagen-polo.jpg", "Volkswagen", "Polo");
            List<Car> cars = new List<Car>();
            cars.Add(car); cars.Add(car2);*/

            //Cars model = new Cars(cars/*, new DateTime(2016, 4, 4), new DateTime(2016, 4, 7)*/); 
            Cars model = new Cars();
            model.CarList = autoService.GetAll();
            IList<decimal> PriceList = new List<decimal>();
            foreach (var car in model.CarList)
            {
                PriceList.Add(autoService.GetPrice(car.AutoId, 1));
            }
            model.PriceList = PriceList;
            model.Duration = 1;
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(Cars model)
        {
            if (ModelState.IsValid && model.EndDate > model.StartDate)
            {
                model.CarList = autoService.GetAllFreeAuto(model.StartDate ?? DateTime.Now, model.EndDate ?? DateTime.Now);
                IList<decimal> PriceList = new List<decimal>();
                TimeSpan difference = (model.EndDate ?? DateTime.Now) - (model.StartDate ?? DateTime.Now);
                int days = (int)Math.Ceiling(difference.TotalDays);
                foreach (var car in model.CarList)
                {
                    var price = autoService.GetPrice(car.AutoId, days);
                    PriceList.Add(price);
                }
                model.PriceList = PriceList;
                model.Duration = days;
            }
            else
            {
                if(model.EndDate < model.StartDate){
                    ModelState.AddModelError("Invalid date error", "Pabaigos data yra anksčiau negu pradžios");
                }
                model.CarList = autoService.GetAll();
                IList<decimal> PriceList = new List<decimal>();
                foreach (var car in model.CarList)
                {
                    PriceList.Add(autoService.GetPrice(car.AutoId, 1));
                }
                model.PriceList = PriceList;
                model.Duration = 1;
            }
            
            return View(model);
        }
    }
}
