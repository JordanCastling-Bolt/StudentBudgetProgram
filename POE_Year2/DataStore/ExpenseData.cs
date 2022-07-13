using System.Collections.Generic;
using System.Linq;
using POE_Year2.Model;
using POE_Year2.DataStore.IDataStore;

namespace POE_Year2.DataStore
{
    public class ExpenseData : IExpenseData
    {
        //Adds Expense to entity
        public bool AddExpenseCategory(string categoryName, decimal budget)
        {
            using (var db = new BudgetAppContext())
            {
                var newCategory = new Expenses
                {
                    Name = categoryName,
                    MonthlyBudget = budget,
                    UserId = SessionInfo.UserId
                };
                db.ExpenseCategories.Add(newCategory);
                var result = db.SaveChanges();
                return result > 0;
            }
        }

        //Adds HomeLoan to entity
        public bool AddHomeLoanCatagory(decimal HomeLoanRepayment)
        {
            using (var db = new BudgetAppContext())
            {
                var newCategory = new Expenses
                {
                    Name = "Home Loan",
                    MonthlyBudget = HomeLoanRepayment,
                    UserId = SessionInfo.UserId
                };
                db.ExpenseCategories.Add(newCategory);
                var result = db.SaveChanges();
                return result > 0;
            }
        }

        //Adds VehicleLoan to entity
        public bool AddVehicleLoan(decimal TotVehCosts)
        {
            using (var db = new BudgetAppContext())
            {
                var newCategory = new Expenses
                {
                    Name = "Vehicle Costs",
                    MonthlyBudget = TotVehCosts,
                    UserId = SessionInfo.UserId
                };
                db.ExpenseCategories.Add(newCategory);
                var result = db.SaveChanges();
                return result > 0;
            }
        }

        //Adds Savings to entity
        public bool AddSavings(string SaveReason, decimal MonthlySavingAmount)
        {
            using (var db = new BudgetAppContext())
            {
                var newCategory = new Expenses
                {
                    Name = SaveReason,
                    MonthlyBudget = MonthlySavingAmount,
                    UserId = SessionInfo.UserId
                };
                db.ExpenseCategories.Add(newCategory);
                var result = db.SaveChanges();
                return result > 0;
            }
        }

        //Adds UserIncome to entity
        public bool User_Income(decimal NewIncome)
        {
            using (var db = new BudgetAppContext())
            {
                var newCategory = new Incomes
                {
                    UsersIncome = NewIncome
                };
                db.UsersIncome.Add(newCategory);
                var result = db.SaveChanges();
                return result > 0;

            }
        }

        //Gets Income from entity
        public List<Incomes> GetIncomes()
        {
            using (var db = new BudgetAppContext())
            {
                return db.UsersIncome.Where(x => x.Id == SessionInfo.UserId).ToList();
            }
        }

        //Gets Expenses from entity
        public List<Expenses> GetExpenseCategoriesList()
        {
            using (var db = new BudgetAppContext())
            {
                return db.ExpenseCategories.Where(p => p.UserId == SessionInfo.UserId).ToList();
            }
        }

    }
}
