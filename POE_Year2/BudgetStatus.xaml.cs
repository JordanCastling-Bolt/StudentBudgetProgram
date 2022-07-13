using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using POE_Year2.DataStore;
using POE_Year2.DataStore.IDataStore;
using POE_Year2.Model;
using POE_Year2.ErrorMessages;

namespace POE_Year2
{
    public partial class BudgetStatus : Window
    {
        //Creating Objects From Interface
        private readonly IExpenseData _expenseList = new ExpenseData();
        private readonly IExpenseData _userIncome = new ExpenseData();

        //Variable Declaration
        private decimal userIncome;
        private decimal total;

        //Get And Set Methods
        public decimal UserIncome { get => userIncome; set => userIncome = value; }
        public decimal Total { get => total; set => total = value; }

        public BudgetStatus()
        {
            InitializeComponent();
            LoadExpenseList();
            LoadExpenseTotal();
            LoadTotalAfterExpense();
        }

        //Gets and Loads Expenses onto Page in Descending Order
        public void LoadExpenseList()
        {
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

        //Calculates and Displays The Total
        public void LoadExpenseTotal()
        {
            var newList =  _expenseList.GetExpenseCategoriesList();           
            foreach (Expenses x in newList)
            {
                Total += x.MonthlyBudget;
            }

            var newLabel = new TextBlock
            {
                Text = String.Format("Total Expenses:   R" + Total.ToString()),
            };
            var margin = newLabel.Margin;
            margin.Top = 5;
            newLabel.Margin = margin;
            newLabel.FontFamily = new System.Windows.Media.FontFamily("Courier New");

            StackPanel.Children.Add(newLabel);
        }

        //Calculates and Displays Income After Costs 
        public void LoadTotalAfterExpense()
        {
            var newIncome = _userIncome.GetIncomes();
            foreach (Incomes x in newIncome)
            {
                UserIncome = x.UsersIncome;
            }
            var newBlock = new TextBlock
            {
                Text = String.Format("Total after Expenses:   R" + (UserIncome-Total).ToString()),
            };           

            var margin = newBlock.Margin;
            margin.Top = 5;
            newBlock.Margin = margin;
            newBlock.FontFamily = new System.Windows.Media.FontFamily("Courier New");          
            StackPanel.Children.Add(newBlock);

            //Displays Warning if Expenses Is Bigger Than 75% Of Gross Income
            if (Total >= (UserIncome * 75/100))
            {
                MessageBox.Show(Messages.ExpenseWarning, "Failed",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else { }
        }

        //Exit Button Event Handler
        private void ExitBTN(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
