using Microsoft.Extensions.Logging;
using RepositoryContracts;
using ServiceContracts.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Orders
{
    public class OrdersDeleterService : IOrdersDeleterService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ILogger<OrdersDeleterService> _logger;

        public OrdersDeleterService(IOrdersRepository ordersRepository, ILogger<OrdersDeleterService> logger)
        {
            _ordersRepository = ordersRepository;
            _logger = logger;
        }

        public Task<bool> DeleteOrderByOrderID(Guid orderID)
        {
            throw new NotImplementedException();
        }
    }
}
