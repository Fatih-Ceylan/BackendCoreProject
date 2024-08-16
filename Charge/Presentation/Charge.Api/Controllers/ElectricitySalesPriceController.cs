using GCharge.Application.Features.Commands.Definitions.ElectricitySalesPrice.Create;
using GCharge.Application.Features.Commands.Definitions.ElectricitySalesPrice.Delete;
using GCharge.Application.Features.Commands.Definitions.ElectricitySalesPrice.Update;
using GCharge.Application.Features.Queries.Definitions.ElectricitySalesPrice.GetAll;
using GCharge.Application.Features.Queries.Definitions.ElectricitySalesPrice.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GCharge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ElectricitySalesPriceController : ControllerBase
    {
        readonly IMediator _mediator;

        public ElectricitySalesPriceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllElectricitySalesPriceRequest request)
        {
            GetAllElectricitySalesPriceResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdElectricitySalesPriceRequest request)
        {
            GetByIdElectricitySalesPriceResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateElectricitySalesPriceRequest request)
        {
            CreateElectricitySalesPriceResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateElectricitySalesPriceRequest request)
        {
            UpdateElectricitySalesPriceResponse response = await _mediator.Send(request);
            return Ok(response);
        }
       
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteElectricitySalesPriceRequest request)
        {
            DeleteElectricitySalesPriceResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}