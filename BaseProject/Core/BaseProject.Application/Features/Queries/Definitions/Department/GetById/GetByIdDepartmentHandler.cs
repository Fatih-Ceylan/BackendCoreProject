using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.VMs.Definitions;
using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.Department.GetById
{
    public class GetByIdDepartmentHandler : IRequestHandler<GetByIdDepartmentRequest, GetByIdDepartmentResponse>
    {
        readonly IDepartmentReadRepository _departmentReadRepository;

        public GetByIdDepartmentHandler(IDepartmentReadRepository departmentReadRepository)
        {
            _departmentReadRepository = departmentReadRepository;
        }

        public async Task<GetByIdDepartmentResponse> Handle(GetByIdDepartmentRequest request, CancellationToken cancellationToken)
        {
            var department = _departmentReadRepository
                            .GetWhere(d => d.Id == Guid.Parse(request.Id), false)
                            .Select(d => new DepartmentVM
                            {
                                Id = d.Id.ToString(),
                                CompanyId = d.CompanyId.ToString(),
                                CompanyName = d.Branch.Company.Name,
                                BranchId = d.BranchId.ToString(),
                                BranchName = d.Branch.Name,
                                Name = d.Name,
                                MainDepartmentId = d.MainDepartmentId.ToString(),
                                MainDepartmentName = d.MainDepartmentId != null ? _departmentReadRepository
                                                                            .GetAllDeletedStatusDesc(false, false)
                                                                            .Where(md => md.Id == d.MainDepartmentId)
                                                                            .Select(md => md.Name).FirstOrDefault() : null,
                                CreatedDate = d.CreatedDate,
                            }).FirstOrDefault();
            return new()
            {
                Department = department
            };
        }
    }
}