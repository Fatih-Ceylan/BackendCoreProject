using GCrm.Application.Features.Commands.Definitions.CustomerCategory.Create;
using GCrm.Application.Features.Commands.Definitions.CustomerCategory.Delete;
using GCrm.Application.Features.Commands.Definitions.CustomerCategory.Update;
using GCrm.Application.Features.Queries.Definitions.CustomerCategory.GetAll;
using GCrm.Application.Features.Queries.Definitions.CustomerCategory.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class CustomerCategoryController : ControllerBase
    {
        readonly IMediator _mediator;
        public CustomerCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCustomerCategoryRequest request)
        {
            GetAllCustomerCategoryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCustomerCategoryRequest request)
        {
            GetByIdCustomerCategoryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCategoryRequest request)
        {
            CreateCustomerCategoryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerCategoryRequest request)
        {
            UpdateCustomerCategoryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCustomerCategoryRequest request)
        {
            DeleteCustomerCategoryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
