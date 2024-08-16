using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platform.Application.Features.Commands.Definitions.SpecialOffer.Create;
using Platform.Application.Features.Commands.Definitions.SpecialOffer.Delete;
using Platform.Application.Features.Commands.Definitions.SpecialOffer.Update;
using Platform.Application.Features.Queries.Definitions.SpecialOffer.GetAll;
using Platform.Application.Features.Queries.Definitions.SpecialOffer.GetById;

namespace Platform.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    [Authorize(AuthenticationSchemes = "Admin")]
    public class SpecialOfferController : ControllerBase
    {
        readonly IMediator _mediator;

        public SpecialOfferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdSpecialOfferRequest request)
        {
            GetByIdSpecialOfferResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllSpecialOfferRequest request)
        {

            GetAllSpecialOfferResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateSpecialOfferRequest request)
        {
            CreateSpecialOfferResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateSpecialOfferRequest request)
        {
            UpdateSpecialOfferResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteSpecialOfferRequest request)
        {
            DeleteSpecialOfferResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
