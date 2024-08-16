using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GControl.Application.Features.Queries.Definitions.EmployeeLabel.LabelGroup.GetById
{
    public class GetByIdLabelGroupHandler : IRequestHandler<GetByIdLabelGroupRequest, GetByIdLabelGroupResponse>
    {
        readonly IEmployeeReadRepository _employeeReadRepository;

        public GetByIdLabelGroupHandler(IEmployeeReadRepository employeeReadRepository)
        {
            _employeeReadRepository = employeeReadRepository;
        }

        public async Task<GetByIdLabelGroupResponse> Handle(GetByIdLabelGroupRequest request, CancellationToken cancellationToken)
        {
            var employee = _employeeReadRepository
                .GetWhere(e => e.Id == Guid.Parse(request.Id))
                .Include(e => e.EmployeeLabels)
                .Select(em => new EmployeeLabelGroupVM
                {
                    Id = em.Id.ToString(),
                    Name = em.FullName,
                    Labels = em.EmployeeLabels.Select(el => new EmployeeLabelGroupLabelVM
                    {
                        Id = el.Id.ToString(),
                        Name = el.Name,
                    }).ToList(),

                }).FirstOrDefault();

            return new()
            {
                Employee = employee
            };
        }
    }
}
