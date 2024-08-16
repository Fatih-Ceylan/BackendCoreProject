using BaseProject.Application.Features.Commands.Definitions.MailCredential.Create;
using BaseProject.Application.Features.Commands.Definitions.MailCredential.Delete;
using BaseProject.Application.Features.Commands.Definitions.MailCredential.Update;
using BaseProject.Application.Features.Queries.Definitions.MailCredential.GetAll;
using BaseProject.Application.Features.Queries.Definitions.MailCredential.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    //[Authorize(AuthenticationSchemes = "Admin")]

    public class MailCredentialController : ControllerBase
    {
        readonly IMediator _mediator;

        public MailCredentialController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllMailCredentialRequest request)
        {
            GetAllMailCredentialResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdMailCredentialRequest request)
        {
            GetByIdMailCredentialResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateMailCredentialRequest request)
        {
            CreateMailCredentialResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateMailCredentialRequest request)
        {
            UpdateMailCredentialResponse response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteMailCredentialRequest request)
        {
            DeleteMailCredentialResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}