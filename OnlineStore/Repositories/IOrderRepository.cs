using System.Collections.Generic;
using OnlineStore.Models;

namespace OnlineStore.Data
{
    public interface IOrderRepository
    {
        void Create(Order order);
        Order ReadById(int id);
        List<Order> ReadAll();
        void Delete(int id);
        List<Order> GetOrdersByAccountId(int accountId);
    }
}
