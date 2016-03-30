using System;
using System.ComponentModel.DataAnnotations;

namespace CarRental.DataAccess.Entities
{
    public class Auto
    {
        public int AutoId { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public string PlateNumber { get; set; }
        public string Color { get; set; }
        public string DocumentNumber { get; set; }
        public float EngineCapicity { get; set; }
        public int Milleage { get; set; }
        public int MainBelt { get; set; }
        public int OilChange { get; set; }
        public DateTime TAEnd { get; set; }
        public DateTime InsurenceEnd { get; set; }
        public DateTime CascoInsurenceEnd { get; set; }
        public string AudioCode { get; set; }
        public string Comments { get; set; }
        public string FuelType { get; set; }
        public string Gearbox { get; set; }
        public bool Activity { get; set; }
    }
}
