using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platform.Application.Features.Commands.Definitions.GModule.Create;
using Platform.Application.Features.Commands.Definitions.GModule.Delete;
using Platform.Application.Features.Commands.Definitions.GModule.Update;
using Platform.Application.Features.Queries.Definitions.GModule.GetAll;
using Platform.Application.Features.Queries.Definitions.GModule.GetAllByCurrentCompanyId;
using Platform.Application.Features.Queries.Definitions.GModule.GetById;

namespace Platform.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class GModuleController : ControllerBase
    {
        readonly IMediator _mediator;

        public GModuleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllGModuleRequest request)
        {

            GetAllGModuleResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdGModuleRequest request)
        {
            GetByIdGModuleResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllByCurrentCompanyId([FromQuery] GetAllByCurrentCompanyIdRequest request)
        {
            GetAllByCurrentCompanyIdResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateGModuleRequest request)
        {
            CreateGModuleResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateGModuleRequest request)
        {
            UpdateGModuleResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteGModuleRequest request)
        {
            DeleteGModuleResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}