using HR.Application.Repositories.ReadRepository;
using HR.Application.VMs.Definitions;
using MediatR;
using Newtonsoft.Json;
using Utilities.Infrastructure.UtilityInfrastructure.Services.RedisCache.InterFaces;

namespace HR.Application.Features.Queries.Definitions.Employee.GetAll
{
    public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeRequest, GetAllEmployeeResponse>
    {
        public IEmployeeReadRepository _employeeReadRepository;
        private IRedisCacheService _redisCacheService;
        //private IDistributedCache _distributedCache;
        private const string CacheKey = "GetAll_Employees";

        public GetAllEmployeeHandler(IEmployeeReadRepository employeeReadRepository/*, IDistributedCache distributedCache*/, IRedisCacheService redisCacheService)
        {
            _employeeReadRepository = employeeReadRepository;
            _redisCacheService = redisCacheService;
            //_distributedCache = distributedCache;
        }

        public async Task<GetAllEmployeeResponse> Handle(GetAllEmployeeRequest request, CancellationToken cancellationToken)
        {

            //redis olmadan cache'leme kullanımı
            List<EmployeeVM> employeeVMList;
            var cachedEmployees = await _redisCacheService.GetValueAsync(CacheKey);
            if (cachedEmployees != null)
            {
                employeeVMList = JsonConvert.DeserializeObject<List<EmployeeVM>>(cachedEmployees);
                if (employeeVMList != null)
                {
                    var paginatedEmployees = request.DoPagination
                        ? employeeVMList.Skip(request.Page * request.Size).Take(request.Size).ToList()
                        : employeeVMList;

                    return new GetAllEmployeeResponse
                    {
                        TotalCount = employeeVMList.Count,
                        Employees = paginatedEmployees
                    };
                }
            }

            //redis ile cache kullanımı
            //List<EmployeeVM> employeeVMList;
            //var cachedEmployees =  _redisCacheService.GetOrAddAsync<IList<T.Employee>("employees");


            var query = _employeeReadRepository.GetAllDeletedStatusDesc(false, request.IsDeleted)
               .Select(c => new EmployeeVM
               {
                   Id = c.Id.ToString(),
                   FirstName = c.FirstName,
                   LastName = c.LastName,
                   Email = c.Email,
                   UserName = c.UserName.ToString(),
                   Password = c.Password,
                   Token = c.Token,
                   PhoneNumber = c.PhoneNumber,
                   HireDate = c.HireDate,
                   Salary = c.Salary,
                   CompanyId = c.CompanyId.ToString(),
                   BranchId = c.BranchId.ToString(),
                   DepartmentId = c.DepartmentId.ToString(),
                   AppellationId = c.AppellationId.ToString(),
                   AppellationName = c.Appellation != null ? c.Appellation.Name : null,
                   CreatedDate = c.CreatedDate,
                   ManagedDepartmentId = c.ManagedDepartmentId.ToString(),
                   ManagerId = c.ManagerId.ToString()

               }).ToList();

            var totalCount = query.Count();
            var employees = request.DoPagination ? query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList() : query.ToList();

            employeeVMList = query;
            await CacheEmployees(employeeVMList);

            return await Task.FromResult(new GetAllEmployeeResponse
            {
                TotalCount = totalCount,
                Employees = employees,
            });
        }

        private async Task CacheEmployees(List<EmployeeVM> employeeVMs)
        {
            //opsiyonel parametre, null gönderilebilir.
            var cacheTime = new TimeSpan(0, 10, 0);

            await _redisCacheService.SetValueAsync(CacheKey, JsonConvert.SerializeObject(employeeVMs), cacheTime);
        }
    }
}
