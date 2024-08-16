using Card.Application.Abstractions.Services.Order;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Platform.Application.Features.Commands.Definitions.Order.UpdateCargoTrackingNo;
using Platform.Application.Features.Commands.Definitions.Order.UpdateOrderStatus;
using Platform.Application.Features.Queries.Definitions.Order.GetAll;

namespace Platform.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]

    public class OrderController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly IOrderService _CardOrderService;
        public OrderController(IMediator mediator, IOrderService orderService)
        {
            _mediator = mediator;
            _CardOrderService = orderService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllOrderRequest request)
        {

            GetAllOrderResponse response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpPut("update-orderstatus")]
        public async Task<IActionResult> UpdateOrderStatus([FromBody] UpdateOrderStatusRequest request)
        {
            UpdateOrderStatusResponse response = await _mediator.Send(request);

            await _CardOrderService.UpdateOrderStatus(request.OrderIdFromModule, request.OrderStatus);
            response.MessageList.Add("Updated order status for the Card module.");

            return Ok(response);
        }

        [HttpPut("update-cargotrackingno")]
        public async Task<IActionResult> UpdateCargoTrackingNo([FromBody] UpdateCargoTrackingNoRequest request)
        {
            UpdateCargoTrackingNoResponse response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}