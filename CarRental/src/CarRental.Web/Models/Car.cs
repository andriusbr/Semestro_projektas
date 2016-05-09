using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Web.Models
{
    public class Car
    {
        public Car(string Make, string Model)
        {
            this.Make = Make;
            this.Model = Model;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        

    }
}
