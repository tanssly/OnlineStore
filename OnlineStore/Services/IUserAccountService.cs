using OnlineStore.Models;

public interface IUserAccountService
{
    void Create(UserAccount newAccount);

    UserAccount GetUserById(int id);

    void Update(UserAccount updatedAccount);

    void Delete(int id);
    List<UserAccount> ReadAll();
}
