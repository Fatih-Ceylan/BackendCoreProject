using BaseProject.Application.Features.Commands.Definitions.City.Create;
using BaseProject.Application.Features.Commands.Definitions.City.Delete;
using BaseProject.Application.Features.Commands.Definitions.City.Update;
using BaseProject.Application.Features.Queries.Definitions.City.GetAll;
using BaseProject.Application.Features.Queries.Definitions.City.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.Api.Controllers.Definitions
{

    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class CityController : ControllerBase
    {
        readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCityRequest request)
        {
            GetAllCityResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCityRequest request)
        {
            GetByIdCityResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCityRequest request)
        {
            CreateCityResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCityRequest request)
        {
            UpdateCityResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCityRequest request)
        {
            DeleteCityResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}