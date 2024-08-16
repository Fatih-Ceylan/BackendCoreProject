using Card.Application.Features.Commands.Definitions.StaffField.Create;
using Card.Application.Features.Commands.Definitions.StaffField.Delete;
using Card.Application.Features.Commands.Definitions.StaffField.Update;
using Card.Application.Features.Commands.Definitions.StaffField.UpdateWithList;
using Card.Application.Features.Queries.Definitions.StaffField.GetAll;
using Card.Application.Features.Queries.Definitions.StaffField.GetAllFieldByStaffId;
using Card.Application.Features.Queries.Definitions.StaffField.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Card.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class StaffFieldController : ControllerBase
    {
        readonly IMediator _mediator;

        public StaffFieldController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllStaffFieldRequest request)
        {
            GetAllStaffFieldResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdStaffFieldRequest request)
        {
            GetByIdStaffFieldResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetAllFieldByStaffId([FromRoute] GetAllFieldByStaffIdStaffFieldRequest request)
        {
            GetAllFieldByStaffIdStaffFieldResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateStaffFieldRequest request)
        {
            CreateStaffFieldResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateStaffFieldRequest request)
        {
            UpdateStaffFieldResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateWithList([FromBody] UpdateWithListStaffFieldRequest request)
        {
            UpdateWithListStaffFieldResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteStaffFieldRequest request)
        {
            DeleteStaffFieldResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
