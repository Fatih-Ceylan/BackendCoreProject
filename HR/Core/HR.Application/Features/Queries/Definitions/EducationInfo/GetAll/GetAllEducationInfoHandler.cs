using HR.Application.Repositories.ReadRepository;
using HR.Application.VMs.Definitions;
using MediatR;

namespace HR.Application.Features.Queries.Definitions.EducationInfo.GetAll
{
    public class GetAllEducationInfoHandler : IRequestHandler<GetAllEducationInfoRequest, GetAllEducationInfoResponse>
    {
        public IEducationInfoReadRepository _EducationInfoReadRepository;

        public GetAllEducationInfoHandler(IEducationInfoReadRepository EducationInfoReadRepository)
        {
            _EducationInfoReadRepository = EducationInfoReadRepository;
        }

        public Task<GetAllEducationInfoResponse> Handle(GetAllEducationInfoRequest request, CancellationToken cancellationToken)
        {
            var query = _EducationInfoReadRepository.GetAllDeletedStatusDesc(false,request.IsDeleted)
               .Select(c => new EducationInfoVM
               {
                   Id = c.Id.ToString(),
                   Name = c.Name,
                   Description = c.Description,
                   EndDate = c.EndDate,
                   StartDate = c.StartDate,
                   EmployeeId = c.EmployeeId.ToString(),
                   EmployeeName = c.Employee.FirstName,
                   CreatedDate = c.CreatedDate,
               });
            var totalCount = query.Count();
            var EducationInfos = request.DoPagination ? query.Skip(request.Page * request.Size)
                                 .Take(request.Size).ToList() : query.ToList();

            return Task.FromResult(new GetAllEducationInfoResponse
            {
                TotalCount = totalCount,
                EducationInfos = EducationInfos,
            });
        }
    }
}
