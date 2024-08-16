using GCrm.Application.Features.Commands.Definitions.CustomerRepresentative.Create;
using GCrm.Application.Features.Queries.Definitions.CustomerRepresentative.GetAll;
using GCrm.Application.Features.Queries.Definitions.CustomerRepresentative.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class CustomerRepresentativeController : ControllerBase
    {
        readonly IMediator _mediator;

        public CustomerRepresentativeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCustomerRepresentativeRequest request)
        {
            GetAllCustomerRepresentativeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCustomerRepresentativeRequest request)
        {
            GetByIdCustomerRepresentativeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerRepresentativeRequest request)
        {
            CreateCustomerRepresentativeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        //[HttpPut("[action]")]
        //public async Task<IActionResult> Update([FromBody] UpdateCustomerRepresentativeRequest request)
        //{
        //    UpdateCustomerRepresentativeResponse response = await _mediator.Send(request);
        //    return Ok(response);
        //}

        //[HttpDelete("[action]/{Id}")]
        //public async Task<IActionResult> Delete([FromRoute] DeleteCustomerRepresentativeRequest request)
        //{
        //    DeleteCustomerRepresentativeResponse response = await _mediator.Send(request);
        //    return Ok(response);
        //}
    }
}
