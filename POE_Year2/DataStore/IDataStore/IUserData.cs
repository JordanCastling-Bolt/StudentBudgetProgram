using POE_Year2.Model;

namespace POE_Year2.DataStore.IDataStore
{
    //Interface and Implements for UserData
    public interface IUserData 
    {
        User CheckLogin(string username, string password);

        bool RegisterUser(string username, string password);
       
    }
}
