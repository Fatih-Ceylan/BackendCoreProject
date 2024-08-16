using BaseProject.Application.Features.Commands.Definitions.CompanyAddress.Create;
using BaseProject.Application.Features.Commands.Definitions.CompanyAddress.Delete;
using BaseProject.Application.Features.Commands.Definitions.CompanyAddress.Update;
using BaseProject.Application.Features.Queries.Definitions.CompanyAddress.GetAll;
using BaseProject.Application.Features.Queries.Definitions.CompanyAddress.GetByCompanyId;
using BaseProject.Application.Features.Queries.Definitions.CompanyAddress.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class CompanyAddressController : ControllerBase
    {
        readonly IMediator _mediator;

        public CompanyAddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCompanyAddressRequest request)
        {
            GetAllCompanyAddressResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCompanyAddressRequest request)
        {
            GetByIdCompanyAddressResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetByCompanyId([FromQuery] GetByCompanyIdCompanyAddressesRequest request)
        {
            GetByCompanyIdCompanyAddressesResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateCompanyAddressRequest request)
        {
            CreateCompanyAddressResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCompanyAddressRequest request)
        {
            UpdateCompanyAddressResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCompanyAddressRequest request)
        {
            DeleteCompanyAddressResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
