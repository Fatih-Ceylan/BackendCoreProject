using Card.Application.Features.Commands.Definitions.Payment.VPos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Card.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class PaymentController : ControllerBase
    {
        readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Payment([FromForm] CreatePaymentRequest request)
        {
            CreatePaymentResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
