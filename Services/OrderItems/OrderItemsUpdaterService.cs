using Microsoft.Extensions.Logging;
using RepositoryContracts;
using ServiceContracts.DTO;
using ServiceContracts.OrderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.OrderItems
{
    public class OrderItemsUpdaterService : IOrderItemsUpdaterService
    {
        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly ILogger<OrderItemsUpdaterService> _logger;

        public OrderItemsUpdaterService(IOrderItemsRepository orderItemsRepository, ILogger<OrderItemsUpdaterService> logger)
        {
            _orderItemsRepository = orderItemsRepository;
            _logger = logger;
        }

        public Task<OrderResponse> UpdateOrderItem(OrderItemUpdateRequest orderItemUpdateRequest)
        {
            throw new NotImplementedException();
        }
    }
}
