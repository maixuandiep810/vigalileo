using System;
using vigalileo.Data.Entities;

namespace vigalileo.Data.RepositoryPattern.IRepositories
{
    public interface IApplicationUserRepository : IGenericRepository<ApplicationUser, Guid>
    {
         
    }
}