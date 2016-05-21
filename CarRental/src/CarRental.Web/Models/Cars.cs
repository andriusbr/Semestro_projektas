using CarRental.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Web.Models
{
    public class Cars
    {
        public Cars() { }

        [Required(ErrorMessage = "Įveskite pabaigos datą")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Pradžia")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Įveskite pabaigos datą")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Pabaiga")]
        public DateTime? EndDate { get; set; }

        public IList<Auto> CarList { get; set; }

        public int Duration { get; set; }

        public IList<decimal> PriceList { get; set; }

    }
}
