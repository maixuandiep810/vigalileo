using System;
using vigalileo.Data.RepositoryPattern.IRepositories;
using vigalileo.Data.Entities;
using vigalileo.Data.EF;

namespace vigalileo.Data.RepositoryPattern.Repositories
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser, Guid>, IApplicationUserRepository
    {
        public ApplicationUserRepository(vigalileoDbContext vigalileoDbContext) : base(vigalileoDbContext)
        {

        }
    }
}