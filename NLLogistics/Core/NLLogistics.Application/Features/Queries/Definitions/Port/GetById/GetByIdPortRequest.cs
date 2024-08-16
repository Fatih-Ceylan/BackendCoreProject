using MediatR;

namespace NLLogistics.Application.Features.Queries.Definitions.Port.GetById
{
    public class GetByIdPortRequest: IRequest<GetByIdPortResponse>
    {
        public string Id { get; set; }

    }
}
