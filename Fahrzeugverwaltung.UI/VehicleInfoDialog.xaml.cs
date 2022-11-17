using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace FahrzeugVerwaltung.UI
{
    /// <summary>
    /// A simple dialog to edit the additional information
    /// (<see cref="FahrzeugVerwaltung.UI.Vehicle.Info"/>).
    /// </summary>
    public partial class VehicleInfoDialog : Window
    {
        /// <summary>
        /// Construct a new and empty dialog.
        /// </summary>
        public VehicleInfoDialog()
        {
            InitializeComponent();
            DataContext = this;
        }

        /// <summary>
        /// Save the user provided info for the vehicle and close the dialog.
        /// </summary>
        private void Save()
        {
            BindingOperations.GetBindingExpression(
               (TextBox)this.FindName("InfoInput"),
               TextBox.TextProperty
           ).UpdateSource();

            DialogResult = true;
        }

        /// <summary>
        /// Cancel the editing of the infp and close the dialog.
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
        /// The vehicle info being edited.
        /// </summary>
        public string Info { get; set; }
    }
}
