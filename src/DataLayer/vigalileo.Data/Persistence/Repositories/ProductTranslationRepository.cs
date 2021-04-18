using vigalileo.Data.Core.Repositories;
using vigalileo.Data.Entities;
using vigalileo.Data.EF;

namespace vigalileo.Data.Persistence.Repositories
{
    public class ProductTranslationRepository : GenericRepository<ProductTranslation, int>, IGenericRepository<ProductTranslation, int>
    {
        public ProductTranslationRepository(vigalileoDbContext vigalileoDbContext) : base(vigalileoDbContext)
        {

        }
    }
}