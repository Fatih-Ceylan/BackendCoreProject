using MediatR;

namespace HR.Application.Features.Queries.Definitions.EducationInfo.GetById
{
    public class GetByIdEducationInfoRequest : IRequest<GetByIdEducationInfoResponse>
    {
        public string Id { get; set; }
    }
}
