using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.TextFormatting;

namespace FahrzeugVerwaltung.UI
{
    /// <summary>
    /// A simple dialog to edit or create a <see cref="FahrzeugVerwaltung.UI.Vehicle"/>.
    /// </summary>
    public partial class VehicleDialog : Window
    {
        /// <summary>
        /// Construct a new dialog to edit the given vehicle.
        /// </summary>
        /// <param name="vehicle">The vehicle to edit.</param>
        public VehicleDialog(Vehicle vehicle)
        {
            InitializeComponent();

            this.Vehicle = vehicle;
            DataContext = Vehicle;
        }

        /// <summary>
        /// Construct a new dialog to create a new vehicle.
        /// </summary>
        public VehicleDialog() : this(new Vehicle())
        { }

        /// <summary>
        /// Check if the input for the vehicle is complete.
        /// </summary>
        /// <returns>Whether or not the input is complete.</returns>
        private bool IsInputComplete()
        {
            BindingOperations.GetBindingExpression((TextBox)this.FindName("TypeInput"), TextBox.TextProperty).UpdateSource();
            BindingOperations.GetBindingExpression((TextBox)this.FindName("BrandInput"), TextBox.TextProperty).UpdateSource();
            BindingOperations.GetBindingExpression((TextBox)this.FindName("ModelInput"), TextBox.TextProperty).UpdateSource();

            return !(Vehicle.Type is null ||
                Vehicle.Brand is null ||
                Vehicle.Model is null ||
                Vehicle.Type.Length == 0 ||
                Vehicle.Brand.Length == 0 ||
                Vehicle.Model.Length == 0);
        }

        /// <summary>
        /// Saves the vehicle data and closes the dialog when the input is complete.
        /// </summary>
        private void Save()
        {
            if (IsInputComplete())
            {
                MessageBox.Show("Input not complete");
            }
            else
            {
                DialogResult = true;
            }
        }

        /// <summary>
        /// Cancels the editing of the vehicle and closes the dialog.
        /// </summary>
        private void Cancel()
        {
            DialogResult = false;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Cancel();
        }

        /// <summary>
        /// The current vehicle being edited.
        /// </summary>
        public Vehicle Vehicle { get; set; }
    }
}
