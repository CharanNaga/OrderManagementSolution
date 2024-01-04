using Entities;
using Microsoft.Extensions.Logging;
using RepositoryContracts;
using ServiceContracts.OrderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.OrderItems
{
    public class OrderItemsDeleterService : IOrderItemsDeleterService
    {
        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly ILogger<OrderItemsDeleterService> _logger;

        public OrderItemsDeleterService(IOrderItemsRepository orderItemsRepository, ILogger<OrderItemsDeleterService> logger)
        {
            _orderItemsRepository = orderItemsRepository;
            _logger = logger;
        }

        public async Task<bool> DeleteOrderItemByOrderItemID(Guid orderItemID)
        {
            _logger.LogInformation("DeleteOrderItemByOrderItemID Service starts");

            //1. Delete matching object object by calling corresponding Repository Method
            var isDeleted = await _orderItemsRepository.DeleteOrderItemByOrderItemID(orderItemID);

            if (isDeleted)
            {
                _logger.LogInformation($"Order Item with OrderItemID: {orderItemID} deleted successfully");
            }
            else
            {
                _logger.LogWarning($"Order Item with OrderItemID: {orderItemID} not found");
            }

            _logger.LogInformation("DeleteOrderItemByOrderItemID Service ends");

            //2. Return boolean value indicating orderitem object was deleted or not
            return isDeleted;
        }
    }
}
