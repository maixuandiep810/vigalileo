using vigalileo.Data.RepositoryPattern.IRepositories;
using vigalileo.Data.Entities;
using vigalileo.Data.EF;

namespace vigalileo.Data.RepositoryPattern.Repositories
{
    public class UserInEntityPermissionRepository : GenericRepository<UserInEntityPermission, int>, IUserInEntityPermissionRepository
    {
        public UserInEntityPermissionRepository(vigalileoDbContext vigalileoDbContext) : base(vigalileoDbContext)
        {

        }
    }
}