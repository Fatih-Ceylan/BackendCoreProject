using GCrm.Application.Features.Commands.Definitions.ProductCategory.Create;
using GCrm.Application.Features.Commands.Definitions.ProductCategory.Delete;
using GCrm.Application.Features.Commands.Definitions.ProductCategory.Update;
using GCrm.Application.Features.Queries.Definitions.ProductCategory.GetAll;
using GCrm.Application.Features.Queries.Definitions.ProductCategory.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class ProductCategoryController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProductCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductCategoryRequest request)
        {
            GetAllProductCategoryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProductCategoryRequest request)
        {
            GetByIdProductCategoryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateProductCategoryRequest request)
        {
            CreateProductCategoryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateProductCategoryRequest request)
        {
            UpdateProductCategoryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductCategoryRequest request)
        {
            DeleteProductCategoryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
