using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NLLogistics.Application.Features.Commands.Definitions.Voyage.Create;
using NLLogistics.Application.Features.Commands.Definitions.Voyage.Delete;
using NLLogistics.Application.Features.Commands.Definitions.Voyage.Update;
using NLLogistics.Application.Features.Queries.Definitions.Voyage.GetAll;
using NLLogistics.Application.Features.Queries.Definitions.Voyage.GetById;

namespace NLLogistics.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class VoyageController : ControllerBase
    {
        readonly IMediator _mediator;

        public VoyageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllVoyageRequest request)
        {
            GetAllVoyageResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdVoyageRequest request)
        {
            GetByIdVoyageResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateVoyageRequest request)
        {
            CreateVoyageResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateVoyageRequest request)
        {
            UpdateVoyageResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteVoyageRequest request)
        {
            DeleteVoyageResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
