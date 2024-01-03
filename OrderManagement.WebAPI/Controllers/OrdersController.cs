using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts.DTO;
using ServiceContracts.Orders;

namespace OrderManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersAdderService _ordersAdderService;
        private readonly IOrdersGetterService _ordersGetterService;
        private readonly IOrdersUpdaterService _ordersUpdaterService;
        private readonly IOrdersDeleterService _ordersDeleterService;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrdersAdderService ordersAdderService, IOrdersGetterService ordersGetterService, IOrdersUpdaterService ordersUpdaterService, IOrdersDeleterService ordersDeleterService, ILogger<OrdersController> logger)
        {
            _ordersAdderService = ordersAdderService;
            _ordersGetterService = ordersGetterService;
            _ordersUpdaterService = ordersUpdaterService;
            _ordersDeleterService = ordersDeleterService;
            _logger = logger;
        }

        //api/Orders/GetAllOrders
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<OrderResponse>>> GetAllOrders()
        {
            _logger.LogInformation("GetAllOrders API starts");

            var orders = await _ordersGetterService.GetAllOrders();

            _logger.LogInformation("GetAllOrders API ends");

            return Ok(orders);
        }
    }
}
