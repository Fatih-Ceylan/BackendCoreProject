using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;

namespace Card.Application.Features.Queries.Definitions.Field.GetById
{
    public class GetByIdFieldHandler : IRequestHandler<GetByIdFieldRequest, GetByIdFieldResponse>
    {
        readonly IFieldReadRepository _fieldReadRepository;

        public GetByIdFieldHandler(IFieldReadRepository fieldReadRepository)
        {
            _fieldReadRepository = fieldReadRepository;
        }

        public async Task<GetByIdFieldResponse> Handle(GetByIdFieldRequest request, CancellationToken cancellationToken)
        {
            var field = _fieldReadRepository
                            .GetWhere(c => c.Id == Guid.Parse(request.Id), false)
                            .Select(c => new FieldVM
                            {
                                Id = c.Id.ToString(),
                                Name = c.Name, 

                            }).FirstOrDefault();

            return new()
            {
                Field = field
            };
        }
    }
}
