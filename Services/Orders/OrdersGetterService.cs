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

            return ordersResponse;
        }

        public Task<OrderResponse>? GetOrderByOrderID(Guid orderID)
        {
            throw new NotImplementedException();
        }
    }
}
