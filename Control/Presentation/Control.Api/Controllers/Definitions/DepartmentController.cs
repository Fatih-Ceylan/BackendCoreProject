using BaseProject.Application.Features.Queries.Definitions.Department.GetDropdownList;
using BaseProject.Application.Repositories.ReadRepository.Definitions;
using GControl.Application.Features.Commands.Definitions.Department.Create;
using GControl.Application.Features.Commands.Definitions.Department.Delete;
using GControl.Application.Features.Commands.Definitions.Department.Update;
using GControl.Application.Features.Commands.Definitions.DepartmentIsActiveStatus;
using GControl.Application.Features.Queries.Definitions.Department.GetAll;
using GControl.Application.Features.Queries.Definitions.Department.TotalDepartmentCount;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GControl.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class DepartmentController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly IDepartmentReadRepository _departmentReadRepository;

        public DepartmentController(IMediator mediator, IDepartmentReadRepository departmentReadRepository)
        {
            _mediator = mediator;
            _departmentReadRepository = departmentReadRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetDropdownListDepartment([FromQuery] GetDropdownListDepartmentRequest request)
        {
            GetDropdownListDepartmentResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllDepartmentRequest request)
        {
            GetAllDepartmentResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateDepartmentRequest request)
        {
            CreateDepartmentResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateDepartmentRequest request)
        {
            UpdateDepartmentResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteDepartmentRequest request)
        {
            DeleteDepartmentResponse response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> TotalDepartmentCount([FromQuery] TotalDepartmentCountRequest request)
        {
            TotalDepartmentCountResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateIsActive([FromBody] DepartmentIsActiveStatusRequest request)
        {
            DepartmentIsActiveStatusResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}