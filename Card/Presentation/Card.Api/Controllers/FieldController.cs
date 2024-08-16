using Card.Application.Features.Commands.Definitions.Field.Create;
using Card.Application.Features.Commands.Definitions.Field.Delete;
using Card.Application.Features.Commands.Definitions.Field.Update;
using Card.Application.Features.Queries.Definitions.Field.GetAll;
using Card.Application.Features.Queries.Definitions.Field.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Card.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    [Authorize(AuthenticationSchemes = "Admin")]
    public class FieldController : ControllerBase
    {
        readonly IMediator _mediator;
        public FieldController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllFieldRequest request)
        {
            GetAllFieldResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdFieldRequest request)
        {
            GetByIdFieldResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateFieldRequest request)
        {
            CreateFieldResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateFieldRequest request)
        {
            UpdateFieldResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteFieldRequest request)
        {
            DeleteFieldResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
