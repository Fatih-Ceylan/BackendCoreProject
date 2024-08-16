using HR.Application.Repositories.ReadRepository;
using HR.Application.VMs.Definitions;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace HR.Application.Features.Queries.Definitions.Employee.GetById
{
    public class GetByIdEmployeeHandler : IRequestHandler<GetByIdEmployeeRequest, GetByIdEmployeeResponse>
    {
        public IEmployeeReadRepository _employeeReadRepository;
        private IDistributedCache _distributedCache;
        public GetByIdEmployeeHandler(IEmployeeReadRepository employeeReadRepository, IDistributedCache distributedCache)
        {
            _employeeReadRepository = employeeReadRepository;
            _distributedCache = distributedCache;
        }

        public async Task<GetByIdEmployeeResponse> Handle(GetByIdEmployeeRequest request, CancellationToken cancellationToken)
        {
            string cacheKey = request.Id;
            string? cachedEmployee = await _distributedCache.GetStringAsync(cacheKey, cancellationToken);

            EmployeeVM? employeeVM;
            if (string.IsNullOrEmpty(cachedEmployee))
            {
                employeeVM = _employeeReadRepository
                            .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                            .Select(c => new EmployeeVM
                            {
                                Id = c.Id.ToString(),
                                FirstName = c.FirstName,
                                LastName = c.LastName,
                                Email = c.Email,
                                PhoneNumber = c.PhoneNumber,
                                HireDate = c.HireDate,
                                Salary = c.Salary,
                                CompanyId = c.CompanyId.ToString(),
                                BranchId = c.BranchId.ToString(),
                                DepartmentId = c.DepartmentId.ToString(),
                                AppellationId = c.AppellationId.ToString(),
                                AppellationName = c.Appellation != null ? c.Appellation.Name : null,
                                CreatedDate = c.CreatedDate,
                            }).FirstOrDefault();

                var cacheOptions = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10),
                    SlidingExpiration = TimeSpan.FromSeconds(10),
                };
                await _distributedCache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(employeeVM), cacheOptions, cancellationToken);

                return new() { Employee = employeeVM };
            }

            employeeVM = JsonConvert.DeserializeObject<EmployeeVM>(cachedEmployee);

            return new() { Employee = employeeVM };
        }
    }
}
