using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.DataAccess.Entities;

namespace CarRental.ServicesContracts
{
    public interface IOrderService
    {
        IList<Order> GetAll();

        Order GetById(int id);

        void Create(Order order);

        void Delete(int id);

        void Edit(int id, Order order);
    }
}
