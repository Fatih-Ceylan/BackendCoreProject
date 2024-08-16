using GCrm.Application.Features.Commands.Definitions.ProjectManager.Create;
using GCrm.Application.Features.Commands.Definitions.ProjectManager.Delete;
using GCrm.Application.Features.Commands.Definitions.ProjectManager.Update;
using GCrm.Application.Features.Queries.Definitions.ProjectManager.GetAll;
using GCrm.Application.Features.Queries.Definitions.ProjectManager.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class ProjectManagerController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProjectManagerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProjectManagerRequest request)
        {
            GetAllProjectManagerResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProjectManagerRequest request)
        {
            GetByIdProjectManagerResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateProjectManagerRequest request)
        {
            CreateProjectManagerResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateProjectManagerRequest request)
        {
            UpdateProjectManagerResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProjectManagerRequest request)
        {
            DeleteProjectManagerResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
