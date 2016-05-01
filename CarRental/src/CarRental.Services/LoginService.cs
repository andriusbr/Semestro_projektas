using CarRental.DataAccess;
using CarRental.DataAccess.Entities;
using CarRental.ServicesContracts;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public User GetById(string id)
        {
            var user = dbContext.Logins.FirstOrDefault(x => x.Id.Equals(id));

            return user;
        }




        public IList<string> GetUserRoles()
        {
            IList<string> list = new List<string>();
            var logins = dbContext.Logins.ToList();
            foreach(var login in logins)
            {
                var role = GetUserRole(login.Id);
                list.Add(role);
            }
            return list;
        }

        public IList<string> GetUserRoles(IEnumerable<User> users)
        {
            IList<string> list = new List<string>();
            foreach (var user in users)
            {
                var role = GetUserRole(user.Id);
                list.Add(role);
            }
            return list;
        }


        public IList<string> GetAllRoles()
        {
            IList<string> list = new List<string>();
            var roles = dbContext.Roles.ToList();
            foreach (var role in roles)
            {
                list.Add(role.Name);
            }
            return list;
        }




        public string AddUser(string _firstName, string _lastName, string _phone, string _email, string _username, string _password)
        {
            bool isEmailTaken = dbContext.Logins.Any(e => e.Email == _email);
            bool isUserNameTaken = dbContext.Logins.Any(e => e.UserName == _username);

            if(!isEmailTaken && !isUserNameTaken)
            {
                User user = new User()
                {
                    FirstName = _firstName,
                    LastName=_lastName,
                    PhoneNumber=_phone,
                    Email = _email,
                    UserName = _username/*,
                    Password = Encode(_password),
                    Status = UserStatus.Regular*/
                };
                dbContext.Add(user);
                dbContext.SaveChanges();
                return "Success";
            }
            
            else if (isEmailTaken)
            {
                return "Email already exists";
            }
            else if (isUserNameTaken)
            {
                return "Username already exists";
            }

            return "Error";
        }

        public bool isEmailTaken(string email)
        {
            return dbContext.Logins.Any(e => e.Email == email);
        }

        public bool ChangePhoneNumber(string id, string phone)
        {
            try {
                var user = dbContext.Logins.FirstOrDefault(x => x.Id.Equals(id));
                user.PhoneNumber = phone;
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }


        public string GetUserRole(string id)
        {
            var roleId = dbContext.UserRoles.Where(x => x.UserId == id).FirstOrDefault();
            if(roleId == null)
            {
                return "";
            }
            var role = dbContext.Roles.Where(x => x.Id == roleId.RoleId).FirstOrDefault();

            return role.Name;
        }


        public void ChangeStatus(string id, string status)
        {
            var newId = dbContext.Roles.FirstOrDefault(x => x.Name.Equals(status)).Id;
            var currId = dbContext.UserRoles.FirstOrDefault(x => x.UserId.Equals(id));
            if(currId != null)
            {
                dbContext.UserRoles.Remove(currId);
                
            }
            IdentityUserRole<string> userRole = new IdentityUserRole<string>();
            userRole.UserId = id;
            userRole.RoleId = newId;
            dbContext.UserRoles.Add(userRole);

            dbContext.SaveChanges();
        }


        public void RemoveUser(int id)
        {
            var user = dbContext.Logins.FirstOrDefault(x => x.Id.Equals(id));
            dbContext.Logins.Remove(user);
            dbContext.SaveChanges();
        }

        public IList<User> SearchUsers(string SearchQuery)
        {
            List<User> list = new List<User>();
            string SearchLower = SearchQuery.ToLower();
            foreach (var user in dbContext.Logins)
            {
                if (user.FirstName != null && user.FirstName.ToLower().Contains(SearchLower))
                {
                    list.Add(user);
                }
                else if (user.LastName != null && user.LastName.ToLower().Contains(SearchLower))
                {
                    list.Add(user);
                }
                else if (user.UserName != null && user.UserName.ToLower().Contains(SearchLower))
                {
                    list.Add(user);
                }
                else if(user.Email !=null && user.Email.ToLower().Contains(SearchLower))
                {
                    list.Add(user);
                }
                else if (user.Id.ToString().Contains(SearchLower))
                {
                    list.Add(user);
                }
                else if (user.PhoneNumber != null && user.PhoneNumber.Contains(SearchLower))
                {
                    list.Add(user);
                }
            }
            return list;
        }

        public bool RoleExists(string role)
        {
            return dbContext.Roles.Any(x => x.Name.Equals(role));
        }


        public static string Encode(string value)
        {
            var hash = System.Security.Cryptography.SHA1.Create();
            var encoder = new ASCIIEncoding();
            var combined = encoder.GetBytes(value ?? "");
            return BitConverter.ToString(hash.ComputeHash(combined)).ToLower().Replace("-", "");
        }

    }
}
