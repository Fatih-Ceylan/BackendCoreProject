using GCharge.Application.Features.Commands.Identity.AppUser.Update;
using GCharge.Application.Features.Commands.Identity.AppUser.UpdatePassword;
using GCharge.Application.Features.Queries.Identity.AppUser.GetAll;
using GCharge.Application.Features.Queries.Identity.AppUser.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCharge.Api.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
   
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


        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateAppUserRequest request)
        {
            UpdateAppUserResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        //[HttpDelete("[action]/{Id}")]
        //public async Task<IActionResult> Delete([FromRoute] DeleteAppUserRequest request)
        //{
        //    DeleteAppUserResponse response = await _mediator.Send(request);

        //    return Ok(response);
        //}


        [HttpPost("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordRequest request)
        {
            UpdatePasswordResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}