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
    }
}
