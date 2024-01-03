using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts.OrderItems;

namespace OrderManagement.WebAPI.Controllers
{
    [Route("api/orders/{orderID}/items")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemsGetterService _orderItemsGetterService;
        private readonly IOrderItemsAdderService _orderItemsAdderService;
        private readonly IOrderItemsUpdaterService _orderItemsUpdaterService;
        private readonly IOrderItemsDeleterService _orderItemsDeleterService;
        private readonly ILogger<OrderItemsController> _logger;

        public OrderItemsController(IOrderItemsGetterService orderItemsGetterService,IOrderItemsAdderService orderItemsAdderService,IOrderItemsUpdaterService orderItemsUpdaterService,IOrderItemsDeleterService orderItemsDeleterService,ILogger<OrderItemsController> logger)
        {
            _orderItemsGetterService = orderItemsGetterService;
            _orderItemsAdderService = orderItemsAdderService;
            _orderItemsUpdaterService = orderItemsUpdaterService;
            _orderItemsDeleterService = orderItemsDeleterService;
            _logger = logger;
        }


    }
}
