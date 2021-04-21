using vigalileo.Data.RepositoryPattern.IRepositories;
using vigalileo.Data.Entities;
using vigalileo.Data.EF;

namespace vigalileo.Data.RepositoryPattern.Repositories
{
    public class StoreInOrderRepository : GenericRepository<StoreInOrder, int>, IGenericRepository<StoreInOrder, int>
    {
        public StoreInOrderRepository(vigalileoDbContext vigalileoDbContext) : base(vigalileoDbContext)
        {

        }
    }
}