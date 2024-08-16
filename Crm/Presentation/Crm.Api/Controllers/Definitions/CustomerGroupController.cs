using GCrm.Application.Features.Commands.Definitions.CustomerGroup.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerGroup.Delete;
using GCrm.Application.Features.Commands.Definitions.CustomerGroup.Update;
using GCrm.Application.Features.Queries.Definitions.CustomerGroup.GetAll;
using GCrm.Application.Features.Queries.Definitions.CustomerGroup.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class CustomerGroupController : ControllerBase
    {

        readonly IMediator _mediator;

        public CustomerGroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCustomerGroupRequest request)
        {
            GetAllCustomerGroupResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCustomerGroupRequest request)
        {
            GetByIdCustomerGroupResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerGroupRequest request)
        {
            CreateCustomerGroupResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerGroupRequest request)
        {
            UpdateCustomerGroupResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCustomerGroupRequest request)
        {
            DeleteCustomerGroupResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
