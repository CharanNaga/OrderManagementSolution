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

        // GET : api/Orders
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<OrderResponse>>> GetAllOrders()
        {
            _logger.LogInformation("GetAllOrders API starts");

            var orders = await _ordersGetterService.GetAllOrders();

            _logger.LogInformation("GetAllOrders API ends");

            return Ok(orders);
        }

        //GET : api/orders/{orderID}
        [HttpGet("{orderID}")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderResponse>> GetOrderByID(Guid orderID)
        {
            _logger.LogInformation("GetOrderByID API starts");

            var order = await _ordersGetterService.GetOrderByOrderID(orderID);

            if (order == null)
            {
                _logger.LogWarning($"Order with ID {orderID} not found");
                return NotFound();
            }

            _logger.LogInformation("GetOrderByID API ends");

            return Ok(order);
        }

        //POST: api/orders
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<OrderResponse>> AddOrder(OrderAddRequest orderRequest)
        {
            _logger.LogInformation("AddOrder API starts");

            var addedOrder = await _ordersAdderService.AddOrder(orderRequest);

            _logger.LogInformation("AddOrder API ends");

            return CreatedAtAction(nameof(GetOrderByID), new { id = addedOrder.OrderID }, addedOrder);
        }

        //PUT: api/orders/{orderID}
        [HttpPut("{orderID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderResponse>> UpdateOrder(Guid orderID, OrderUpdateRequest orderRequest)
        {
            _logger.LogInformation("UpdateOrder API starts");

            if (orderID != orderRequest.OrderID)
            {
                _logger.LogWarning($"Mismatched ID between route parameter ({orderID}) and order request ({orderRequest.OrderID})");
                return BadRequest();
            }

            var updatedOrder = await _ordersUpdaterService.UpdateOrder(orderRequest);
            _logger.LogInformation("UpdateOrder API ends");

            return Ok(updatedOrder);
        }
    }
}
