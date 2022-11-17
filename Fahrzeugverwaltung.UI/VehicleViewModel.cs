using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Input;

namespace FahrzeugVerwaltung.UI
{
    /// <summary>
    /// A view model to control the app.
    /// </summary>
    public class VehicleViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Whether or not the vehicle list or a vehicle was changed.
        /// </summary>
        private bool isDirty;
        /// <summary>
        /// The main window containing the app.
        /// </summary>
        private Window mainWindow;
        /// <summary>
        /// The index of the selected vehicle or -1 if no vehicles is selected.
        /// </summary>
        private int selectedIndex;
        /// <summary>
        /// The config used by the app.
        /// </summary>
        private Config config;

        /// <summary>
        /// Construct a new VehicleViewModel.
        /// </summary>
        /// <param name="mainWindow">The main window of the app.</param>
        public VehicleViewModel(Window mainWindow)
        {
            this.mainWindow = mainWindow;

            config = Config.Load("config.json");

            if (!PerformLogin())
            {
                mainWindow.Close();
                return;
            }

            if (config.VehicleListPath != "")
                Load(config.VehicleListPath);
            else
                Vehicles = new ObservableCollection<Vehicle>();

            InitCommands();

            isDirty = false;
            SelectedIndex = -1;

            mainWindow.Closing += OnExit;
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Load the user credential list from a 'users.json'.
        /// </summary>
        /// <returns>The loaded user credentials or an empty list when
        /// the file could not be opened.</returns>
        private Dictionary<string, string> LoadUsers()
        {
            try
            {
                var userJson = File.ReadAllText("users.json");
                return JsonSerializer.Deserialize<Dictionary<string, string>>(userJson);
            }
            catch (System.Exception)
            {
                return new Dictionary<string, string>();
            }
        }

        /// <summary>
        /// Display a login dialog and authenticate the user.
        /// </summary>
        /// <returns>True when login was successfull, otherwise false</returns>
        private bool PerformLogin()
        {
            var users = LoadUsers();

            if (config.Username.Length > 0 && config.Password.Length > 0)
            {
                if (users.ContainsKey(config.Username))
                    return users[config.Username] == config.Password;
                else
                    return false;
            }
            else
            {
                var loginDialog = new LoginDialog(users);
                if (!loginDialog.ShowDialog().GetValueOrDefault(false))
                {
                    return false;
                }

                if (loginDialog.SaveLogin)
                {
                    config.Password = loginDialog.Password;
                    config.Username = loginDialog.UserName;
                }
            }

            return true;
        }

        /// <summary>
        /// Initialize the commands exposed to xaml.
        /// </summary>
        private void InitCommands()
        {
            NewVehicleCommand = new RelayCommand(New);
            EditVehicleCommand = new RelayCommand(Edit);
            DeleteVehicleCommand = new RelayCommand(Delete);
            EditInfoCommand = new RelayCommand(EditInfo);
            LogoutCommand = new RelayCommand(Logout);
            ExitCommand = new RelayCommand(Exit);
            SaveCommand = new RelayCommand(Save);
            SaveAsCommand = new RelayCommand(SaveAs);
            LoadCommand = new RelayCommand(Load);
        }

        /// <summary>
        /// Creates a new vehicle using <see cref="FahrzeugVerwaltung.UI.VehicleDialog"/>.
        /// </summary>
        private void New()
        {
            var dialog = new VehicleDialog();
            dialog.ShowDialog();

            if (dialog.DialogResult.GetValueOrDefault(false))
            {
                Vehicles.Add(dialog.Vehicle);
                isDirty = true;
            }
        }

        /// <summary>
        /// Edit the selected vehicle using <see cref="FahrzeugVerwaltung.UI.VehicleDialog"/>.
        /// </summary>
        private void Edit()
        {
            if (SelectedIndex == -1)
            {
                MessageBox.Show("No vehicle selected");
                return;
            }

            var selectedVehicle = Vehicles[SelectedIndex];
            var dialog = new VehicleDialog((Vehicle)selectedVehicle.Clone());
            if (dialog.ShowDialog().GetValueOrDefault(false))
            {
                Vehicles[SelectedIndex] = dialog.Vehicle;
                isDirty = true;
            }
        }

        /// <summary>
        /// Edit the info of the selected vehicle using
        /// <see cref="FahrzeugVerwaltung.UI.VehicleInfoDialog"/>.
        /// </summary>
        private void EditInfo()
        {
            if (SelectedIndex == -1)
            {
                MessageBox.Show("No vehicle selected");
                return;
            }

            var dialog = new VehicleInfoDialog();
            dialog.Info = Vehicles[SelectedIndex].Info;
            if (dialog.ShowDialog().GetValueOrDefault(false))
            {
                Vehicles[SelectedIndex].Info = dialog.Info;
                isDirty = true;
            }
        }

        /// <summary>
        /// Delete the selected vehicle.
        /// </summary>
        private void Delete()
        {
            if (SelectedIndex == -1)
            {
                MessageBox.Show("No vehicle selected");
                return;
            }

            Vehicles.RemoveAt(SelectedIndex);
            isDirty = true;
        }

        /// <summary>
        /// Log the user out and close the app.
        /// </summary>
        private void Logout()
        {
            config.Username = "";
            config.Password = "";

            Exit();
        }

        /// <summary>
        /// Performs pre-exit tasks.
        /// 
        /// <list type="bullet">
        ///     <item>Prompt the user to save unsaved changes.</item>
        ///     <item>Save the config.</item>
        /// </list>
        /// </summary>
        private bool PrepareExit()
        {
            if (isDirty)
            {
                var result = MessageBox.Show("There are unsaved changes, save?", "Unsaved changes", MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Cancel:
                        return false;
                    case MessageBoxResult.Yes:
                        Save();
                        break;
                    default:
                        break;
                }
            }

            config.Save("config.json");

            return true;
        }

        /// <summary>
        /// Event handler for closing the window.
        /// </summary>
        private void OnExit(object sender, CancelEventArgs e)
        {
            e.Cancel = !PrepareExit();
        }

        /// <summary>
        /// Exit the app.
        /// </summary>
        private void Exit()
        {
            if (PrepareExit())
                mainWindow.Close();
        }

        /// <summary>
        /// Save the vehicle list.
        /// </summary>
        private void Save()
        {
            if (config.VehicleListPath == "")
                SaveAs();
            else
                Save(config.VehicleListPath);
        }

        /// <summary>
        /// Prompt the user for a location to save the vehicle list to
        /// and Save the vehicle list.
        /// </summary>
        private void SaveAs()
        {
            var dialog = new SaveFileDialog();

            dialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
            dialog.FilterIndex = 1;

            if (!dialog.ShowDialog().GetValueOrDefault(false))
                return;

            Save(dialog.FileName);

            config.VehicleListPath = dialog.FileName;
        }

        /// <summary>
        /// Save the vehicle list to a given file.
        /// </summary>
        /// <param name="filePath">The path of the file to save to.</param>
        private void Save(string filePath)
        {
            using (var file = File.CreateText(filePath))
            {
                var json = JsonSerializer.Serialize(Vehicles);
                file.Write(json);
                isDirty = false;
            }
        }

        /// <summary>
        /// Prompt the user for a file to load the vehicle list from and load it.
        /// </summary>
        private void Load()
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
            dialog.FilterIndex = 1;

            if (!dialog.ShowDialog().GetValueOrDefault(false))
                return;

            Load(dialog.FileName);
        }

