using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace FahrzeugVerwaltung.UI
{
    public class VehicleViewModel
    {
        private Vehicle vehicle;
        private ICommand saveCommand;
        private ICommand newCommand;
        private ICommand editCommand;
        private ICommand deleteCommand;
        private ObservableCollection<Vehicle> vehicles;
        int selectedVehicleIndex;

        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleViewModel()
        {
            saveCommand = new RelayCommand(Save);
            newCommand = new RelayCommand(New);
            editCommand = new RelayCommand(Edit);
            deleteCommand = new RelayCommand(Delete);
            vehicle = new Vehicle();
            vehicles = new ObservableCollection<Vehicle>();

            FillVehicleList();
            selectedVehicleIndex = -1;
        }

        private void FillVehicleList()
        {
            Random random = new Random();

            string[] types = { "PKW", "LKW" };

            // type -> brand
            Dictionary<string, string[]> brands = new Dictionary<string, string[]>();
            brands["PKW"] = new string[] { "VW" };
            brands["LKW"] = new string[] { "Mercedes" };

            // brand -> model
            Dictionary<string, string[]> models = new Dictionary<string, string[]>();
            models["VW"] = new string[] { "Käfer", "Polo", "Touran" };
            models["Mercedes"] = new string[] { "LKW1" };

            var vehicleCount = random.Next(3, 6);
            for (int i = 0; i < vehicleCount; i++)
            {
                vehicle.Type = types[random.Next(types.Length)];

                var brandList = brands[vehicle.Type];
                vehicle.Brand = brandList[random.Next(brandList.Length)];


                var modelList = models[vehicle.Brand];
                vehicle.Model = modelList[random.Next(modelList.Length)];

                vehicles.Add(vehicle);
                vehicle = new Vehicle();
            }
        }

        private void Save()
        {
            MessageBox.Show(string.Format("Es wurde folgendes Fahrzeug angelegt:\n{0}", vehicle));

            vehicles.Add(vehicle);
            vehicle = new Vehicle();
        }

        private void New()
        {

        }

        private void Edit()
        {

        }
        private void Delete()
        {
            if (selectedVehicleIndex > -1 && selectedVehicleIndex < vehicles.Count)
            {
                vehicles.RemoveAt(selectedVehicleIndex);
            }
            selectedVehicleIndex = -1;
        }

        /// <summary>
        /// Gets or sets a type of a <see cref="Vehicle"/>.
        /// </summary>
        public string Type { get => vehicle.Type; set => vehicle.Type = value; }

        /// <summary>
        /// Gets or sets a model of a <see cref="Vehicle"/>.
        /// </summary>
        public string Model { get => vehicle.Model; set => vehicle.Model = value; }

        public string Brand { get => vehicle.Brand; set => vehicle.Brand = value; }

        /// <summary>
        /// Gets or sets a save command
        /// </summary>
        public ICommand SaveCommand { get => saveCommand; set => saveCommand = value; }
        public ICommand NewCommand { get => newCommand; set => newCommand = value; }
        public ICommand EditCommand { get => editCommand; set => editCommand = value; }
        public ICommand DeleteCommand { get => deleteCommand; set => deleteCommand = value; }

        public ObservableCollection<Vehicle> VehicleList { get => vehicles; }

        public int SelectedVehicleIndex { get => selectedVehicleIndex; set => selectedVehicleIndex = value; }

    }
}