using GCrm.Application.Features.Commands.Definitions.CustomerContact.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerContact.Delete;
using GCrm.Application.Features.Commands.Definitions.CustomerContact.Update;
using GCrm.Application.Features.Queries.Definitions.CustomerContact.GetAll;
using GCrm.Application.Features.Queries.Definitions.CustomerContact.GetByCustomerId;
using GCrm.Application.Features.Queries.Definitions.CustomerContact.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class CustomerContactController : ControllerBase
    {

        readonly IMediator _mediator;

        public CustomerContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCustomerContactRequest request)
        {
            GetAllCustomerContactResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCustomerContactRequest request)
        {
            GetByIdCustomerContactResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByCustomerId([FromRoute] GetByCustomerIdRequest request)
        {
            GetByCustomerIdResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerContactRequest request)
        {
            CreateCustomerContactResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerContactRequest request)
        {
            UpdateCustomerContactResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCustomerContactRequest request)
        {
            DeleteCustomerContactResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
