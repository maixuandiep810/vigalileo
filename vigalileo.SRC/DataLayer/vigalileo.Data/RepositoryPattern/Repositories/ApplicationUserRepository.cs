using System;
using vigalileo.Data.RepositoryPattern.IRepositories;
using vigalileo.Data.Entities;
using vigalileo.Data.EF;

namespace vigalileo.Data.RepositoryPattern.Repositories
{
    public class ApplicationRoleRepository : GenericRepository<ApplicationRole, Guid>, IApplicationRoleRepository
    {
        public ApplicationRoleRepository(vigalileoDbContext vigalileoDbContext) : base(vigalileoDbContext)
        {

        }
    }
}