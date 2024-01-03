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

        public Task<bool> DeleteOrderItemByOrderItemID(Guid orderItemID)
        {
            throw new NotImplementedException();
        }
    }
}
