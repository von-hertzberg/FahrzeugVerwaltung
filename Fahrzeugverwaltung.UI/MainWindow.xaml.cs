using System.Windows;

namespace FahrzeugVerwaltung.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class VehicleWindow : Window
    {
        public VehicleWindow()
        {
            InitializeComponent();
            DataContext = new VehicleViewModel(this);
        }
    }
}
