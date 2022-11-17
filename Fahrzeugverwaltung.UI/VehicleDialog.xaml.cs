using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.TextFormatting;

namespace FahrzeugVerwaltung.UI
{
    /// <summary>
    /// Interaction logic for VehicleDialog.xaml
    /// </summary>
    public partial class VehicleDialog : Window
    {
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
            BindingOperations.GetBindingExpression((TextBox)this.FindName("TypeInput"), TextBox.TextProperty).UpdateSource();
            BindingOperations.GetBindingExpression((TextBox)this.FindName("BrandInput"), TextBox.TextProperty).UpdateSource();
            BindingOperations.GetBindingExpression((TextBox)this.FindName("ModelInput"), TextBox.TextProperty).UpdateSource();

            if (Vehicle.Type is null ||
                Vehicle.Brand is null ||
                Vehicle.Model is null ||
                Vehicle.Type.Length == 0 ||
                Vehicle.Brand.Length == 0 ||
                Vehicle.Model.Length == 0)
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

        public Vehicle Vehicle { get; set; }
    }
}
