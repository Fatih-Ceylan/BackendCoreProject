using MediatR;

namespace BaseProject.Application.Features.Queries.Definitions.Country.GetById
{
    public class GetByIdCountryRequest : IRequest<GetByIdCountryResponse>
    {
        public int Id { get; set; }
    }
}