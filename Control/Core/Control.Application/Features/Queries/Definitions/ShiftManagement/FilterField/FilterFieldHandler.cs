using AutoMapper;
using GControl.Application.Features.Queries.Definitions.ShiftManagement.FilterField;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GControl.Application.Features.Queries.Definitions.ShiftManagement.GetAll
{
    public class FilterFieldHandler : IRequestHandler<FilterFieldRequest, FilterFieldResponse>
    {
        readonly IMapper _mapper;
        readonly IShiftManagementReadRepository _shiftManagementReadRepository;

        public FilterFieldHandler(IShiftManagementReadRepository shiftManagementReadRepository, IMapper mapper)
        {
            _shiftManagementReadRepository = shiftManagementReadRepository;
            this._mapper = mapper;
        }

        public async Task<FilterFieldResponse> Handle(FilterFieldRequest request, CancellationToken cancellationToken)
        {
            var query = _shiftManagementReadRepository
                        .GetAllDeletedStatusDesc(false, request.IsDeleted)
                        .Select(ds => new ShiftManagementVM
                        {
                            Id = ds.Id.ToString(),
                            Title = ds.Title,
                            ShiftStartDate = ds.ShiftStartDate,
                            ShiftEndDate = ds.ShiftEndDate,
                        });

            if (!string.IsNullOrEmpty(request.FilterText) && !string.IsNullOrEmpty(request.FilterField) && !string.IsNullOrEmpty(request.Operator) && !string.IsNullOrEmpty(request.CompanyId))
            {
                query = ApplyFilter(query, request.FilterField, request.Operator, request.FilterText, request.SortDirection, request.CompanyId);
            }
            else if (!string.IsNullOrEmpty(request.FilterField) && !string.IsNullOrEmpty(request.SortDirection))
            {
                query = ApplyShortOperation(query, request.FilterField, request.SortDirection);
            }

            var totalCount = query.Count();
            var shiftManagementes = await query
                                    .Skip(request.Page * request.Size)
                                    .Take(request.Size)
                                    .ToListAsync(cancellationToken);

            IQueryable<ShiftManagementVM> pagedQuery = query.AsQueryable();
            if (request.DoPagination || request.IsDeleted)
            {
                pagedQuery = request.IsDeleted ? query.AsQueryable().Skip(request.Page * request.Size).Take(request.Size)
                                               : pagedQuery.AsQueryable();
            }
            var pagedShiftManagementes = pagedQuery.ToList();
            return new FilterFieldResponse
            {
                TotalCount = totalCount,
                ShiftManagements = pagedShiftManagementes,
            };
        }
        private IQueryable<ShiftManagementVM> ApplyFilter(IQueryable<ShiftManagementVM> query, string filterField, string filterOperator, string filterText, string sortDirection, string companyId)
        {
            if (!string.IsNullOrEmpty(companyId))
            {
                query = query.Where(shiftManagement => shiftManagement.CompanyId == companyId);
            }
            switch (filterField.ToLower())
            {
                case "title":
                    switch (filterOperator.ToLower())
                    {
                        case "contains":
                            query = query.Where(shiftManagement => shiftManagement.Title.Contains(filterText));
                            break;
                        case "equals":
                            query = query.Where(shiftManagement => shiftManagement.Title.Equals(filterText));
                            break;
                        case "starts with":
                            query = query.Where(shiftManagement => shiftManagement.Title.StartsWith(filterText));
                            break;
                        case "ends with":
                            query = query.Where(shiftManagement => shiftManagement.Title.EndsWith(filterText));
                            break;
                        default:
                            query = query.Where(shiftManagement => shiftManagement.Title.Contains(filterText));
                            break;
                    }
                    break;
                default:
                    query = query.Where(shiftManagement => shiftManagement.Title.Contains(filterText));
                    break;
            }

            if (!string.IsNullOrEmpty(sortDirection))
            {
                query = ApplySorting(query, filterField, sortDirection);
            }

            return query;
        }

        private IQueryable<ShiftManagementVM> ApplyShortOperation(IQueryable<ShiftManagementVM> query, string filterField, string sortDirection)
        {
            switch (filterField.ToLower())
            {
                case "title":
                    query = ApplySorting(query, "Title", sortDirection);
                    break;
                case "shiftStartDate":
                    query = ApplySorting(query, "shiftStartDate", sortDirection);
                    break;
                case "shiftEndDate":
                    query = ApplySorting(query, "shiftEndDate", sortDirection);
                    break;
                default:
                    break;
            }

            return query;
        }

        private IQueryable<ShiftManagementVM> ApplySorting(IQueryable<ShiftManagementVM> query, string sortField, string sortDirection)
        {
            switch (sortField.ToLower())
            {
                case "title":
                    query = sortDirection.ToLower() == "asc" ? query.OrderBy(
                        shiftManagement => shiftManagement.Title) : query.OrderByDescending(shiftManagement => shiftManagement.Title);
                    break;
                default:
                    break;
            }

            return query;
        }
    }

}

