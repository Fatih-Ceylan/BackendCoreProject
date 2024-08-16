using GCharge.Application.Features.Commands.Definitions.ChargeTag.Create;
using GCharge.Application.Features.Queries.Definitions.ChargeTag.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GCharge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ChargeTagController : ControllerBase
    {
        readonly IMediator _mediator;

        public ChargeTagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllChargeTagRequest request)
        {
            GetAllChargeTagResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateChargeTagRequest request)
        {
            CreateChargeTagResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
