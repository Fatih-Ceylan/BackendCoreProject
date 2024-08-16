using MediatR;

namespace NLLogistics.Application.Features.Queries.Definitions.Vessel.GetById
{
    public class GetByIdVesselRequest: IRequest<GetByIdVesselResponse>
    {
        public string Id { get; set; }

    }
}
