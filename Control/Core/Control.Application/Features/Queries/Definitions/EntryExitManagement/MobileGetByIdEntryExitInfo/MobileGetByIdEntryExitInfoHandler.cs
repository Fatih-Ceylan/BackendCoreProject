using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Utilities.Core.UtilityApplication.Enums;

namespace GControl.Application.Features.Queries.Definitions.EntryExitManagement.MobileGetByIdEntryExitInfo
{
    public class MobileGetByIdEntryExitInfoHandler : IRequestHandler<MobileGetByIdEntryExitInfoRequest, MobileGetByIdEntryExitInfoResponse>
    {
        readonly IEntryExitManagementReadRepository _entryExitManagementReadRepository;
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly ILocationReadRepository _locationReadRepository;
        public MobileGetByIdEntryExitInfoHandler(IEntryExitManagementReadRepository entryExitManagementReadRepository, IEmployeeReadRepository employeeReadRepository, ILocationReadRepository locationReadRepository)
        {
            _entryExitManagementReadRepository = entryExitManagementReadRepository;
            _employeeReadRepository = employeeReadRepository;
            _locationReadRepository = locationReadRepository;
        }
        public async Task<MobileGetByIdEntryExitInfoResponse> Handle(MobileGetByIdEntryExitInfoRequest request, CancellationToken cancellationToken)
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

            var employeeId = Guid.Parse(request.Id);



            if (employee != null && employee.Token == request.Token && expirationDate > DateTime.Now)
            {
                DateTime startDate;
                switch (request.FilterPeriod)
                {
                    case "15days":
                        startDate = DateTime.Now.AddDays(-15);
                        break;
                    case "1month":
                        startDate = DateTime.Now.AddMonths(-1);
                        break;
                    case "3months":
                        startDate = DateTime.Now.AddMonths(-3);
                        break;
                    default:
                        startDate = DateTime.MinValue;
                        break;
                }

                var dataList = await _entryExitManagementReadRepository
                                    .GetWhere(ee => ee.EmployeeId == employeeId && ee.CompanyId == Guid.Parse(request.CompanyId) && ee.BranchId == Guid.Parse(request.BranchId) && ee.DateTime >= startDate, false)
                                    .Join(
                                        _locationReadRepository.GetAll(),
                                        ee => ee.LocationId,
                                        loc => loc.Id,
                                        (ee, loc) => new MobileRelatedListByEntryExitIdVM
                                        {
                                            Id = ee.Id.ToString(),
                                            EmployeeId = ee.EmployeeId.ToString(),
                                            LocationId = ee.LocationId.ToString(),
                                            BranchId = ee.BranchId.ToString(),
                                            BranchName = ee.Branch.Name,
                                            CompanyId = ee.CompanyId.ToString(),
                                            CompanyName = ee.Company.Name,
                                            LocationName = loc.Name,
                                            DateTime = ee.DateTime,
                                            IsRegistrationType = ee.IsRegistrationType,

                                        }
                                    ).ToListAsync();


                return new MobileGetByIdEntryExitInfoResponse
                {
                    Data = dataList,
                    Message = CommandResponseMessage.AddedSuccess.ToString(),
                    StatusCode = "200"
                };

            }
            else if (employee != null && employee.Token != request.Token)
            {
                return new MobileGetByIdEntryExitInfoResponse { Message = CommandResponseMessage.TokenNotMatchedError.ToString(), StatusCode = "403" };
            }
            else if (employee != null && expirationDate <= DateTime.Now)
            {
                return new MobileGetByIdEntryExitInfoResponse { Message = CommandResponseMessage.SessionExpired.ToString(), StatusCode = "419" };
            }
            else
            {
                return new MobileGetByIdEntryExitInfoResponse { Message = CommandResponseMessage.UserNotFound.ToString(), StatusCode = "404" };
            }
        }

    }

}
