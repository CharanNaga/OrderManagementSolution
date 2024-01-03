using Entities;
using System.Linq.Expressions;

namespace RepositoryContracts
{
    public interface IOrdersRepository
    {
        Task<Order> AddOrder(Order order);
        Task<List<Order>> GetAllOrders();
        Task<Order>? GetOrderByOrderID(Guid orderID);
        Task<List<Order>> GetFilteredOrders(Expression<Func<Order, bool>> predicate);
        Task<Order> UpdateOrder(Order order);
        Task<bool> DeleteOrderByOrderID(Guid orderID);

    }
}