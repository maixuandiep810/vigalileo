using vigalileo.Data.RepositoryPattern.IRepositories;
using vigalileo.Data.Entities;
using vigalileo.Data.EF;

namespace vigalileo.Data.RepositoryPattern.Repositories
{
    public class ProductInCategoryRepository : GenericRepository<ProductInCategory, int>, IGenericRepository<ProductInCategory, int>
    {
        public ProductInCategoryRepository(vigalileoDbContext vigalileoDbContext) : base(vigalileoDbContext)
        {

        }
    }
}