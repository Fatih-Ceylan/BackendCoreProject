using GCrm.Application.Features.Commands.Definitions.CustomerActivityTeam.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerActivityTeam.Delete;
using GCrm.Application.Features.Commands.Definitions.CustomerActivityTeam.Update;
using GCrm.Application.Features.Queries.Definitions.CustomerActivityTeam.GetAll;
using GCrm.Application.Features.Queries.Definitions.CustomerActivityTeam.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class CustomerActivityTeamController : ControllerBase
    {
        readonly IMediator _mediator;

        public CustomerActivityTeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCustomerActivityTeamRequest request)
        {
            GetAllCustomerActivityTeamResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCustomerActivityTeamRequest request)
        {
            GetByIdCustomerActivityTeamResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerActivityTeamRequest request)
        {
            CreateCustomerActivityTeamResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerActivityTeamRequest request)
        {
            UpdateCustomerActivityTeamResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCustomerActivityTeamRequest request)
        {
            DeleteCustomerActivityTeamResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
