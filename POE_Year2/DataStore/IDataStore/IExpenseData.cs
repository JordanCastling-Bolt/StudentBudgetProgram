using System.Collections.Generic;
using POE_Year2.Model;

namespace POE_Year2.DataStore.IDataStore
{
    //Interface and Implements for ExpenseData
    internal interface IExpenseData
    {
    bool AddExpenseCategory(string categoryName, decimal budget);

    bool AddHomeLoanCatagory(decimal HomeLoanRepayment);

     bool AddVehicleLoan(decimal TotVehCosts);
      
    bool AddSavings(string SaveReason, decimal MonthlySavingAmount);

    List<Expenses> GetExpenseCategoriesList();


    bool User_Income(decimal UserIncome);

    List<Incomes> GetIncomes();
    }
}
