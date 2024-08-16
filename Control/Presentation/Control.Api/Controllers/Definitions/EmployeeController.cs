using GControl.Application.Features.Commands.Definitions.Employee.Create;
using GControl.Application.Features.Commands.Definitions.Employee.Delete;
using GControl.Application.Features.Commands.Definitions.Employee.EmployeeCredentials;
using GControl.Application.Features.Commands.Definitions.Employee.IsEmailUnique;
using GControl.Application.Features.Commands.Definitions.Employee.Update;
using GControl.Application.Features.Commands.Definitions.EmployeeIsActiveStatus;
using GControl.Application.Features.Commands.Definitions.EmployeeIsDeletedStatus;
using GControl.Application.Features.Commands.Definitions.UserMainInfo.Create;
using GControl.Application.Features.Commands.Identity.Employee.ChangePassword;
using GControl.Application.Features.Commands.Identity.Employee.ConfirmVerificationCode;
using GControl.Application.Features.Commands.Identity.Employee.ForgotPassword;
using GControl.Application.Features.Commands.Identity.Employee.Login;
using GControl.Application.Features.Commands.Identity.Employee.SendPasswordWithMail;
using GControl.Application.Features.Queries.Definitions.Employee.BringAllEmployee;
using GControl.Application.Features.Queries.Definitions.Employee.GetAll;
using GControl.Application.Features.Queries.Definitions.Employee.GetById;
using GControl.Application.Features.Queries.Definitions.Employee.MobileGetByIdEmployeeInfo;
using GControl.Application.Features.Queries.Definitions.Employee.NumberOfEmployeesOfDepartments;
using GControl.Application.Features.Queries.Definitions.UserMainInfo.GetCurrentUserInfo;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GControl.Api.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class EmployeeController : ControllerBase
    {
        readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllEmployeeRequest request)
        {
            GetAllEmployeeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdEmployeeRequest request)
        {
            GetByIdEmployeeResponse response = await _mediator.Send(request);
            return Ok(response);
        }
         
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromForm] CreateEmployeeRequest request)
        {
            CreateEmployeeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromForm] UpdateEmployeeRequest request)
        {
            UpdateEmployeeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteEmployeeRequest request)
        {
            DeleteEmployeeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginEmployeeRequest request)
        {

            LoginEmployeeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> DeletedEmployee([FromQuery] IsDeletedEmployeeRequest request)
        {
            IsDeletedEmployeeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> NumberOfEmployeesOfDepartments([FromQuery] NumberOfEmployeesOfDepartmentsRequest request)
        {
            NumberOfEmployeesOfDepartmentsResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> SendPasswordWithMail([FromForm] SendPasswordWithMailRequest request)
        {
            SendPasswordWithMailResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromForm] ForgotPasswordRequest request)
        {
            ForgotPasswordResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            ChangePasswordResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> MobileGetByIdEmployeeInfo([FromQuery] MobileGetByIdEmployeeInfoRequest request)
        {
            MobileGetByIdEmployeeInfoResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{VerificationCode}")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmVerificationCode([FromRoute] ConfirmVerificationCodeRequest request)
        {
            ConfirmVerificationCodeResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")] 
        public async Task<IActionResult> GetCurrentUserInfo([FromQuery] GetCurrentUserInfoRequest request)
        {
            GetCurrentUserInfoResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCurrentUserInfo([FromForm] CreateUserMainInfoRequest request)
        {
            CreateUserMainInfoResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateIsActive([FromBody] EmployeeIsActiveStatusRequest request)
        {
            EmployeeIsActiveStatusResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateIsDeleted([FromBody] EmployeeIsDeletedStatusRequest request)
        {
            EmployeeIsDeletedStatusResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> IsEmailUnique([FromForm] IsEmailUniqueRequest request)
        {
            IsEmailUniqueResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> EmployeeCredentials([FromForm] EmployeeCredentialsRequest request)
        {
            EmployeeCredentialsResponse response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}

