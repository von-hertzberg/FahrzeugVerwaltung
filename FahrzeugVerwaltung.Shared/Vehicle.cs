using System;

namespace FahrzeugVerwaltung.Shared
{
    public class Vehicle
    {
        public int Id { get; set; }
        public VehicleType VehicleType { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Seats { get; set; }

    }
}
