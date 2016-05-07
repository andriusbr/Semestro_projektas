using CarRental.DataAccess.Entities;
using CarRental.ServicesContracts;
using CarRental.Web.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;

namespace CarRental.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class AutosController : Controller
    {
        private readonly IAutoService autoService;

        public AutosController(IAutoService autoService)
        {
            this.autoService = autoService;
        }

        [HttpGet]
        public IEnumerable<Auto> Get()
        {
            var autos = autoService.GetAll();

            return autos;
        }

        [HttpGet("{rentStart}/{rentEnd}")]
        public IEnumerable<Auto> GetFree(DateTime rentStart, DateTime rentEnd)
        {
            var autos = autoService.GetAllFreeAuto(rentStart, rentEnd);

            return autos;
        }

        [HttpGet("{id}")]
        public Auto Get(int id)
        {
            var auto = autoService.GetById(id);

            return auto;
        }

        [HttpGet("{id}/{duration}/{bla}")]
        public decimal Get(int id, int duration)
        {
            decimal price;
            price = autoService.GetPrice(id, duration);

            return price;
        }

        [HttpPost("{twoDays}/{sixDays}/{thirteenDays}/{twoTwoDays}/{thirtyDays}")]
        public void Post([FromBody]Auto value, int twoDays, int sixDays, 
            int thirteenDays, int twoTwoDays, int thirtyDays)
        {
            int[] prices = { twoDays, sixDays, thirteenDays, twoTwoDays, thirteenDays };
            autoService.Create(value, prices);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Auto value)
        {
            autoService.Edit(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            autoService.Delete(id);
        }
    }
}
