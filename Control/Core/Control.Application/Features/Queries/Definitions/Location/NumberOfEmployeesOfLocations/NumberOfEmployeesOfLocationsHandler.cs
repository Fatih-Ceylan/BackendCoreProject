using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;
using T = BaseProject.Domain.Entities.GControl.Definitions;

namespace GControl.Application.Features.Queries.Definitions.Location.NumberOfEmployeesOfLocations
{
    public class NumberOfEmployeesOfLocationsHandler : IRequestHandler<NumberOfEmployeesOfLocationsRequest, NumberOfEmployeesOfLocationsResponse>
    {
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly ILocationReadRepository _locationReadRepository;
        public NumberOfEmployeesOfLocationsHandler(IEmployeeReadRepository employeeReadRepository, ILocationReadRepository locationReadRepository)
        {
            _employeeReadRepository = employeeReadRepository;
            _locationReadRepository = locationReadRepository;
        }


        public Task<NumberOfEmployeesOfLocationsResponse> Handle(NumberOfEmployeesOfLocationsRequest request, CancellationToken cancellationToken)
        {
            var locationList = _locationReadRepository
                .GetAllDeletedStatusDesc(false, false)
                .Select(d => new LocationVM
                {
                    Id = d.Id.ToString(),
                    Name = d.Name
                })
                .ToList();

            List<T.Employee> employees = new List<T.Employee>(); 

            employees = _employeeReadRepository.GetAllDeletedStatusDesc(false, false).ToList();

            var result = (from e in employees
                          join loc in locationList on e.LocationId.ToString().ToUpper() equals loc.Id into locJoin
                          from loc in locJoin.DefaultIfEmpty()
                          where e.LocationId != null
                          select new EmployeeVM
                          {
                              Id = e.Id.ToString(),
                              FullName = e.FullName,
                              LocationId = e.LocationId.ToString(),
                              LocationName = loc != null ? loc.Name : null
                          }).ToList();

            var groupedLocationEmployees = result
               .GroupBy(e => e.LocationId)
               .Select(g => new LocationGroupEmployeeVM
               {
                   LocationId = g.Key,
                   LocationName = locationList.FirstOrDefault(d => d.Id.ToLower() == g.Key)?.Name,
                   LocationCount = g.Count()
               }).ToList();

            return Task.FromResult(new NumberOfEmployeesOfLocationsResponse
            {
                TotalCount = locationList.Count(),
                Locations = groupedLocationEmployees
            });
        }
    }
}