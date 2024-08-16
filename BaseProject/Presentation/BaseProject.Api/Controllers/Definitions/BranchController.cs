using BaseProject.Application.Features.Commands.Definitions.Branch.Create;
using BaseProject.Application.Features.Commands.Definitions.Branch.Delete;
using BaseProject.Application.Features.Commands.Definitions.Branch.Update;
using BaseProject.Application.Features.Queries.Definitions.Branch.GetAll;
using BaseProject.Application.Features.Queries.Definitions.Branch.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class BranchController : ControllerBase
    {
        readonly IMediator _mediator;

        public BranchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllBranchRequest request)
        {
            GetAllBranchResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdBranchRequest request)
        {
            GetByIdBranchResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateBranchRequest request)
        {
            CreateBranchResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateBranchRequest request)
        {
            UpdateBranchResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteBranchRequest request)
        {
            DeleteBranchResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}