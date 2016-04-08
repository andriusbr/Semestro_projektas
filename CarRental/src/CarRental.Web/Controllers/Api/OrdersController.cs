using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CarRental.DataAccess.Entities;
using CarRental.ServicesContracts;

namespace CarRental.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            var orders = orderService.GetAll();

            return orders;
        }

        [HttpGet("{id}")]
        public Order Get(int id)
        {
            var order = orderService.GetById(id);

            return order;
        }

        [HttpPost]
        public void Post([FromBody]Order order)
        {
            orderService.Create(order);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Order order)
        {
            orderService.Edit(id, order);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            orderService.Delete(id);
        }
    }
}
