using HR.Application.Features.Commands.Definitions.Employment.Payroll.Create;
using HR.Application.Features.Commands.Definitions.Employment.Payroll.Update;
using HR.Application.Features.Queries.Definitions.Payroll.GetAll;
using HR.Application.Features.Queries.Definitions.Payroll.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class PayrollController : ControllerBase
    {
        readonly IMediator _mediator;

        public PayrollController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreatePayrollRequest request)
        {
            CreatePayrollResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdatePayrollRequest request)
        {
            UpdatePayrollResponse response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdPayrollRequest request)
        {
            GetByIdPayrollResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPayrollRequest request)
        {
            GetAllPayrollResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
