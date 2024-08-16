using Card.Application.VMs;

namespace Card.Application.Features.Queries.Definitions.Iban.GetAll
{
    public class GetAllIbanResponse
    {
        public int TotalCount { get; set; }

        public List<IbanVM> Ibans { get; set; }
    }
}
