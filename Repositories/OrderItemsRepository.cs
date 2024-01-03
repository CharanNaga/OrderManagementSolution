using Entities;
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

        public Task<List<OrderItem>> GetAllOrderItems()
        {
            throw new NotImplementedException();
        }

        public Task<OrderItem>? GetOrderItemByOrderItemID(Guid orderItemID)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderItem>> GetOrderItemsByOrderID(Guid orderID)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItem> UpdateOrderItem(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }
    }
}
