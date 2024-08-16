namespace GCrm.Application.Features.Queries.Definitions.Employee.GetById
{
    //public class GetByIdEmployeeHandler : IRequestHandler<GetByIdEmployeeRequest, GetByIdEmployeeResponse>
    //{
    //    readonly IEmployeeReadRepository _employeeReadRepository;
    //    public GetByIdEmployeeHandler(IEmployeeReadRepository employeeReadRepository) 
    //    {
    //        _employeeReadRepository = employeeReadRepository;
    //    }
    //    public async Task<GetByIdEmployeeResponse> Handle(GetByIdEmployeeRequest request, CancellationToken cancellationToken)
    //    {
    //        var emloyees = _employeeReadRepository
    //                           .GetWhere(emp => emp.Id == Guid.Parse(request.Id))
    //                           .Select(emp => new EmployeeVM
    //                           {
    //                               Id = emp.Id.ToString(),
    //                               Name = emp.Name,
    //                           }).FirstOrDefault();
    //        return new()
    //        {
    //            Employee = emloyees
    //        };
    //    }
    //}
}
