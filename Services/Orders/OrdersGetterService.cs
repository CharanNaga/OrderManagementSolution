using Entities;
using Microsoft.Extensions.Logging;
using RepositoryContracts;
using ServiceContracts.DTO;
using ServiceContracts.OrderItems;
using ServiceContracts.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Orders
{
    public class OrdersGetterService : IOrdersGetterService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IOrderItemsGetterService _orderItemsGetterService;
        private readonly ILogger<OrdersGetterService> _logger;

        public OrdersGetterService(IOrdersRepository ordersRepository,IOrderItemsGetterService orderItemsGetterService ,ILogger<OrdersGetterService> logger)
        {
            _ordersRepository = ordersRepository;
            _orderItemsGetterService = orderItemsGetterService;
            _logger = logger;
        }
        public async Task<List<OrderResponse>> GetAllOrders()
        {
            _logger.LogInformation("GetAllOrders Service starts");

            //retrieves all orders from corresponding repository
            var orders = await _ordersRepository.GetAllOrders();
            var ordersResponse = orders.ToOrderResponseList();

            //retrieves all List<OrderItem> with OrderResponse.OrderID & store the List to OrderItems Property of OrderResponse DTO

            foreach (var orderResponse in ordersResponse)
            {
                orderResponse.OrderItems = await _orderItemsGetterService.GetOrderItemsByOrderID(orderResponse.OrderID);
            }
            _logger.LogInformation("GetAllOrders Service ends");

            //return List<OrderResponse> object
            return ordersResponse;
        }

        public async Task<OrderResponse?> GetOrderByOrderID(Guid orderID)
        {
            _logger.LogInformation("GetOrderByOrderID Service starts");

            //retrieve order based on OrderID supplied
            var matchingOrder = await _ordersRepository.GetOrderByOrderID(orderID);

            //convert Order object to OrderResponse object
            var matchingOrderResponse = matchingOrder?.ToOrderResponse();

            //retrieve List<OrderItem> by invoking corresponding Repository & assign the same to OrderItems property of OrderResponse object   
            matchingOrderResponse.OrderItems = await _orderItemsGetterService.GetOrderItemsByOrderID(matchingOrderResponse.OrderID);

            if (matchingOrder == null)
            {
                _logger.LogWarning($"Order not found for Order ID: {orderID}.");
            }
            else
            {
                _logger.LogInformation($"Order retrieved successfully. Order ID: {orderID}.");
            }
            _logger.LogInformation("GetOrderByOrderID Service ends");

            //return OrderResponse object
            return matchingOrderResponse;
        }
    }
}
