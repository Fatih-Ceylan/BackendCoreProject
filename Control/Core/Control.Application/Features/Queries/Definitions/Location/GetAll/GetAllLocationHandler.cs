using AutoMapper;
using BaseProject.Domain.Entities.Definitions;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;

namespace GControl.Application.Features.Queries.Definitions.Location.GetAll
{
    public class GetAllLocationHandler : IRequestHandler<GetAllLocationRequest, GetAllLocationResponse>
    {
        private readonly IMapper _mapper;
        readonly ILocationReadRepository _locationReadRepository;

        public GetAllLocationHandler(ILocationReadRepository locationReadRepository, IMapper mapper)
        {
            _locationReadRepository = locationReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllLocationResponse> Handle(GetAllLocationRequest request, CancellationToken cancellationToken)
        {
            var queryable = _locationReadRepository.GetAllDeletedStatusDesc(false, request.IsDeleted);

            if (request.CompanyId != "SelectAll")
            {
                queryable = queryable.Where(e => e.CompanyId == Guid.Parse(request.CompanyId));
            }

            IQueryable<LocationVM> query = queryable.Select(l => new LocationVM
            {
                Id = l.Id.ToString(),
                                        Name = l.Name,
                                        Address = l.Address,
                                        Latitude = l.Latitude,
                                        Longitude = l.Longitude,
                                        Radius = l.Radius,
                                        EntryTimeLimit = l.EntryTimeLimit,
                                        IsEntryTimeLimitEnabled = l.IsEntryTimeLimitEnabled,
                                        Description = l.Description,
                                        LocationOut = l.LocationOut.ToString(),
                                        CreatedDate = l.CreatedDate,
                                        Company = l.Company != null ? new Company
                                        {
                                            Id = l.Company.Id,
                                            Name = l.Company.Name
                                        } : null,
            });

            var totalCount = query.Count();

            var filteredQuery = query;

            if (!string.IsNullOrEmpty(request.FilterText))
            {
                filteredQuery = query.Where(x =>
                    x.Name.Contains(request.FilterText) ||
                    x.Radius.ToString().Contains(request.FilterText) ||
                    x.Address.ToString().Contains(request.FilterText)
                );
                totalCount = filteredQuery.Count();
            }
            var pagedQuery = filteredQuery.Skip(request.Page * request.Size)
                                         .Take(request.Size)
                                         .ToList();
            var locations = _mapper.Map<List<LocationVM>>(pagedQuery);


            return new GetAllLocationResponse
            {
                TotalCount = totalCount,
                Locations = locations,
            }; 
        }
    }
}
