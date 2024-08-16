using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProjectType.GetAll
{
    public class GetAllProjectTypeHandler : IRequestHandler<GetAllProjectTypeRequest, GetAllProjectTypeResponse>
    {
        public Task<GetAllProjectTypeResponse> Handle(GetAllProjectTypeRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
