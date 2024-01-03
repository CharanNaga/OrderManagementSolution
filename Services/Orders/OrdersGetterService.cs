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
        public Task<List<OrderResponse>> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Task<OrderResponse>? GetOrderByOrderID(Guid orderID)
        {
            throw new NotImplementedException();
        }
    }
}
