using GCrm.Application.Features.Commands.Definitions.ProjectTeam.Create;
using GCrm.Application.Features.Commands.Definitions.ProjectTeam.Delete;
using GCrm.Application.Features.Commands.Definitions.ProjectTeam.Update;
using GCrm.Application.Features.Queries.Definitions.ProjectTeam.GetAll;
using GCrm.Application.Features.Queries.Definitions.ProjectTeam.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class ProjectTeamController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProjectTeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProjectTeamRequest request)
        {
            GetAllProjectTeamResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProjectTeamRequest request)
        {
            GetByIdProjectTeamResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateProjectTeamRequest request)
        {
            CreateProjectTeamResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateProjectTeamRequest request)
        {
            UpdateProjectTeamResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProjectTeamRequest request)
        {
            DeleteProjectTeamResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
