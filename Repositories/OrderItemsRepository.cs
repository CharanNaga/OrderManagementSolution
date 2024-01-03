using Entities;
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

        public Task<bool> DeleteOrderItemByOrderItemID(Guid orderItemID)
        {
            throw new NotImplementedException();
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
