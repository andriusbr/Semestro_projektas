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
        [Display(Name = "Pradžia")]
        public DateTime? StartDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Pabaiga")]
        public DateTime? EndDate { get; set; }

        [Required]
        [Display(Name = "Vardas")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Pavardė")]
        public string LastName { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "El. paštas")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([+]?[0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3,6})$", ErrorMessage = "Not a valid Phone number")]
        [Display(Name = "Telefono nr.")]
        public string PhoneNumber { get; set; }

        
        [Display(Name = "Pristatymo vieta")]
        public string PickUp { get; set; }

        
        [Display(Name = "Grąžinimo vieta")]
        public string DropOff { get; set; }

        [Display(Name = "Komentarai")]
        public string Comments { get; set; }

        [Display(Name ="Jei pasirinkote vieną iš miestų, prašom nurodyti tikslią vietą komentaruose")]
        public string LocationComment { get; }
    }
}
