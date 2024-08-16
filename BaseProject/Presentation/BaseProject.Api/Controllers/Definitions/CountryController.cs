using BaseProject.Application.Features.Commands.Definitions.Country.Create;
using BaseProject.Application.Features.Commands.Definitions.Country.Delete;
using BaseProject.Application.Features.Commands.Definitions.Country.Update;
using BaseProject.Application.Features.Queries.Definitions.Country.GetAll;
using BaseProject.Application.Features.Queries.Definitions.Country.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class CountryController : ControllerBase
    {
        readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCountryRequest request)
        {
            GetAllCountryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCountryRequest request)
        {
            GetByIdCountryResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCountryRequest request)
        {
            CreateCountryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCountryRequest request)
        {
            UpdateCountryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCountryRequest request)
        {
            DeleteCountryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}