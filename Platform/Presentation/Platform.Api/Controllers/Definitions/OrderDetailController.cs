using MediatR;
using Microsoft.AspNetCore.Mvc;
using Platform.Application.Features.Queries.Definitions.OrderDetail.GetOrderDetailGroupsByOrderId;

namespace Platform.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]

    public class OrderDetailController : ControllerBase
    {
        readonly IMediator _mediator;

        public OrderDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-orderdetailgroups-byorderid/{OrderId}")]
        public async Task<IActionResult> GetById([FromRoute] GetOrderDetailGroupsByOrderIdRequest request)
        {
            GetOrderDetailGroupsByOrderIdResponse response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
