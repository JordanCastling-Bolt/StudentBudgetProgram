using System.Data.Entity;


namespace POE_Year2.Model
{
    //Using DbContext
    internal class BudgetAppContext : DbContext
    {
        //Creates BudgetAppContext  Db
        public BudgetAppContext() : base("BudgetAppContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<BudgetAppContext>());
        }

        //Sets Entities
        public DbSet<User> Users { get; set; }
        public DbSet<Expenses> ExpenseCategories { get; set; }

        public DbSet<Incomes> UsersIncome { get; set; }
        
    }
}
