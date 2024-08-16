using GCrm.Application.Features.Commands.Definitions.OpportunitySector.Create;
using GCrm.Application.Features.Commands.Definitions.OpportunitySector.Delete;
using GCrm.Application.Features.Commands.Definitions.OpportunitySector.Update;
using GCrm.Application.Features.Queries.Definitions.OpportunitySector.GetAll;
using GCrm.Application.Features.Queries.Definitions.OpportunitySector.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class OpportunitySectorController : ControllerBase
    {
        readonly IMediator _mediator;

        public OpportunitySectorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllOpportunitySectorRequest request)
        {
            GetAllOpportunitySectorResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdOpportunitySectorRequest request)
        {
            GetByIdOpportunitySectorResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateOpportunitySectorRequest request)
        {
            CreateOpportunitySectorResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateOpportunitySectorRequest request)
        {
            UpdateOpportunitySectorResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteOpportunitySectorRequest request)
        {
            DeleteOpportunitySectorResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
