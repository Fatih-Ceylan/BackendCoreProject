using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NLLogistics.Application.Features.Commands.Definitions.Airport.Create;
using NLLogistics.Application.Features.Commands.Definitions.Airport.Delete;
using NLLogistics.Application.Features.Commands.Definitions.Airport.Update;
using NLLogistics.Application.Features.Queries.Definitions.Airport.GetAll;
using NLLogistics.Application.Features.Queries.Definitions.Airport.GetById;

namespace NLLogistics.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class AirportController : ControllerBase
    {
        readonly IMediator _mediator;

        public AirportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllAirportRequest request)
        {
            GetAllAirportResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdAirportRequest request)
        {
            GetByIdAirportResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateAirportRequest request)
        {
            CreateAirportResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateAirportRequest request)
        {
            UpdateAirportResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteAirportRequest request)
        {
            DeleteAirportResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
