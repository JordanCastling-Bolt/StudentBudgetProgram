using System.Linq;
using POE_Year2.Model;
using POE_Year2.DataStore.IDataStore;

namespace POE_Year2.DataStore
{
    public class UserData : IUserData
    {
        //Checks if User exists
        public User CheckLogin(string username, string password)
        {
            using (var db = new BudgetAppContext())
            {
                var result = db.Users.FirstOrDefault(p => p.UserName == username && p.Password == password);
                return result;
            }
        }

        //Registers New User
        public bool RegisterUser(string username, string password)
        {
            using (var db = new BudgetAppContext())
            {
                var user = new User
                {
                    UserName = username,
                    Password = password
                };
                db.Users.Add(user);
                var result = db.SaveChanges();
                return result > 0;
            }
        }

        
    }
}
