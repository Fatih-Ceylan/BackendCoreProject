using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platform.Application.Features.Commands.Identity.AppUser.Create;
using Platform.Application.Features.Commands.Identity.AppUser.Delete;
using Platform.Application.Features.Commands.Identity.AppUser.Update;
using Platform.Application.Features.Queries.Identity.AppUser.GetAll;
using Platform.Application.Features.Queries.Identity.AppUser.GetById;

namespace Platform.Api.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
   
    [Authorize(AuthenticationSchemes = "Admin")]
    public class UserController : ControllerBase
    {
        readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllAppUserRequest request)
        {

            GetAllAppUserResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdAppUserRequest request)
        {
            GetByIdAppUserResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateAppUserRequest request)
        {
            CreateAppUserResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateAppUserRequest request)
        {
            UpdateAppUserResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteAppUserRequest request)
        {
            DeleteAppUserResponse response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}