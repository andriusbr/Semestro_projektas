using CarRental.DataAccess.Entities;
using System.Collections.Generic;
using System;

namespace CarRental.ServicesContracts
{
    public interface IAutoService
    {
        IList<Auto> GetAll();

        Auto GetById(int id);

        void Create(Auto auto, int[] prices);

        void Delete(int id);

        void Edit(int id, Auto auto);

        IList<Auto> GetAllFreeAuto(DateTime rentStart, DateTime rentEnd);
    }
}