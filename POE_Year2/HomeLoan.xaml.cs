using System.Windows;
using POE_Year2.DataStore;
using POE_Year2.DataStore.IDataStore;
using POE_Year2.ErrorMessages;
using POE_Year2.Model;

namespace POE_Year2
{
    public partial class HomeLoan : Window
    {
        //Variable Declaration
        private static decimal homePrice;
        private static decimal homeDeposit;
        private static decimal homeInterestRate;
        private static decimal homeMTR;
        private static decimal loanInterest;
        private static decimal loanMonths;
        private static decimal totHomeInterest;
        private static decimal homeloanRepayment;
        private decimal userIncome;
        //Objects from Interface
        private readonly IExpenseData _expenseData = new ExpenseData();
        private readonly IExpenseData _userIncome = new ExpenseData();

        //Getters and Setter
        public static decimal HomePrice { get => homePrice; set => homePrice = value; }
        public static decimal HomeDeposit { get => homeDeposit; set => homeDeposit = value; }
        public static decimal HomeInterestRate { get => homeInterestRate; set => homeInterestRate = value; }
        public static decimal HomeMTR { get => homeMTR; set => homeMTR = value; }
        public static decimal LoanInterest { get => loanInterest; set => loanInterest = value; }
        public static decimal LoanMonths { get => loanMonths; set => loanMonths = value; }
        public static decimal TotHomeInterest { get => totHomeInterest; set => totHomeInterest = value; }
        public static decimal HomeloanRepayment { get => homeloanRepayment; set => homeloanRepayment = value; }
        public decimal UserIncome { get => userIncome; set => userIncome = value; }

        public HomeLoan()
        {
            InitializeComponent();
        }

        //Next Button Event Handler
        public void nextBTN2(object sender, RoutedEventArgs e)
        {                         
            AddHomeLoanRepayment();
        }

        //Adds and Calculates Monthly Home Loan Repayments to Expenses
        private void AddHomeLoanRepayment()
        {
            try
            {
                HomePrice = decimal.Parse(purchasePrice.Text);

                HomeDeposit = decimal.Parse(deposit.Text);

                HomeInterestRate = decimal.Parse(interestRate.Text);

                HomeMTR = decimal.Parse(monthsToRepay.Text);
            } catch
            {
                MessageBox.Show(Messages.MissingInfo, "Failed",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            LoanInterest = HomeInterestRate / 100;           
            TotHomeInterest = 1 + LoanInterest * LoanMonths;
            HomeloanRepayment = TotHomeInterest + HomePrice / HomeMTR;

            var newIncome = _userIncome.GetIncomes();

            foreach (Incomes x in newIncome)
            {
                UserIncome = x.UsersIncome;
            }
            //Displays Warning If Home Loan Is More Than A Third Of Gross Income
            if (HomeloanRepayment >= (UserIncome * 33/100))
            {
                MessageBox.Show(Messages.HomeExpenseWarning, "Failed",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                var result = _expenseData.AddHomeLoanCatagory(HomeloanRepayment);
                DialogResult = result;
            } else
            {
                var result = _expenseData.AddHomeLoanCatagory(HomeloanRepayment);
                DialogResult = result;
            }
        }
    }
}
