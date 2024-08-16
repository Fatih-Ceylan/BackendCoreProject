using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platform.Application.Features.Commands.Definitions.GModuleLicenseTypePrice.Create;
using Platform.Application.Features.Commands.Definitions.GModuleLicenseTypePrice.Delete;
using Platform.Application.Features.Commands.Definitions.GModuleLicenseTypePrice.Update;
using Platform.Application.Features.Queries.Definitions.GModuleLicenseTypePrice.GetAll;
using Platform.Application.Features.Queries.Definitions.GModuleLicenseTypePrice.GetById;

namespace Platform.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    [Authorize(AuthenticationSchemes = "Admin")]
    public class GModuleLicenseTypePriceController : ControllerBase
    {
        readonly IMediator _mediator;

        public GModuleLicenseTypePriceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllGModuleLicenseTypePriceRequest request)
        {

            GetAllGModuleLicenseTypePriceResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdGModuleLicenseTypePriceRequest request)
        {
            GetByIdGModuleLicenseTypePriceResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateGModuleLicenseTypePriceRequest request)
        {
            CreateGModuleLicenseTypePriceResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateGModuleLicenseTypePriceRequest request)
        {
            UpdateGModuleLicenseTypePriceResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteGModuleLicenseTypePriceRequest request)
        {
            DeleteGModuleLicenseTypePriceResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}