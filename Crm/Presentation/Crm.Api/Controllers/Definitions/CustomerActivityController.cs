using GCrm.Application.Features.Commands.Definitions.CustomerActivity.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerActivity.Delete;
using GCrm.Application.Features.Commands.Definitions.CustomerActivity.Update;
using GCrm.Application.Features.Queries.Definitions.CustomerActivity.GetAll;
using GCrm.Application.Features.Queries.Definitions.CustomerActivity.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class CustomerActivityController : ControllerBase
    {
        readonly IMediator _mediator;

        public CustomerActivityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCustomerActivityRequest request)
        {
            GetAllCustomerActivityResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCustomerActivityRequest request)
        {
            GetByIdCustomerActivityResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerActivityRequest request)
        {
            CreateCustomerActivityResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerActivityRequest request)
        {
            UpdateCustomerActivityResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCustomerActivityRequest request)
        {
            DeleteCustomerActivityResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
