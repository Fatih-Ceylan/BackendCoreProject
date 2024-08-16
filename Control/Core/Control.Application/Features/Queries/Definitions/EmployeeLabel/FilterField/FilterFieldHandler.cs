using GControl.Application.Features.Queries.Definitions.EmployeeLabel.FilterField;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace GControl.Application.Features.Queries.Definitions.EmployeeLabel.GetAll
{
    public class FilterFieldHandler : IRequestHandler<FilterFieldRequest, FilterFieldResponse>
    {
        readonly IEmployeeLabelReadRepository _employeeLabelReadRepository;
        readonly IEmployeeReadRepository _employeeReadRepository;

        public FilterFieldHandler(IEmployeeLabelReadRepository employeeLabelReadRepository, IEmployeeReadRepository employeeReadRepository)
        {
            _employeeReadRepository = employeeReadRepository;
            _employeeLabelReadRepository = employeeLabelReadRepository;
        }

        public async Task<FilterFieldResponse> Handle(FilterFieldRequest request, CancellationToken cancellationToken)
        {
            var employeeQuery = _employeeReadRepository.GetAllDeletedStatusDesc(false, request.IsDeleted);
            var labelQuery = _employeeLabelReadRepository.GetAllDeletedStatusDesc(false);

            var employeeLabels = await labelQuery.Select(label => new EmployeeLabelVM
            {
                Id = label.Id.ToString(),
                Name = label.Name,
                CreatedDate = label.CreatedDate,
                UpdatedDate = label.UpdatedDate
            }).ToListAsync();

            if (!string.IsNullOrEmpty(request.FilterText) && !string.IsNullOrEmpty(request.FilterField) && !string.IsNullOrEmpty(request.Operator) && !string.IsNullOrEmpty(request.CompanyId))
            {
                employeeLabels = ApplyFilter(employeeLabels.AsQueryable(), request.FilterField, request.Operator, request.FilterText, request.SortDirection, request.CompanyId).ToList();
            }
            else if (!string.IsNullOrEmpty(request.FilterField) && !string.IsNullOrEmpty(request.SortDirection))
            {
                employeeLabels = ApplyShortOperation(employeeLabels.AsQueryable(), request.FilterField, request.SortDirection).ToList();
            }

            foreach (var label in employeeLabels)
            {
                label.EmployeeCount = await employeeQuery.CountAsync(employee => employee.EmployeeLabels.Any(el => el.Id == Guid.Parse(label.Id)));
            }

            var totalCount = employeeLabels.Count;

            IQueryable<EmployeeLabelVM> pagedQuery = employeeLabels.AsQueryable();
            if (request.DoPagination || request.IsDeleted)
            {
                pagedQuery = request.IsDeleted ? employeeLabels.AsQueryable().Skip(request.Page * request.Size).Take(request.Size)
                                               : pagedQuery.AsQueryable();
            }

            var pagedEmployeeLabels = pagedQuery.ToList();


            return new FilterFieldResponse
            {
                TotalCount = totalCount,
                EmployeeLabels = pagedEmployeeLabels,
            };
        }
        private IQueryable<EmployeeLabelVM> ApplyFilter(IQueryable<EmployeeLabelVM> query, string filterField, string filterOperator, string filterText, string sortDirection, string companyId)
        {
            if (!string.IsNullOrEmpty(companyId))
            {
                query = query.Where(label => label.CompanyId == companyId);
            }
            switch (filterField.ToLower())
            {
                case "name":
                    switch (filterOperator.ToLower())
                    {
                        case "contains":
                            query = query.Where(label => label.Name.Contains(filterText));
                            break;
                        case "equals":
                            query = query.Where(label => label.Name.Equals(filterText));
                            break;
                        case "starts with":
                            query = query.Where(l => l.Name.StartsWith(filterText));
                            break;
                        case "ends with":
                            query = query.Where(l => l.Name.EndsWith(filterText));
                            break;
                        default:
                            query = query.Where(label => label.Name.Contains(filterText));
                            break;
                    }
                    break;
                default:
                    query = query.Where(label => label.Name.Contains(filterText));
                    break;
            }

            if (!string.IsNullOrEmpty(sortDirection))
            {
                query = ApplySorting(query, filterField, sortDirection);
            }

            return query;
        }

        private IQueryable<EmployeeLabelVM> ApplyShortOperation(IQueryable<EmployeeLabelVM> query, string filterField, string sortDirection)
        {
            switch (filterField.ToLower())
            {
                case "name":
                    query = ApplySorting(query, "Name", sortDirection);
                    break;
                case "createdDate":
                    query = ApplySorting(query, "createdDate", sortDirection);
                    break;
                case "updatedDate":
                    query = ApplySorting(query, "updatedDate", sortDirection);
                    break;
                // Add cases for other fields as needed
                default:
                    // Handle default case if necessary
                    break;
            }

            return query;
        }

        private IQueryable<EmployeeLabelVM> ApplySorting(IQueryable<EmployeeLabelVM> query, string sortField, string sortDirection)
        {
            switch (sortField.ToLower())
            {
                case "name":
                    query = sortDirection.ToLower() == "asc" ? query.OrderBy(label => label.Name) : query.OrderByDescending(label => label.Name);
                    break;
                // Add cases for other fields as needed
                default:
                    // Handle default case if necessary
                    break;
            }

            return query;
        }
    }
}


