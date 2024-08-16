using AutoMapper;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace GControl.Application.Features.Queries.Definitions.Location.FilterField
{
    public class FilterFieldHandler : IRequestHandler<FilterFieldRequest, FilterFieldResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILocationReadRepository _locationReadRepository;

        public FilterFieldHandler(ILocationReadRepository locationReadRepository, IMapper mapper)
        {
            _locationReadRepository = locationReadRepository;
            _mapper = mapper;
        }

        public async Task<FilterFieldResponse> Handle(FilterFieldRequest request, CancellationToken cancellationToken)
        {
            var queryable = _locationReadRepository.GetAllDeletedStatusDesc(false, request.IsDeleted);

            if (request.CompanyId != "SelectAll")
            {
                queryable = queryable.Where(e => e.CompanyId == Guid.Parse(request.CompanyId));
            }
            // Get the base query from repository
            IQueryable<LocationVM> query = queryable.Select(l => new LocationVM
            {
                Id = l.Id.ToString(),
                                Name = l.Name,
                                Address = l.Address,
                                Latitude = l.Latitude,
                                Longitude = l.Longitude,
                                CompanyId = l.CompanyId.ToString(),
                                Radius = l.Radius,
                                EntryTimeLimit = l.EntryTimeLimit,
                                IsEntryTimeLimitEnabled = l.IsEntryTimeLimitEnabled,
                                Description = l.Description,
                                LocationOut = l.LocationOut.ToString(),
                                CreatedDate = l.CreatedDate
                            });

            // Apply dynamic filtering based on request parameters
            if (!string.IsNullOrEmpty(request.FilterText) && !string.IsNullOrEmpty(request.FilterField) && !string.IsNullOrEmpty(request.Operator) && !string.IsNullOrEmpty(request.CompanyId))
            { 
                query = ApplyFilter(query, request.FilterField, request.Operator, request.FilterText, request.SortDirection, request.CompanyId);
            }
            else if (!string.IsNullOrEmpty(request.FilterField) && !string.IsNullOrEmpty(request.SortDirection))
            {
                // Perform filtering based on FilterText and Operator when they are provided
                query = ApplyShortOperation(query, request.FilterField, request.SortDirection);
            }

            // Get total count before pagination
            var totalCount = query.Count();

            // Apply pagination
            var locations = await query
                                    .Skip(request.Page * request.Size)
                                    .Take(request.Size)
                                    .ToListAsync(cancellationToken);

            // Map the results to ViewModel
            var mappedLocations = _mapper.Map<List<LocationVM>>(locations);

            // Return the response
            return new FilterFieldResponse
            {
                TotalCount = totalCount,
                Locations = mappedLocations
            };
        }
        private IQueryable<LocationVM> ApplyFilter(IQueryable<LocationVM> query, string filterField, string filterOperator, string filterText, string sortDirection, string companyId)
        {
            if (!string.IsNullOrEmpty(companyId))
            {
                query = query.Where(l => l.CompanyId == companyId);
            }

            switch (filterField.ToLower())
            {
                case "name":
                    switch (filterOperator.ToLower())
                    {
                        case "contains":
                            query = query.Where(l => l.Name.Contains(filterText));
                            break;
                        case "equals":
                            query = query.Where(l => l.Name.Equals(filterText));
                            break;
                        case "starts with":
                            query = query.Where(l => l.Name.StartsWith(filterText));
                            break;
                        case "ends with":
                            query = query.Where(l => l.Name.EndsWith(filterText));
                            break;
                        default:
                            query = query.Where(l => l.Name.Contains(filterText));
                            break;
                    }
                    break;
                case "radius":
                    switch (filterOperator.ToLower())
                    {
                        case "contains":
                            query = query.Where(l => l.Radius.ToString().Contains(filterText));
                            break;
                        default:
                            query = query.Where(l => l.Radius.ToString().Contains(filterText));
                            break;
                    }
                    break;
                default:
                    query = query.Where(l => l.Name.Contains(filterText));
                    break;
            }

            // Apply sorting based on SortDirection
            if (!string.IsNullOrEmpty(sortDirection))
            {
                switch (sortDirection.ToLower())
                {
                    case "asc":
                        query = ApplySorting(query, filterField, SortOrder.Ascending);
                        break;
                    case "desc":
                        query = ApplySorting(query, filterField, SortOrder.Descending);
                        break;
                    default:
                        // Default to no sorting
                        break;
                }
            }

            return query;
        }
        private IQueryable<LocationVM> ApplyShortOperation(IQueryable<LocationVM> query, string filterField, string sortDirection)
        {
            // Assume SortDirection can be parsed to SortOrder enum
            SortOrder sortOrder = sortDirection.ToLower() == "asc" ? SortOrder.Ascending : SortOrder.Descending;

            switch (filterField.ToLower())
            {
                case "name":
                    query = ApplySorting(query, "Name", sortOrder);
                    break;
                case "radius":
                    query = ApplySorting(query, "Radius", sortOrder);
                    break;
                case "entryTimeLimit":
                    query = ApplySorting(query, "entryTimeLimit", sortOrder);
                    break;
                case "locationOut":
                    query = ApplySorting(query, "locationOut", sortOrder);
                    break;
                // Add cases for other fields as needed
                default:
                    // Handle default case if necessary
                    break;
            }

            return query;
        }
        private IQueryable<LocationVM> ApplySorting(IQueryable<LocationVM> query, string sortField, SortOrder sortOrder)
        {
            switch (sortField.ToLower())
            {
                case "name":
                    if (sortOrder == SortOrder.Ascending)
                    {
                        query = query.OrderBy(l => l.Name);
                    }
                    else if (sortOrder == SortOrder.Descending)
                    {
                        query = query.OrderByDescending(l => l.Name);
                    }
                    break;
                case "radius":
                    if (sortOrder == SortOrder.Ascending)
                    {
                        query = query.OrderBy(l => l.Radius);
                    }
                    else if (sortOrder == SortOrder.Descending)
                    {
                        query = query.OrderByDescending(l => l.Radius);
                    }
                    break;
                // Add cases for other fields as needed
                default:
                    // Default to no sorting
                    break;
            }

            return query;
        }

        public enum SortOrder
        {
            Ascending,
            Descending
        }
    }
}
