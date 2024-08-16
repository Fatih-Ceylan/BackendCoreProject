using GCrm.Application.Features.Commands.Definitions.CustomerActivityType.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerActivityType.Delete;
using GCrm.Application.Features.Commands.Definitions.CustomerActivityType.Update;
using GCrm.Application.Features.Queries.Definitions.CustomerActivityType.GetAll;
using GCrm.Application.Features.Queries.Definitions.CustomerActivityType.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class CustomerActivityTypeController : ControllerBase
    {

        readonly IMediator _mediator;

        public CustomerActivityTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCustomerActivityTypeRequest request)
        {
            GetAllCustomerActivityTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCustomerActivityTypeRequest request)
        {
            GetByIdCustomerActivityTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerActivityTypeRequest request)
        {
            CreateCustomerActivityTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerActivityTypeRequest request)
        {
            UpdateCustomerActivityTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCustomerActivityTypeRequest request)
        {
            DeleteCustomerActivityTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
