using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Utilities.Core.UtilityApplication.Enums;

namespace GControl.Application.Features.Queries.Definitions.Employee.MobileGetByIdEmployeeInfo
{
    public class MobileGetByIdEmployeeInfoHandler : IRequestHandler<MobileGetByIdEmployeeInfoRequest, MobileGetByIdEmployeeInfoResponse>
    {
        readonly IEmployeeReadRepository _employeeReadRepository;

        public MobileGetByIdEmployeeInfoHandler(IEmployeeReadRepository employeeReadRepository)
        {
            _employeeReadRepository = employeeReadRepository;
        }

        public async Task<MobileGetByIdEmployeeInfoResponse> Handle(MobileGetByIdEmployeeInfoRequest request, CancellationToken cancellationToken)
        {
            var tokenParts = request.Token.Split('@');
            var userId = tokenParts[0];
            var expirationDate = DateTime.ParseExact(tokenParts[1], "dd.MM.yyyy HH:mm:ss", null);

            var employee = await _employeeReadRepository
                           .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                           .Select(c => new LoginVM
                           {
                               Id = c.Id.ToString(),
                               UserName = c.UserName,
                               Password = c.Password,
                               Token = c.Token

                           }).FirstOrDefaultAsync();

            if (employee != null && employee.Token == request.Token && expirationDate > DateTime.Now)
            {
                var data = await _employeeReadRepository.GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                .Select(c => new MobileRelatedListByEmployeeIdVM
                {
                    Id = c.Id.ToString(),
                    Email = c.Email,
                    FullName = c.FullName,
                    PhoneNumber = c.PhoneNumber,
                    CreatedDate = c.CreatedDate,
                    ProfilePicturePath = c.ProfilePicturePath,
                    UserName = c.UserName,
                    Password = c.Password,
                    Token = c.Token,
                }).FirstOrDefaultAsync();

                return new MobileGetByIdEmployeeInfoResponse
                {
                    Data = data,
                    Message = CommandResponseMessage.AddedSuccess.ToString(),
                    StatusCode = "200"
                };

            }
            else if (employee != null && employee.Token != request.Token)
            {
                return new MobileGetByIdEmployeeInfoResponse { Message = CommandResponseMessage.TokenNotMatchedError.ToString(), StatusCode = "403" };
            }
            else if (employee != null && expirationDate <= DateTime.Now)
            {
                return new MobileGetByIdEmployeeInfoResponse { Message = CommandResponseMessage.SessionExpired.ToString(), StatusCode = "419" };
            }
            else
            {
                return new MobileGetByIdEmployeeInfoResponse { Message = CommandResponseMessage.UserNotFound.ToString(), StatusCode = "404" };
            }
        }
    }
}
