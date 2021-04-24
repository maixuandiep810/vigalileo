using vigalileo.Data.RepositoryPattern.IRepositories;
using vigalileo.Data.Entities;
using vigalileo.Data.EF;

namespace vigalileo.Data.RepositoryPattern.Repositories
{
    public class CustomerDetailRepository : GenericRepository<CustomerDetail, int>, ICustomerDetailRepository
    {
        public CustomerDetailRepository(vigalileoDbContext vigalileoDbContext) : base(vigalileoDbContext)
        {

        }
    }
}