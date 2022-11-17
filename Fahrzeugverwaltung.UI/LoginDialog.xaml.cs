using System.Collections.Generic;
using System.Windows;

namespace FahrzeugVerwaltung.UI
{
    /// <summary>
    /// A simple dialog used for user authentication.
    /// </summary>
    public partial class LoginDialog : Window
    {
        /// <summary>
        /// The allowed user credentials.
        /// </summary>
        private Dictionary<string, string> users;

        /// <summary>
        /// Construct a new login dialog.
        /// </summary>
        /// <param name="users">The allowed user credentials.</param>
        public LoginDialog(Dictionary<string, string> users)
        {
            InitializeComponent();
            this.users = users;
            DataContext = this;
            SaveLogin = false;
            UserName = "";
            Password = "";
        }

        /// <summary>
        /// Checks if the given username and password are valid.
        /// If they are valid the dialog will be closed otherwise
        /// the user will be notified.
        /// </summary>
        private void Authenticate()
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

        /// <summary>
        /// Cancels the user authentication.
        /// </summary>
        private void Cancel()
        {
            DialogResult = false;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Authenticate();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Cancel();
        }

        /// <summary>
        /// The username the user has input.
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// The password the user has input.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Controls whether the user credentials should be saved to
        /// skip the login on the next app startup.
        /// </summary>
        public bool SaveLogin { get; set; }
    }
}
