using Card.Application.Features.Commands.Definitions.Address.Create;
using Card.Application.Features.Commands.Definitions.Address.Delete;
using Card.Application.Features.Commands.Definitions.Address.Update;
using Card.Application.Features.Queries.Definitions.Address.GetAll;
using Card.Application.Features.Queries.Definitions.Address.GetById;
using Card.Application.Features.Queries.Definitions.Address.GetUserAddress;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Card.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    [Authorize(AuthenticationSchemes = "Admin")]
    public class AddressController : ControllerBase
    {
        readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllAddressRequest request)
        {
            GetAllAddressResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdAddressRequest request)
        {
            GetByIdAddressResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserAddress([FromRoute] GetUserAddressRequest request)
        {
            GetUserAddressResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateAddressRequest request)
        {
            CreateAddressResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateAddressRequest request)
        {
            UpdateAddressResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteAddressRequest request)
        {
            DeleteAddressResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
