using HR.Application.Features.Queries.Definitions.Jobs.JobAdvert.VM;

namespace HR.Application.Features.Queries.Definitions.Jobs.JobAdvert.GetAll
{
    public class GetAllJobAdvertResponse
    {
        public int TotalCount { get; set; }

        public List<QueryJobAdvertVM> JobAdverts { get; set; }
    }
}
