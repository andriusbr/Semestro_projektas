using CarRental.DataAccess;
using CarRental.DataAccess.Entities;
using CarRental.ServicesContracts;
using System.Collections.Generic;
using System.Linq;

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
    }
}
