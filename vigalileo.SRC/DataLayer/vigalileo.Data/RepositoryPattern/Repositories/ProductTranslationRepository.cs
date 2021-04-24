using vigalileo.Data.RepositoryPattern.IRepositories;
using vigalileo.Data.Entities;
using vigalileo.Data.EF;

namespace vigalileo.Data.RepositoryPattern.Repositories
{
    public class ProductTranslationRepository : GenericRepository<ProductTranslation, int>, IProductTranslationRepository
    {
        public ProductTranslationRepository(vigalileoDbContext vigalileoDbContext) : base(vigalileoDbContext)
        {

        }
    }
}