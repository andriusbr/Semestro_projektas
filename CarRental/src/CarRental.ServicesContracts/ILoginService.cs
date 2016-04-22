using CarRental.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.ServicesContracts
{
    public interface ILoginService
    {
        IList<User> GetAll();

        User GetById(string id);
    }
}
