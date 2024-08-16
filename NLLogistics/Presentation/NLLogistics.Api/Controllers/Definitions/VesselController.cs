using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NLLogistics.Application.Features.Commands.Definitions.Vessel.Create;
using NLLogistics.Application.Features.Commands.Definitions.Vessel.Delete;
using NLLogistics.Application.Features.Commands.Definitions.Vessel.Update;
using NLLogistics.Application.Features.Queries.Definitions.Vessel.GetAll;
using NLLogistics.Application.Features.Queries.Definitions.Vessel.GetById;

namespace NLLogistics.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class VesselController : ControllerBase
    {
        readonly IMediator _mediator;

        public VesselController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllVesselRequest request)
        {
            GetAllVesselResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdVesselRequest request)
        {
            GetByIdVesselResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateVesselRequest request)
        {
            CreateVesselResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateVesselRequest request)
        {
            UpdateVesselResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteVesselRequest request)
        {
            DeleteVesselResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
