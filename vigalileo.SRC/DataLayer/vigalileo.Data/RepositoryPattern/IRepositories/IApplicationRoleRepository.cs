using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vigalileo.Data.Entities;

namespace vigalileo.Data.RepositoryPattern.IRepositories
{
    public interface IApplicationRoleRepository : IGenericRepository<ApplicationRole, Guid>
    {
    }
}