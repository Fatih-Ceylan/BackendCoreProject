using GCrm.Application.Features.Commands.Definitions.OpportunityReference.Create;
using GCrm.Application.Features.Commands.Definitions.OpportunityReference.Delete;
using GCrm.Application.Features.Commands.Definitions.OpportunityReference.Update;
using GCrm.Application.Features.Queries.Definitions.OpportunityReference.GetAll;
using GCrm.Application.Features.Queries.Definitions.OpportunityReference.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class OpportunityReferenceController : ControllerBase
    {
        readonly IMediator _mediator;

        public OpportunityReferenceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllOpportunityReferenceRequest request)
        {
            GetAllOpportunityReferenceResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdOpportunityReferenceRequest request)
        {
            GetByIdOpportunityReferenceResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateOpportunityReferenceRequest request)
        {
            CreateOpportunityReferenceResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateOpportunityReferenceRequest request)
        {
            UpdateOpportunityReferenceResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteOpportunityReferenceRequest request)
        {
            DeleteOpportunityReferenceResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
