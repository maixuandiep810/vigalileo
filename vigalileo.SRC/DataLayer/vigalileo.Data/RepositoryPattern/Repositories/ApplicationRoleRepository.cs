using System.Linq;
using System;
using vigalileo.Data.RepositoryPattern.IRepositories;
using vigalileo.Data.Entities;
using vigalileo.Data.EF;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace vigalileo.Data.RepositoryPattern.Repositories
{
    public class ApplicationRoleRepository : GenericRepository<ApplicationRole, Guid>, IApplicationRoleRepository
    {
        public ApplicationRoleRepository(vigalileoDbContext vigalileoDbContext) : base(vigalileoDbContext)
        {

        }
    }
}