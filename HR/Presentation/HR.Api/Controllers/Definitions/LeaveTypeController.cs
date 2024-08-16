using HR.Application.Features.Commands.Definitions.Employment.LeaveType.Create;
using HR.Application.Features.Commands.Definitions.Employment.LeaveType.Update;
using HR.Application.Features.Queries.Definitions.LeaveType.GetAll;
using HR.Application.Features.Queries.Definitions.LeaveType.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class LeaveTypeController : ControllerBase
    {
        readonly IMediator _mediator;

        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateLeaveTypeRequest request)
        {
            CreateLeaveTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateLeaveTypeRequest request)
        {
            UpdateLeaveTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdLeaveTypeRequest request)
        {
            GetByIdLeaveTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllLeaveTypeRequest request)
        {
            GetAllLeaveTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
