using System;

namespace FahrzeugVerwaltung.UI
{
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

        public string Type { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Info { get; set; }
        public bool InService { get; set; }
    }
}
