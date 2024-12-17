using OnlineStore.Data;
using OnlineStore.Models;

public class UserAccountRepository : IUserAccountRepository
{
    private DatabaseContext DbContext { get; }

    public UserAccountRepository(DatabaseContext dbContext)
    {
        DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext), "Database context cannot be null.");
    }

    public void Create(UserAccount account)
    {
        if (DbContext.Users.Any(u => u.Username == account.Username))
        {
            throw new ArgumentException("A user with that username already exists. Please enter a unique username.");
        }
        DbContext.Users.Add(account);
    }

    public UserAccount ReadById(int id)
    {
        return DbContext.Users.FirstOrDefault(u => u.Id == id);
    }

    public List<UserAccount> ReadAll()
    {
        return DbContext.Users.ToList();
    }

    public UserAccount ReadByUsername(string username)
    {
        return DbContext.Users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
    }

    public void Update(UserAccount updatedAccount)
    {
        var account = DbContext.Users.FirstOrDefault(u => u.Id == updatedAccount.Id);
        if (account != null)
        {
            account.Username = updatedAccount.Username;
            account.Password = updatedAccount.Password;
            account.Email = updatedAccount.Email;
            account.Balance = updatedAccount.Balance;
        }
        else
        {
            throw new ArgumentException("User account not found.");
        }
    }

    public void Delete(int id)
    {
        var account = DbContext.Users.FirstOrDefault(u => u.Id == id);
        if (account != null)
        {
            DbContext.Users.Remove(account);
        }
        else
        {
            throw new ArgumentException("User account not found.");
        }
    }
}