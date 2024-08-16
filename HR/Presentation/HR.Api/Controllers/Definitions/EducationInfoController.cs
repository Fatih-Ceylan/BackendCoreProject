using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class EducationInfoController : ControllerBase
    {
        readonly IMediator _mediator;

        public EducationInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpPost("[action]")]
        //public async Task<IActionResult> Create([FromBody] CreateEducationInfoRequest request)
        //{
        //    CreateEducationInfoResponse response = await _mediator.Send(request);
        //    return Ok(response);
        //}

        //[HttpPut("[action]")]
        //public async Task<IActionResult> Update([FromBody] UpdateEducationInfoRequest request)
        //{
        //    UpdateEducationInfoResponse response = await _mediator.Send(request);
        //    return Ok(response);
        //}

        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetAll([FromQuery] GetAllEducationInfoRequest request)
        //{
        //    GetAllEducationInfoResponse response = await _mediator.Send(request);
        //    return Ok(response);
        //}

        //[HttpGet("[action]/{Id}")]
        //public async Task<IActionResult> GetById([FromRoute] GetByIdEducationInfoRequest request)
        //{
        //    GetByIdEducationInfoResponse response = await _mediator.Send(request);
        //    return Ok(response);
        //}

        //[HttpDelete("[action]/{Id}")]
        //public async Task<IActionResult> Delete([FromRoute] DeleteEducationInfoRequest request)
        //{
        //    DeleteEducationInfoResponse response = await _mediator.Send(request);
        //    return Ok(response);

    }
}
