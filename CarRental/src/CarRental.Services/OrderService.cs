using CarRental.DataAccess;
using CarRental.DataAccess.Entities;
using CarRental.ServicesContracts;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Services
{
    public class OrderService : IOrderService
    {
        private readonly CarRentalDbContext dbContext;

        public OrderService(CarRentalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IList<Order> GetAll()
        {
            var orders = dbContext.Orders.ToList();

            return orders;
        }

        public Order GetById(int id)
        {
            var order = dbContext.Orders.FirstOrDefault(x => x.OrderId == id);

            return order;
        }

        public void Create(Order order)
        {
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Order order = dbContext.Orders.Single(m => m.OrderId == id);
            dbContext.Orders.Remove(order);
            dbContext.SaveChanges();
        }

        public void Edit(int id, Order order)
        {
            order.OrderId = id;
            dbContext.Orders.Update(order);
            dbContext.SaveChanges();
        }
    }
}
