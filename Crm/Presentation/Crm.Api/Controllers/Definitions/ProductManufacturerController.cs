using GCrm.Application.Features.Commands.Definitions.ProductManufacturer.Create;
using GCrm.Application.Features.Commands.Definitions.ProductManufacturer.Delete;
using GCrm.Application.Features.Commands.Definitions.ProductManufacturer.Update;
using GCrm.Application.Features.Queries.Definitions.ProductManufacturer.GetAll;
using GCrm.Application.Features.Queries.Definitions.ProductManufacturer.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class ProductManufacturerController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProductManufacturerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductManufacturerRequest request)
        {
            GetAllProductManufacturerResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProductManufacturerRequest request)
        {
            GetByIdProductManufacturerResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateProductManufacturerRequest request)
        {
            CreateProductManufacturerResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateProductManufacturerRequest request)
        {
            UpdateProductManufacturerResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductManufacturerRequest request)
        {
            DeleteProductManufacturerResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
