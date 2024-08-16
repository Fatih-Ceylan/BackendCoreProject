using GCrm.Application.Features.Commands.Definitions.CompanyTender.Create;
using GCrm.Application.Features.Commands.Definitions.CompanyTender.Delete;
using GCrm.Application.Features.Commands.Definitions.CompanyTender.Update;
using GCrm.Application.Features.Queries.Definitions.CompanyTender.GetAll;
using GCrm.Application.Features.Queries.Definitions.CompanyTender.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class CompanyTenderController : ControllerBase
    {
        readonly IMediator _mediator;

        public CompanyTenderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCompanyTenderRequest request)
        {
            GetAllCompanyTenderResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCompanyTenderRequest request)
        {
            GetByIdCompanyTenderResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCompanyTenderRequest request)
        {
            CreateCompanyTenderResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCompanyTenderRequest request)
        {
            UpdateCompanyTenderResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCompanyTenderRequest request)
        {
            DeleteCompanyTenderResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
