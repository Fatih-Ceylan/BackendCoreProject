using MediatR;
using Microsoft.AspNetCore.Mvc;
using Platform.Application.Features.Commands.Outbounds.SendEmailToContacts;

namespace Platform.Api.Controllers.Outbounds
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutboundContactController : ControllerBase
    {
        readonly IMediator _mediator;

        public OutboundContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SendEmail([FromBody] SendEmailToContactsRequest request)
        {
            SendEmailToContactsResponse response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}