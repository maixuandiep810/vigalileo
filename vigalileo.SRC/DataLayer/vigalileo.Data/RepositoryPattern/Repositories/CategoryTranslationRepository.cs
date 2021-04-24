using vigalileo.Data.RepositoryPattern.IRepositories;
using vigalileo.Data.Entities;
using vigalileo.Data.EF;

namespace vigalileo.Data.RepositoryPattern.Repositories
{
    public class CategoryTranslationRepository : GenericRepository<CategoryTranslation, int>, ICategoryTranslationRepository
    {
        public CategoryTranslationRepository(vigalileoDbContext vigalileoDbContext) : base(vigalileoDbContext)
        {

        }
    }
}