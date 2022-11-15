using System.Windows;

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
