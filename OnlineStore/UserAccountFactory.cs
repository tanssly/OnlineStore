using OnlineStore.Models;
using System.Security.Principal;

namespace OnlineStore;

public class UserAccountFactory
{
    public static UserAccount CreateAccount(int accountType, string username, int balance, string email, string password)
    {
        UserAccount account = accountType switch
        {
            1 => new RegularUserAccount(username, balance, email, password, new ShoppingCart(new List<CartEntry>())),
            _ => throw new ArgumentException("Invalid account type.")
        };
        return account;
    }
}
