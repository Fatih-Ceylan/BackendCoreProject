using BaseProject.Application.Features.Commands.Identity.AppUserAppellation.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.Api.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserAppellationAppellationController : ControllerBase
    {
        readonly IMediator _mediator;
        public AppUserAppellationAppellationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //[Authorize(AuthenticationSchemes = "Admin")]

        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetAll([FromQuery] GetAllAppUserAppellationRequest request)
        //{

        //    GetAllAppUserAppellationResponse response = await _mediator.Send(request);

        //    return Ok(response);
        //}

        //[HttpGet("[action]/{Id}")]
        //public async Task<IActionResult> GetById([FromRoute] GetByIdAppUserAppellationRequest request)
        //{
        //    GetByIdAppUserAppellationResponse response = await _mediator.Send(request);

        //    return Ok(response);
        //}

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateAppUserAppellationRequest request)
        {
            CreateAppUserAppellationResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
