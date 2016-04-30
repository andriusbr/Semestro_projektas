using CarRental.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Web.Models
{
    public class Master
    {
        public Master(IList<User> Users, IList<string> UserRoles, IList<string> Roles)
        {
            this.Users = Users;
            this.UserRoles = UserRoles;
            this.Roles = Roles;
        }

        public IList<User> Users { get; set; }
        public IList<string> UserRoles { get; set; }
        public IList<string> Roles { get; set; }
    }
}
