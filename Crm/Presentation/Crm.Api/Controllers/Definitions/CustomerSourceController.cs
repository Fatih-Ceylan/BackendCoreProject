using GCrm.Application.Features.Commands.Definitions.CustomerSource.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerSource.Delete;
using GCrm.Application.Features.Commands.Definitions.CustomerSource.Update;
using GCrm.Application.Features.Queries.Definitions.CustomerSource.GetAll;
using GCrm.Application.Features.Queries.Definitions.CustomerSource.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class CustomerSourceController : ControllerBase
    {
        readonly IMediator _mediator;

        public CustomerSourceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCustomerSourceRequest request)
        {
            GetAllCustomerSourceResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCustomerSourceRequest request)
        {
            GetByIdCustomerSourceResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerSourceRequest request)
        {
            CreateCustomerSourceResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerSourceRequest request)
        {
            UpdateCustomerSourceResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCustomerSourceRequest request)
        {
            DeleteCustomerSourceResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
