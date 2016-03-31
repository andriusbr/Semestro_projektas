using CarRental.DataAccess.Entities;
using CarRental.ServicesContracts;
using CarRental.Web.Models;
using Microsoft.AspNet.Mvc;
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

        [HttpGet("{id}")]
        public Auto Get(int id)
        {
            var auto = autoService.GetById(id);

            return auto;
        }

        [HttpPost]
        public void Post([FromBody]Auto value)
        {
            autoService.Create(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            autoService.Delete(id);
        }
    }
}
