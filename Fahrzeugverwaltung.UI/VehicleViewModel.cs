using System.Windows;

namespace Fahrzeugverwaltung.UI
{
    public class VehicleViewModel
    {
        private Vehicle vehicle;

        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleViewModel()
        {
            vehicle = new Vehicle();
        }

        public string Type { get => vehicle.Type; set => vehicle.Type = value; }
        public string Model { get => vehicle.Model; set => vehicle.Model = value; }

    }
}