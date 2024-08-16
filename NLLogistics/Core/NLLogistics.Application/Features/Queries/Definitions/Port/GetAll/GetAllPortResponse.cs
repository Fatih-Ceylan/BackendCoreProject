using NLLogistics.Application.VMs.Definitions.Port;

namespace NLLogistics.Application.Features.Queries.Definitions.Port.GetAll
{
    public class GetAllPortResponse
    {
        public int TotalCount { get; set; }

        public List<PortVM> Ports { get; set; }
    }
}
