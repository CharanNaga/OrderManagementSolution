using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts.DTO;
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

        //GET : api/orders/{orderID}/items
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<OrderItemResponse>>> GetOrderItemsByOrderID(Guid orderID)
        {
            _logger.LogInformation("GetOrderItemsByOrderID API starts");

            var orderItems = await _orderItemsGetterService.GetOrderItemsByOrderID(orderID);

            _logger.LogInformation("GetOrderItemsByOrderID API ends");

            return Ok(orderItems);
        }

        //GET: api/orders/{orderID}/items/{orderItemID}
        [HttpGet("{orderItemID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderItemResponse?>> GetOrderItemByOrderItemID(Guid orderItemID)
        {
            _logger.LogInformation("GetOrderItemByOrderItemID API starts");

            var orderItem = await _orderItemsGetterService.GetOrderItemByOrderItemID(orderItemID);

            if (orderItem == null)
            {
                _logger.LogWarning($"Order item not found for Order Item ID: {orderItemID}.");
                return NotFound();
            }

            _logger.LogInformation("GetOrderItemByOrderItemID API ends");

            return Ok(orderItem);
        }

        //POST : api/orders/{orderID}/items
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<OrderItemResponse>> AddOrderItem(Guid orderID, OrderItemAddRequest orderItemRequest)
        {
            _logger.LogInformation("AddOrderItem API starts");

            var addedOrderItem = await _orderItemsAdderService.AddOrderItem(orderItemRequest);

            _logger.LogInformation("AddOrderItem API ends");

            return CreatedAtAction(nameof(GetOrderItemByOrderItemID), new { orderItemID = addedOrderItem.OrderItemID }, addedOrderItem);
        }

        //PUT: api/orders/{orderID}/items
        [HttpPut("{orderItemID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderItemResponse>> UpdateOrderItem(Guid orderItemID, OrderItemUpdateRequest orderItemRequest)
        {
            _logger.LogInformation("UpdateOrderItem API starts");
            if (orderItemID != orderItemRequest.OrderItemID)
            {
                _logger.LogWarning($"Invalid Order Item ID in the request: {orderItemRequest.OrderItemID}.");
                return BadRequest();
            }

            var updatedOrderItem = await _orderItemsUpdaterService.UpdateOrderItem(orderItemRequest);

            _logger.LogInformation("UpdateOrderItem API ends");

            return Ok(updatedOrderItem);
        }

    }
}
