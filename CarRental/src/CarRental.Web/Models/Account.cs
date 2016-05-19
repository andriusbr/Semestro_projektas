using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CarRental.Web.Models
{
    public class Account
    {
        [Required(ErrorMessage = "Įveskite prisijungimą")]
        [Display(Name = "Prisijungimas")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Įveskite slaptažodį")]
        [DataType(DataType.Password)]
        [Display(Name = "Slaptažodis")]
        public string Password { get; set; }

        [Display(Name = "Prisiminti mane")]
        public bool RememberMe { get; set; }
    }
}
