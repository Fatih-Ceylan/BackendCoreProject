using BaseProject.Application.Repositories.ReadRepository.Definitions;
using BaseProject.Application.VMs.Definitions;
using MediatR;
namespace BaseProject.Application.Features.Queries.Definitions.Department.GetDropdownList
{
    public class GetDropdownListDepartmentHandler : IRequestHandler<GetDropdownListDepartmentRequest, GetDropdownListDepartmentResponse>
    {
        readonly IDepartmentReadRepository _departmentReadRepository;

        public GetDropdownListDepartmentHandler(IDepartmentReadRepository departmentReadRepository)
        {
            _departmentReadRepository = departmentReadRepository;
        }

        public async Task<GetDropdownListDepartmentResponse> Handle(GetDropdownListDepartmentRequest request, CancellationToken cancellationToken)
        {
            var departments = _departmentReadRepository
                             .GetAllDeletedStatusDesc(false)
                             .Select(d => new DepartmentDropdownListVM
                             {
                                 Id = d.Id.ToString(),
                                 Name = d.Name,
                             })
                             .ToList();

            return new()
            {
                DepartmentDropdownList = departments
            };
        }
    }
}
