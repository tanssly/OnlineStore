using OnlineStore.Models;
using System.Security.Principal;

public class UserAccountService : IUserAccountService
{
    private readonly IUserAccountRepository _userAccountRepository;

    public UserAccountService(IUserAccountRepository userAccountRepository)
    {
        _userAccountRepository = userAccountRepository ?? throw new ArgumentNullException(nameof(userAccountRepository), "Repository cannot be null.");
    }

    public void RegisterUser(UserAccount newAccount)
    {
        if (newAccount == null)
        {
            throw new ArgumentNullException(nameof(newAccount), "User account cannot be null.");
        }
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
    public CartEntry GetCartItem(UserAccount account, int productId)
    {
        if (account == null)
        {
            throw new ArgumentNullException(nameof(account), "Account cannot be null.");
        }

        if (productId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(productId), "Product ID must be a positive integer.");
        }

        var cartItem = account.Cart.Items.FirstOrDefault(item => item.Item.Id == productId);
        if (cartItem == null)
        {
            throw new KeyNotFoundException("Cart item not found.");
        }

        return cartItem;
    }

    public void ReduceCartItemQuantity(UserAccount account, int productId, int quantity)
    {
        if (account == null)
        {
            throw new ArgumentNullException(nameof(account), "Account cannot be null.");
        }

        if (productId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(productId), "Product ID must be a positive integer.");
        }

        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be a positive integer.");
        }

        var cartItem = GetCartItem(account, productId);
        if (cartItem != null)
        {
            cartItem.DecreaseQuantity(quantity);
            if (cartItem.Quantity <= 0)
            {
                RemoveFromCart(account, productId);
            }
        }
    }

    public void RemoveFromCart(UserAccount account, int productId)
    {
        if (account == null)
        {
            throw new ArgumentNullException(nameof(account), "Account cannot be null.");
        }

        if (productId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(productId), "Product ID must be a positive integer.");
        }

        var cartItem = GetCartItem(account, productId);
        if (cartItem != null)
        {
            account.Cart.Items.Remove(cartItem);
        }
    }

}