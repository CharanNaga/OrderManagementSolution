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
    public class OrdersFilterService : IOrdersFilterService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ILogger<OrdersFilterService> _logger;

        public OrdersFilterService(IOrdersRepository ordersRepository, ILogger<OrdersFilterService> logger)
        {
            _ordersRepository = ordersRepository;
            _logger = logger;
        }

        public Task<List<OrderResponse>> GetFilteredOrders(string searchBy, string? searchString)
        {
            throw new NotImplementedException();
        }
    }
}
