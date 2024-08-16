using BaseProject.Application.DTOs.Identity.AppUser;
using BaseProject.Application.Repositories;
using BaseProject.Application.Repositories.WriteRepository.Definitions;
using Platform.Api.Services.BaseProject;
using Platform.Application.Features.Commands.Definitions.Company.Create;
using Platform.Application.Features.Commands.Definitions.Company.Delete;
using T = BaseProject.Domain.Entities.Definitions;

namespace Platform.Api.Services.Company
{
    public class CompanyService : ICompanyService
    {
        readonly IBaseProjectDbContext _baseProjectDbContext;
        readonly IBaseProjectService _baseProjectService;
        readonly ICompanyWriteRepository _baseProjectCompanyWriteRepository;
        readonly IBranchWriteRepository _branchWriteRepository;
        readonly IDepartmentWriteRepository _departmentWriteRepository;

        public CompanyService(IBaseProjectDbContext baseProjectDbContext, IBaseProjectService baseProjectService, ICompanyWriteRepository baseProjectCompanyWriteRepository, IBranchWriteRepository branchWriteRepository, IDepartmentWriteRepository departmentWriteRepository)
        {
            _baseProjectDbContext = baseProjectDbContext;
            _baseProjectService = baseProjectService;
            _baseProjectCompanyWriteRepository = baseProjectCompanyWriteRepository;
            _branchWriteRepository = branchWriteRepository;
            _departmentWriteRepository = departmentWriteRepository;
        }

        public async Task<CreateCompanyResponse> Create(CreateCompanyRequest request, CreateCompanyResponse response, string accessToken)
        {
                _baseProjectDbContext.BaseProjectUpdateDatabase(request.BaseDbName);
                response.MessageList.Add($"{request.BaseDbName}_base database has been created.");

                T.Company company = new();
                company.Name = request.Name;
                company.LogoPath = response.LogoPath;
                company.AuthorizedFullName = request.AuthorizedFullName;
                company.PhoneNumber = request.PhoneNumber;
                company.FaxNo = request.FaxNo;
                company.Email = request.Email;
                company.WebAddress = request.WebAddress;
                company.TaxOffice = request.TaxOffice;
                company.TaxNo = request.TaxNo;
                company.TradeRegisterNo = request.TradeRegisterNo;
                company.SocialSecurityNo = request.SocialSecurityNo;
                company.MersisNo = request.MersisNo;
                company.MasterCompanyIdFromPlatform = Guid.Parse(response.Id);

                company = await _baseProjectCompanyWriteRepository.AddAsync(company);
                response.MessageList.Add($"{request.Name} Company was added to the {request.BaseDbName}_base database as the parent company.");

                T.Branch branch = new();
                branch.CompanyId = company.Id;
                branch.Code = "0001";
                branch.Name = "Merkez Şube";
                branch.AuthorizedFullName = company.AuthorizedFullName;
                branch.PhoneNumber = company.PhoneNumber;
                branch.Email = company.Email;

                branch = await _branchWriteRepository.AddAsync(branch);
                response.MessageList.Add($"The branch for the company was added to the {request.BaseDbName}_base database");

                T.Department department = new();
                department.CompanyId = company.Id;
                department.BranchId = branch.Id;
                department.Name = "İdari İşler";

                department = await _departmentWriteRepository.AddAsync(department);
                await _departmentWriteRepository.SaveAsync();
                response.MessageList.Add($"The department for the branch was added to the {request.BaseDbName}_base database");

                CreateUserRequestDTO user = new();
                user.ProfileImagePath = "850762ab-3786-47ee-8219-cc3178b931d7";
                user.FullName = request.AdminUserFullName;
                user.UserName = request.AdminUserEmail;
                user.Email = request.AdminUserEmail;
                user.Password = request.AdminUserPassword;
                user.PasswordConfirm = request.AdminUserPasswordConfirm;
                user.CompanyId = company.Id.ToString();
                user.BranchId = branch.Id.ToString();
                user.DepartmentId = department.Id.ToString();

                var createdUserResponseMessage = await _baseProjectService.AddUser(user, accessToken, request.BaseDbName);
                if (createdUserResponseMessage != null)
                    response.MessageList.Add($"{user.UserName} {createdUserResponseMessage} to {request.BaseDbName}_base database");

                return response;
         
        }

        public async Task<DeleteCompanyResponse> Delete(DeleteCompanyRequest request, DeleteCompanyResponse response, string accessToken)
        {
            var message = await _baseProjectService.SoftDeleteAllUsers(accessToken, response.UrlPath);

            if (message != null)
                response.MessageList.Add($"{message} from {response.UrlPath}_base database");

            return response;
        }
    }
}