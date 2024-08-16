using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class ProjectStatuesController : ControllerBase
    {
        //readonly IMediator _mediator;

        //public ProjectStatuesController(IMediator mediator)
        //{
        //    _mediator = mediator;
        //}

        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetAll([FromQuery] GetAllProjectStatuesRequest request)
        //{
        //    GetAllProjectStatuesResponse response = await _mediator.Send(request);
        //    return Ok(response);
        //}

        //[HttpGet("[action]/{Id}")]
        //public async Task<IActionResult> GetById([FromRoute] GetByIdProjectStatuesRequest request)
        //{
        //    GetByIdProjectStatuesResponse response = await _mediator.Send(request);
        //    return Ok(response);
        //}

        //[HttpPost("[action]")]
        //public async Task<IActionResult> Create([FromBody] CreateProjectStatuesRequest request)
        //{
        //    CreateProjectStatuesResponse response = await _mediator.Send(request);
        //    return Ok(response);
        //}

        //[HttpPut("[action]")]
        //public async Task<IActionResult> Update([FromBody] UpdateProjectStatuesRequest request)
        //{
        //    UpdateProjectStatuesResponse response = await _mediator.Send(request);
        //    return Ok(response);
        //}

        //[HttpDelete("[action]/{Id}")]
        //public async Task<IActionResult> Delete([FromRoute] DeleteProjectStatuesRequest request)
        //{
        //    DeleteProjectStatuesResponse response = await _mediator.Send(request);
        //    return Ok(response);
        //}
    }
}
