using Card.Application.Features.Commands.Definitions.Iban.Create;
using Card.Application.Features.Commands.Definitions.Iban.Delete;
using Card.Application.Features.Commands.Definitions.Iban.Update;
using Card.Application.Features.Queries.Definitions.Iban.GetAll;
using Card.Application.Features.Queries.Definitions.Iban.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Card.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    [Authorize(AuthenticationSchemes = "Admin")]
    public class IbanController : ControllerBase
    {
        readonly IMediator _mediator;
        public IbanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllIbanRequest request)
        {
            GetAllIbanResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdIbanRequest request)
        {
            GetByIdIbanResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateIbanRequest request)
        {
            CreateIbanResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateIbanRequest request)
        {
            UpdateIbanResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteIbanRequest request)
        {
            DeleteIbanResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
