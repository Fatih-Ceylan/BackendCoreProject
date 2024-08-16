using GCrm.Application.Features.Commands.Definitions.OpportunityStage.Create;
using GCrm.Application.Features.Commands.Definitions.OpportunityStage.Delete;
using GCrm.Application.Features.Commands.Definitions.OpportunityStage.Update;
using GCrm.Application.Features.Queries.Definitions.OpportunityStage.GetAll;
using GCrm.Application.Features.Queries.Definitions.OpportunityStage.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class OpportunityStageController : ControllerBase
    {
        readonly IMediator _mediator;

        public OpportunityStageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllOpportunityStageRequest request)
        {
            GetAllOpportunityStageResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdOpportunityStageRequest request)
        {
            GetByIdOpportunityStageResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateOpportunityStageRequest request)
        {
            CreateOpportunityStageResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateOpportunityStageRequest request)
        {
            UpdateOpportunityStageResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteOpportunityStageRequest request)
        {
            DeleteOpportunityStageResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
