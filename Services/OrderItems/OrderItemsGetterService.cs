using Microsoft.Extensions.Logging;
using RepositoryContracts;
using ServiceContracts.DTO;
using ServiceContracts.OrderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.OrderItems
{
    public class OrderItemsGetterService : IOrderItemsGetterService
    {
        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly ILogger<OrderItemsGetterService> _logger;

        public OrderItemsGetterService(IOrderItemsRepository orderItemsRepository, ILogger<OrderItemsGetterService> logger)
        {
            _orderItemsRepository = orderItemsRepository;
            _logger = logger;
        }

        public async Task<List<OrderItemResponse>> GetAllOrderItems()
        {
            _logger.LogInformation("GetAllOrderItems Service starts");

            var orderItems = await _orderItemsRepository.GetAllOrderItems();

            _logger.LogInformation("GetAllOrderItems Service ends");
            var orderItemsResponse = orderItems.ToOrderItemResponseList();
            return orderItemsResponse;
        }

        public Task<OrderItemResponse>? GetOrderItemByOrderItemID(Guid orderItemID)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderItemResponse>> GetOrderItemsByOrderID(Guid orderID)
        {
            throw new NotImplementedException();
        }
    }
}
