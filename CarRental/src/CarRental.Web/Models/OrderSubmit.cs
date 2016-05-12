using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Web.Models
{
    public class OrderSubmit
    {
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([+]?[0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3,6})$", ErrorMessage = "Not a valid Phone number")]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }

        
        [Display(Name = "Pick Up Location")]
        public string PickUp { get; set; }

        
        [Display(Name = "Drop Off Location")]
        public string DropOff { get; set; }

        [Display(Name = "Comments (Optional)")]
        public string Comments { get; set; }

        [Display(Name ="If you selected one of the cities, please specify the location in the comments")]
        public string LocationComment { get; }
    }
}