        /// <summary>
        /// Load the vehicle list from a given file.
        /// </summary>
        /// <param name="filePath">The path of the file to load from.</param>
        private void Load(string filePath)
        {
            if (isDirty)
                Save();

            var fileContent = File.ReadAllText(filePath);
            var newVehicles = JsonSerializer.Deserialize<ObservableCollection<Vehicle>>(fileContent);

            if (Vehicles == null)
            {
                Vehicles = newVehicles;
                return;
            }
            else
            {
                Vehicles.Clear();
                foreach (var item in newVehicles)
                {
                    Vehicles.Add(item);
                }
            }

            isDirty = false;
            config.VehicleListPath = filePath;
        }

        /// <summary>
        /// The list of vehicles that are manged by the app.
        /// </summary>
        public ObservableCollection<Vehicle> Vehicles { get; set; }
        /// <summary>
        /// The command to create a new Vehicle.
        /// </summary>
        public ICommand NewVehicleCommand { get; set; }
        /// <summary>
        /// The command to edit the selected vehicle.
        /// </summary>
        public ICommand EditVehicleCommand { get; set; }
        /// <summary>
        /// The command to edit the info of the seleced vehicle.
        /// </summary>
        public ICommand EditInfoCommand { get; set; }
        /// <summary>
        /// The command to delete the selected vehicle.
        /// </summary>
        public ICommand DeleteVehicleCommand { get; set; }
        /// <summary>
        /// The command to log the user out and exit the app.
        /// </summary>
        public ICommand LogoutCommand { get; set; }
        /// <summary>
        /// The command to exit the app.
        /// </summary>
        public ICommand ExitCommand { get; set; }
        /// <summary>
        /// The command to save the vehicle list to disk.
        /// </summary>
        public ICommand SaveCommand { get; set; }
        /// <summary>
        /// The command to prompt the user for a save location
        /// and save the vehicle list.
        /// </summary>
        public ICommand SaveAsCommand { get; set; }
        /// <summary>
        /// The command to prompt the user for a location to load
        /// the vehicle lst from and load it.
        /// </summary>
        public ICommand LoadCommand { get; set; }
        /// <summary>
        /// The index of the currently selected vehicle.
        /// </summary>
        public int SelectedIndex
        {
            get => selectedIndex;

            set
            {
                IsVehicleSelected = value != -1;
                NotifyPropertyChanged("IsVehicleSelected");
                selectedIndex = value;
            }
        }
        /// <summary>
        /// Whether or not a vehicle is selected.
        /// </summary>
        public bool IsVehicleSelected { get; set; }
    }
}