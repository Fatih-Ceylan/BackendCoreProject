using HR.Application.Features.Commands.Definitions.Recruitment.Applications.JobApplicationStatus.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers.Definitions.Applications
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationStatusController : ControllerBase
    {
        readonly IMediator _mediator;
        public JobApplicationStatusController(IMediator mediator) { _mediator = mediator; }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateJobApplicationStatusRequest request)
        {
            CreateJobApplicationStatusResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        //[HttpPut("[action]")]
        //public async Task<IActionResult> Update([FromBody] UpdateJobApplicationStatusRequest request)
        //{
        //    UpdateJobApplicationStatusResponse response = await _mediator.Send(request);
        //    return Ok(response);
        //}

        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetAll([FromQuery] GetAllJobApplicationStatusRequest request)
        //{
        //    GetAllJobApplicationStatusResponse response = await _mediator.Send(request);
        //    return Ok(response);
        //}

        //[HttpGet("[action]/{Id}")]
        //public async Task<IActionResult> GetById([FromRoute] GetByIdJobApplicationStatusRequest request)
        //{
        //    GetByIdJobApplicationStatusResponse response = await _mediator.Send(request);
        //    return Ok(response);
        //}
    }
}
