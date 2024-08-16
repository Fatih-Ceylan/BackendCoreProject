using GCrm.Application.Features.Commands.Definitions.ProductBrand.Create;
using GCrm.Application.Features.Commands.Definitions.ProductBrand.Delete;
using GCrm.Application.Features.Commands.Definitions.ProductBrand.Update;
using GCrm.Application.Features.Queries.Definitions.ProductBrand.GetAll;
using GCrm.Application.Features.Queries.Definitions.ProductBrand.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class ProductBrandController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProductBrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductBrandRequest request)
        {
            GetAllProductBrandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProductBrandRequest request)
        {
            GetByIdProductBrandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateProductBrandRequest request)
        {
            CreateProductBrandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateProductBrandRequest request)
        {
            UpdateProductBrandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductBrandRequest request)
        {
            DeleteProductBrandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
