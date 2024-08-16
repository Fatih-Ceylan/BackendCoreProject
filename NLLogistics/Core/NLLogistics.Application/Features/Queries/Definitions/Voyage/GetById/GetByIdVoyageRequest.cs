using MediatR;

namespace NLLogistics.Application.Features.Queries.Definitions.Voyage.GetById
{
    public class GetByIdVoyageRequest: IRequest<GetByIdVoyageResponse>
    {
        public string Id { get; set; }

    }
}
