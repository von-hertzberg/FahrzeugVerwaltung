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
    public class VehicleViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool isDirty;
        private Window mainWindow;
        private int selectedIndex;
        private Config config;

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

        private void Logout()
        {
            config.Username = "";
            config.Password = "";

            Exit();
        }

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

        private void OnExit(object sender, CancelEventArgs e)
        {
            e.Cancel = !PrepareExit();
        }

        private void Exit()
        {
            if (PrepareExit())
                mainWindow.Close();
        }

        private void Save()
        {
            if (config.VehicleListPath == "")
                SaveAs();
            else
                Save(config.VehicleListPath);
        }

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

        private void Save(string filePath)
        {
            using (var file = File.CreateText(filePath))
            {
                var json = JsonSerializer.Serialize(Vehicles);
                file.Write(json);
                isDirty = false;
            }
        }

        private void Load()
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
            dialog.FilterIndex = 1;

            if (!dialog.ShowDialog().GetValueOrDefault(false))
                return;

            Load(dialog.FileName);
        }

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

        public ObservableCollection<Vehicle> Vehicles { get; set; }

        public ICommand NewVehicleCommand { get; set; }
        public ICommand EditVehicleCommand { get; set; }
        public ICommand EditInfoCommand { get; set; }
        public ICommand DeleteVehicleCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand SaveAsCommand { get; set; }
        public ICommand LoadCommand { get; set; }
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
        public bool IsVehicleSelected { get; set; }
    }
}