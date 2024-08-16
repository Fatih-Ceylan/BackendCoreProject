using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.VMs.Definitions;
using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.Department.GetAll
{
    public class GetAllDepartmentHandler : IRequestHandler<GetAllDepartmentRequest, GetAllDepartmentResponse>
    {
        readonly IDepartmentReadRepository _departmentReadRepository;

        public GetAllDepartmentHandler(IDepartmentReadRepository departmentReadRepository)
        {
            _departmentReadRepository = departmentReadRepository;
        }

        public async Task<GetAllDepartmentResponse> Handle(GetAllDepartmentRequest request, CancellationToken cancellationToken)
        {
            var query = _departmentReadRepository
                        .GetAllDeletedStatusDesc(false, request.IsDeleted)
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
                                                                              .GetAllDeletedStatusDesc(false,false)
                                                                              .Where(md => md.Id == d.MainDepartmentId)
                                                                              .Select(md => md.Name).FirstOrDefault() 
                                                                            : null,
                            CreatedDate = d.CreatedDate,
                        });

            if (request.BranchId != null)
            {
                query = query.Where(d => d.BranchId == request.BranchId);
            }

            var totalCount = query.Count();
            var departments = request.DoPagination ? query.Skip(request.Page * request.Size)
                                                          .Take(request.Size)
                                                          .ToList()
                                                   : query.ToList();

            return new()
            {
                TotalCount = totalCount,
                Departments = departments,
            };
        }
    }
}