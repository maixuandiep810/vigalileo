using System.Collections.Generic;
using System.Threading.Tasks;
using vigalileo.Data.Entities;

namespace vigalileo.Data.RepositoryPattern.IRepositories
{
    public interface IPermissionRepository : IGenericRepository<Permission, int>
    {
        Task<List<Permission>> GetRoutePermissions();
        Task<List<Permission>> GetEntityPermissions();
    }
}