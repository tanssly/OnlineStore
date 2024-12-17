using System.Collections.Generic;
using System.Linq;
using OnlineStore.Data;
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

        public void Create(Order order)
        {
            _dbContext.Orders.Add(order);
        }

        public Order ReadById(int id)
        {
            return _dbContext.Orders.FirstOrDefault(g => g.OrderId.Equals(id));
        }

        public List<Order> ReadAll()
        {
            return _dbContext.Orders.Count == 0 ? null : _dbContext.Orders;
        }
        public void Delete(int id)
        {
            var orders = ReadAll();
            var order = orders.FirstOrDefault();

            if (order != null)
            {
                _dbContext.Orders.Remove(order);
            }
            else
            {
                throw new ArgumentException("Order not found.");
            }
        }
        public List<Order> GetOrdersByAccountId(int accountId)
        {
            return _dbContext.Orders.Where(order => order.CustomerId == accountId).ToList();
        }
    }
}
