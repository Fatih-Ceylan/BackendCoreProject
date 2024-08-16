using MediatR;
using Microsoft.AspNetCore.Mvc;
using NLLogistics.Application.Features.Commands.Definitions.Airline.Create;
using NLLogistics.Application.Features.Commands.Definitions.Airline.Delete;
using NLLogistics.Application.Features.Commands.Definitions.Airline.Update;
using NLLogistics.Application.Features.Queries.Definitions.Airline.GetAll;
using NLLogistics.Application.Features.Queries.Definitions.Airline.GetById;

namespace NLLogistics.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class AirlineController : ControllerBase
    {
        readonly IMediator _mediator;

        public AirlineController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllAirlineRequest request)
        {
            GetAllAirlineResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdAirportRequest request)
        {
            GetByIdAirlineResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateAirlineRequest request)
        {
            CreateAirlineResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateAirlineRequest request)
        {
            UpdateAirlineResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteAirlineRequest request)
        {
            DeleteAirlineResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
