using System.Windows;
using POE_Year2.DataStore;
using POE_Year2.DataStore.IDataStore;
using POE_Year2.ErrorMessages;

namespace POE_Year2
{
    public partial class VehicleLoan : Window
    {
        //Variable Declaration and Getters/Setter
        private static decimal purchaseAmount;
        private static decimal vehPrice;
        private static decimal vehDeposit;
        private static decimal yearsToRepay = 5;
        private static decimal vehInterestPer;
        private static decimal vehInterestRate;
        private static decimal totVehInterest;
        private static decimal vehInsurance;
        private static decimal vehLoanRepayment;
        private static decimal totVehCosts;
        //Object From Expense Data
        private readonly IExpenseData _expenseData = new ExpenseData();

        public static decimal VehDeposit { get => vehDeposit; set => vehDeposit = value; }
        public static decimal VehInterestRate { get => vehInterestRate; set => vehInterestRate = value; }
        public static decimal VehInsurance { get => vehInsurance; set => vehInsurance = value; }
        public static decimal TotVehCosts { get => totVehCosts; set => totVehCosts = value; }
        public static decimal VehLoanRepayment { get => vehLoanRepayment; set => vehLoanRepayment = value; }
        public static decimal VehPrice { get => vehPrice; set => vehPrice = value; }
        public static decimal PurchaseAmount { get => purchaseAmount; set => purchaseAmount = value; }

        public VehicleLoan()
        {
            InitializeComponent();
        }
        //Handles Next Button Event
        public void NextBTN(object sender, RoutedEventArgs e)
        {
            AddVehicleLoan();
        }
        //Adds And Calculates Monthly Vehicle Loan Repayment To Expenses
        private void AddVehicleLoan()
        {
            try
            {
                PurchaseAmount = decimal.Parse(veh_Price.Text);
                VehDeposit = decimal.Parse(veh_Deposit.Text);
                VehInterestRate = decimal.Parse(veh_InterestRate.Text);
                VehInsurance = decimal.Parse(veh_Insurance.Text);
            } catch
            {
                MessageBox.Show(Messages.MissingInfo, "Failed",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            vehInterestPer = VehInterestRate / 100;
            vehPrice = PurchaseAmount - VehDeposit;
            totVehInterest = 1 + VehInterestRate * yearsToRepay;
            vehLoanRepayment = (totVehInterest + VehPrice) / 60;
            TotVehCosts = VehLoanRepayment + VehInsurance;

            var result = _expenseData.AddVehicleLoan(TotVehCosts);
            DialogResult = result;

        }

    }
}
