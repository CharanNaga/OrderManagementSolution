using Entities;
using Microsoft.Extensions.Logging;
using RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<OrdersRepository> _logger;

        public OrdersRepository(ApplicationDbContext db, ILogger<OrdersRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<Order> AddOrder(Order order)
        {
            _logger.LogInformation("Adding Order to the database...");

            _db.Orders.Add(order);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Order with ID: {OrderID} added to the database.", order.OrderID);
            return order;
        }

        public async Task<bool> DeleteOrderByOrderID(Guid orderID)
        {
            _logger.LogInformation("Deleting an Order from the database");

            //_db.Orders.RemoveRange(
            //    _db.Orders.Where(
            //        temp=> temp.OrderID == orderID
            //        ));
            //int rowsDeleted = await _db.SaveChangesAsync();
            //return rowsDeleted > 0;

            var order = await _db.Orders.FindAsync(orderID);
            if (order == null)
            {
                _logger.LogWarning($"Order not found with ID: {orderID}.");
                return false;
            }
            _db.Orders.Remove(order);
            await _db.SaveChangesAsync();
            _logger.LogInformation("Order with ID {OrderID} deleted from the database.", orderID);
            return true;
        }

        public Task<List<Order>> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetFilteredOrders(Expression<Func<Order, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Order>? GetOrderByOrderID(Guid orderID)
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
