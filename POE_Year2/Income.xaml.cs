using System.Windows;
using System.Windows.Input;
using POE_Year2.DataStore;
using POE_Year2.DataStore.IDataStore;
using POE_Year2.ErrorMessages;
namespace POE_Year2
{
    public partial class Income : Window
    {
        //Variable Declaration
        private decimal userIncome;

        private readonly IExpenseData _expenseData = new ExpenseData();

        public Income()
        {
            InitializeComponent();
        }

        //Getters and Setters
        public decimal UserIncome { get => userIncome; set => userIncome = value; }

        //Handles the OK Button Click Event
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {          
            AddNewIncome();
            this.Close();
        }
        //Handles When User Presses Enter 
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddNewIncome();
            }
        }
        //Adds The User Income 
        public void AddNewIncome()
        {   try
            {
                UserIncome = decimal.Parse(NewIncome.Text);
            } 
            catch 
            {
                MessageBox.Show(Messages.MissingInfo, "Failed",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var result = _expenseData.User_Income(UserIncome);
            DialogResult = result;
        }
    }
}
