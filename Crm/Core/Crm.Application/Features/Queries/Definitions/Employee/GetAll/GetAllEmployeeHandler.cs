namespace GCrm.Application.Features.Queries.Definitions.Employee.GetAll
{
    //public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeRequest, GetAllEmployeeResponse>
    //{
    //    readonly IEmployeeReadRepository _employeeReadRepository;

    //    public GetAllEmployeeHandler(IEmployeeReadRepository employeeReadRepository)

    //    {
    //        _employeeReadRepository = employeeReadRepository;

    //    }
    //    public  Task<GetAllEmployeeResponse> Handle(GetAllEmployeeRequest request, CancellationToken cancellationToken)
    //    {
    //        var query = _employeeReadRepository
    //                     .GetAllDeletedStatusDesc(false)
    //                     .Select(ds => new EmployeeVM
    //                     {
    //                         Id = ds.Id.ToString(),
    //                         Name = ds.Name,
    //                     });

    //        var totalCount = query.Count();
    //        var employees = query.Skip(request.Page * request.Size)
    //                             .Take(request.Size).ToList();

    //        return Task.FromResult(new GetAllEmployeeResponse
    //        {
    //            TotalCount = totalCount,
    //            Employees = employees,
    //        });
    //    }
    //}
}
