using Card.Application.Features.Commands.Definitions.SocialMediaUrl.Create;
using Card.Application.Features.Commands.Definitions.SocialMediaUrl.Delete;
using Card.Application.Features.Commands.Definitions.SocialMediaUrl.Update;
using Card.Application.Features.Queries.Definitions.SocialMediaUrl.GetAll;
using Card.Application.Features.Queries.Definitions.SocialMediaUrl.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Card.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    [Authorize(AuthenticationSchemes = "Admin")]
    public class SocialMediaUrlController : ControllerBase
    {
        readonly IMediator _mediator;
        public SocialMediaUrlController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllSocialMediaUrlRequest request)
        {
            GetAllSocialMediaUrlResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdSocialMediaUrlRequest request)
        {
            GetByIdSocialMediaUrlResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateSocialMediaUrlRequest request)
        {
            CreateSocialMediaUrlResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateSocialMediaUrlRequest request)
        {
            UpdateSocialMediaUrlResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteSocialMediaUrlRequest request)
        {
            DeleteSocialMediaUrlResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
