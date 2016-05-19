using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Entities
{
    public class OrderLocation
    {
        public const string ParkingLot = "Aikštelė (Donelaičio g. 15)";
        public const string KaunasCity = "Kaunas";
        public const string KaunasAirport = "Kauno oro uostas";
        public const string VilniusCity = "Vilnius";
        public const string VilniusAirport = "Vilniaus oro uostas";

        public static readonly List<string> LocationList = new List<string>() {
            ParkingLot,
            KaunasCity,
            KaunasAirport,
            VilniusCity,
            VilniusAirport
        };
    }
}
