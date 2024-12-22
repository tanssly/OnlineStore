using OnlineStore.Models; 
using OnlineStore.Services;
using OnlineStore.Data;

namespace OnlineStore.Commands;
public class AddBalanceCommand : ICommand
{
    public void Execute()
    {
        UserAccount account = Program.currentAccount;
        Console.WriteLine("Enter the amount to add to your balance: ");
        if (int.TryParse(Console.ReadLine(), out int amount) && amount > 0)
        {
            account.Balance += amount;
            Console.WriteLine($"Balance successfully updated. New balance: {account.Balance}");
        }
        else
        {
            Console.WriteLine("Invalid amount entered.");
        }

        Console.ReadKey();
    }

    public string ShowInfo()
    {
        return "Add Balance";
    }
}

public class CheckBalanceCommand : ICommand
{
    public void Execute()
    {
        UserAccount account = Program.currentAccount;
        Console.WriteLine($"Your current balance is: {account.Balance} ");
        Console.ReadKey();
    }

    public string ShowInfo()
    {
        return "Check Balance";
    }
}
public class ViewProductsCommand(ProductService productService) : ICommand
{
    private ProductService _productService = productService;

    public void Execute()
    {
        var products = _productService.ReadAll();
        if (products.Count == 0)
        {
            Console.WriteLine("No products available.");
            return;
        }
        Console.WriteLine("Available products:");
        foreach (var product in products)
        {
            Console.WriteLine($"ID: {product.Id} | Name: {product.Name} | Price: {product.Price} | Quantity: {product.Quantity}");
        }
        Console.ReadKey();
    }

    public string ShowInfo()
    {
        return "View Products";
    }
}

