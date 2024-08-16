using Card.Application.VMs;

namespace Card.Application.Features.Queries.Definitions.Card.GetAll
{
    public class GetAllCardResponse
    {
        public int TotalCount { get; set; }
        public List<CardVM> Cards { get; set; }
    }
}
