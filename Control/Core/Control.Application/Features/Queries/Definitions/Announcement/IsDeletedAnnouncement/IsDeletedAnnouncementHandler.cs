using AutoMapper;
using BaseProject.Domain.Entities.Definitions;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;

namespace GControl.Application.Features.Queries.Definitions.Announcement.IsDeletedAnnouncement
{
    public class IsDeletedAnnouncementHandler : IRequestHandler<IsDeletedAnnouncementRequest, IsDeletedAnnouncementResponse>
    {
        private readonly IMapper _mapper;
        readonly IAnnouncementReadRepository _announcementReadRepository;
        public IsDeletedAnnouncementHandler(IMapper mapper, IAnnouncementReadRepository announcementReadRepository)
        {
            _mapper = mapper;
            _announcementReadRepository = announcementReadRepository;
        }

        public async Task<IsDeletedAnnouncementResponse> Handle(IsDeletedAnnouncementRequest request, CancellationToken cancellationToken)
        {
            var queryable = _announcementReadRepository.GetAllDeletedStatusIncluding([e => e.Departments, e => e.EmployeeLabels], false, true);

            if (request.CompanyId != "SelectAll")
            {
                queryable = queryable.Where(e => e.CompanyId == Guid.Parse(request.CompanyId));
            }

            var announcements = queryable
                .Select(ac => new AnnouncementVM
                {
                    Id = ac.Id.ToString(),
                    Title = ac.Title,
                    Content = ac.Content,
                    CreatedDate = ac.CreatedDate,
                    Company = ac.Company != null ? new Company
                    {
                        Id = ac.Company.Id,
                        Name = ac.Company.Name
                    } : null,
                    EmployeeLabels = ac.EmployeeLabels
                        .Select(el => new EmployeeLabelVM
                        {
                            Id = el.Id.ToString(),
                            Name = el.Name,
                            CreatedDate = el.CreatedDate,
                            EmployeeCount = el.Employees.Count()
                        }).ToList(),
                    EmployeeDepartmentCount = ac.Departments.Count(),
                })
                .ToList();

            foreach (var announcement in announcements)
            {
                announcement.EmployeeCount = announcement.EmployeeLabels.Sum(el => el.EmployeeCount);
                announcement.SentToEmployeeCount += announcement.EmployeeCount + announcement.EmployeeDepartmentCount;
            }

            var filteredAnnouncements = string.IsNullOrEmpty(request.FilterText)
                ? announcements
                : announcements.Where(x => x.Title.Contains(request.FilterText)).ToList();

            var totalCount = filteredAnnouncements.Count();

            var pagedAnnouncements = filteredAnnouncements
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .ToList();

            var announcementVMs = pagedAnnouncements.Select(ac =>
            {
                var mapped = _mapper.Map<AnnouncementVM>(ac);

                var labelCounts = ac.EmployeeLabels
                    .GroupBy(el => el.Id)
                    .Select(group => new EmployeeLabelVM
                    {
                        Id = group.Key,
                        Count = group.Count()
                    })
                    .ToList();

                mapped.EmployeeLabels = labelCounts;

                return mapped;
            })
                .ToList();

            return new IsDeletedAnnouncementResponse
            {
                TotalCount = totalCount,
                Announcements = announcementVMs,
            };

        }
    }
 }

