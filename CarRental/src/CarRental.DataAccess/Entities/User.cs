using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarRental.DataAccess.Entities
{
    public class User : IdentityUser
    {
        /*public override string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public override string Email { get; set; }
        public string Status { get; set; }
        public override string PhoneNumber { get; set; }*/
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsInRole(string role)
        {
            var result = Roles.Where(x => x.UserId == Id);
            if(result != null)
            {
                return true;
            }
            return false;
        }
        
    }
}
