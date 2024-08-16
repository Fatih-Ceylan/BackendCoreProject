using HR.Application.Features.Commands.Definitions.Employment.Employee.Create;
using HR.Application.Features.Commands.Definitions.Employment.Employee.Delete;
using HR.Application.Features.Commands.Definitions.Employment.Employee.Update;
using HR.Application.Features.Commands.Identity.Employee.Login;
using HR.Application.Features.Queries.Definitions.Employee.GetAll;
using HR.Application.Features.Queries.Definitions.Employee.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class EmployeeController : ControllerBase
    {
        readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllEmployeeRequest request)
        {
            GetAllEmployeeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdEmployeeRequest request)
        {
            GetByIdEmployeeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeRequest request)
        {
            CreateEmployeeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeRequest request)
        {
            UpdateEmployeeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginEmployeeRequest request)
        {
            LoginEmployeeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteEmployeeRequest request)
        {
            DeleteEmployeeResponse response = await _mediator.Send(request);
            return Ok(response);

        }
    }
}
