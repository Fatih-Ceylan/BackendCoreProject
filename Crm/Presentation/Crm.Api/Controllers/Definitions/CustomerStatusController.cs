using GCrm.Application.Features.Commands.Definitions.CustomerStatus.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerStatus.Delete;
using GCrm.Application.Features.Commands.Definitions.CustomerStatus.Update;
using GCrm.Application.Features.Queries.Definitions.CustomerStatus.GetAll;
using GCrm.Application.Features.Queries.Definitions.CustomerStatus.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class CustomerStatusController : ControllerBase
    {
        readonly IMediator _mediator;

        public CustomerStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCustomerStatusRequest request)
        {
            GetAllCustomerStatusResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCustomerStatusRequest request)
        {
            GetByIdCustomerStatusResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerStatusRequest request)
        {
            CreateCustomerStatusResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerStatusRequest request)
        {
            UpdateCustomerStatusResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCustomerStatusRequest request)
        {
            DeleteCustomerStatusResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
