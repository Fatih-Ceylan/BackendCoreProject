using Card.Application.Features.Commands.Definitions.Staff.Create;
using Card.Application.Features.Commands.Definitions.Staff.Delete;
using Card.Application.Features.Commands.Definitions.Staff.Update;
using Card.Application.Features.Commands.Identity.Staff.ChangePassword;
using Card.Application.Features.Commands.Identity.Staff.ConfirmVerificationCode;
using Card.Application.Features.Commands.Identity.Staff.ForgotPassword;
using Card.Application.Features.Commands.Identity.Staff.ForgotPasswordSendMail;
using Card.Application.Features.Commands.Identity.Staff.Login;
using Card.Application.Features.Queries.Definitions.Staff.GetAll;
using Card.Application.Features.Queries.Definitions.Staff.GetAllRelatedListByStaffId;
using Card.Application.Features.Queries.Definitions.Staff.GetById;
using Card.Application.Features.Queries.Definitions.Staff.GetByIdStaffInfo;
using Card.Application.Features.Queries.Definitions.Staff.MobileGetByIdStaffInfo;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Card.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class StaffController : ControllerBase
    {
        readonly IMediator _mediator;  

        public StaffController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllStaffRequest request)
        {  
            GetAllStaffResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdStaffRequest request)
        {
            GetByIdStaffResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetAllRelatedListByStaffId([FromRoute] GetAllRelatedListByStaffIdRequest request)
        {
            GetAllRelatedListByStaffIdResponse response = await _mediator.Send(request);
            return Ok(response);
        }  

        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> MobileGetByIdStaffInfo([FromQuery] MobileGetByIdStaffInfoRequest request)
        {
            MobileGetByIdStaffInfoResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdStaffInfo([FromQuery] GetByIdStaffInfoRequest request)
        { 
            GetByIdStaffInfoResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginStaffRequest request)
        {
            LoginStaffResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            ChangePasswordResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPasswordSendMail([FromForm] ForgotPasswordSendMailRequest request)
        { 
            ForgotPasswordSendMailResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromForm] ForgotPasswordRequest request)
        {
            ForgotPasswordResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{VerificationCode}")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmVerificationCode([FromRoute] ConfirmVerificationCodeRequest request)
        {
            ConfirmVerificationCodeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromForm] CreateStaffRequest request)
        {
            request.Files = Request.Form.Files;
            CreateStaffResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromForm] UpdateStaffRequest request)
        {
            UpdateStaffResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteStaffRequest request)
        {
            DeleteStaffResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
