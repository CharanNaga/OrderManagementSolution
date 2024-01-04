using Entities;
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

        public async Task<bool> DeleteOrderByOrderID(Guid orderID)
        {
            _logger.LogInformation("DeleteOrderByOrderID Service starts");

            //1. Delete matching object object by calling corresponding Repository Method
            var isDeleted = await _ordersRepository.DeleteOrderByOrderID(orderID);

            if (isDeleted)
            {
                _logger.LogInformation($"Order with ID {orderID} deleted successfully");
            }
            else
            {
                _logger.LogWarning($"Order with ID {orderID} not found");
            }

            _logger.LogInformation("DeleteOrderByOrderID Service ends");

            //2. Return boolean value indicating order object was deleted or not
            return isDeleted;
        }
    }
}
