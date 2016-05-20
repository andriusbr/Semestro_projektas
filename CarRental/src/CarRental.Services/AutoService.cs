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

        public void Create(Auto auto, int[] prices)
        {
            AutoPrice price = new AutoPrice(dbContext);
            dbContext.Autos.Add(auto);
            dbContext.SaveChanges();
            for(int i = 0; i < prices.Length; i++)
            {
                price.AddPrice(auto.AutoId, prices[i], i);
            }          
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
            if (rentStart.Year == 1 || rentEnd.Year == 1)
                return null;

            OrderService order = new OrderService(dbContext);
            var autosId = order.GetFromInterval(rentStart, rentEnd);

                var freeAutos = dbContext.Autos
                .Where(aut => !autosId.Contains(aut.AutoId))
                .ToList();

            return freeAutos;
        }       

        public decimal GetPrice(int id, int duration)
        {
            var price = dbContext.Prices
                .Where(pr => id == pr.AutoId && duration >= pr.dayFrom && duration <= pr.dayEnd)
                .ToList();

            if(price.Count() == 0)
            {
                var priceLong = dbContext.Prices
                    .Where(pr => id == pr.AutoId && pr.dayEnd == 30)
                    .ToList();
                return priceLong[0].Value;
            }

            return price[0].Value;
        }

        public void ChangePrice(int autoId, int dayEnd, decimal price)
        {
            Price autoPrice = dbContext.Prices.Single(m => m.AutoId == autoId && m.dayEnd == dayEnd);
            autoPrice.Value = price;
            dbContext.Prices.Update(autoPrice);
            dbContext.SaveChanges();
        }
    }
}