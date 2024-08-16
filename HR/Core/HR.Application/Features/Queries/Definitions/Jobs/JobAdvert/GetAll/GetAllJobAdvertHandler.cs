using HR.Application.Features.Queries.Definitions.Jobs.JobAdvert.VM;
using HR.Application.Repositories.ReadRepository;
using MediatR;

namespace HR.Application.Features.Queries.Definitions.Jobs.JobAdvert.GetAll
{
    public class GetAllJobAdvertHandler : IRequestHandler<GetAllJobAdvertRequest, GetAllJobAdvertResponse>
    {
        public IJobAdvertReadRepository _jobAdvertReadRepository;

        public GetAllJobAdvertHandler(IJobAdvertReadRepository JobAdvertReadRepository)
        {
            _jobAdvertReadRepository = JobAdvertReadRepository;
        }

        public Task<GetAllJobAdvertResponse> Handle(GetAllJobAdvertRequest request, CancellationToken cancellationToken)
        {
            var query = _jobAdvertReadRepository.GetAllDeletedStatusDesc(false, request.IsDeleted)
               .Select(c => new QueryJobAdvertVM
               {
                   Id = c.Id.ToString(),
                   Code = c.Code,
                   CompanyName = c.CompanyName,
                   Description = c.Description,
                   JobTitle = c.JobTitle,
                   NumberOfVacancy = c.NumberOfVacancy,
                   PostingDate = c.PostingDate,
                   AppellationId = c.AppellationId.ToString(),
                   AppellationName = c.Appellation != null ? c.Appellation.Name : null,
                   WorkLocation = c.WorkLocationString,
                   CreatedDate = c.CreatedDate,
               }).ToList();
            var totalCount = query.Count();
            var JobAdverts = request.DoPagination ? query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList() : query.ToList();

            return Task.FromResult(new GetAllJobAdvertResponse
            {
                TotalCount = totalCount,
                JobAdverts = JobAdverts,
            });
        }
    }
}
