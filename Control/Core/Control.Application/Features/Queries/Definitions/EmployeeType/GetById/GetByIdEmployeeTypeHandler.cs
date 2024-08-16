using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;

namespace GControl.Application.Features.Queries.Definitions.EmployeeType.GetById
{
    public class GetByIdEmployeeTypeHandler : IRequestHandler<GetByIdEmployeeTypeRequest, GetByIdEmployeeTypeResponse>
    {
        readonly IEmployeeTypeReadRepository _employeeTypeReadRepository;

        public GetByIdEmployeeTypeHandler(IEmployeeTypeReadRepository employeeTypeReadRepository)
        {
            _employeeTypeReadRepository = employeeTypeReadRepository;
        }

        public async Task<GetByIdEmployeeTypeResponse> Handle(GetByIdEmployeeTypeRequest request, CancellationToken cancellationToken)
        {
            var employeeType = _employeeTypeReadRepository
                                .GetWhere(ds => ds.Id == Guid.Parse(request.Id))
                                .Select(ds => new EmployeeTypeVM
                                {
                                    Id = ds.Id.ToString(),
                                    Name = ds.Name
                                }).FirstOrDefault();
            return new()
            {
                EmployeeType = employeeType
            };
        }
    }
}
