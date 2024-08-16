using GControl.Application.Features.Commands.Definitions.EmployeeFile.Create;
using GControl.Application.Features.Queries.Definitions.EmployeeFile.GetById;
using GControl.Application.Features.Queries.Definitions.EmployeeFile.GetFileListByEmployeeId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GControl.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class EmployeeFileController : ControllerBase
    {
        readonly IMediator _mediator;

        public EmployeeFileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromForm] CreateEmployeeFileRequest request)
        {
            request.Files = Request.Form.Files;
            CreateEmployeeFileResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetFileListByEmployeeId([FromRoute] GetFileListByEmployeeIdRequest request)
        {
            GetFileListByEmployeeIdResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdEmployeeFileRequest request)
        {
            GetByIdEmployeeFileResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}

