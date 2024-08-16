using BaseProject.Application.Features.Commands.Definitions.AddressType.Create;
using BaseProject.Application.Features.Commands.Definitions.AddressType.Delete;
using BaseProject.Application.Features.Commands.Definitions.AddressType.Update;
using BaseProject.Application.Features.Queries.Definitions.AddressType.GetAll;
using BaseProject.Application.Features.Queries.Definitions.AddressType.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    [Authorize(AuthenticationSchemes = "Admin")]
    public class AddressTypeController : ControllerBase
    {
        readonly IMediator _mediator;

        public AddressTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllAddressTypeRequest request)
        {
            GetAllAddressTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdAddressTypeRequest request)
        {
            GetByIdAddressTypeResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateAddressTypeRequest request)
        {
            CreateAddressTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateAddressTypeRequest request)
        {
            UpdateAddressTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteAddressTypeRequest request)
        {
            DeleteAddressTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
