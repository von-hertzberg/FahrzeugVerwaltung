using System;
using System.Text.Json.Serialization;

namespace FahrzeugVerwaltung.Shared
{
    public abstract class Vehicle : IEquatable<Vehicle>
    {
        public int Id { get; set; }
        public VehicleType VehicleType { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        //public string Color { get; set; }
        //public int Seats { get; set; }

        public override string ToString()
        {
            return string.Format("{3}: Ident: {0}, Marke: {1}, Modell: {2}", Id, Brand, Model, VehicleType.ToString());
        }

        public bool Equals(Vehicle other)
        {
            return VehicleType == other.VehicleType && Brand == other.Brand && Model == other.Model;
        }
    }
}
