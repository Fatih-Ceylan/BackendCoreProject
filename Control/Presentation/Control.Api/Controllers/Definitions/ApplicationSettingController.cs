using GControl.Application.Features.Commands.Definitions.ApplicationSetting.Create;
using GControl.Application.Features.Commands.Definitions.ApplicationSetting.Delete;
using GControl.Application.Features.Commands.Definitions.ApplicationSetting.Update;
using GControl.Application.Features.Queries.Definitions.ApplicationSetting.GetAll;
using GControl.Application.Features.Queries.Definitions.ApplicationSetting.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GControl.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ApplicationSettingController : ControllerBase
    {
        readonly IMediator _mediator;

        public ApplicationSettingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllApplicationSettingRequest request)
        {
            GetAllApplicationSettingResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdApplicationSettingRequest request)
        {
            GetByIdApplicationSettingResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateApplicationSettingRequest request)
        {
            CreateApplicationSettingResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateApplicationSettingRequest request)
        {
            UpdateApplicationSettingResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteApplicationSettingRequest request)
        {
            DeleteApplicationSettingResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
