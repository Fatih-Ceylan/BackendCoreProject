using GCharge.Application.Features.Commands.Identity.AppUser.Create;
using GCharge.Application.Features.Commands.Identity.AppUser.Login;
using GCharge.Application.Features.Commands.Identity.AppUser.RefreshTokenLogin;
using GCharge.Application.Features.Commands.Identity.AppUser.ResetPassword;
using GCharge.Application.Features.Commands.Identity.AppUser.SendEmailToken;
using GCharge.Application.Features.Commands.Identity.AppUser.VerifyEmailToken;
using GCharge.Application.Features.Commands.Identity.AppUser.VerifyResetToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCharge.Api.Controllers.Identity
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
        public async Task<IActionResult> Login(LoginAppUserRequest request)
        {
            LoginAppUserResponse response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshTokenLogin([FromBody] RefreshTokenLoginRequest request)
        {
            RefreshTokenLoginResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            ResetPasswordResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("verify-reset-token")]
        public async Task<IActionResult> VerifyResetToken([FromBody] VerifyResetTokenRequest request)
        {
            VerifyResetTokenResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("send-email-token")]
        public async Task<IActionResult> SendEmailToken([FromBody] SendEmailTokenRequest request)
        {
            SendEmailTokenResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("verify-email-token")]
        public async Task<IActionResult> VerifyEmailToken([FromBody] VerifyEmailTokenRequest request)
        {
            VerifyEmailTokenResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SignUp([FromBody] CreateAppUserRequest request)
        {
            CreateAppUserResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}