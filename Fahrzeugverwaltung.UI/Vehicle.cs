using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugVerwaltung.UI
{
    public class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }

        public override string ToString()
        {
            return string.Format("Typ: {0}, Marke: {1}, Modell: {2}", Type, Brand, Model);
        }
    }
}
