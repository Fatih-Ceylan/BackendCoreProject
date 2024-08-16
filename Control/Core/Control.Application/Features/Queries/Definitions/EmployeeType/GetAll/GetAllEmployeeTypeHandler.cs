using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;

namespace GControl.Application.Features.Queries.Definitions.EmployeeType.GetAll
{
    public class GetAllEmployeeTypeHandler : IRequestHandler<GetAllEmployeeTypeRequest, GetAllEmployeeTypeResponse>
    {
        readonly IEmployeeTypeReadRepository _employeeTypeReadRepository;

        public GetAllEmployeeTypeHandler(IEmployeeTypeReadRepository employeeTypeReadRepository)
        {
            _employeeTypeReadRepository = employeeTypeReadRepository;
        }

        public Task<GetAllEmployeeTypeResponse> Handle(GetAllEmployeeTypeRequest request, CancellationToken cancellationToken)
        {
            var query = _employeeTypeReadRepository
                        .GetAllDeletedStatusDesc(false,request.IsDeleted)
                        .Select(ds => new EmployeeTypeVM
                        {
                            Id = ds.Id.ToString(),
                            Name = ds.Name,
                        });

            var totalCount = query.Count();
            var employeeTypes = request.DoPagination ? query.Skip(request.Page * request.Size)
                                                            .Take(request.Size).ToList()
                                                     : query.ToList();

            return Task.FromResult(new GetAllEmployeeTypeResponse
            {
                TotalCount = totalCount,
                EmployeeTypes = employeeTypes,
            });
        }
    }
}
