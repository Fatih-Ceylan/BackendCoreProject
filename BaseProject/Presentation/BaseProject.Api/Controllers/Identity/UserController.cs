using BaseProject.Application.Features.Commands.Identity.AppUser.Create;
using BaseProject.Application.Features.Commands.Identity.AppUser.CreateFromPlatform;
using BaseProject.Application.Features.Commands.Identity.AppUser.Delete;
using BaseProject.Application.Features.Commands.Identity.AppUser.Update;
using BaseProject.Application.Features.Commands.Identity.AppUser.UpdatePassword;
using BaseProject.Application.Features.Commands.Identity.AppUserAppellation.Create;
using BaseProject.Application.Features.Queries.Identity.AppUser.GetAll;
using BaseProject.Application.Features.Queries.Identity.AppUser.GetAllAppUserLicenses;
using BaseProject.Application.Features.Queries.Identity.AppUser.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.Api.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class UserController : ControllerBase
    {
        readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getall-appuserlicenses")]
        public async Task<IActionResult> GetAllAppUserLicenses([FromQuery] GetAllAppUserLicensesRequest request)
        {
            GetAllAppUserLicensesResponse response = await _mediator.Send(request);
            return Ok(response);
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
        public async Task<IActionResult> Create([FromBody] CreateAppUserRequest request)
        {
            CreateAppUserResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("create-from-platform")]
        public async Task<IActionResult> CreateFromPlatform([FromBody] CreateAppUserFromPlatformRequest request)
        {
            CreateAppUserFromPlatformResponse response = await _mediator.Send(request);
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


        [HttpPost("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordRequest request)
        {
            UpdatePasswordResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("create-appellation")]
        public async Task<IActionResult> Create([FromBody] CreateAppUserAppellationRequest request)
        {
            CreateAppUserAppellationResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}