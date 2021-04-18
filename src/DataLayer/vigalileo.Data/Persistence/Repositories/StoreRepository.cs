using vigalileo.Data.Core.Repositories;
using vigalileo.Data.Entities;
using vigalileo.Data.EF;

namespace vigalileo.Data.Persistence.Repositories
{
    public class StoreRepository : GenericRepository<Store, int>, IGenericRepository<Store, int>
    {
        public StoreRepository(vigalileoDbContext vigalileoDbContext) : base(vigalileoDbContext)
        {

        }
    }
}