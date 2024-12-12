using OnlineStore.Models;
using System.Security.Principal;
namespace shop;

public class AccountFactory
{
    public static UserAccount CreateAccount(int accountType, string name, int balance, string email, string password)
    {
        UserAccount account = accountType switch
        {
            1 => new RegularUserAccount(name, balance, email, password, new Cart(new List<CartItem>())),
            2 => new AdminAccount(name, balance, email, password, new Cart(new List<CartItem>())),
            _ => throw new ArgumentException("Invalid account type.")
        };
        return account;
    }
}