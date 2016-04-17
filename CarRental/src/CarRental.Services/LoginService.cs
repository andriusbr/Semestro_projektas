using CarRental.DataAccess;
using CarRental.DataAccess.Entities;
using CarRental.ServicesContracts;
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





        public string VerifyAccount(string _username, string _password)
        {
            /*bool isCorrect = dbContext.Logins.Any(e => e.UserName == _username && e.Password == Encode(_password));
            if (isCorrect)
            {
                var user = dbContext.Logins.FirstOrDefault(x => x.UserName == _username);
                if (user.Status.Equals(UserStatus.Admin))
                {
                    return UserStatus.Admin;
                }
                else if (user.Status.Equals(UserStatus.Master))
                {
                    return UserStatus.Master;
                }
                else
                {
                    return "Success";
                }
            }*/
            return "Error";
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


        /*public bool ChangePassword(string username, string currentPassword, string newPassword)
        {
            var user = dbContext.Logins.FirstOrDefault(x => x.Username == username && x.Password == Encode(currentPassword));
            if (user == null)
            {
                return false;
            }
            user.Password = Encode(newPassword);
            dbContext.SaveChanges();
            return true;
        }*/


        public void ChangeStatus(int id, string status)
        {
            var user = dbContext.Logins.FirstOrDefault(x => x.Id.Equals(id));
            //user.Status = status;
            dbContext.SaveChanges();
        }


        public void RemoveUser(int id)
        {
            var user = dbContext.Logins.FirstOrDefault(x => x.Id.Equals(id));
            dbContext.Logins.Remove(user);
            dbContext.SaveChanges();
        }

        public IEnumerable<User> SearchUsers(string SearchQuery)
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


        public static string Encode(string value)
        {
            var hash = System.Security.Cryptography.SHA1.Create();
            var encoder = new ASCIIEncoding();
            var combined = encoder.GetBytes(value ?? "");
            return BitConverter.ToString(hash.ComputeHash(combined)).ToLower().Replace("-", "");
        }

    }
}
