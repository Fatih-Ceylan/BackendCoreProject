using MediatR;

namespace GCrm.Application.Features.Queries.Definitions.ProjectType.GetById
{
    public class GetByIdProjectTypeHandler : IRequestHandler<GetByIdProjectTypeRequest, GetByIdProjectTypeResponse>
    {
        public Task<GetByIdProjectTypeResponse> Handle(GetByIdProjectTypeRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
