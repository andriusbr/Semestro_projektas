using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Web.Models
{
    public class AddPhoneNumber
    {
        [Required(ErrorMessage = "Įveskite telefono numerį")]
        [Display(Name = "Telefono numeris")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([+]?[0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3,6})$", ErrorMessage = "Netinkamas telefono numeris")]
        public string PhoneNumber { get; set; }
    }
}
