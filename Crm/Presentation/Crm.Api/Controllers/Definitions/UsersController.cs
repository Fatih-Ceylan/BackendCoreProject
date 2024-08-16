using GCrm.Application.Features.Commands.Definitions.Users.Create;
using GCrm.Application.Features.Commands.Definitions.Users.Delete;
using GCrm.Application.Features.Commands.Definitions.Users.Update;
using GCrm.Application.Features.Queries.Definitions.Users.GetAll;
using GCrm.Application.Features.Queries.Definitions.Users.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllUsersRequest request)
        {
            GetAllUsersResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdUsersRequest request)
        {
            GetByIdUsersResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateUsersRequest request)
        {
            CreateUsersResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateUsersRequest request)
        {
            UpdateUsersResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUsersRequest request)
        {
            DeleteUsersResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
