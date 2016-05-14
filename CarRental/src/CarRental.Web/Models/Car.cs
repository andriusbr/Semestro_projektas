using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Web.Models
{
    public class Car
    {
        public Car() { }

        public Car(int Id, string Photo, string Make, string Model)
        {
            this.Id = Id;
            this.Photo = Photo;
            this.Make = Make;
            this.Model = Model;
        }

        public int Id { get; set; }
        public string Photo { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
}
