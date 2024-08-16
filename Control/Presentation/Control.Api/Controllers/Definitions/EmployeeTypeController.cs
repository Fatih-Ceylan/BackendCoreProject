using GControl.Application.Features.Commands.Definitions.EmployeeType.Create;
using GControl.Application.Features.Commands.Definitions.EmployeeType.Delete;
using GControl.Application.Features.Commands.Definitions.EmployeeType.Update;
using GControl.Application.Features.Queries.Definitions.EmployeeType.GetAll;
using GControl.Application.Features.Queries.Definitions.EmployeeType.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GControl.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class EmployeeTypeController : ControllerBase
    {
        readonly IMediator _mediator;

        public EmployeeTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllEmployeeTypeRequest request)
        {
            GetAllEmployeeTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdEmployeeTypeRequest request)
        {
            GetByIdEmployeeTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeTypeRequest request)
        {
            CreateEmployeeTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeTypeRequest request)
        {
            UpdateEmployeeTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteEmployeeTypeRequest request)
        {
            DeleteEmployeeTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
