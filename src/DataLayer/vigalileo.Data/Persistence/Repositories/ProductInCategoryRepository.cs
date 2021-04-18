using vigalileo.Data.Core.Repositories;
using vigalileo.Data.Entities;
using vigalileo.Data.EF;

namespace vigalileo.Data.Persistence.Repositories
{
    public class ProductInCategoryRepository : GenericRepository<ProductInCategory, int>, IGenericRepository<ProductInCategory, int>
    {
        public ProductInCategoryRepository(vigalileoDbContext vigalileoDbContext) : base(vigalileoDbContext)
        {

        }
    }
}