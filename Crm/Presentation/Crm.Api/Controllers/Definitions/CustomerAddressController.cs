using GCrm.Application.Features.Commands.Definitions.CustomerAddress.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerAddress.Delete;
using GCrm.Application.Features.Commands.Definitions.CustomerAddress.Update;
using GCrm.Application.Features.Queries.Definitions.CustomerAddress.GetAll;
using GCrm.Application.Features.Queries.Definitions.CustomerAddress.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class CustomerAddressController : ControllerBase
    {
        readonly IMediator _mediator;

        public CustomerAddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCustomerAddressRequest request)
        {
            GetAllCustomerAddressResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCustomerAddressRequest request)
        {
            GetByIdCustomerAddressResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerAddressRequest request)
        {
            CreateCustomerAddressResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerAddressRequest request)
        {
            UpdateCustomerAddressResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCustomerAddressRequest request)
        {
            DeleteCustomerAddressResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}