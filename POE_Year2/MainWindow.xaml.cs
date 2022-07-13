using System.Windows;
using System.Windows.Controls;
using POE_Year2.ErrorMessages;
using POE_Year2.DataStore;
using POE_Year2.DataStore.IDataStore;
using System.Linq;
using System;

namespace POE_Year2
{
    public partial class MainWindow : Window
    {
        //Creating Object from Expense Data
        private readonly IExpenseData _expenseList= new ExpenseData();

        public MainWindow()

        {
            InitializeComponent();
            //Displays Income Dialog
            var newIncome = new Income();
            newIncome.ShowDialog();
        }
        //Adds Expenses To The MainPage In Decending Order 
        private void LoadExpenseLists()
        {
            RemoveStackPanelItems();
            var newList = _expenseList.GetExpenseCategoriesList();
            var result = newList.OrderByDescending(x => x.MonthlyBudget).ToList();

            foreach (var item in result)
            {
                var newLabel = new TextBlock
                {
                    Text = String.Format(item.Name + "           R" + item.MonthlyBudget + "\n").ToString(),
                };
                var margin = newLabel.Margin;
                margin.Top = 5;
                newLabel.Margin = margin;
                newLabel.FontFamily = new System.Windows.Media.FontFamily("Courier New");

                StackPanel.Children.Add(newLabel);
            }
        }

        private void RemoveStackPanelItems()
        {
            while (StackPanel.Children.Count > 0)
            {
                StackPanel.Children.RemoveAt(StackPanel.Children.Count - 1);
            }
        }
        //Handles When New Expense Is Clicked and Shows The Success Pop Up If The Expense Is Added 
        private void NewListItem_Click(object sender, RoutedEventArgs e)
        {
            var newList = new NewExpense();
            if (newList.ShowDialog() != true) return;
            MessageBox.Show(Messages.NewListAdded, "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
            LoadExpenseLists();
        }
        //Displays New Loan When New Loans Is Clicked
        private void Loans_Click(object sender, RoutedEventArgs e)
        {
            var newLoan = new NewLoan();
            newLoan.ShowDialog();
            LoadExpenseLists();
        }
        //Shows The Budget Report When Clicked
        private void BudgetReport_Click(object sender, RoutedEventArgs e)
        {
            var budgetReport = new BudgetStatus();
            budgetReport.ShowDialog();
            
        }
        //Shows The Savings Window When Clicked and Success Pop Up Shows If Added
        private void Savings_Click(object sender, RoutedEventArgs e)
        {
            var newSavings = new Savings();
            if (newSavings.ShowDialog() != true) return;
            MessageBox.Show(Messages.NewSavingsAdded, "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
            LoadExpenseLists();
        }
        //Exits MainPage Back To Register Page
        private void ExitItem_Click(object sender, RoutedEventArgs e)
        {
            var register = new Register();
            Close();
            register.Show();
        }
    }
}
