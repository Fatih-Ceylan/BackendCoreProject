using GCrm.Application.Features.Commands.Definitions.Opportunity.Create;
using GCrm.Application.Features.Commands.Definitions.Opportunity.Delete;
using GCrm.Application.Features.Commands.Definitions.Opportunity.Update;
using GCrm.Application.Features.Queries.Definitions.Opportunity.GetAll;
using GCrm.Application.Features.Queries.Definitions.Opportunity.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class OpportunityController : ControllerBase
    {
        readonly IMediator _mediator;

        public OpportunityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllOpportunityRequest request)
        {
            GetAllOpportunityResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdOpportunityRequest request)
        {
            GetByIdOpportunityResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateOpportunityRequest request)
        {
            CreateOpportunityResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateOpportunityRequest request)
        {
            UpdateOpportunityResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteOpportunityRequest request)
        {
            DeleteOpportunityResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
