using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Logging;
using RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderItemsRepository : IOrderItemsRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<OrderItemsRepository> _logger;

        public OrderItemsRepository(ApplicationDbContext db, ILogger<OrderItemsRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<OrderItem> AddOrderItem(OrderItem orderItem)
        {
            _logger.LogInformation("Adding Order Item to the database...");

            _db.OrderItems.Add(orderItem);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Order Item with ID: {OrderItemID} added to the database.", orderItem.OrderItemID);
            return orderItem;
        }

        public async Task<bool> DeleteOrderItemByOrderItemID(Guid orderItemID)
        {
            _logger.LogInformation("Deleting an Order Item from the database");

            //_db.OrderItems.RemoveRange(
            //    _db.OrderItems.Where(
            //        temp=> temp.OrderItemID == orderItemID
            //        ));
            //int rowsDeleted = await _db.SaveChangesAsync();
            //return rowsDeleted > 0;

            var orderItem = await _db.OrderItems.FindAsync(orderItemID);
            if (orderItem == null)
            {
                _logger.LogWarning($"Order item not found with ID: {orderItemID}.");
                return false;
            }
            _db.OrderItems.Remove(orderItem);
            await _db.SaveChangesAsync();
            _logger.LogInformation("Order item with ID {OrderItemId} deleted from the database.", orderItemID);
            return true;
        }

        public async Task<List<OrderItem>> GetAllOrderItems()
        {
            _logger.LogInformation("Retrieving all order items...");

            var orderItems = await _db.OrderItems.OrderByDescending(temp=>temp.OrderID).ToListAsync();

            _logger.LogInformation($"Retrieved {orderItems.Count} order items successfully.");
            return orderItems;
        }

        public async Task<OrderItem?> GetOrderItemByOrderItemID(Guid orderItemID)
        {
            _logger.LogInformation("Retrieving Order Item by OrderItemID...");
            var orderItem = await _db.OrderItems.FindAsync(orderItemID);
            if(orderItem == null)
            {
                _logger.LogWarning($"Order Item not found with OrderItemID: {orderItemID}.");
            }
            else
            {
                _logger.LogInformation("Order Item retrieved successfully.");
            }
            return orderItem;
        }

        public async Task<List<OrderItem>> GetOrderItemsByOrderID(Guid orderID)
        {
            _logger.LogInformation("Retrieving Order Items by OrderID...");
            var orderItems = await _db.OrderItems.Where(temp => temp.OrderID == orderID).ToListAsync();
            _logger.LogInformation($"Retrieved {orderItems.Count} order items associated with OrderID: {orderID}.");
            return orderItems;
        }

        public Task<OrderItem> UpdateOrderItem(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }
    }
}
