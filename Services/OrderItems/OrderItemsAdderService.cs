using Entities;
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
    public class OrderItemsAdderService : IOrderItemsAdderService
    {
        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly ILogger<OrderItemsAdderService> _logger;

        public OrderItemsAdderService(IOrderItemsRepository orderItemsRepository, ILogger<OrderItemsAdderService> logger)
        {
            _orderItemsRepository = orderItemsRepository;
            _logger = logger;
        }

        public async Task<OrderItemResponse> AddOrderItem(OrderItemAddRequest orderItemAddRequest)
        {
            _logger.LogInformation("AddOrderItem Service starts");

            //1. Convert orderItemAddRequest to OrderItem type
            OrderItem orderItem = orderItemAddRequest.ToOrderItem();

            //2. Generate a new OrderItemID
            orderItem.OrderItemID = Guid.NewGuid();

            //3. Then add it to the Repository
            var addedOrderItem = await _orderItemsRepository.AddOrderItem(orderItem);
            var addedOrderItemResponse = addedOrderItem.ToOrderItemResponse();

            _logger.LogInformation("AddOrderItem Service ends");

            //4. Return OrderItemResponse Object
            return addedOrderItemResponse;
        }
    }
}
