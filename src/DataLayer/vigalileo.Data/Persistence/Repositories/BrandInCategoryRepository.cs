using vigalileo.Data.Core.Repositories;
using vigalileo.Data.Entities;
using vigalileo.Data.EF;

namespace vigalileo.Data.Persistence.Repositories
{
    public class BrandInCategoryRepository : GenericRepository<BrandInCategory, int>, IGenericRepository<BrandInCategory, int>
    {
        public BrandInCategoryRepository(vigalileoDbContext vigalileoDbContext) : base(vigalileoDbContext)
        {

        }
    }
}