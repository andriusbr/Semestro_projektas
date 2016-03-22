using CarRental.DataAccess;
using CarRental.DataAccess.Entities;
using CarRental.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Services
{
    public class LoginService : ILoginService
    {
        private readonly LoginDbContext dbContext;

        public LoginService(LoginDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IList<User> GetAll()
        {
            var logins = dbContext.Logins.ToList();

            return logins;
        }

        public User GetById(int id)
        {
            var user = dbContext.Logins.FirstOrDefault(x => x.Id == id);

            return user;
        }
    }
}
