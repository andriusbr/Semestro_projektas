using CarRental.DataAccess;
using CarRental.DataAccess.Entities;
using CarRental.ServicesContracts;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CarRental.Services
{
    public class AutoService : IAutoService
    {
        private readonly CarRentalDbContext dbContext;

        public AutoService(CarRentalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IList<Auto> GetAll()
        {
            var autos = dbContext.Autos.ToList();

            return autos;
        }

        public Auto GetById(int id)
        {
            var auto = dbContext.Autos.FirstOrDefault(x => x.AutoId == id);

            return auto;
        }

        public void Create(Auto auto)
        {          
            dbContext.Autos.Add(auto);
            dbContext.SaveChanges();           
        }

        public void Delete(int id)
        {
            Auto auto = dbContext.Autos.Single(m => m.AutoId == id);
            dbContext.Autos.Remove(auto);
            dbContext.SaveChanges();
        }

        public void Edit(int id, Auto auto)
        {
            auto.AutoId = id;
            dbContext.Autos.Update(auto);
            dbContext.SaveChanges();
        }

        public IList<Auto> GetAllFreeAuto(DateTime rentStart, DateTime rentEnd)
        {
            var autos = dbContext.Autos.ToList();
            List<Auto> freeAutos = new List<Auto>();
            foreach (var auto in autos)
                if (IsFree(auto.AutoId, rentStart, rentEnd))
                    freeAutos.Add(auto);

            return freeAutos;
        }

        bool IsFree(int id, DateTime rentStart, DateTime rentEnd)
        {
            if (rentStart.Year == 0001 || rentEnd.Year == 0001)
                return false;
            bool free = true;
            OrderService order = new OrderService(dbContext);
            IList<Order> orders = order.GetAll();
            foreach(var ord in orders)
            {
                if(id == ord.AutoId)
                {
                    if (rentStart.Date >= ord.OrderStart.Date && rentStart.Date <= ord.OrderEnd.Date || 
                        rentEnd.Date >= ord.OrderStart.Date && rentEnd.Date <= ord.OrderEnd.Date || 
                        rentStart.Date <= ord.OrderStart.Date && rentEnd.Date >= ord.OrderEnd.Date)
                    {
                        free = false;
                    }
                }
            }

            return free;
        }
    }
}