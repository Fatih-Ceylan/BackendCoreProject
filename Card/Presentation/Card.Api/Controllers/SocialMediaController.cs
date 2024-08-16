using Card.Application.Features.Commands.Definitions.SocialMedia.Create;
using Card.Application.Features.Commands.Definitions.SocialMedia.Delete;
using Card.Application.Features.Commands.Definitions.SocialMedia.Update;
using Card.Application.Features.Queries.Definitions.SocialMedia.GetAll;
using Card.Application.Features.Queries.Definitions.SocialMedia.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Card.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    [Authorize(AuthenticationSchemes = "Admin")]
    public class SocialMediaController : ControllerBase
    {
        readonly IMediator _mediator;
        public SocialMediaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllSocialMediaRequest request)
        {
            GetAllSocialMediaResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdSocialMediaRequest request)
        {
            GetByIdSocialMediaResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateSocialMediaRequest request)
        {
            CreateSocialMediaResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateSocialMediaRequest request)
        {
            UpdateSocialMediaResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteSocialMediaRequest request)
        {
            DeleteSocialMediaResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
