using System.Collections.Generic;
using System.Threading.Tasks;
using vigalileo.Data.RepositoryPattern.IRepositories;
using vigalileo.Data.Entities;
using vigalileo.Data.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace vigalileo.Data.RepositoryPattern.Repositories
{
    public class PermissionRepository : GenericRepository<Permission, int>, IPermissionRepository
    {
        public PermissionRepository(vigalileoDbContext vigalileoDbContext) : base(vigalileoDbContext)
        {

        }

        public async Task<List<Permission>> GetRoutePermissions()
        {
            return await entities.Include(x => x.RoutePermission).Select(y => y).ToListAsync();
        }
        public async Task<List<Permission>> GetEntityPermissions()
        {
            return await entities.Include(x => x.EntityPermission).Select(y => y).ToListAsync();
        }
    }
}