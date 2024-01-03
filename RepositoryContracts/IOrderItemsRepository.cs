using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryContracts
{
    public interface IOrderItemsRepository
    {
        Task<OrderItem> AddOrderItem(OrderItem orderItem);
        Task<List<OrderItem>> GetAllOrderItems();
        Task<List<OrderItem>> GetOrderItemsByOrderID(Guid orderID);
        Task<OrderItem>? GetOrderItemByOrderItemID(Guid orderItemID);
        Task<OrderItem> UpdateOrderItem(OrderItem orderItem);
        Task<bool> DeleteOrderItemByOrderItemID(Guid orderItemID);
    }
}
