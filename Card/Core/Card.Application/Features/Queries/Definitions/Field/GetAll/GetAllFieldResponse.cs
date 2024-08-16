using Card.Application.VMs;

namespace Card.Application.Features.Queries.Definitions.Field.GetAll
{
    public class GetAllFieldResponse
    {
        public int TotalCount { get; set; }

        public List<FieldVM> Fields { get; set; }
    }
}
