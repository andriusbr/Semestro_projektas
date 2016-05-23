using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CarRental.Web.Models;
using CarRental.DataAccess.Entities;
using Microsoft.AspNet.Mvc.Rendering;
using CarRental.DataAccess;
using CarRental.Services;
using Microsoft.AspNet.Authorization;

namespace CarRental.Web.Controllers.Web
{
    public class OrderController : Controller
    {
        private static LoginDbContext loginContext = new LoginDbContext();
        private static LoginService loginService = new LoginService(loginContext);

        private static AutoService autoService = new AutoService(new CarRentalDbContext());
        private static OrderService orderService = new OrderService(new CarRentalDbContext());

        [Authorize(Roles = UserStatus.Admin + "," + UserStatus.Master + "," + UserStatus.SuperAdmin)]
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

        [HttpGet]
        public IActionResult OrderSubmit(int id, DateTime? start, DateTime? end)
        {
            ViewData["Title"] = "Užsakymas";

            ViewBag.locations = OrderLocation.LocationList.Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.ToString(),
                                      Value = x.ToString()
                                  });
            Auto car = autoService.GetById(id);
            OrderSubmit orderSubmit = new OrderSubmit()
            {
                AutoId = car.AutoId,
                Car = car
            };
            if (User.Identity.IsAuthenticated)
            {
                User user = loginService.GetByUsername(User.Identity.Name);
                orderSubmit.FirstName = user.FirstName;
                orderSubmit.LastName = user.LastName;
                orderSubmit.Email = user.Email;
                orderSubmit.PhoneNumber = user.PhoneNumber;

                
            }
            orderSubmit.StartDate = start;
            orderSubmit.EndDate = end;

            return View(orderSubmit);
        }

        [HttpPost]
        public IActionResult OrderSubmit(OrderSubmit model)
        {
            ViewData["Title"] = "Užsakymas";
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(OrderController.OrderConfirm), "Order", 
                    new {
                        @autoId = model.AutoId,
                        @startDate = model.StartDate,
                        @endDate = model.EndDate,
                        @firstName = model.FirstName,
                        @lastName = model.LastName,
                        @email = model.Email,
                        @phone = model.PhoneNumber,
                        @pickup = model.PickUp,
                        @dropoff = model.DropOff,
                        @comments = model.Comments
                    });
            }

            ViewBag.locations = OrderLocation.LocationList.Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.ToString(),
                                      Value = x.ToString()
                                  });
            Auto car = autoService.GetById(model.AutoId);
            model.Car = car;
            return View(model);
        }

        [HttpGet]
        public IActionResult OrderConfirm(int autoId, DateTime startDate, DateTime endDate,
            string firstName, string lastName, string email, string phone,
            string pickup, string dropoff, string comments)
        {
            ViewData["Title"] = "Patvirtinimas";
            OrderConfirm confirmModel = new OrderConfirm()
            {
                AutoId = autoId,
                Car = autoService.GetById(autoId),
                StartDate = startDate,
                EndDate = endDate,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phone,
                PickUp = pickup,
                DropOff = dropoff,
                Comments = comments
            };
            return View(confirmModel);
        }

        [HttpPost]
        public IActionResult OrderConfirm(OrderConfirm model)
        {
            ViewData["Title"] = "Patvirtinimas";
            if (ModelState.IsValid)
            {
                DateTime start = new DateTime(model.StartDate.Year, model.StartDate.Month, model.StartDate.Day);
                DateTime end = new DateTime(model.EndDate.Year, model.EndDate.Month, model.EndDate.Day);
                TimeSpan difference = end - start;
                Order order = new Order()
                {
                    AutoId = model.AutoId,
                    OrderStart = model.StartDate,
                    OrderEnd = model.EndDate,
                    RentPlace = model.PickUp,
                    RentReturn = model.DropOff,
                    DayPrice = (decimal) GetDailyRate(model.AutoId, (int) difference.TotalDays),
                    Comments = model.Comments

                };
                orderService.Create(order);
                return RedirectToAction(nameof(OrderController.OrderSuccess), "Order");
            }

            ViewBag.locations = OrderLocation.LocationList.Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.ToString(),
                                      Value = x.ToString()
                                  });
            Auto car = autoService.GetById(model.AutoId);
            model.Car = car;
            return View(model);
        }

        public double GetDailyRate(int autoId, int duration)
        {
            if(duration == 0)
            {
                return (double)autoService.GetPrice(autoId, 1);
            }
            
            return (double)autoService.GetPrice(autoId, duration);
        }

        public bool IsAvailable(int id, DateTime startDate, DateTime endDate)
        {
            DateTime start = new DateTime(startDate.Year, startDate.Month, startDate.Day);
            DateTime end = new DateTime(endDate.Year, endDate.Month, endDate.Day);
            bool reslt = orderService.IsAvailable(id, start, end);
            return orderService.IsAvailable(id, start, end);
        }

        public IActionResult OrderSuccess()
        {
            return View();
        }
    }
}
