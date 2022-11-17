using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace FahrzeugVerwaltung.UI
{
    /// <summary>
    /// Interaction logic for VehicleInformation.xaml
    /// </summary>
    public partial class VehicleInfoDialog : Window
    {
        public VehicleInfoDialog()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            BindingOperations.GetBindingExpression((TextBox)this.FindName("InfoInput"), TextBox.TextProperty).UpdateSource();

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        public string Info { get; set; }
    }
}
