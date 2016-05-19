using CarRental.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Web.Models
{
    public class Cars
    {
        public Cars(IList<Auto> CarList)
        {
            StartDate = null;
            EndDate = null;
            this.CarList = CarList;
        }

        public Cars(IList<Auto> CarList, DateTime StartDate, DateTime EndDate)
        {
            this.CarList = CarList;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public IList<Auto> CarList { get; set; }

    }
}
