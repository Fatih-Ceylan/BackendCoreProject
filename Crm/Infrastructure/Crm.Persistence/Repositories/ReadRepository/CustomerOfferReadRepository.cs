using BaseProject.Domain.Entities.GCrm.Definitions.CustomerManagement.Customers;
using BaseProject.Persistence.Contexts;
using GCrm.Application.Repositories.ReadRepository;
using Utilities.Infrastructure.UtilityPersistence.Repositories;

namespace GCrm.Persistence.Repositories.ReadRepository
{
    internal class CustomerOfferReadRepository : ReadRepository<BaseProjectDbContext, CustomerOffer>, ICustomerOfferReadRepository
    {
        public CustomerOfferReadRepository(BaseProjectDbContext context) : base(context)
        {
        }
    }
}
