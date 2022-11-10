using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FahrzeugVerwaltung.UI
{
    /// <summary>
    /// Interaction logic for VehicleDialog.xaml
    /// </summary>
    public partial class VehicleDialog : Window
    {
        public Vehicle Vehicle { get; set; }

        public VehicleDialog(Vehicle vehicle)
        {
            InitializeComponent();

            this.Vehicle = vehicle;
            DataContext = Vehicle;
        }

        public VehicleDialog() : this(new Vehicle())
        { }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (Vehicle.Type is null ||
                Vehicle.Brand is null ||
                Vehicle.Model is null ||
                Vehicle.Type == string.Empty ||
                Vehicle.Brand == string.Empty ||
                Vehicle.Model == string.Empty)
            {
                MessageBox.Show("Input not complete");
            }
            else
            {
                DialogResult = true;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
