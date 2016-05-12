using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Web.Models
{
    public class ChangePassword
    {
        [Required(ErrorMessage = "Įveskite dabartinį slaptažodį")]
        [DataType(DataType.Password)]
        [Display(Name = "Dabartinis slaptažodis")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Įveskite naują slaptažodį")]
        [DataType(DataType.Password)]
        [Display(Name = "Naujas slaptažodis")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Pakartokite slaptažodį")]
        [DataType(DataType.Password)]
        [Display(Name = "Pakartokite slaptažodį")]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match.")]
        public string NewPasswordConfirm { get; set; }
    }
}
