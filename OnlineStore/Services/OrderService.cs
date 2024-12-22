using System.Collections.Generic;
using OnlineStore.Data;
using OnlineStore.Models;
using OnlineStore.Repositories; 

namespace OnlineStore.Data
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository), "Order repository cannot be null.");
        }

        public void Create(Order order)
        {
            _orderRepository.Create(order);
        }

        public Order ReadById(int id)
        {
            return _orderRepository.ReadById(id);
        }

        public List<Order> ReadAll()
        {
            return _orderRepository.ReadAll();
        }

        public void Delete(int id)
        {
            _orderRepository.Delete(id);
        }

        public List<Order> GetOrdersByAccountId(int accountId)
        {
            return _orderRepository.GetOrdersByAccountId(accountId);
        }
    }
}
