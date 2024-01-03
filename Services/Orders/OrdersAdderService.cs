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

        public Task<OrderResponse> AddOrder(OrderAddRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
