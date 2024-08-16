using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NLLogistics.Application.Features.Commands.Definitions.Port.Create;
using NLLogistics.Application.Features.Commands.Definitions.Port.Delete;
using NLLogistics.Application.Features.Commands.Definitions.Port.Update;
using NLLogistics.Application.Features.Queries.Definitions.Port.GetAll;
using NLLogistics.Application.Features.Queries.Definitions.Port.GetById;

namespace NLLogistics.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class PortController : ControllerBase
    {
        readonly IMediator _mediator;

        public PortController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPortRequest request)
        {
            GetAllPortResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdPortRequest request)
        {
            GetByIdPortResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreatePortRequest request)
        {
            CreatePortResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdatePortRequest request)
        {
            UpdatePortResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeletePortRequest request)
        {
            DeletePortResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
