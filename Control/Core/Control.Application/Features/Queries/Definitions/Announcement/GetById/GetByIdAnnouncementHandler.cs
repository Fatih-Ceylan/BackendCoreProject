using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;

namespace GControl.Application.Features.Queries.Definitions.Announcement.GetById
{
    public class GetByIdAnnouncementHandler : IRequestHandler<GetByIdAnnouncementRequest, GetByIdAnnouncementResponse>
    {
        readonly IAnnouncementReadRepository _announcementReadRepository;

        public GetByIdAnnouncementHandler(IAnnouncementReadRepository announcementReadRepository)
        {
            _announcementReadRepository = announcementReadRepository;
        }

        public async Task<GetByIdAnnouncementResponse> Handle(GetByIdAnnouncementRequest request, CancellationToken cancellationToken)
        {
            var announcement = _announcementReadRepository
                                .GetWhere(ds => ds.Id == Guid.Parse(request.Id))
                                .Select(ds => new AnnouncementVM
                                {
                                    Id = ds.Id.ToString(),
                                    Title = ds.Title,
                                    Content = ds.Content,
                                    CreatedDate = ds.CreatedDate,
                                    EmployeeLabels = ds.EmployeeLabels.Select(el => new EmployeeLabelVM
                                    {
                                        Id = el.Id.ToString(),
                                        Name = el.Name,
                                        CreatedDate = el.CreatedDate
                                    }).ToList(),

                                }).FirstOrDefault();
            return new()
            {
                Announcement = announcement
            };
        }
    }
}
