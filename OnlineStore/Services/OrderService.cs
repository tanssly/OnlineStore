using OnlineStore.Data;
using OnlineStore.Models;
using Store;

namespace OnlineStore.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void CreateOrder(ShoppingCart cart, int customerId)
        {
            if (cart == null || cart.Items.Count == 0)
                throw new ArgumentException("Cart cannot be null or empty.", nameof(cart));

            var order = cart.CreateOrder(customerId);
            _orderRepository.AddOrder(order);
        }

        public Order GetOrder(int id)
        {
            return _orderRepository.GetOrderById(id);
        }

        public List<Order> GetOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        public void UpdateOrder(Order updatedOrder)
        {
            _orderRepository.UpdateOrder(updatedOrder);
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.DeleteOrder(id);
        }
    }
}
