using HR.Application.Features.Commands.Definitions.Employment.Appellation.Create;
using HR.Application.Features.Queries.Definitions.Appellation.GetAll;
using HR.Application.Features.Queries.Definitions.Appellation.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]

    public class AppellationController : ControllerBase
    {
        readonly IMediator _mediator;

        public AppellationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateAppellationRequest request)
        {
            CreateAppellationResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllAppellationRequest request)
        {
            GetAllAppellationResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdAppellationRequest request)
        {
            GetByIdAppellationResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
