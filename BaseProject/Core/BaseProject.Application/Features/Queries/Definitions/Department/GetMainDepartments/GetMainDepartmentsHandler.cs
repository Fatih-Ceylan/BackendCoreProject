using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.VMs.Definitions;
using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.Department.GetMainDepartments
{
    public class GetMainDepartmentsHandler : IRequestHandler<GetMainDepartmentsRequest, GetMainDepartmentsResponse>
    {
        readonly IDepartmentReadRepository _departmentReadRepository;

        public GetMainDepartmentsHandler(IDepartmentReadRepository departmentReadRepository)
        {
            _departmentReadRepository = departmentReadRepository;
        }

        public async Task<GetMainDepartmentsResponse> Handle(GetMainDepartmentsRequest request, CancellationToken cancellationToken)
        {
            var query = _departmentReadRepository
                       .GetAllDeletedStatusDesc(false)
                       .Where(d => d.BranchId == Guid.Parse(request.BranchId) && d.MainDepartmentId == null)
                       .Select(d => new DepartmentVM
                       {
                           Id = d.Id.ToString(),
                           Name = d.Name,
                       });

            var totalCount = query.Count();
            var mainDepartments = query.ToList();

            return new()
            {
                TotalCount = totalCount,
                MainDepartments = mainDepartments,
            };
        }
    }
}