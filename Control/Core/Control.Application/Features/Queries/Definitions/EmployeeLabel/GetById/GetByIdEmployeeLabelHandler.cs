using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;

namespace GControl.Application.Features.Queries.Definitions.EmployeeLabel.GetById
{
    public class GetByIdEmployeeLabelHandler : IRequestHandler<GetByIdEmployeeLabelRequest, GetByIdEmployeeLabelResponse>
    {
        readonly IEmployeeLabelReadRepository _employeeLabelReadRepository;

        public GetByIdEmployeeLabelHandler(IEmployeeLabelReadRepository employeeLabelReadRepository)
        {
            _employeeLabelReadRepository = employeeLabelReadRepository;
        }

        public async Task<GetByIdEmployeeLabelResponse> Handle(GetByIdEmployeeLabelRequest request, CancellationToken cancellationToken)
        {
            var employeeLabel = _employeeLabelReadRepository
                                .GetWhere(ds => ds.Id == Guid.Parse(request.Id))
                                .Select(ds => new EmployeeLabelVM
                                {
                                    Id = ds.Id.ToString(),
                                    Name = ds.Name,
                                    //BaseProjectBranchId = ds.BaseProjectBranchId.ToString(),
                                    //BaseProjectCompanyId = ds.BaseProjectCompanyId.ToString(),
                                    CreatedDate = ds.CreatedDate
                                }).FirstOrDefault();

            return new()
            {
                EmployeeLabel = employeeLabel
            };
        }
    }
}


