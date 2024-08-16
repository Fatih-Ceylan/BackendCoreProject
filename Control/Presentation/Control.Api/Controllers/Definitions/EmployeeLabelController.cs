using GControl.Application.Features.Commands.Definitions.EmployeeLabel.Create;
using GControl.Application.Features.Commands.Definitions.EmployeeLabel.Delete;
using GControl.Application.Features.Commands.Definitions.EmployeeLabel.DeletingEmployeesLabels;
using GControl.Application.Features.Commands.Definitions.EmployeeLabel.GroupLabel.Create;
using GControl.Application.Features.Commands.Definitions.EmployeeLabel.GroupLabel.Update;
using GControl.Application.Features.Commands.Definitions.EmployeeLabel.Update;
using GControl.Application.Features.Queries.Definitions.EmployeeLabel.FilterField;
using GControl.Application.Features.Queries.Definitions.EmployeeLabel.GetAll;
using GControl.Application.Features.Queries.Definitions.EmployeeLabel.GetById;
using GControl.Application.Features.Queries.Definitions.EmployeeLabel.LabelGroup.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GControl.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class EmployeeLabelController : ControllerBase
    {
        readonly IMediator _mediator;

        public EmployeeLabelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllEmployeeLabelRequest request)
        {
            GetAllEmployeeLabelResponse response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdEmployeeLabelRequest request)
        {
            GetByIdEmployeeLabelResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeLabelRequest request)
        {
            CreateEmployeeLabelResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeLabelRequest request)
        {
            UpdateEmployeeLabelResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteEmployeeLabelRequest request)
        {
            DeleteEmployeeLabelResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdLabelGroup([FromRoute] GetByIdLabelGroupRequest request)
        {
            GetByIdLabelGroupResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateLabelGroupAssignment([FromBody] CreateLabelGroupRequest request)
        {
            CreateLabelGroupResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> FilterField([FromQuery] FilterFieldRequest request)
        {
            FilterFieldResponse response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateLabelGroupAssignment([FromBody] UpdateGroupLabelRequest request)
        {
            UpdateGroupLabelResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> DeletingEmployeesLabels([FromBody] DeletingEmployeesLabelsRequest request)
        {
            DeletingEmployeesLabelsResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
