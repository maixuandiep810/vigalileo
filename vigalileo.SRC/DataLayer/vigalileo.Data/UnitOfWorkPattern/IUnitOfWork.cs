using System;
using System.Threading.Tasks;
using vigalileo.Data.RepositoryPattern.IRepositories;

namespace vigalileo.Data.UnitOfWorkPattern
{
    public interface IUnitOfWork : IDisposable
    {
        IAppConfigRepository AppConfigRepository { get; }
        IApplicationRoleRepository ApplicationRoleRepository { get; }
        IApplicationUserRepository ApplicationUserRepository { get; }
        IBrandRepository BrandRepository { get; }
        IBrandInCategoryRepository BrandInCategoryRepository { get; }
        ICartRepository CartRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ICategoryTranslationRepository categoryTranslationRepository { get; }
        IContactRepository ContactRepository { get; }
        ICustomerDetailRepository CustomerDetailRepository { get; }
        IEntityPermissionRepository EntityPermissionRepository { get; }
        ILanguageRepository LanguageRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        IPermissionRepository PermissionRepository { get; }
        IPermissionInRoleRepository PermissionInRoleRepository { get; }
        IProductRepository ProductRepository { get; }
        IProductInCategoryRepository ProductInCategoryRepository { get; }
        IProductTranslationRepository ProductTranslationRepository { get; }
        IRoutePermissionRepository RoutePermissionRepository { get; }
        ISellerDetailRepository SellerDetailRepository { get; }
        IStoreRepository StoreRepository { get; }
        IStoreInOrderRepository storeInOrderRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        IUserInEntityPermissionRepository UserInEntityPermissionRepository { get; }


        Task CommitAsync();
    }
}