using GCrm.Application.Features.Commands.Definitions.Project.Create;
using GCrm.Application.Features.Commands.Definitions.Project.Delete;
using GCrm.Application.Features.Commands.Definitions.Project.Update;
using GCrm.Application.Features.Queries.Definitions.Project.GetAll;
using GCrm.Application.Features.Queries.Definitions.Project.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class ProjectController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProjectRequest request)
        {
            GetAllProjectResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProjectRequest request)
        {
            GetByIdProjectResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromForm] CreateProjectRequest request)
        {
            request.Files = Request.Form.Files;
            CreateProjectResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromForm] UpdateProjectRequest request)
        {
            UpdateProjectResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProjectRequest request)
        {
            DeleteProjectResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
