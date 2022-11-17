using System;

namespace FahrzeugVerwaltung.UI
{
    /// <summary>
    /// A simple class to store information about a vehicle.
    /// </summary>
    public class Vehicle : ICloneable
    {
        public override string ToString()
        {
            return string.Format("Typ: {0}, Marke: {1}, Modell: {2}", Type, Brand, Model);
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// The type of the vehicle.
        /// e.g. PKW, LKW
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// The brand of the vehicle.
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// The model of the vehicle.
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// Whether the vehicle is currently under repair.
        /// </summary>
        public bool UnderRepair { get; set; }
        /// <summary>
        /// A string containing additional info defined by the user.
        /// </summary>
        public string Info { get; set; }
    }
}
