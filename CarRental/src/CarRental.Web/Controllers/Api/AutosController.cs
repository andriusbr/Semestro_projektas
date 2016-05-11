using CarRental.DataAccess.Entities;
using CarRental.ServicesContracts;
using CarRental.Web.Models;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;

namespace CarRental.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class AutosController : Controller
    {
        private IHostingEnvironment _environment;

        private readonly IAutoService autoService;

        public AutosController(IAutoService autoService, IHostingEnvironment environment)
        {
            this.autoService = autoService;
            _environment = environment;
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

        [HttpPost]
        public async Task<string> PostPhot(IFormFile file)
        {
            string fileName = "";
            string uploads = Path.Combine(_environment.WebRootPath, "Uploads");            
                if (file.Length > 0)
                {
                    fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    await file.SaveAsAsync(Path.Combine(uploads, fileName));
                }
            return "{\"id\":\"" + fileName + "\"}";
        }
    }
}
