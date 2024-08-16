using BaseProject.Application.Features.Commands.Definitions.Department.Create;
using BaseProject.Application.Features.Commands.Definitions.Department.Delete;
using BaseProject.Application.Features.Commands.Definitions.Department.Update;
using BaseProject.Application.Features.Queries.Definitions.Department.GetAll;
using BaseProject.Application.Features.Queries.Definitions.Department.GetById;
using BaseProject.Application.Features.Queries.Definitions.Department.GetMainDepartments;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class DepartmentController : ControllerBase
    {
        readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllDepartmentRequest request)
        {
            GetAllDepartmentResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetMainDepartments([FromQuery] GetMainDepartmentsRequest request)
        {
            GetMainDepartmentsResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdDepartmentRequest request)
        {
            GetByIdDepartmentResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateDepartmentRequest request)
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
            return Ok(response);//merge
        }
    }
}