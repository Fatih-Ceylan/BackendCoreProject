using GCharge.Application.Features.Commands.Definitions.UserChargeTag.Create;
using GCharge.Application.Features.Queries.Definitions.UserChargeTag.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GCharge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    [Authorize(AuthenticationSchemes = "Admin")]
    public class UserChargeTagController : ControllerBase
    {
        readonly IMediator _mediator;

        public UserChargeTagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllUserChargeTagRequest request)
        {
            GetAllUserChargeTagResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateUserChargeTagRequest request)
        {
            CreateUserChargeTagResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
