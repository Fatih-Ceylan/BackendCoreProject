using HR.Application.Features.Commands.Definitions.Recruitment.Jobs.JobAdvert.Create;
using HR.Application.Features.Commands.Definitions.Recruitment.Jobs.JobAdvert.Update;
using HR.Application.Features.Queries.Definitions.Jobs.JobAdvert.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers.Job
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class JobAdvertController : ControllerBase
    {
        readonly IMediator _mediator;
        public JobAdvertController(IMediator mediator) { _mediator = mediator; }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateJobAdvertRequest request)
        {
            CreateJobAdvertResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateJobAdvertRequest request)
        {
            UpdateJobAdvertResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllJobAdvertRequest request)
        {
            GetAllJobAdvertResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        //[HttpGet("[action]/{Id}")]
        //public async Task<IActionResult> GetById([FromRoute] GetByIdJobAdvertRequest request)
        //{
        //    GetByIdJobAdvertResponse response = await _mediator.Send(request);
        //    return Ok(response);
        //}
    }
}
