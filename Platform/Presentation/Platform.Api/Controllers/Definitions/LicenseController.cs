using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platform.Application.Features.Commands.Definitions.License.CalculateLicensePrice;
using Platform.Application.Features.Commands.Definitions.License.Create;
using Platform.Application.Features.Commands.Definitions.License.Delete;
using Platform.Application.Features.Commands.Definitions.License.Update;
using Platform.Application.Features.Queries.Definitions.License.GetAll;
using Platform.Application.Features.Queries.Definitions.License.GetById;

namespace Platform.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    [Authorize(AuthenticationSchemes = "Admin")]
    public class LicenseController : ControllerBase
    {
        readonly IMediator _mediator;

        public LicenseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdLicenseRequest request)
        {
            GetByIdLicenseResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllLicenseRequest request)
        {

            GetAllLicenseResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateLicenseRequest request)
        {
            CreateLicenseResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CalculateLicensePrice([FromBody] CalculateLicensePriceRequest request)
        {
            CalculateLicensePriceResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateLicenseRequest request)
        {
            UpdateLicenseResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteLicenseRequest request)
        {
            DeleteLicenseResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}