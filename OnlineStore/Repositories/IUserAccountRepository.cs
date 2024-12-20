using OnlineStore.Models;

public interface IUserAccountRepository
{
    void Create(UserAccount account);
    UserAccount ReadById(int id);
    List<UserAccount> ReadAll();
    UserAccount ReadByUsername(string username);
    void Update(UserAccount updatedAccount);
    void Delete(int id);
}
