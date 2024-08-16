using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class ProjectTypeController : ControllerBase
    {
        //readonly IMediator _mediator;

        //public ProjectTypeController(IMediator mediator)
        //{
        //    _mediator = mediator;
        //}

        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetAll([FromQuery] GetAllProjectTypeRequest request)
        //{
        //    GetAllProjectTypeResponse response = await _mediator.Send(request);
        //    return Ok(response);
        //}

        //[HttpGet("[action]/{Id}")]
        //public async Task<IActionResult> GetById([FromRoute] GetByIdProjectTypeRequest request)
        //{
        //    GetByIdProjectTypeResponse response = await _mediator.Send(request);
        //    return Ok(response);
        //}

        //[HttpPost("[action]")]
        //public async Task<IActionResult> Create([FromBody] CreateProjectTypeRequest request)
        //{
        //    CreateProjectTypeResponse response = await _mediator.Send(request);
        //    return Ok(response);
        //}

        //[HttpPut("[action]")]
        //public async Task<IActionResult> Update([FromBody] UpdateProjectTypeRequest request)
        //{
        //    UpdateProjectTypeResponse response = await _mediator.Send(request);
        //    return Ok(response);
        //}

        //[HttpDelete("[action]/{Id}")]
        //public async Task<IActionResult> Delete([FromRoute] DeleteProjectTypeRequest request)
        //{
        //    DeleteProjectTypeResponse response = await _mediator.Send(request);
        //    return Ok(response);
        //}
    }
}
