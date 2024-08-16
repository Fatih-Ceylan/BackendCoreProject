using GCrm.Application.Features.Commands.Definitions.ProductSubCategory.Create;
using GCrm.Application.Features.Commands.Definitions.ProductSubCategory.Delete;
using GCrm.Application.Features.Commands.Definitions.ProductSubCategory.Update;
using GCrm.Application.Features.Queries.Definitions.ProductSubCategory.GetAll;
using GCrm.Application.Features.Queries.Definitions.ProductSubCategory.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class ProductSubCategoryController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProductSubCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductSubCategoryRequest request)
        {
            GetAllProductSubCategoryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProductSubCategoryRequest request)
        {
            GetByIdProductSubCategoryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateProductSubCategoryRequest request)
        {
            CreateProductSubCategoryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateProductSubCategoryRequest request)
        {
            UpdateProductSubCategoryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductSubCategoryRequest request)
        {
            DeleteProductSubCategoryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
