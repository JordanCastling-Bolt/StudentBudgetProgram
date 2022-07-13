using System.Windows;
using System.Windows.Input;
using POE_Year2.ErrorMessages;
using POE_Year2.DataStore;
using POE_Year2.DataStore.IDataStore;

namespace POE_Year2
{
 
    public partial class NewExpense : Window
    {
        //Object From Expense data
        private readonly IExpenseData _expenseData = new ExpenseData();

        public NewExpense()
        {
            InitializeComponent();
        }
        //OK Button Event Handler
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewList();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddNewList();
            }
        }
        //Adds Expense To List If Data Is Entered Correctly
        private void AddNewList()
        {
            if (string.IsNullOrEmpty(NewExpenseName.Text))
            {
                MessageBox.Show(Messages.MissingInfo, "Failed",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                DialogResult = false;
                return;
            }

            if (string.IsNullOrEmpty(NewExpenseBudget.Text))
            {
                MessageBox.Show(Messages.MissingBudget, "Failed",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                DialogResult = false;
                return;
            }

            var budgetValue = decimal.Parse(NewExpenseBudget.Text);
            var result = _expenseData.AddExpenseCategory(NewExpenseName.Text, budgetValue);
            DialogResult = result;
        }
    }
}
