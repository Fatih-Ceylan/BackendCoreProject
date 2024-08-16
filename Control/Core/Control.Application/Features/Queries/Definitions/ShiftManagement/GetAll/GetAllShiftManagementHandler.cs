using AutoMapper;
using BaseProject.Domain.Entities.Definitions;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;

namespace GControl.Application.Features.Queries.Definitions.ShiftManagement.GetAll
{
    public class GetAllShiftManagementHandler : IRequestHandler<GetAllShiftManagementRequest, GetAllShiftManagementResponse>
    {
        readonly IMapper _mapper;
        readonly IShiftManagementReadRepository _shiftManagementReadRepository;

        public GetAllShiftManagementHandler(IShiftManagementReadRepository shiftManagementReadRepository, IMapper mapper)
        {
            _shiftManagementReadRepository = shiftManagementReadRepository;
            this._mapper = mapper;
        }

        public Task<GetAllShiftManagementResponse> Handle(GetAllShiftManagementRequest request, CancellationToken cancellationToken)
        {
            var queryable = _shiftManagementReadRepository.GetAllDeletedStatusDesc(false, request.IsDeleted);

            if (request.CompanyId != "SelectAll")
            {
                queryable = queryable.Where(e => e.CompanyId == Guid.Parse(request.CompanyId));
            }

            IQueryable<ShiftManagementVM> query = queryable.Select(sm => new ShiftManagementVM
            {
                            Id = sm.Id.ToString(),
                            Title = sm.Title,
                            ShiftStartDate = sm.ShiftStartDate,
                            ShiftEndDate = sm.ShiftEndDate,
                            Company = sm.Company != null ? new Company
                            {
                                Id = sm.Company.Id,
                                Name = sm.Company.Name
                            } : null,
            });

            var totalCount = query.Count();
            var filteredQuery = query;


            if (!string.IsNullOrEmpty(request.FilterText))
            {
                filteredQuery = filteredQuery.Where(x =>
                    x.Title.Contains(request.FilterText)
                );
                totalCount = filteredQuery.Count();
            }

            var pagedQuery = filteredQuery.Skip(request.Page * request.Size)
                                        .Take(request.Size)
                                        .ToList();

            var shiftsManagements = _mapper.Map<List<ShiftManagementVM>>(filteredQuery);

            return Task.FromResult(new GetAllShiftManagementResponse
            {
                TotalCount = totalCount,
                ShiftManagements = shiftsManagements,
            });
        }
    }
}
