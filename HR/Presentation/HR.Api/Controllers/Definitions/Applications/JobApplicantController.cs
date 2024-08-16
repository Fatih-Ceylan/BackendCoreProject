using HR.Application.Features.Commands.Definitions.Recruitment.Applications.JobApplicant.Create;
using HR.Application.Features.Commands.Definitions.Recruitment.Applications.JobApplicant.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers.Definitions.Applications
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicantController : ControllerBase
    {
        readonly IMediator _mediator;
        public JobApplicantController(IMediator mediator) { _mediator = mediator; }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateJobApplicantRequest request)
        {
            CreateJobApplicantResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateJobApplicantRequest request)
        {
            UpdateJobApplicantResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetAll([FromQuery] GetAllJobApplicantRequest request)
        //{
        //    GetAllJobApplicantResponse response = await _mediator.Send(request);
        //    return Ok(response);
        //}

        //[HttpGet("[action]/{Id}")]
        //public async Task<IActionResult> GetById([FromRoute] GetByIdJobApplicantRequest request)
        //{
        //    GetByIdJobApplicantResponse response = await _mediator.Send(request);
        //    return Ok(response);
        //}
    }
}
