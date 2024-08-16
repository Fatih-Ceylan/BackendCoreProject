using GControl.Application.Features.Commands.Definitions.EmployeeLabel.GroupEntryExit;
using GControl.Application.Features.Commands.Definitions.EntryExitManagement.Create;
using GControl.Application.Features.Commands.Definitions.EntryExitManagement.Delete;
using GControl.Application.Features.Commands.Definitions.EntryExitManagement.ToggleEntryExitRecord;
using GControl.Application.Features.Commands.Definitions.EntryExitManagement.Update;
using GControl.Application.Features.Queries.Definitions.EntryExitManagement.EmployeeEntryInAndOut;
using GControl.Application.Features.Queries.Definitions.EntryExitManagement.GetAll;
using GControl.Application.Features.Queries.Definitions.EntryExitManagement.GetById;
using GControl.Application.Features.Queries.Definitions.EntryExitManagement.LoggedInEmployees;
using GControl.Application.Features.Queries.Definitions.EntryExitManagement.MobileGetByIdEntryExitInfo;
using GControl.Application.Features.Queries.Definitions.EntryExitManagement.NotLoggedInEmployee;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GControl.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class EntryExitManagementController : ControllerBase
    {
        readonly IMediator _mediator;

        public EntryExitManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllEntryExitManagementRequest request)
        {
            GetAllEntryExitManagementResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdEntryExitManagementRequest request)
        {
            GetByIdEntryExitManagementResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateEntryExitManagementRequest request)
        {
            CreateEntryExitManagementResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateEntryExitManagementRequest request)
        {
            UpdateEntryExitManagementResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteEntryExitManagementRequest request)
        {
            DeleteEntryExitManagementResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> EmployeeEntryInAndOut([FromQuery] EmployeeEntryInAndOutRequest request)
        {
            EmployeeEntryInAndOutResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> LoggedInEmployees([FromQuery] LoggedInEmployeesRequest request)
        {
            LoggedInEmployeesResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> NotLoggedInEmployee([FromQuery] NotLoggedInEmployeeRequest request)
        {
            NotLoggedInEmployeeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> MobileGetByIdEntryExitInfo([FromQuery] MobileGetByIdEntryExitInfoRequest request)
        {
            MobileGetByIdEntryExitInfoResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateEntryExitGroupAssignment([FromBody] CreateGroupEntryExitRequest request)
        {
            CreateGroupEntryExitResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> ToggleEntryExitRecord([FromBody] ToggleEntryExitRecordRequest request)
        {
            ToggleEntryExitRecordResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}

