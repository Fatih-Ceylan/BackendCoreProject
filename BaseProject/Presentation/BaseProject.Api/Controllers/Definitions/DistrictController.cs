using BaseProject.Application.Features.Commands.Definitions.District.Create;
using BaseProject.Application.Features.Commands.Definitions.District.Delete;
using BaseProject.Application.Features.Commands.Definitions.District.Update;
using BaseProject.Application.Features.Queries.Definitions.District.GetAll;
using BaseProject.Application.Features.Queries.Definitions.District.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.Api.Controllers.Definitions
{

    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class DistrictController : ControllerBase
    {
        readonly IMediator _mediator;

        public DistrictController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllDistrictRequest request)
        {
            GetAllDistrictResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdDistrictRequest request)
        {
            GetByIdDistrictResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateDistrictRequest request)
        {
            CreateDistrictResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateDistrictRequest request)
        {
            UpdateDistrictResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteDistrictRequest request)
        {
            DeleteDistrictResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}