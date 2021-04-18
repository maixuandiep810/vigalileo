using vigalileo.Data.Core.Repositories;
using vigalileo.Data.Entities;
using vigalileo.Data.EF;

namespace vigalileo.Data.Persistence.Repositories
{
    public class StoreInOrderRepository : GenericRepository<StoreInOrder, int>, IGenericRepository<StoreInOrder, int>
    {
        public StoreInOrderRepository(vigalileoDbContext vigalileoDbContext) : base(vigalileoDbContext)
        {

        }
    }
}