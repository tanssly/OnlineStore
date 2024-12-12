using OnlineStore.Models;
using System.Formats.Tar;

public interface IOrderService
{
    void CreateOrder(Order order);
    Order GetOrderById(int orderId);
    List<Order> ReadAll();
    void UpdateOrder(Order order);
    void DeleteOrder(int orderId);
}
