using OnlineStore.Models;

public class UserAccountService : IUserAccountService
{
    private readonly IUserAccountRepository _userAccountRepository;

    public UserAccountService(IUserAccountRepository userAccountRepository)
    {
        _userAccountRepository = userAccountRepository;
    }

    public void RegisterUser(UserAccount newAccount)
    {
        _userAccountRepository.Create(newAccount);
    }

    public UserAccount GetUserById(int id)
    {
        return _userAccountRepository.ReadById(id);
    }

    public UserAccount GetUserByUsername(string username)
    {
        return _userAccountRepository.ReadByUsername(username);
    }

    public void UpdateUser(UserAccount updatedAccount)
    {
        _userAccountRepository.Update(updatedAccount);
    }

    public void DeleteUser(int id)
    {
        _userAccountRepository.Delete(id);
    }

    public List<UserAccount> GetAllUsers()
    {
        return _userAccountRepository.ReadAll();
    }
}
