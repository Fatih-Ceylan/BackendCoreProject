using GCrm.Application.Features.Commands.Definitions.ProductModel.Create;
using GCrm.Application.Features.Commands.Definitions.ProductModel.Delete;
using GCrm.Application.Features.Commands.Definitions.ProductModel.Update;
using GCrm.Application.Features.Queries.Definitions.ProductModel.GetAll;
using GCrm.Application.Features.Queries.Definitions.ProductModel.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class ProductModelController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProductModelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductModelRequest request)
        {
            GetAllProductModelResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProductModelRequest request)
        {
            GetByIdProductModelResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateProductModelRequest request)
        {
            CreateProductModelResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateProductModelRequest request)
        {
            UpdateProductModelResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductModelRequest request)
        {
            DeleteProductModelResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
