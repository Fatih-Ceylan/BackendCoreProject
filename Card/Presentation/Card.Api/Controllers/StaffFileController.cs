using Card.Application.Features.Commands.Definitions.StaffFile.Create;
using Card.Application.Features.Commands.Definitions.StaffFile.Delete;
using Card.Application.Features.Queries.Definitions.StaffFile.GetById;
using Card.Application.Features.Queries.Definitions.StaffFile.GetFileListByStaffId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Card.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class StaffFileController : ControllerBase
    {
        readonly IMediator _mediator;

        public StaffFileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromForm] CreateStaffFileRequest request)
        {
            request.Files = Request.Form.Files;
            CreateStaffFileResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteStaffFileRequest request)
        {
            DeleteStaffFileResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetFileListByStaffId([FromRoute] GetFileListByStaffIdRequest request)
        {
            GetFileListByStaffIdResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdStaffFileRequest request)
        {
            GetByIdStaffFileResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
