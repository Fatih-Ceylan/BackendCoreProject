using GCrm.Application.Features.Commands.Definitions.Product.Create;
using GCrm.Application.Features.Commands.Definitions.Product.Delete;
using GCrm.Application.Features.Commands.Definitions.Product.Update;
using GCrm.Application.Features.Queries.Definitions.Product.GetAll;
using GCrm.Application.Features.Queries.Definitions.Product.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class ProductController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductRequest request)
        {
            GetAllProductResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProductRequest request)
        {
            GetByIdProductResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
        {
            CreateProductResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateProductRequest request)
        {
            UpdateProductResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductRequest request)
        {
            DeleteProductResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
