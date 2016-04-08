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

        public User GetById(int id)
        {
            var user = dbContext.Logins.FirstOrDefault(x => x.Id == id);

            return user;
        }





        public string VerifyAccount(string _username, string _password)
        {
            bool isCorrect = dbContext.Logins.Any(e => e.Username == _username && e.Password == Encode(_password));
            if (isCorrect)
            {
                var user = dbContext.Logins.FirstOrDefault(x => x.Username == _username);
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
            }
            return "Error";
        }


        public string AddUser(string _email, string _username, string _password)
        {
            bool isEmailTaken = dbContext.Logins.Any(e => e.Email == _email);
            bool isUserNameTaken = dbContext.Logins.Any(e => e.Username == _username);

            if(!isEmailTaken && !isUserNameTaken)
            {
                User user = new User()
                {
                    Email = _email,
                    Username = _username,
                    Password = Encode(_password)
                };
                dbContext.Add(user);
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


        public bool ChangePassword(string username, string currentPassword, string newPassword)
        {
            var user = dbContext.Logins.FirstOrDefault(x => x.Username == username && x.Password == Encode(currentPassword));
            if (user == null)
            {
                return false;
            }
            user.Password = Encode(newPassword);
            dbContext.SaveChanges();
            return true;
        }


        public void ChangeStatus(int id, string status)
        {
            var user = dbContext.Logins.FirstOrDefault(x => x.Id == id);
            user.Status = status;
            dbContext.SaveChanges();
        }


        public void RemoveUser(int id)
        {
            var user = dbContext.Logins.FirstOrDefault(x => x.Id == id);
            dbContext.Logins.Remove(user);
            dbContext.SaveChanges();
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
