using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platform.Api.Services.Company;
using Platform.Application.Features.Commands.Definitions.Company.Create;
using Platform.Application.Features.Commands.Definitions.Company.Delete;
using Platform.Application.Features.Commands.Definitions.Company.Update;
using Platform.Application.Features.Queries.Definitions.Company.GetAll;
using Platform.Application.Features.Queries.Definitions.Company.GetByCompanyIdModulesLicenses;
using Platform.Application.Features.Queries.Definitions.Company.GetById;
using Platform.Application.Features.Queries.Definitions.Company.GetByUrlPath;
using Platform.Application.Features.Queries.Definitions.Order.GetAll;
using Utilities.Core.UtilityApplication.Exceptions;
using Utilities.Infrastructure.UtilityInfrastructure.Operations;

namespace Platform.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class CompanyController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly ICompanyService _companyService;

        public CompanyController(IMediator mediator, ICompanyService companyService)
        {
            _mediator = mediator;
            _companyService = companyService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCompanyRequest request)
        {
            GetAllCompanyResponse response = await _mediator.Send(request);
            
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllOrder([FromQuery] GetAllOrderRequest request)
        {

            GetAllOrderResponse response = await _mediator.Send(request);
            
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCompanyRequest request)
        {
            GetByIdCompanyResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByCompanyIdModulesLicenses([FromRoute] GetByCompanyIdModulesLicensesRequest request)
        {
            GetByCompanyIdModulesLicensesResponse response = await _mediator.Send(request);

            return Ok(response);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromForm] CreateCompanyRequest request)
        {

            if (request.AdminUserPassword == request.AdminUserPasswordConfirm)
            {
                request.Files = Request.Form.Files;
                request.BaseDbName = NameOperation.CharacterRegulatory(request.BaseDbName).ToLower();
                CreateCompanyResponse response = await _mediator.Send(request);
                
                return Ok(await _companyService.Create(request, response, HttpContext.Request.Headers["Authorization"]));
            }
            else
            {
                throw new PasswordConfirmException();
            }

        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromForm] UpdateCompanyRequest request)
        {
            request.Files = Request.Form.Files;
            UpdateCompanyResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCompanyRequest request)
        {
            DeleteCompanyResponse response = await _mediator.Send(request);

            return Ok(await _companyService.Delete(request, response, HttpContext.Request.Headers["Authorization"]));
        }

        [AllowAnonymous]
        [HttpGet("[action]/{UrlPath}")]
        public async Task<IActionResult> GetByUrlPathCompany([FromRoute] GetByUrlPathCompanyRequest requestGetByUrlPathCompanyRequest)
        {
            GetByUrlPathCompanyResponse response = await _mediator.Send(requestGetByUrlPathCompanyRequest);

            return Ok(response);
        }

        //[HttpPost("[action]")]
        //public async Task<IActionResult> UploadFile([FromQuery] CompanyFileCreateRequest companyFileCreateRequest)
        //{
        //    companyFileCreateRequest.Files = Request.Form.Files;
        //    CompanyFileCreateResponse response = await _mediator.Send(companyFileCreateRequest); 
        //    return Ok(response);
        //}

        //[HttpDelete("[action]")]
        //public async Task<IActionResult> DeleteFile([FromBody] DeleteFileOption request)
        //{
        //    await _storageService.DeleteAsync(request.Path, request.FileName);
        //    return Ok("DeletedSuccess");
        //}

        //[HttpGet("[action]/{Path}")]
        //public async Task<IActionResult> GetAllFiles([FromRoute] string Path)
        //{
        //    var files = _storageService.GetFiles(Path);

        //    return Ok(files);
        //}
    }
}