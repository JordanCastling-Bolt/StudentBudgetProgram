using System.Windows;
using POE_Year2.DataStore;
using POE_Year2.DataStore.IDataStore;
using POE_Year2.ErrorMessages;

namespace POE_Year2
{
    public partial class Savings : Window
    {
        //Variable Declration And Getters/Setters 
        private static decimal saveAmount;
        private static string saveReason;
        private static decimal saveInterestRate;
        private static decimal noOfYears;
        private static decimal monthlySavingAmount;
        private static decimal totInterest;
        private static decimal noOfMonths;
        private static decimal newInterest;

        public static decimal SaveAmount { get => saveAmount; set => saveAmount = value; }
        public static string SaveReason { get => saveReason; set => saveReason = value; }
        public static decimal NoOfYears { get => noOfYears; set => noOfYears = value; }
        public static decimal SaveInterestRate { get => saveInterestRate; set => saveInterestRate = value; }
        public static decimal MonthlySavingAmount { get => monthlySavingAmount; set => monthlySavingAmount = value; }
        //Object From Expense Data
        private readonly IExpenseData _expenseData = new ExpenseData();

        public Savings()
        {
            InitializeComponent();
        }
        //handles Next Button Click
        private void NextBTN(object sender, RoutedEventArgs e)
        {
            AddSavings();
        }
        //Adds and Calculates Monthly Savings To Expenses 
        public void AddSavings()
        {
            try
            {
                SaveAmount = decimal.Parse(Save_Amount.Text);
                SaveReason = Save_Reason.Text;
                SaveInterestRate = decimal.Parse(Save_InterestRate.Text);
                NoOfYears = decimal.Parse(No_OfYears.Text);
            }
            catch
            {
                MessageBox.Show(Messages.MissingInfo, "Failed",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            noOfMonths = NoOfYears * 12;
            totInterest = SaveInterestRate / 100;
            newInterest = 1 + totInterest * NoOfYears;
            MonthlySavingAmount = (SaveAmount - newInterest) / noOfMonths;

            var result = _expenseData.AddSavings(SaveReason, MonthlySavingAmount);
            DialogResult = result;
        }
    }
}
