using System.Collections.Generic;
using OnlineStore.Models;

namespace OnlineStore.Data
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
        Order ReadById(int id);
        List<Order> ReadAll();
        void Update(Order updatedOrder);
        void Delete(int id);
    }
}
