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

        public async Task<OrderResponse> UpdateOrder(OrderUpdateRequest orderUpdateRequest)
        {
            _logger.LogInformation("UpdateOrder Service starts");
            //1. convert orderUpdateRequest to Order type
            var order = orderUpdateRequest.ToOrder();

            //2. call corresponding Repository method & store it in a variable
            var updatedOrder = await _ordersRepository.UpdateOrder(order);

            //3. convert Order to OrderResponse type
            var updatedOrderResponse = updatedOrder.ToOrderResponse();

            _logger.LogInformation("UpdateOrder Service ends");

            //4. return the OrderResponse Object
            return updatedOrderResponse;
        }
    }
}
