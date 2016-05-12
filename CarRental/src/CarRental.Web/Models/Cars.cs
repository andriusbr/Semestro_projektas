using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Web.Models
{
    public class Cars
    {
        public Cars(List<Car> CarList)
        {
            StartDate = null;
            EndDate = null;
            this.CarList = CarList;
        }

        public Cars(List<Car> CarList, DateTime StartDate, DateTime EndDate)
        {
            this.CarList = CarList;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<Car> CarList { get; set; }

        

    }
}
