using System.Windows;
using System.Windows.Input;
using POE_Year2.DataStore;
using POE_Year2.DataStore.IDataStore;
using POE_Year2.ErrorMessages;

namespace POE_Year2
{
    
    public partial class Register
    {
        //Oject From User Data
        private readonly IUserData _userData = new UserData();

        public Register()
        {
            InitializeComponent();
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Login_Clicked(object sender, RoutedEventArgs e)
        {
            NavigateToLogin();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterUser();
        }
        //Goes to Login
        private void NavigateToLogin()
        {
            var login = new Login();
            login.Show();
            Close();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RegisterUser();
            }
        }
        //Checks Data and Registers User
        private void RegisterUser()
        {
            if (string.IsNullOrEmpty(UserName.Text) || string.IsNullOrEmpty(PasswordText.Password))
            {
                MessageBox.Show(Messages.MissingInfo, "Failed",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var result = _userData.RegisterUser(UserName.Text, PasswordText.Password);
            if (result)
            {
                NavigateToLogin();
            }
            else
            {
                MessageBox.Show(Messages.SomethingWrong, "Failed",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
