using OnlineStore.Models;

public interface IUserAccountService
{
    void RegisterUser(UserAccount newAccount);
    UserAccount GetUserById(int id);
    UserAccount GetUserByUsername(string username);
    void UpdateUser(UserAccount updatedAccount);
    void DeleteUser(int id);
    List<UserAccount> GetAllUsers();
}