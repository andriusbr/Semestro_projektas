using CarRental.DataAccess;
using CarRental.DataAccess.Entities;
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
            Cars model = new Cars();
            model.CarList = autoService.GetAll();
            IList<decimal> PriceList = new List<decimal>();
            foreach (var car in model.CarList)
            {
                PriceList.Add(autoService.GetPrice(car.AutoId, 30));
            }
            model.PriceList = PriceList;
            model.Duration = 1;
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(Cars model)
        {
            DateTime start = new DateTime(model.StartDate.Value.Year, model.StartDate.Value.Month, model.StartDate.Value.Day);
            DateTime end = new DateTime(model.EndDate.Value.Year, model.EndDate.Value.Month, model.EndDate.Value.Day);
            DateTime now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            if (ModelState.IsValid && start < end && start != end && start >= now && end >= now)
            {
                model.CarList = autoService.GetAllFreeAuto(model.StartDate ?? DateTime.Now, model.EndDate ?? DateTime.Now);
                TimeSpan difference = end - start;
                int days = (int)Math.Ceiling(difference.TotalDays);
                model.PriceList = GetAvailableAutoPriceList(model.CarList, 30);
                model.Duration = days;
            }
            else
            {
                if (model.EndDate < model.StartDate) {
                    ModelState.AddModelError("Invalid date error", "Pabaigos data yra anksčiau negu pradžios");
                }
                else if (model.EndDate == model.StartDate)
                {
                    ModelState.AddModelError("Invalid date error", "Užsakymo trukmė turi būti bent viena diena");
                }
                else if (start < DateTime.Now || end < DateTime.Now)
                {
                    ModelState.AddModelError("Invalid date error", "Pasirinkta diena jau praėjo");
                }

                model.CarList = autoService.GetAll();
                model.PriceList = GetAvailableAutoPriceList(model.CarList, 30);
                model.Duration = 1;
            }
            
            return View(model);
        }

        private IList<decimal> GetAvailableAutoPriceList(IList<Auto> carList, int duration)
        {
            IList<decimal> PriceList = new List<decimal>();
            foreach (var car in carList)
            {
                var price = autoService.GetPrice(car.AutoId, duration);
                PriceList.Add(price);
            }
            return PriceList;
        }
    }
}
