using GCrm.Application.Features.Commands.Definitions.CustomerActivityStatus.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerActivityStatus.Delete;
using GCrm.Application.Features.Commands.Definitions.CustomerActivityStatus.Update;
using GCrm.Application.Features.Queries.Definitions.CustomerActivityStatus.GetAll;
using GCrm.Application.Features.Queries.Definitions.CustomerActivityStatus.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class CustomerActivityStatusController : ControllerBase
    {
        readonly IMediator _mediator;

        public CustomerActivityStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCustomerActivityStatusRequest request)
        {
            GetAllCustomerActivityStatusResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCustomerActivityStatusRequest request)
        {
            GetByIdCustomerActivityStatusResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerActivityStatusRequest request)
        {
            CreateCustomerActivityStatusResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerActivityStatusRequest request)
        {
            UpdateCustomerActivityStatusResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCustomerActivityStatusRequest request)
        {
            DeleteCustomerActivityStatusResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
