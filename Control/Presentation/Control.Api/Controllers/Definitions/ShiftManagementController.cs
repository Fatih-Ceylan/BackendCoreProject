using GControl.Application.Features.Commands.Definitions.ShiftManagement.Create;
using GControl.Application.Features.Commands.Definitions.ShiftManagement.Delete;
using GControl.Application.Features.Commands.Definitions.ShiftManagement.Update;
using GControl.Application.Features.Commands.Definitions.ShiftManagementIsActiveStatus;
using GControl.Application.Features.Queries.Definitions.ShiftManagement.FilterField;
using GControl.Application.Features.Queries.Definitions.ShiftManagement.GetAll;
using GControl.Application.Features.Queries.Definitions.ShiftManagement.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GControl.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ShiftManagementController : ControllerBase
    {
        readonly IMediator _mediator;

        public ShiftManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllShiftManagementRequest request)
        {
            GetAllShiftManagementResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdShiftManagementRequest request)
        {
            GetByIdShiftManagementResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateShiftManagementRequest request)
        {
            CreateShiftManagementResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateShiftManagementRequest request)
        {
            UpdateShiftManagementResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteShiftManagementRequest request)
        {
            DeleteShiftManagementResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateIsActive([FromBody] ShiftManagementIsActiveStatusRequest request)
        {
            ShiftManagementIsActiveStatusResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> FilterField([FromQuery] FilterFieldRequest request)
        {
            FilterFieldResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}

