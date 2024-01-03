using Entities;
using Microsoft.Extensions.Logging;
using RepositoryContracts;
using ServiceContracts.DTO;
using ServiceContracts.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Orders
{
    public class OrdersAdderService : IOrdersAdderService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly ILogger<OrdersAdderService> _logger;

        public OrdersAdderService(IOrdersRepository ordersRepository, IOrderItemsRepository orderItemsRepository, ILogger<OrdersAdderService> logger)
        {
            _ordersRepository = ordersRepository;
            _orderItemsRepository = orderItemsRepository;
            _logger = logger;
        }

        public async Task<OrderResponse> AddOrder(OrderAddRequest orderAddRequest)
        {
            _logger.LogInformation("AddOrder Service starts");

            //1. Convert orderAddRequest to Order type
            Order order = orderAddRequest.ToOrder();

            //2. Generate a new OrderID
            order.OrderID = Guid.NewGuid();

            //3. Then add it to the Repository
            var addedOrder = await _ordersRepository.AddOrder(order);
            var addedOrderResponse = addedOrder.ToOrderResponse();

            foreach (var item in orderAddRequest.OrderItems)
            {
                var orderItem = item.ToOrderItem();
                orderItem.OrderItemID = Guid.NewGuid();
                orderItem.OrderID = addedOrder.OrderID;

                var addedOrderItem = await _orderItemsRepository.AddOrderItem(orderItem);
                addedOrderResponse.OrderItems.Add(addedOrderItem.ToOrderItemResponse()); //Adding OrderItems from OrderAddRequest to OrderResponse
            }
            _logger.LogInformation("AddOrder Service ends");

            //4. Return OrderResponse Object
            return addedOrderResponse;
        }
    }
}