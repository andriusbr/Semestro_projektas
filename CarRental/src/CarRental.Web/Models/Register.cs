using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Web.Models
{
    public class Register
    {

        [Required(ErrorMessage = "Įveskite savo vardą")]
        [Display(Name = "Vardas")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Įveskite savo pavardę")]
        [Display(Name = "Pavardė")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Įveskite el. paštą")]
        [EmailAddress]
        [Display(Name = "El. paštas")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Įveskite prisijungimą")]
        [StringLength(100, ErrorMessage = "{0} turi būti sudarytas bent iš {2} simbolių.", MinimumLength = 6)]
        [Display(Name = "Prisijungimas")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Įveskite slaptažodį")]
        [StringLength(100, ErrorMessage = "{0} turi būti sudarytas bent iš {2} simbolių.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Slaptažodis")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Pakartokite slaptažodį")]
        [DataType(DataType.Password)]
        [Display(Name = "Pakartokite slaptažodį")]
        [Compare("Password", ErrorMessage = "Slaptažodžiai nesutampa.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([+]?[0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3,6})$", ErrorMessage = "Not a valid Phone number")]
        [Display(Name = "Telefono nr.")]
        public string PhoneNumber { get; set; }


    }
}
