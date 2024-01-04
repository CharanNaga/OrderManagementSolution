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
    public class OrderItemsUpdaterService : IOrderItemsUpdaterService
    {
        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly ILogger<OrderItemsUpdaterService> _logger;

        public OrderItemsUpdaterService(IOrderItemsRepository orderItemsRepository, ILogger<OrderItemsUpdaterService> logger)
        {
            _orderItemsRepository = orderItemsRepository;
            _logger = logger;
        }

        public async Task<OrderItemResponse> UpdateOrderItem(OrderItemUpdateRequest orderItemUpdateRequest)
        {
            _logger.LogInformation("UpdateOrderItem Service starts");

            //1. convert orderItemUpdateRequest to OrderItem type
            var orderItem = orderItemUpdateRequest.ToOrderItem();

            //2. call corresponding Repository method & store it in a variable
            var updatedOrderItem = await _orderItemsRepository.UpdateOrderItem(orderItem);

            //3. convert OrderItem to OrderItemResponse type
            var updatedOrderItemResponse = updatedOrderItem.ToOrderItemResponse();

            _logger.LogInformation("UpdateOrderItem Service ends");

            //4. return the OrderResponse Object
            return updatedOrderItemResponse;
        }
    }
}
