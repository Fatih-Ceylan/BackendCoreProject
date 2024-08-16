using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;

namespace GControl.Application.Features.Queries.Definitions.Location.GetById
{
    internal class GetByIdLocationHandler : IRequestHandler<GetByIdLocationRequest, GetByIdLocationResponse>
    {
        readonly ILocationReadRepository _locationReadRepository;

        public GetByIdLocationHandler(ILocationReadRepository locationReadRepository)
        {
            _locationReadRepository = locationReadRepository;
        }

        public async Task<GetByIdLocationResponse> Handle(GetByIdLocationRequest request, CancellationToken cancellationToken)
        {
            var location = _locationReadRepository
                          .GetWhere(l => l.Id == Guid.Parse(request.Id), false)
                            .Select(l => new LocationVM
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
                                CreatedDate = l.CreatedDate
                            }).FirstOrDefault();

            return new()
            {
                Location = location
            };
        }
    }
}
