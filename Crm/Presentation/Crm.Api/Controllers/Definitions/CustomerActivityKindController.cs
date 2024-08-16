using GCrm.Application.Features.Commands.Definitions.CustomerActivityKind.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerActivityKind.Delete;
using GCrm.Application.Features.Commands.Definitions.CustomerActivityKind.Update;
using GCrm.Application.Features.Queries.Definitions.CustomerActivityKind.GetAll;
using GCrm.Application.Features.Queries.Definitions.CustomerActivityKind.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class CustomerActivityKindController : ControllerBase
    {
        readonly IMediator _mediator;

        public CustomerActivityKindController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCustomerActivityKindRequest request)
        {
            GetAllCustomerActivityKindResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCustomerActivityKindRequest request)
        {
            GetByIdCustomerActivityKindResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerActivityKindRequest request)
        {
            CreateCustomerActivityKindResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerActivityKindRequest request)
        {
            UpdateCustomerActivityKindResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCustomerActivityKindRequest request)
        {
            DeleteCustomerActivityKindResponse response = await _mediator.Send(request);
            return Ok(response);
        }


    }
}
