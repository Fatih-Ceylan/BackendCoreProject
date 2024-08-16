using HR.Application.Features.Commands.Definitions.Recruitment.Applications.JobApplication.Create;
using HR.Application.Features.Commands.Definitions.Recruitment.Applications.JobApplication.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers.Definitions.Applications
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationController : ControllerBase
    {
        readonly IMediator _mediator;
        public JobApplicationController(IMediator mediator) { _mediator = mediator; }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateJobApplicationRequest request)
        {
            CreateJobApplicationResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateJobApplicationRequest request)
        {
            UpdateJobApplicationResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetAll([FromQuery] GetAllJobApplicationRequest request)
        //{
        //    GetAllJobApplicationResponse response = await _mediator.Send(request);
        //    return Ok(response);
        //}

        //[HttpGet("[action]/{Id}")]
        //public async Task<IActionResult> GetById([FromRoute] GetByIdJobApplicationRequest request)
        //{
        //    GetByIdJobApplicationResponse response = await _mediator.Send(request);
        //    return Ok(response);
        //}
    }
}
