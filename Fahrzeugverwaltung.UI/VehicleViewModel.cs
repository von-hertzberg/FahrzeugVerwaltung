using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows.Input;

namespace FahrzeugVerwaltung.UI
{
    public class VehicleViewModel
    {
        public ObservableCollection<Vehicle> Vehicles { get; set; }

        public ICommand NewVehicleCommand { get; set; }
        public ICommand EditVehicleCommand { get; set; }
        public ICommand DeleteVehicleCommand { get; set; }

        public VehicleViewModel()
        {
            NewVehicleCommand = new RelayCommand(New);
            EditVehicleCommand = new RelayCommand(Edit);
            DeleteVehicleCommand = new RelayCommand(Delete);
            Vehicles = new ObservableCollection<Vehicle>();
        }

        private void Save()
        {
            var dialog = new SaveFileDialog();

            if (!dialog.ShowDialog().GetValueOrDefault(false))
                return;

            var json = JsonSerializer.Serialize(Vehicles);
            using (var file = File.CreateText(dialog.FileName))
            {
                file.Write(json);
            }
        }

        private void New()
        {
            var dialog = new VehicleDialog();
            dialog.ShowDialog();

            if (dialog.DialogResult.GetValueOrDefault(false))
            {
                Vehicles.Add(dialog.Vehicle);
            }
        }

        private void Edit()
        {
        }
        private void Delete()
        {
        }
    }
}