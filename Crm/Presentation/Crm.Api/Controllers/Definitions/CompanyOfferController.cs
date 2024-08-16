using GCrm.Application.Features.Commands.Definitions.CompanyOffer.Create;
using GCrm.Application.Features.Commands.Definitions.CompanyOffer.Delete;
using GCrm.Application.Features.Commands.Definitions.CompanyOffer.Update;
using GCrm.Application.Features.Queries.Definitions.CompanyOffer.GetAll;
using GCrm.Application.Features.Queries.Definitions.CompanyOffer.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GCrm.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class CompanyOfferController : ControllerBase
    {
        readonly IMediator _mediator;

        public CompanyOfferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCompanyOfferRequest request)
        {
            GetAllCompanyOfferResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCompanyOfferRequest request)
        {
            GetByIdCompanyOfferResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCompanyOfferRequest request)
        {
            CreateCompanyOfferResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCompanyOfferRequest request)
        {
            UpdateCompanyOfferResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCompanyOfferRequest request)
        {
            DeleteCompanyOfferResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
