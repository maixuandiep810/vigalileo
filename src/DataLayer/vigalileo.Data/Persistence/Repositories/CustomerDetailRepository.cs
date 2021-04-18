using vigalileo.Data.Core.Repositories;
using vigalileo.Data.Entities;
using vigalileo.Data.EF;

namespace vigalileo.Data.Persistence.Repositories
{
    public class CustomerDetailRepository : GenericRepository<CustomerDetail, int>, IGenericRepository<CustomerDetail, int>
    {
        public CustomerDetailRepository(vigalileoDbContext vigalileoDbContext) : base(vigalileoDbContext)
        {

        }
    }
}