using GControl.Application.Features.Commands.Definitions.Location.Create;
using GControl.Application.Features.Commands.Definitions.Location.Delete;
using GControl.Application.Features.Commands.Definitions.Location.Update;
using GControl.Application.Features.Queries.Definitions.Location.DownloadQrCode;
using GControl.Application.Features.Queries.Definitions.Location.FilterField;
using GControl.Application.Features.Queries.Definitions.Location.GetAll;
using GControl.Application.Features.Queries.Definitions.Location.GetById;
using GControl.Application.Features.Queries.Definitions.Location.GetQrCode;
using GControl.Application.Features.Queries.Definitions.Location.NumberOfEmployeesOfLocations;
using GControl.Application.Features.Queries.Definitions.Location.TotalLocationCount;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GControl.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class LocationController : ControllerBase
    {
        readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
       
        public async Task<IActionResult> GetAll([FromQuery] GetAllLocationRequest request)
        {
            GetAllLocationResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdLocationRequest request)
        {
            GetByIdLocationResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateLocationRequest request)
        {
            CreateLocationResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateLocationRequest request)
        {
            UpdateLocationResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteLocationRequest request)
        {
            DeleteLocationResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]/{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DownloadQrCode([FromRoute] DownloadQrCodeRequest request)
        {
            DownloadQrCodeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        //[AllowAnonymous]
        public async Task<IActionResult> GetQrCodeById([FromRoute] GetQrCodeRequest request)
        {
            GetQrCodeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> TotalLocationCount([FromQuery] TotalLocationCountRequest request)
        {
            TotalLocationCountResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> NumberOfEmployeesOfLocations([FromQuery] NumberOfEmployeesOfLocationsRequest request)
        {
            NumberOfEmployeesOfLocationsResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> FilterField([FromQuery] FilterFieldRequest request)
        {
            FilterFieldResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}

