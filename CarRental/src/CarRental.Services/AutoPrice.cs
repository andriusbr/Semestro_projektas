using CarRental.DataAccess;
using CarRental.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Services
{
    public class AutoPrice
    {
        private readonly CarRentalDbContext dbContext;

        public AutoPrice(CarRentalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddPrice(int autoId, int autoPrice, int time)
        {
            Price price = new Price();
            price.AutoId = autoId;
            price.Value = autoPrice;
            switch (time)
            {
                case 0:
                    price.dayFrom = 0;
                    price.dayEnd = 2;
                    break;
                case 1:
                    price.dayFrom = 3;
                    price.dayEnd = 6;
                    break;
                case 2:
                    price.dayFrom = 7;
                    price.dayEnd = 13;
                    break;
                case 3:
                    price.dayFrom = 14;
                    price.dayEnd = 22;
                    break;
                case 4:
                    price.dayFrom = 23;
                    price.dayEnd = 30;
                    break;
            }
            dbContext.Prices.Add(price);
            dbContext.SaveChanges();
        }
    }
}
