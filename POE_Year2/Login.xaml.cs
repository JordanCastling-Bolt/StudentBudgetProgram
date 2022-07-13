using System.Windows;
using System.Windows.Input;
using POE_Year2.ErrorMessages;
using POE_Year2.DataStore;
using POE_Year2.DataStore.IDataStore;

namespace POE_Year2
{

    public partial class Login
        {
        //Creating Object From User Data
            private readonly IUserData _userData = new UserData();

            public Login()
            {
                InitializeComponent();
            
            }
        //Handles The Register Button Event
            private void Register_BTN(object sender, RoutedEventArgs e)
            {
                var register = new Register();
                register.Show();
                Close();
            }
        //Handles The Login Button Event
            private void LoginButton_BTN(object sender, RoutedEventArgs e)
            {
                LoginUser();
            }
        //Handles When User Presses Enter 
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Enter)
                {
                    LoginUser();
                }
            }
        //Checks If Data Is Entered Correctly And If User Is Registered To Login  
            private void LoginUser()
            {
                if (string.IsNullOrEmpty(UserName.Text) || string.IsNullOrEmpty(PasswordText.Password))
                {
                    MessageBox.Show(Messages.MissingInfo, "Failed",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var result = _userData.CheckLogin(UserName.Text, PasswordText.Password);
                if (result != null)
                {
                    SessionInfo.UserId = result.Id;               
                var  mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
                else
                {
                    MessageBox.Show(Messages.WrongLogin, "Failed",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    ClearFields();
                }
            }

            private void ClearFields()
            {
                UserName.Text = "";
                PasswordText.Password = "";
            }

       
    }
    }
