using vigalileo.Data.Core.Repositories;
using vigalileo.Data.Entities;
using vigalileo.Data.EF;

namespace vigalileo.Data.Persistence.Repositories
{
    public class CategoryTranslationRepository : GenericRepository<CategoryTranslation, int>, IGenericRepository<CategoryTranslation, int>
    {
        public CategoryTranslationRepository(vigalileoDbContext vigalileoDbContext) : base(vigalileoDbContext)
        {

        }
    }
}