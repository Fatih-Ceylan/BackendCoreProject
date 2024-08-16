using GCrm.Application.VMs.Definitions;

namespace GCrm.Application.Features.Queries.Definitions.CustomerCategory.GetAll
{
    public class GetAllCustomerCategoryResponse
    {
        public int TotalCount { get; set; }

        public List<CustomerCategoryVM> CustomerCategories { get; set; }
    }
}
