using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;
using System.Windows.Input;

namespace FahrzeugVerwaltung.UI
{
    public class VehicleViewModel
    {
        private Vehicle vehicle;
        private ICommand saveCommand;

        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleViewModel()
        {
            saveCommand = new RelayCommand(Save);
            vehicle = new Vehicle();
        }

        private void Save()
        {
            MessageBox.Show("");
        }

        /// <summary>
        /// Gets or sets a type of a <see cref="Vehicle"/>.
        /// </summary>
        public string Type { get => vehicle.Type; set => vehicle.Type = value; }

        /// <summary>
        /// Gets or sets a model of a <see cref="Vehicle"/>.
        /// </summary>
        public string Model { get => vehicle.Model; set => vehicle.Model = value; }

        /// <summary>
        /// Gets or sets a save command
        /// </summary>
        public ICommand SaveCommand { get => saveCommand; set => saveCommand = value; }

    }
}