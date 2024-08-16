using Card.Application.Features.Commands.Definitions.PhoneNumber.Create;
using Card.Application.Features.Commands.Definitions.PhoneNumber.Delete;
using Card.Application.Features.Commands.Definitions.PhoneNumber.Update;
using Card.Application.Features.Queries.Definitions.PhoneNumber.GetAll;
using Card.Application.Features.Queries.Definitions.PhoneNumber.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Card.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    [Authorize(AuthenticationSchemes = "Admin")]
    public class PhoneNumberController : ControllerBase
    {
        readonly IMediator _mediator;
        public PhoneNumberController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPhoneNumberRequest request)
        {
            GetAllPhoneNumberResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdPhoneNumberRequest request)
        {
            GetByIdPhoneNumberResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreatePhoneNumberRequest request)
        {
            CreatePhoneNumberResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdatePhoneNumberRequest request)
        {
            UpdatePhoneNumberResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeletePhoneNumberRequest request)
        {
            DeletePhoneNumberResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
