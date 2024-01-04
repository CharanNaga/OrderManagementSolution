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

            // Retrieve all order items from the repository
            var orderItems = await _orderItemsRepository.GetAllOrderItems();

            _logger.LogInformation("GetAllOrderItems Service ends");

            //convert order items into List<OrderItemResponse>
            var orderItemsResponse = orderItems.ToOrderItemResponseList();

            //return List<OrderItemResponse> object
            return orderItemsResponse;
        }

        public async Task<OrderItemResponse?> GetOrderItemByOrderItemID(Guid orderItemID)
        {
            _logger.LogInformation("GetOrderItemByOrderItemID Service starts");

            // Retrieve an order item based on its Order Item ID from the Repository method
            var orderItem = await _orderItemsRepository.GetOrderItemByOrderItemID(orderItemID);

            if (orderItem == null)
            {
                _logger.LogWarning($"Order item not found for Order Item ID: {orderItemID}.");
            }
            else
            {
                _logger.LogInformation($"Order item retrieved successfully. Order Item ID: {orderItemID}.");
            }
            _logger.LogInformation("GetOrderItemByOrderItemID Service ends");

            // Convert the OrderItem object to OrderItemResponse object
            var orderItemResponse =  orderItem?.ToOrderItemResponse();

            //return OrderItemResponse object
            return orderItemResponse;
        }

        public async Task<List<OrderItemResponse>> GetOrderItemsByOrderID(Guid orderID)
        {
            _logger.LogInformation("GetOrderItemsByOrderID Service starts");

            // Retrieve order items based on its Order ID from the Repository method
            var orderItems = await _orderItemsRepository.GetOrderItemsByOrderID(orderID);

            _logger.LogInformation("GetOrderItemsByOrderID Service ends");

            //convert List<OrderItem> object to List<OrderItemResponse> object
            var orderItemsResponse = orderItems.ToOrderItemResponseList();

            //return List<OrderItemResponse> object
            return orderItemsResponse;

        }
    }
}
