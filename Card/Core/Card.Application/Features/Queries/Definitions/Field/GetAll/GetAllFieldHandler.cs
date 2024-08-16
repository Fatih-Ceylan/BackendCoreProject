using Card.Application.Repositories.ReadRepository;
using Card.Application.VMs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Card.Application.Features.Queries.Definitions.Field.GetAll
{
    public class GetAllFieldHandler : IRequestHandler<GetAllFieldRequest, GetAllFieldResponse>
    {
        readonly IFieldReadRepository _fieldReadRepository; 

        public GetAllFieldHandler(IFieldReadRepository fieldReadRepository)
        {
            _fieldReadRepository = fieldReadRepository; 
        }

        public async Task<GetAllFieldResponse> Handle(GetAllFieldRequest request, CancellationToken cancellationToken)
        {
            var fieldQuery = _fieldReadRepository.GetAllDeletedStatusDesc(false); 

            var fields = await fieldQuery.Select(f => new FieldVM
            {
                Id = f.Id.ToString(),
                Name = f.Name, 
                CreatedDate = f.CreatedDate

            }).ToListAsync(cancellationToken);
              
            var totalCount = fields.Count;

            var response = fields.Skip(request.Page * request.Size).Take(request.Size).ToList();

            return new GetAllFieldResponse
            {
                TotalCount = totalCount,
                Fields = response
            };
        }
    }
}
