using GCrm.Application.Features.Commands.Definitions.CustomerType.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerType.Delete;
using GCrm.Application.Features.Commands.Definitions.CustomerType.Update;
using GCrm.Application.Features.Queries.Definitions.CustomerType.GetAll;
using GCrm.Application.Features.Queries.Definitions.CustomerType.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class CustomerTypeController : ControllerBase
    {
        readonly IMediator _mediator;
        public CustomerTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCustomerTypeRequest request)
        {
            GetAllCustomerTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCustomerTypeRequest request)
        {
            GetByIdCustomerTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerTypeRequest request)
        {
            CreateCustomerTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerTypeRequest request)
        {
            UpdateCustomerTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCustomerTypeRequest request)
        {
            DeleteCustomerTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
