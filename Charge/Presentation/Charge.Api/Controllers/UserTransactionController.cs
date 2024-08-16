using GCharge.Application.Features.Queries.Definitions.UserTransaction.GetAll;
using GCharge.Application.Features.Queries.Definitions.UserTransaction.GetByUserId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GCharge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(AuthenticationSchemes = "Admin")]
    public class UserTransactionController : ControllerBase
    {
        readonly IMediator _mediator;

        public UserTransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllUserTransactionRequest request)
        {
            GetAllUserTransactionResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{UserId}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdUserTransactionRequest request)
        {
            GetByIdUserTransactionResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
