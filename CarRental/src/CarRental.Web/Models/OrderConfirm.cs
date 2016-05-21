using CarRental.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Web.Models
{
    public class OrderConfirm
    {
        public int AutoId { get; set; }
        public Auto Car { get; set; }
        public decimal Price { get; set; }


        //[Required(ErrorMessage = "Įveskite pradžios datą")]
        //[DataType(DataType.DateTime)]
        [Display(Name = "Pradžia")]
        public DateTime StartDate { get; set; }

        //[Required(ErrorMessage = "Įveskite pabaigos datą")]
        //[DataType(DataType.DateTime)]
        [Display(Name = "Pabaiga")]
        public DateTime EndDate { get; set; }

        //[Required(ErrorMessage = "Įveskite savo vardą")]
        //[Display(Name = "Vardas")]
        public string FirstName { get; set; }

        //[Required(ErrorMessage = "Įveskite savo pavardę")]
        [Display(Name = "Pavardė")]
        public string LastName { get; set; }


        //[Required(ErrorMessage = "Įveskite el. paštą")]
        //[EmailAddress]
        [Display(Name = "El. paštas")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Įveskite tel. numerį")]
        //[DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([+]?[0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3,6})$", ErrorMessage = "Netinkamas telefono numeris")]
        [Display(Name = "Telefono nr.")]
        public string PhoneNumber { get; set; }


        [Display(Name = "Pristatymo vieta")]
        public string PickUp { get; set; }


        [Display(Name = "Grąžinimo vieta")]
        public string DropOff { get; set; }

        [Display(Name = "Komentarai")]
        public string Comments { get; set; }

    }
}
