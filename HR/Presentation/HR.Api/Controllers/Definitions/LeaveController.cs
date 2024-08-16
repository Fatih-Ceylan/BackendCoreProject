using HR.Application.Features.Commands.Definitions.Employment.Leave.Create;
using HR.Application.Features.Commands.Definitions.Employment.Leave.Update;
using HR.Application.Features.Queries.Definitions.Leave.GetAll;
using HR.Application.Features.Queries.Definitions.Leave.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class LeaveController : ControllerBase
    {
        readonly IMediator _mediator;

        public LeaveController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateLeaveRequest request)
        {
            CreateLeaveResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateLeaveRequest request)
        {
            UpdateLeaveResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdLeaveRequest request)
        {
            GetByIdLeaveResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllLeaveRequest request)
        {
            GetAllLeaveResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
