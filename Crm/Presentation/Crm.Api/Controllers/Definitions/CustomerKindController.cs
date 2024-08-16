using GCrm.Application.Features.Commands.Definitions.CustomerKind.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerKind.Delete;
using GCrm.Application.Features.Commands.Definitions.CustomerKind.Update;
using GCrm.Application.Features.Queries.Definitions.CustomerKind.GetAll;
using GCrm.Application.Features.Queries.Definitions.CustomerKind.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class CustomerKindController : ControllerBase
    {
        readonly IMediator _mediator;

        public CustomerKindController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCustomerKindRequest request)
        {
            GetAllCustomerKindResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCustomerKindRequest request)
        {
            GetByIdCustomerKindResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerKindRequest request)
        {
            CreateCustomerKindResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerKindRequest request)
        {
            UpdateCustomerKindResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCustomerKindRequest request)
        {
            DeleteCustomerKindResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}