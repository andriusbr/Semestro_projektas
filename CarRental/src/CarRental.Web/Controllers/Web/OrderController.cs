﻿using System;
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
        public IActionResult OrderSubmit(int id, DateTime? start, DateTime? end, decimal price)
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
            orderSubmit.Price = price;

            return View(orderSubmit);
        }

        [HttpPost]
        public IActionResult OrderSubmit(OrderSubmit model)
        {
            if (ModelState.IsValid)
            {
                Order order = new Order()
                {
                    AutoId = model.AutoId,
                    OrderStart = model.StartDate ?? DateTime.Now,
                    OrderEnd = model.EndDate ?? DateTime.Now,
                    RentPlace = model.PickUp,
                    RentReturn = model.DropOff,
                    DayPrice = model.Price,
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

        public IActionResult OrderSuccess()
        {
            return View();
        }
    }
}
