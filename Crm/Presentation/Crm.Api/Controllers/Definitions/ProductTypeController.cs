using GCrm.Application.Features.Commands.Definitions.ProductType.Create;
using GCrm.Application.Features.Commands.Definitions.ProductType.Delete;
using GCrm.Application.Features.Commands.Definitions.ProductType.Update;
using GCrm.Application.Features.Queries.Definitions.ProductType.GetAll;
using GCrm.Application.Features.Queries.Definitions.ProductType.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class ProductTypeController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProductTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductTypeRequest request)
        {
            GetAllProductTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProductTypeRequest request)
        {
            GetByIdProductTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateProductTypeRequest request)
        {
            CreateProductTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateProductTypeRequest request)
        {
            UpdateProductTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductTypeRequest request)
        {
            DeleteProductTypeResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
