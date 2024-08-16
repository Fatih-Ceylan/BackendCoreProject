using Card.Application.Features.Commands.Definitions.Cargo.Create;
using Card.Application.Features.Commands.Definitions.Cargo.Delete;
using Card.Application.Features.Commands.Definitions.Cargo.Update;
using Card.Application.Features.Queries.Definitions.Cargo.GetAll;
using Card.Application.Features.Queries.Definitions.Cargo.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Card.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    [Authorize(AuthenticationSchemes = "Admin")]
    public class CargoController : ControllerBase
    {
        readonly IMediator _mediator;

        public CargoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCargoRequest request)
        {
            GetAllCargoResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCargoRequest request)
        {
            GetByIdCargoResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCargoRequest request)
        {
            CreateCargoResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCargoRequest request)
        {
            UpdateCargoResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCargoRequest request)
        {
            DeleteCargoResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
