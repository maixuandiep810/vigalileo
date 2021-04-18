using System;
using vigalileo.Data.Core.Repositories;
using vigalileo.Data.Entities;
using vigalileo.Data.EF;

namespace vigalileo.Data.Persistence.Repositories
{
    public class ApplicationRoleRepository : GenericRepository<ApplicationRole, Guid>, IGenericRepository<ApplicationRole, Guid>
    {
        public ApplicationRoleRepository(vigalileoDbContext vigalileoDbContext) : base(vigalileoDbContext)
        {

        }
    }
}