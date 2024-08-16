using GCrm.Application.Features.Commands.Definitions.CompanyContactName.Create;
using GCrm.Application.Features.Commands.Definitions.CompanyContactName.Update;
using GCrm.Application.Features.Commands.Definitions.CustomerActivity.Delete;
using GCrm.Application.Features.Queries.Definitions.CompanyContactName.GetAll;
using GCrm.Application.Features.Queries.Definitions.CompanyContactName.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class CompanyContactNameController : ControllerBase
    {
        readonly IMediator _mediator;

        public CompanyContactNameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCompanyContactNameRequest request)
        {
            GetAllCompanyContactNameResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCompanyContactNameRequest request)
        {
            GetByIdCompanyContactNameResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCompanyContactNameRequest request)
        {
            CreateCompanyContactNameResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCompanyContactNameRequest request)
        {
            UpdateCompanyContactNameResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCustomerActivityRequest request)
        {
            DeleteCustomerActivityResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
