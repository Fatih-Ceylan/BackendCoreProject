using GCrm.Application.Features.Commands.Definitions.ProductMainCategory.Create;
using GCrm.Application.Features.Commands.Definitions.ProductMainCategory.Delete;
using GCrm.Application.Features.Commands.Definitions.ProductMainCategory.Update;
using GCrm.Application.Features.Queries.Definitions.ProductMainCategory.GetAll;
using GCrm.Application.Features.Queries.Definitions.ProductMainCategory.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class ProductMainCategoryController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProductMainCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductMainCategoryRequest request)
        {
            GetAllProductMainCategoryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProductMainCategoryRequest request)
        {
            GetByIdProductMainCategoryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateProductMainCategoryRequest request)
        {
            CreateProductMainCategoryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateProductMainCategoryRequest request)
        {
            UpdateProductMainCategoryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductMainCategoryRequest request)
        {
            DeleteProductMainCategoryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
