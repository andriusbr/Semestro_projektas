using CarRental.DataAccess.Entities;
using System.Collections.Generic;

namespace CarRental.ServicesContracts
{
    public interface IAutoService
    {
        IList<Auto> GetAll();

        Auto GetById(int id);

        void Create(Auto auto);

        void Delete(int id);

        void Edit(int id, Auto auto);
    }
}
