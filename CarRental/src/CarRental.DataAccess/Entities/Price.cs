using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Entities
{
    public class Price
    {
        public int PriceId { get; set; }
        public int AutoId { get; set; }
        public decimal Value { get; set; }
        public int dayFrom { get; set; }
        public int dayEnd { get; set; }
    }
}
