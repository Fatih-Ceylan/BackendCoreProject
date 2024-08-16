using GCrm.Application.Features.Commands.Definitions.CustomerActivitySubject.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerActivitySubject.Delete;
using GCrm.Application.Features.Commands.Definitions.CustomerActivitySubject.Update;
using GCrm.Application.Features.Queries.Definitions.CustomerActivitySubject.GetAll;
using GCrm.Application.Features.Queries.Definitions.CustomerActivitySubject.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class CustomerActivitySubjectController : ControllerBase
    {
        readonly IMediator _mediator;

        public CustomerActivitySubjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCustomerActivitySubjectRequest request)
        {
            GetAllCustomerActivitySubjectResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCustomerActivitySubjectRequest request)
        {
            GetByIdCustomerActivitySubjectResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerActivitySubjectRequest request)
        {
            CreateCustomerActivitySubjectResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerActivitySubjectRequest request)
        {
            UpdateCustomerActivitySubjectResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCustomerActivitySubjectRequest request)
        {
            DeleteCustomerActivitySubjectResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
