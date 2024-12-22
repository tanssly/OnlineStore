using OnlineStore.Models;
using OnlineStore.Services;
using OnlineStore.Data;

namespace OnlineStore.Commands;

public class AddProductToCartCommand : ICommand
{
    private readonly ProductService _productService;
    public AddProductToCartCommand(ProductService productService)
    {
        _productService = productService;
    }

    public AddProductToCartCommand(ProductService productService, UserAccountService accountService)
    {
        _productService = productService;
    }

    public void Execute()
    {
        UserAccount account = Program.currentAccount;

        if (account == null)
        {
            Console.WriteLine("No user is logged in.");
            return;
        }

        Console.WriteLine("Enter the ID of the product to add to your cart: ");
        if (int.TryParse(Console.ReadLine(), out int productId))
        {
            var product = _productService.ReadById(productId);
            if (product != null)
            {
                Console.WriteLine("Enter the quantity to add: ");
                if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
                {
                    if (quantity > product.Quantity)
                    {
                        Console.WriteLine($"Max quantity for this product is {product.Quantity}.");
                    }
                    else
                    {
                        account.Cart.AddToShoppingCart(new Item(product.Id, product.Name, product.Price), quantity);
                        Console.WriteLine($"Added {quantity} of {product.Name} to your cart.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid quantity entered.");
                }
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid product ID entered.");
        }

        Console.ReadKey();
    }

    public string ShowInfo()
    {
        return "Add Product to Cart";
    }
}


public class DeleteProductFromCartCommand(UserAccountService accountService)
    : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Enter the ID of the product to remove from your cart: ");

        if (int.TryParse(Console.ReadLine(), out int productId))
        {
            UserAccount account = Program.currentAccount;
            var cartItem = accountService.GetCartItem(account, productId);

            if (cartItem != null)
            {
                Console.WriteLine($"Current quantity of this product in your cart: {cartItem.Quantity}");
                Console.WriteLine("Enter the quantity to remove: ");

                if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
                {
                    if (quantity < cartItem.Quantity)
                    {
                        accountService.ReduceCartItemQuantity(account, productId, quantity);
                        Console.WriteLine($"Removed {quantity} units of product ID {productId} from your cart.");
                    }
                    else if (quantity == cartItem.Quantity)
                    {
                        accountService.RemoveFromCart(account, productId);
                        Console.WriteLine($"Product ID {productId} has been fully removed from your cart.");
                    }
                    else
                    {
                        Console.WriteLine("You can't remove more than the available quantity in your cart.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid quantity entered.");
                }
            }
            else
            {
                Console.WriteLine("Product not found in your cart.");
            }
        }
        else
        {
            Console.WriteLine("Invalid product ID entered.");
        }
        Console.ReadKey();
    }

    public string ShowInfo()
    {
        return "Delete or reduce product quantity from cart.";
    }
}
