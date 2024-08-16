using HR.Application.Repositories.ReadRepository;
using HR.Application.VMs.Definitions;
using MediatR;

namespace HR.Application.Features.Queries.Definitions.EducationInfo.GetById
{
    public class GetByIdEducationInfoHandler : IRequestHandler<GetByIdEducationInfoRequest, GetByIdEducationInfoResponse>
    {
        public IEducationInfoReadRepository _EducationInfoReadRepository;

        public GetByIdEducationInfoHandler(IEducationInfoReadRepository EducationInfoReadRepository)
        { _EducationInfoReadRepository = EducationInfoReadRepository; }

        public async Task<GetByIdEducationInfoResponse> Handle(
            GetByIdEducationInfoRequest request,
            CancellationToken cancellationToken)
        {
            var educationInfo = _EducationInfoReadRepository
                            .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
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
                            }).FirstOrDefault();

            return new() { EducationInfo = educationInfo };
        }
    }
}
