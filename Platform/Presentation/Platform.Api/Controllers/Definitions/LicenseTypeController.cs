using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platform.Application.Features.Commands.Definitions.LicenseType.Create;
using Platform.Application.Features.Commands.Definitions.LicenseType.Delete;
using Platform.Application.Features.Commands.Definitions.LicenseType.Update;
using Platform.Application.Features.Queries.Definitions.LicenseType.GetAll;
using Platform.Application.Features.Queries.Definitions.LicenseType.GetById;

namespace Platform.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    [Authorize(AuthenticationSchemes = "Admin")]
    public class LicenseTypeController : ControllerBase
    {
        readonly IMediator _mediator;

        public LicenseTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdLicenseTypeRequest request)
        {
            GetByIdLicenseTypeResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllLicenseTypeRequest request)
        {

            GetAllLicenseTypeResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateLicenseTypeRequest request)
        {
            CreateLicenseTypeResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateLicenseTypeRequest request)
        {
            UpdateLicenseTypeResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteLicenseTypeRequest request)
        {
            DeleteLicenseTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}