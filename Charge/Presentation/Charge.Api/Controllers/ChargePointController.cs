using GCharge.Application.Features.Queries.Definitions.ChargePoint.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GCharge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ChargePointController : ControllerBase
    {
        readonly IMediator _mediator;

        public ChargePointController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllChargePointRequest request)
        {
            GetAllChargePointResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
