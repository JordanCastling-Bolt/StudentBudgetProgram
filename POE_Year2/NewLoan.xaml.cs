using System.Windows;
using POE_Year2.ErrorMessages;

namespace POE_Year2
{

    public partial class NewLoan : Window
    {
        public NewLoan()
        {
            InitializeComponent();
        }
        //Shows Either HomeLoan Page or Vehicle Loan Page depending On Choice
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            var homeLoan = new HomeLoan();
            var vehicleLoan = new VehicleLoan();
            if (Loan_Choice.SelectedItem == Home_Loan)
            {
                if (homeLoan.ShowDialog() != true) return;
                MessageBox.Show(Messages.NewLoanAdded, "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            if (Loan_Choice.SelectedItem == Vehicle_Loan)
            {
                if (vehicleLoan.ShowDialog() != true) return;
                MessageBox.Show(Messages.NewLoanAdded, "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }


        }

    }
}
