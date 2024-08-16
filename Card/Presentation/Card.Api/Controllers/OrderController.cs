using Card.Application.Features.Commands.Definitions.Order.Create;
using Card.Application.Features.Commands.Definitions.Order.Delete;
using Card.Application.Features.Commands.Definitions.Order.Update;
using Card.Application.Features.Queries.Definitions.Order.GetAll;
using Card.Application.Features.Queries.Definitions.Order.GetById;
using Card.Application.Features.Queries.Definitions.Order.GetDetailedListById;
using Card.Application.Features.Queries.Definitions.Order.GetDetailedListByStatus;
using Card.Application.Features.Queries.Definitions.Order.GetStaffAndQrListByOrderId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Card.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class OrderController : ControllerBase
    {
        readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllOrderRequest request)
        {
            GetAllOrderResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdOrderRequest request)
        {
            GetByIdOrderResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetDetailedListById([FromRoute] GetDetailedListByIdRequest request)
        {
            GetDetailedListByIdResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetStaffAndQrListByOrderId([FromQuery] GetStaffAndQrListByOrderIdRequest request)
        {
            GetStaffAndQrListByOrderIdResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetDetailedListByStatus([FromQuery] GetDetailedListByStatusRequest request)
        {
            GetDetailedListByStatusResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
        {
            CreateOrderResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateOrderRequest request)
        {
            UpdateOrderResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteOrderRequest request)
        {
            DeleteOrderResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
