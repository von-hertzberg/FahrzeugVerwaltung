using System.Collections.Generic;
using System.Windows;

namespace FahrzeugVerwaltung.UI
{
    public partial class LoginDialog : Window
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool SaveLogin { get; set; }

        private Dictionary<string, string> users;

        public LoginDialog(Dictionary<string, string> users)
        {
            InitializeComponent();
            this.users = users;
            DataContext = this;
            SaveLogin = false;
            UserName = "";
            Password = "";
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (users.ContainsKey(UserName))
            {
                if (users[UserName] == Password)
                {
                    DialogResult = true;
                    return;
                }
            }

            Password = "";
            MessageBox.Show("Invalid password or username");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
