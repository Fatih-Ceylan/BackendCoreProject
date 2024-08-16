using MediatR;
using Microsoft.AspNetCore.Mvc;
using Platform.Application.Features.Commands.Identity.AppUser.Login;
using Platform.Application.Features.Commands.Identity.AppUser.RefreshTokenLogin;

namespace Platform.Api.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class AuthController : ControllerBase
    {
        IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginAppUserRequest request)
        {
            LoginAppUserResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshTokenLogin([FromBody] LoginRefreshTokenRequest request)
        {
            LoginRefreshTokenResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
