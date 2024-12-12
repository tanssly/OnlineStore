using System.Collections.Generic;
using OnlineStore.Models;

namespace OnlineStore.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DatabaseContext _dbContext;

        public OrderRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddOrder(Order order)
        {
            _dbContext.Orders.Add(order);
        }

        public Order ReadById(int id)
        {
            return _dbContext.Orders.FirstOrDefault(g => g.OrderId.Equals(id));
        }

        public List<Order> ReadAll()
        {
            return _dbContext.Orders.Count == 0 ? null : DatabaseContext.orders;
        }

        public void UpdateOrder(Order updatedOrder)
        {
            var order = _dbContext.Orders.Find(updatedOrder.Id);
            if (order != null)
            {
                // оновлюємо поля замовлення
                order.Products = updatedOrder.Products;
                order.TotalPrice = updatedOrder.TotalPrice;
                order.OrderDate = updatedOrder.OrderDate;
                order.OrderTime = updatedOrder.OrderTime;
                // збереження змін в базі даних
            }
        }

        public void Delete(int id)
        {
            var order = _dbContext.Orders.Find(id);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                // збереження змін в базі даних
            }
        }
    }
}

/*  void AddOrder(Order order);
        Order ReadById(int id);
        List<Order> ReadAll();
        void Update(Order updatedOrder);
        void Delete(int id);