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
    public class OrdersUpdaterService : IOrdersUpdaterService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ILogger<OrdersUpdaterService> _logger;

        public OrdersUpdaterService(IOrdersRepository ordersRepository, ILogger<OrdersUpdaterService> logger)
        {
            _ordersRepository = ordersRepository;
            _logger = logger;
        }

        public Task<OrderResponse> UpdateOrder(OrderUpdateRequest orderUpdateRequest)
        {
            throw new NotImplementedException();
        }
    }
}
