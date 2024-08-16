using BaseProject.Application.Features.Commands.Definitions.Company.Create;
using BaseProject.Application.Features.Commands.Definitions.Company.Delete;
using BaseProject.Application.Features.Commands.Definitions.Company.Update;
using BaseProject.Application.Features.Queries.Definitions.Company.GetAll;
using BaseProject.Application.Features.Queries.Definitions.Company.GetAllCompanyLicenses;
using BaseProject.Application.Features.Queries.Definitions.Company.GetById;
using BaseProject.Application.Features.Queries.Definitions.Company.GetMailCredentialsByCompanies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utilities.Core.UtilityApplication.Abstractions.Services.CurrentUser;

namespace BaseProject.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(AuthenticationSchemes = "Admin")]

    public class CompanyController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly ICurrentUserService _currentUserService;

        public CompanyController(IMediator mediator, ICurrentUserService currentUserService)
        {
            _mediator = mediator;
            _currentUserService = currentUserService;
        }

        [HttpGet("getall-companylicenses")]
        public async Task<IActionResult> GetAllCompanyLicenses([FromQuery] GetAllCompanyLicensesRequest request)
        {
            GetAllCompanyLicensesResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("get-mailcredantials-bycompanies")]
        public async Task<IActionResult> GetMailCredantialsByCompanies([FromQuery] GetMailCredentialsByCompaniesRequest request)
        {
            GetMailCredentialsByCompaniesResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCompanyRequest request)
        {
            GetAllCompanyResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdCompanyRequest request)
        {
            GetByIdCompanyResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCompanyRequest request)
        {
            CreateCompanyResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCompanyRequest request)
        {
            UpdateCompanyResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCompanyRequest request)
        {
            DeleteCompanyResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}