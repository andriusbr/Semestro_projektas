using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int AutoId { get; set; }
        public DateTime OrderStart { get; set; }
        public DateTime OrderEnd { get; set; }
        public string RentPlace { get; set; }
        public string RentReturn { get; set; }
        public decimal DayPrice { get; set; }
        public string DeliveryPrice { get; set; }
        public string Comments { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Confirmed { get; set; }
    }
}
