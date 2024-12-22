using OnlineStore.Data;
using OnlineStore.Models;
using OnlineStore.Services;

namespace OnlineStore.Commands;
public class ViewCartCommand() : ICommand
{
    public void Execute()
    {
        var account = Program.currentAccount;
        var currentCart = account.Cart;

        if (currentCart == null || currentCart.Items == null || currentCart.Items.Count == 0)
        {
            Console.WriteLine("Your cart is empty.");
            return;
        }

        Console.WriteLine("Products in your cart:");
        float totalPrice = 0;
        foreach (var cartItem in currentCart.Items)
        {
            var price = cartItem.Item.Price * cartItem.Quantity;
            Console.WriteLine($"Product: {cartItem.Item.Name} | Price: {price} | Quantity: {cartItem.Quantity}");
            totalPrice += (float)price;
        }
        Console.WriteLine($"Total price: {totalPrice}");
        Console.ReadKey();
    }

    public string ShowInfo()
    {
        return "View Cart";
    }
}

public class ViewOrderHistoryCommand(OrderService orderService) : ICommand
{
    private OrderService _orderService = orderService;
    UserAccount _account = Program.currentAccount;
    public void Execute()
    {
        Console.Clear();
        var orders = _orderService.GetOrdersByAccountId(_account.Id);
        if (orders.Count == 0)
        {
            Console.WriteLine("You have no order history.");
            return;
        }

        float totalPrice = 0;
        Console.WriteLine("Order history:");
        foreach (var order in orders)
        {
            Console.WriteLine($"Order ID: {order.OrderId} | Date: {order.OrderDate} | Time : {order.OrderTime} | Status: {order.OrderStatus}");
            foreach (var item in order.Products)
            {
                var price = item.Item.Price * item.Quantity;
                Console.WriteLine($"  - Product: {item.Item.Name} | Price: {item.Item.Price}");

                totalPrice += (float)price;
            }
            Console.WriteLine($"  - Total price: {totalPrice}");
        }
        Console.ReadKey();
    }

    public string ShowInfo()
    {
        return "View Order History";
    }
}

public class CreateOrderCommand(OrderService orderService, ProductService productService) : ICommand
{
    public void Execute()
    {
        var account = Program.currentAccount;
        var cart = account.Cart;
        Order order = new Order(account.Id, cart.Items);
        var balance = account.Balance;
        orderService.Create(order);
        if (order.OrderPrice <= balance)
        {
            Console.WriteLine("Order created successfully.");
            Console.WriteLine($"Price: {order.OrderPrice}");

            foreach (var item in cart.Items)
            {
                var productId = item.Item.Id;
                var productItemQuantity = item.Quantity;
                productService.DecreaseQuantity(productId, productItemQuantity);
            }
            int totalPrice = (int)order.CalculateOrderPrice();
            account.Balance -= totalPrice;
        }
        else
        {
            Console.WriteLine("Order could not be created. Please add money to balance.");
        }
        Console.ReadKey();
    }


    public string ShowInfo()
    {
        return "Create Order";
    }
}