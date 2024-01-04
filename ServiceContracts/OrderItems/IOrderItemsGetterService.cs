using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.OrderItems
{
    public interface IOrderItemsGetterService
    {
        Task<List<OrderItemResponse>> GetAllOrderItems();
        Task<List<OrderItemResponse>> GetOrderItemsByOrderID(Guid orderID);
        Task<OrderItemResponse?> GetOrderItemByOrderItemID(Guid orderItemID);
    }
}
