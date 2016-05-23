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


        [Display(Name = "Pradžia")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Pabaiga")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Vardas")]
        public string FirstName { get; set; }

        [Display(Name = "Pavardė")]
        public string LastName { get; set; }


        [Display(Name = "El. paštas")]
        public string Email { get; set; }

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
