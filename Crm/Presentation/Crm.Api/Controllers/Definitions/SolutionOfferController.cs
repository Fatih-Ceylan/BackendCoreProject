using GCrm.Application.Features.Commands.Definitions.SolutionOffer.Create;
using GCrm.Application.Features.Commands.Definitions.SolutionOffer.Delete;
using GCrm.Application.Features.Commands.Definitions.SolutionOffer.Update;
using GCrm.Application.Features.Queries.Definitions.SolutionOffer.GetAll;
using GCrm.Application.Features.Queries.Definitions.SolutionOffer.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class SolutionOfferController : ControllerBase
    {
        readonly IMediator _mediator;

        public SolutionOfferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllSolutionOfferRequest request)
        {
            GetAllSolutionOfferResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdSolutionOfferRequest request)
        {
            GetByIdSolutionOfferResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateSolutionOfferRequest request)
        {
            CreateSolutionOfferResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateSolutionOfferRequest request)
        {
            UpdateSolutionOfferResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteSolutionOfferRequest request)
        {
            DeleteSolutionOfferResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
