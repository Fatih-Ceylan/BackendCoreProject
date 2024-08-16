using GCharge.Api.Services.OcppCoreServer;
using GCharge.Api.Services.OcppCoreServer.Models.Transaction.RemoteStartTransaction;
using GCharge.Api.Services.OcppCoreServer.Models.Transaction.RemoteStopTransaction;
using GCharge.Application.Features.Queries.Definitions.TransactionDetail.GetAll;
using GCharge.Application.Features.Queries.Definitions.TransactionDetail.GetByTransaction;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GCharge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(AuthenticationSchemes = "Admin")]
    //[Authorize(Roles = "MobileUser")]
    public class TransactionController : ControllerBase
    {
        readonly IOcppCoreServerService _ocppServer;
        readonly IMediator _mediator;

        public TransactionController(IOcppCoreServerService ocppServer, IMediator mediator)
        {
            _ocppServer = ocppServer;
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RemoteStartTransaction([FromBody] RemoteStartTransactionRequest request)
        {
            var response = await _ocppServer.RemoteStartTransaction(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RemoteStopTransaction([FromBody] RemoteStopTransactionRequest request)
        {
            var response = await _ocppServer.RemoteStopTransaction(request);
            return Ok(response);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllTransactionDetailRequest request)
        {

            GetAllTransactionDetailResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetTransactionDetail([FromQuery] GetTransactionDetailRequest request)
        {
            GetTransactionDetailResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
