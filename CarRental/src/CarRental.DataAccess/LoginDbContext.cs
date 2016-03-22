using CarRental.DataAccess.Entities;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.DataAccess
{
    public class LoginDbContext : DbContext
    {
        public DbSet<User> Logins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;");
        }
    }
}
