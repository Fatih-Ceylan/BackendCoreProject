using AutoMapper;
using BaseProject.Domain.Entities.Definitions;
using GControl.Application.Repositories.ReadRepository;
using GControl.Application.VMs.Definitions;
using MediatR;

namespace GControl.Application.Features.Queries.Definitions.ApplicationSetting.GetAll
{
    public class GetAllApplicationSettingHandler : IRequestHandler<GetAllApplicationSettingRequest, GetAllApplicationSettingResponse>
    {
        private readonly IMapper _mapper;
        readonly IApplicationSettingReadRepository _applicationSettingReadRepository;

        public GetAllApplicationSettingHandler(IApplicationSettingReadRepository applicationSettingReadRepository, IMapper mapper)
        {
            _applicationSettingReadRepository = applicationSettingReadRepository;
            _mapper = mapper;
        }

        public Task<GetAllApplicationSettingResponse> Handle(GetAllApplicationSettingRequest request, CancellationToken cancellationToken)
        {
            var queryable = _applicationSettingReadRepository.GetAllDeletedStatusDesc(false, request.IsDeleted);

            if (request.CompanyId != "SelectAll")
            {
                queryable = queryable.Where(e => e.CompanyId == Guid.Parse(request.CompanyId));
            }

            IQueryable<ApplicationSettingVM> query = queryable.Select(aps => new ApplicationSettingVM
            {
                            Id = aps.Id.ToString(),
                            Name = aps.Name,
                            Company = aps.Company != null ? new Company
                            {
                                Id = aps.Company.Id,
                                Name = aps.Company.Name
                            } : null,
            });

            var totalCount = query.Count();

            var filteredQuery = query;

            if (!string.IsNullOrEmpty(request.FilterText))
            {
                filteredQuery = query.Where(x =>
                    x.Name.Contains(request.FilterText)
                );
                totalCount = filteredQuery.Count();
            }
            var pagedQuery = filteredQuery.Skip(request.Page * request.Size)
                                         .Take(request.Size)
                                         .ToList();
            var applicationSettinges = _mapper.Map<List<ApplicationSettingVM>>(filteredQuery);


            return Task.FromResult(new GetAllApplicationSettingResponse
            {
                TotalCount = totalCount,
                ApplicationSettings = applicationSettinges,
            });
        }
    }
}
