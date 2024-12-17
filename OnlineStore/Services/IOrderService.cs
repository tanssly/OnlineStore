using OnlineStore.Models;
using System.Formats.Tar;

public interface IOrderService
{
    void Create(Order order);
    Order ReadById(int orderId);
    List<Order> ReadAll();
    void Delete(int orderId);
}
